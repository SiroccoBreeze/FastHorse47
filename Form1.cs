using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace FastHorse
{
    public partial class Form1 : Form
    {
        private string selectedFolderPath = "";
        private List<string> sqlFiles = new List<string>();
        private BindingList<SqlFileInfo> fileList = new BindingList<SqlFileInfo>();
        private DatabaseConfig dbConfig = new DatabaseConfig();
        private BindingList<ExecutionRecord> executionRecords = new BindingList<ExecutionRecord>();
        private const string ConfigFileName = "dbconfig.json";
        private bool setAnsiNulls = true;
        private bool setQuotedIdentifier = false;

        public Form1()
        {
            InitializeComponent();
            InitializeForm();
            ApplyModernStyling();
            InitializeDataGridViewColumns();
        }

        private void InitializeForm()
        {
            // 初始化文件列表 DataGridView
            dgvFiles.AutoGenerateColumns = false;
            dgvFiles.DataSource = fileList;
            // colFileListName 已在 Designer 中配置

            // 确保执行记录 DataGridView 列正确初始化
            InitializeDataGridViewColumns();
            dgvExecutionLog.AutoGenerateColumns = false;

            // 初始绑定执行记录列表
            dgvExecutionLog.DataSource = executionRecords;
            dgvExecutionLog.DataBindingComplete += DgvExecutionLog_DataBindingComplete;

            // 加载保存的数据库配置
            LoadDatabaseConfig();

            // 更新界面信息
            UpdateDatabaseInfo();
            UpdateExecuteButtonState();
            UpdateExecutionStats("待执行");
            UpdateFileCount();
            UpdateExecutionSummary();
        }

        private void InitializeDataGridViewColumns()
        {
            // 确保列已正确配置（防止设计器问题）
            if (dgvExecutionLog.Columns.Count > 0)
            {
                // 设置列的显示名称和属性
                if (colFileName != null)
                {
                    colFileName.HeaderText = "脚本文件";
                    colFileName.DataPropertyName = "FileName";
                    colFileName.Width = 280;
                }

                if (colExecuteTime != null)
                {
                    colExecuteTime.HeaderText = "执行耗时";
                    colExecuteTime.DataPropertyName = "DurationText";
                    colExecuteTime.Width = 120;
                }

                if (colStatus != null)
                {
                    colStatus.HeaderText = "执行状态";
                    colStatus.DataPropertyName = "Status";
                    colStatus.Width = 110;
                }

                if (colErrorMessage != null)
                {
                    colErrorMessage.HeaderText = "错误详情";
                    colErrorMessage.DataPropertyName = "ErrorMessage";
                    colErrorMessage.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
        }

        private void ApplyModernStyling()
        {
            // 应用现代化样式
            this.Font = new Font("Microsoft YaHei UI", 9F);
            
            // 设置按钮鼠标悬停效果
            AddHoverEffect(btnSelectFolder, Color.FromArgb(89, 100, 104));
            AddHoverEffect(btnDbConfig, Color.FromArgb(62, 106, 156));
            AddHoverEffect(btnSqlOptions, Color.FromArgb(62, 106, 156));
            AddHoverEffect(btnExecute, Color.FromArgb(42, 191, 133));
            AddHoverEffect(btnClearSearch, Color.FromArgb(206, 212, 220));
        }

        private void AddHoverEffect(Button btn, Color hoverColor)
        {
            Color originalColor = btn.BackColor;
            btn.MouseEnter += (s, e) => { if (btn.Enabled) btn.BackColor = hoverColor; };
            btn.MouseLeave += (s, e) => { if (btn.Enabled) btn.BackColor = originalColor; };
        }

        private void UpdateDatabaseInfo()
        {
            if (!string.IsNullOrEmpty(dbConfig.Server) && !string.IsNullOrEmpty(dbConfig.Database))
            {
                lblDbInfo.Text = $"🔌 数据库: {dbConfig.Server} / {dbConfig.Database}";
                lblDbInfo.ForeColor = Color.FromArgb(52, 211, 153);
            }
            else
            {
                lblDbInfo.Text = "🔌 数据库: 未配置";
                lblDbInfo.ForeColor = Color.FromArgb(239, 68, 68);
            }
        }

        private void UpdateExecuteButtonState()
        {
            bool canExecute = !string.IsNullOrEmpty(dbConfig.Server) && 
                             !string.IsNullOrEmpty(dbConfig.Database) && 
                             sqlFiles.Count > 0;
            btnExecute.Enabled = canExecute;
            
            if (canExecute)
            {
                btnExecute.BackColor = Color.FromArgb(52, 211, 153);
            }
            else
            {
                btnExecute.BackColor = Color.FromArgb(156, 163, 175);
            }
        }

        private void UpdateFileCount()
        {
            lblFileCount.Text = sqlFiles.Count > 0 ? $"{sqlFiles.Count} 个文件" : "0 个文件";
        }

        private void UpdateExecutionStats(string message)
        {
            lblExecutionStats.Text = message;
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "选择包含SQL脚本的文件夹";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFolderPath = dialog.SelectedPath;
                    lblFolderPath.Text = $"📁 {selectedFolderPath}";
                    LoadSqlFiles();
                }
            }
        }

        private void LoadSqlFiles()
        {
            sqlFiles.Clear();
            fileList.Clear();

            if (string.IsNullOrEmpty(selectedFolderPath) || !Directory.Exists(selectedFolderPath))
            {
                UpdateExecuteButtonState();
                UpdateFileCount();
                return;
            }

            try
            {
                var files = Directory.GetFiles(selectedFolderPath, "*.sql", SearchOption.AllDirectories);
                sqlFiles.AddRange(files.OrderBy(f => f));

                foreach (var file in sqlFiles)
                {
                    fileList.Add(new SqlFileInfo(file));
                }

                UpdateFileCount();
                UpdateExecutionStats($"已加载 {sqlFiles.Count} 个脚本文件");
                MessageBox.Show($"找到 {sqlFiles.Count} 个SQL文件", "加载成功", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载文件失败: {ex.Message}", "错误", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                UpdateExecuteButtonState();
            }
        }

        private void dgvFiles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFiles.SelectedRows.Count > 0)
            {
                var selectedRow = dgvFiles.SelectedRows[0];
                if (selectedRow.DataBoundItem is SqlFileInfo fileInfo)
                {
                    string filePath = fileInfo.FilePath;
                    try
                    {
                        txtFileContent.Text = FileEncodingHelper.ReadFileWithEncodingDetection(filePath);
                        lblFileContent.Text = $"📄 {fileInfo.FileName}";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"读取文件失败: {ex.Message}", "错误", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDbConfig_Click(object sender, EventArgs e)
        {
            using (DatabaseConfigForm form = new DatabaseConfigForm(dbConfig))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    dbConfig = form.Config;
                    SaveDatabaseConfig();
                    UpdateDatabaseInfo();
                    UpdateExecuteButtonState();
                    MessageBox.Show("数据库配置已保存", "成功", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSqlOptions_Click(object sender, EventArgs e)
        {
            using (SqlOptionsForm form = new SqlOptionsForm(setAnsiNulls, setQuotedIdentifier))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    setAnsiNulls = form.SetAnsiNulls;
                    setQuotedIdentifier = form.SetQuotedIdentifier;
                }
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (sqlFiles.Count == 0)
            {
                MessageBox.Show("请先选择包含SQL文件的文件夹", "提示", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(dbConfig.Server) || string.IsNullOrEmpty(dbConfig.Database))
            {
                MessageBox.Show("请先配置数据库连接信息", "提示", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"确定要执行 {sqlFiles.Count} 个SQL脚本吗？", "确认执行", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            // 清空之前的执行记录
            executionRecords.Clear();

            // 显示遮罩
            ShowOverlay("正在执行脚本...");

            // 异步执行
            Task.Run(() => ExecuteScriptsAsync());
        }

        private async Task ExecuteScriptsAsync()
        {
            string connectionString = dbConfig.GetConnectionString();
            var stopwatchTotal = Stopwatch.StartNew();

            int totalFiles = sqlFiles.Count;
            int currentFileIndex = 0;

            foreach (var filePath in sqlFiles)
            {
                currentFileIndex++;
                string fileName = Path.GetFileName(filePath);
                ExecutionRecord record = new ExecutionRecord
                {
                    FileName = fileName,
                    Status = "执行中",
                    DurationText = "..."
                };

                var stopwatch = Stopwatch.StartNew();

                this.Invoke(new Action(() =>
                {
                    record.StartTime = DateTime.Now;
                    executionRecords.Add(record);
                    // 更新进度显示
                    UpdateOverlayProgress(currentFileIndex, totalFiles, fileName);
                    // 在执行过程中不要频繁筛选,等执行完再筛选
                }));

                try
                {
                    string sqlScript = FileEncodingHelper.ReadFileWithEncodingDetection(filePath);
                    string finalScript = BuildSqlScriptWithOptions(sqlScript);
                    await ExecuteSqlScriptAsync(connectionString, finalScript);

                    stopwatch.Stop();
                    UpdateRecordResult(record, "成功", string.Empty, stopwatch.Elapsed);
                }
                catch (Exception ex)
                {
                    stopwatch.Stop();
                    string detailedError = BuildDetailedErrorMessage(ex);
                    UpdateRecordResult(record, "失败", detailedError, stopwatch.Elapsed);
                }
            }

            stopwatchTotal.Stop();

            // 恢复按钮状态并隐藏遮罩
            this.Invoke(new Action(() =>
            {
                // 隐藏遮罩
                HideOverlay();

                btnSelectFolder.Enabled = true;
                btnDbConfig.Enabled = true;
                UpdateExecuteButtonState();

                int successCount = executionRecords.Count(r => r.Status == "成功");
                int failCount = executionRecords.Count(r => r.Status == "失败");
                
                string resultMsg = $"执行完成！\n\n" +
                    $"总耗时: {stopwatchTotal.Elapsed.TotalSeconds:F2} 秒\n" +
                    $"成功: {successCount} 个\n" +
                    $"失败: {failCount} 个";

                UpdateExecutionStats($"执行完成 - 成功 {successCount} | 失败 {failCount}");
                
                // 执行完成后应用筛选
                FilterExecutionRecords();
                
                MessageBox.Show(resultMsg, "执行结果", 
                    MessageBoxButtons.OK, 
                    failCount > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
            }));
        }

        private string BuildSqlScriptWithOptions(string sqlScript)
        {
            if (!setAnsiNulls && !setQuotedIdentifier)
            {
                // 如果两个选项都没有勾选，直接返回原始脚本
                return "SET ANSI_NULLS OFF \n GO \"SET ANSI_NULLS OFF \n GO\"" + sqlScript;
            }

            StringBuilder sb = new StringBuilder();

            // 根据勾选状态添加SET语句
            if (setAnsiNulls)
            {
                sb.AppendLine("SET ANSI_NULLS ON \n GO");
            }
            else
            {
                sb.AppendLine("SET ANSI_NULLS OFF \n GO");
            }

            if (setQuotedIdentifier)
            {
                sb.AppendLine("SET QUOTED_IDENTIFIER ON \n GO");
            }
            else
            {
                sb.AppendLine("SET QUOTED_IDENTIFIER OFF \n GO");
            }

            sb.AppendLine("GO");
            sb.AppendLine();
            sb.Append(sqlScript);

            return sb.ToString();
        }

        private async Task ExecuteSqlScriptAsync(string connectionString, string sqlScript)
        {
            await Task.Run(() =>
            {
                var serverConnection = new ServerConnection();

                if (dbConfig.ConnectionTimeout > 0)
                {
                    serverConnection.ConnectTimeout = dbConfig.ConnectionTimeout;
                    serverConnection.StatementTimeout = dbConfig.ConnectionTimeout;
                }

                serverConnection.ConnectionString = connectionString;

                try
                {
                    serverConnection.Connect();
                    var server = new Server(serverConnection);
                    server.ConnectionContext.ExecuteNonQuery(sqlScript);
                }
                finally
                {
                    if (serverConnection.IsOpen)
                    {
                        serverConnection.Disconnect();
                    }
                }
            });
        }

        private void LoadDatabaseConfig()
        {
            string configPath = Path.Combine(Application.StartupPath, ConfigFileName);
            dbConfig = DatabaseConfig.LoadFromFile(configPath);
        }

        private void SaveDatabaseConfig()
        {
            string configPath = Path.Combine(Application.StartupPath, ConfigFileName);
            dbConfig.SaveToFile(configPath);
        }

        private void chkShowSuccess_CheckedChanged(object sender, EventArgs e)
        {
            FilterExecutionRecords();
        }

        private void chkShowFailed_CheckedChanged(object sender, EventArgs e)
        {
            FilterExecutionRecords();
        }

        private void chkShowPending_CheckedChanged(object sender, EventArgs e)
        {
            FilterExecutionRecords();
        }

        private void txtExecutionSearch_TextChanged(object sender, EventArgs e)
        {
            FilterExecutionRecords();
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtExecutionSearch.Text = string.Empty;
            FilterExecutionRecords();
        }

        private void FilterExecutionRecords()
        {
            if (executionRecords.Count == 0)
            {
                UpdateExecutionSummary();
                return;
            }

            // 使用 BindingList 过滤而不是直接设置行可见性
            var filtered = new BindingList<ExecutionRecord>();
            string keyword = txtExecutionSearch?.Text?.Trim() ?? string.Empty;

            foreach (var record in executionRecords)
            {
                bool statusMatch = ShouldShowStatusForRecord(record.Status);
                bool keywordMatch = string.IsNullOrEmpty(keyword) || 
                    ContainsKeyword(record.FileName, keyword) ||
                    ContainsKeyword(record.Status, keyword) ||
                    ContainsKeyword(record.ErrorMessage, keyword) ||
                    ContainsKeyword(record.DurationText, keyword);

                if (statusMatch && keywordMatch)
                {
                    filtered.Add(record);
                }
            }

            // 暂时解除绑定，重新绑定过滤后的数据
            dgvExecutionLog.DataSource = null;
            dgvExecutionLog.DataSource = filtered;

            // 数据绑定完成后会自动触发 DataBindingComplete 事件，在那里应用样式
            // 但为了确保样式立即应用，我们也在这里调用一次
            this.BeginInvoke(new Action(() =>
            {
                ApplyRowStyles();
            }));

            UpdateExecutionSummary();
        }

        private bool ShouldShowStatusForRecord(string status)
        {
            if (string.IsNullOrEmpty(status))
            {
                return true;
            }

            if (status == "执行中" || status == "等待执行")
            {
                return chkShowPending?.Checked ?? true;
            }

            if (status == "成功")
            {
                return chkShowSuccess?.Checked ?? true;
            }

            if (status == "失败")
            {
                return chkShowFailed?.Checked ?? true;
            }

            return true;
        }

        private bool ContainsKeyword(string text, string keyword)
        {
            if (string.IsNullOrEmpty(text)) return false;
            return text.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void UpdateRecordResult(ExecutionRecord record, string status, string errorMessage, TimeSpan duration)
        {
            this.Invoke(new Action(() =>
            {
                record.Status = status;
                record.ErrorMessage = errorMessage;
                record.DurationText = FormatDuration(duration);
                
                // 更新单元格样式
                UpdateRowStyle(record);
                
                // 不在这里筛选,等全部执行完成后再筛选
            }));
        }

        private void UpdateRowStyle(ExecutionRecord record)
        {
            try
            {
                foreach (DataGridViewRow row in dgvExecutionLog.Rows)
                {
                    if (row.DataBoundItem == record)
                    {
                        ApplyRowStyle(row, record.Status);
                        break;
                    }
                }
            }
            catch
            {
                // 忽略样式更新错误
            }
        }

        private void ApplyRowStyles()
        {
            try
            {
                foreach (DataGridViewRow row in dgvExecutionLog.Rows)
                {
                    if (row.DataBoundItem is ExecutionRecord record)
                    {
                        ApplyRowStyle(row, record.Status);
                    }
                }
            }
            catch
            {
                // 忽略样式更新错误
            }
        }

        private void ApplyRowStyle(DataGridViewRow row, string status)
        {
            switch (status)
            {
                case "成功":
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(22, 163, 74);
                    break;
                case "失败":
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(220, 38, 38);
                    break;
                case "执行中":
                case "等待执行":
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(59, 130, 246);
                    break;
                default:
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
                    break;
            }
        }

        private void DgvExecutionLog_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ApplyRowStyles();
        }

        private string FormatDuration(TimeSpan duration)
        {
            if (duration.TotalSeconds >= 1)
            {
                return $"{duration.TotalSeconds:F2} 秒";
            }
            return $"{duration.TotalMilliseconds:F0} ms";
        }

        private string BuildDetailedErrorMessage(Exception ex)
        {
            if (ex == null)
            {
                return string.Empty;
            }

            List<string> messages = new List<string>();
            Exception current = ex;

            while (current != null)
            {
                string typeName = current.GetType().Name;
                string message = current.Message;

                // 跳过 ExecutionFailureException 和通用的 SQL 执行错误信息
                if (typeName == "ExecutionFailureException" && 
                    message.Contains("An exception occurred while executing a Transact-SQL statement or batch"))
                {
                    // 跳过这个异常，继续处理内部异常
                    current = current.InnerException;
                    continue;
                }

                if (!string.IsNullOrWhiteSpace(message))
                {
                    messages.Add($"[{typeName}] {message}");
                }
                
                current = current.InnerException;
            }

            string combined = string.Join(" -> ", messages);
            
            // 移除不需要的前缀信息
            string prefixToRemove = "[ExecutionFailureException] An exception occurred while executing a Transact-SQL statement or batch.";
            if (combined.StartsWith(prefixToRemove))
            {
                combined = combined.Substring(prefixToRemove.Length).Trim();
                if (combined.StartsWith("->"))
                {
                    combined = combined.Substring(2).Trim();
                }
            }
            
            const int maxLength = 1000;
            return combined.Length > maxLength ? combined.Substring(0, maxLength) + "..." : combined;
        }

        private void UpdateExecutionSummary()
        {
            int total = executionRecords.Count;
            int success = executionRecords.Count(r => r.Status == "成功");
            int failed = executionRecords.Count(r => r.Status == "失败");
            int pending = executionRecords.Count(r => r.Status == "执行中" || r.Status == "等待执行");
            
            lblExecutionSummary.Text = $"共 {total} 条 | ✓ {success} | ✗ {failed} | ⏳ {pending}";
        }

        private void lblExecutionLog_Click(object sender, EventArgs e)
        {
            // 可以添加额外的功能
        }

        private void dgvExecutionLog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblFileList_Click(object sender, EventArgs e)
        {

        }

        private void lblExecutionSummary_Click(object sender, EventArgs e)
        {

        }

        private void ShowOverlay(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(ShowOverlay), message);
                return;
            }

            lblOverlayMessage.Text = message;
            lblOverlayProgress.Text = "准备中...";
            
            // 禁用所有按钮和控件
            btnExecute.Enabled = false;
            btnSelectFolder.Enabled = false;
            btnDbConfig.Enabled = false;
            btnSqlOptions.Enabled = false;
            dgvFiles.Enabled = false;
            txtFileContent.Enabled = false;
            
            panelOverlay.Visible = true;
            panelOverlay.Enabled = true;
            panelOverlay.BringToFront();
            panelOverlay.Refresh();
            
            progressBarOverlay.Style = ProgressBarStyle.Marquee;
            progressBarOverlay.Value = 0;
            Application.DoEvents();
        }

        private void UpdateOverlayProgress(int current, int total, string fileName)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int, int, string>(UpdateOverlayProgress), current, total, fileName);
                return;
            }

            lblOverlayProgress.Text = $"正在执行第 {current} / {total} 个文件: {fileName}";
            Application.DoEvents();
        }

        private void HideOverlay()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(HideOverlay));
                return;
            }

            panelOverlay.Visible = false;
            panelOverlay.Enabled = false;
            progressBarOverlay.Style = ProgressBarStyle.Continuous;
            
            // 恢复所有按钮和控件
            btnSelectFolder.Enabled = true;
            btnDbConfig.Enabled = true;
            btnSqlOptions.Enabled = true;
            dgvFiles.Enabled = true;
            txtFileContent.Enabled = true;
            UpdateExecuteButtonState();
        }
    }
}
