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
            
            // 设置按钮鼠标悬停效果 - 使用更现代的配色
            AddHoverEffect(btnSelectFolder, Color.FromArgb(79, 70, 229)); // 深紫色悬停
            AddHoverEffect(btnDbConfig, Color.FromArgb(37, 99, 235)); // 深蓝色悬停
            AddHoverEffect(btnSqlOptions, Color.FromArgb(37, 99, 235)); // 深蓝色悬停
            AddHoverEffect(btnExecute, Color.FromArgb(5, 150, 105)); // 深绿色悬停
            AddHoverEffect(btnClearSearch, Color.FromArgb(203, 213, 225)); // 灰色悬停
            AddHoverEffect(btnAbout, Color.FromArgb(100, 116, 139)); // 深灰色悬停
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
                lblDbInfo.ForeColor = Color.FromArgb(16, 185, 129); // 翠绿色
            }
            else
            {
                lblDbInfo.Text = "🔌 数据库: 未配置";
                lblDbInfo.ForeColor = Color.FromArgb(239, 68, 68); // 红色
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
                btnExecute.BackColor = Color.FromArgb(16, 185, 129); // 翠绿色
            }
            else
            {
                btnExecute.BackColor = Color.FromArgb(156, 163, 175); // 灰色
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
                        string sqlContent = FileEncodingHelper.ReadFileWithEncodingDetection(filePath);
                        
                        // 应用 SQL 语法高亮
                        ApplySqlSyntaxHighlight(sqlContent);
                        
                        // 检查该文件是否有执行记录
                        var executionRecord = executionRecords.FirstOrDefault(r => r.FileName == fileInfo.FileName);
                        if (executionRecord != null)
                        {
                            if (executionRecord.Status == "失败")
                            {
                                lblFileContent.Text = $"📄 {fileInfo.FileName} ⚠️ 执行失败";
                                lblFileContent.ForeColor = Color.FromArgb(239, 68, 68);
                            }
                            else if (executionRecord.Status == "成功")
                            {
                                lblFileContent.Text = $"📄 {fileInfo.FileName} ✓ 执行成功";
                                lblFileContent.ForeColor = Color.FromArgb(16, 185, 129);
                            }
                            else
                            {
                                lblFileContent.Text = $"📄 {fileInfo.FileName}";
                                lblFileContent.ForeColor = Color.FromArgb(51, 65, 85);
                            }
                        }
                        else
                        {
                            lblFileContent.Text = $"📄 {fileInfo.FileName}";
                            lblFileContent.ForeColor = Color.FromArgb(51, 65, 85);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"读取文件失败: {ex.Message}", "错误", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ApplySqlSyntaxHighlight(string sqlContent)
        {
            // 根据文件大小选择高亮方式
            if (sqlContent.Length > 50000)
            {
                // 大文件使用快速高亮
                SqlSyntaxHighlighter.ApplyFastSyntaxHighlight(txtFileContent, sqlContent);
            }
            else
            {
                // 小文件使用完整高亮
                SqlSyntaxHighlighter.ApplySyntaxHighlight(txtFileContent, sqlContent);
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

        private void btnAbout_Click(object sender, EventArgs e)
        {
            ShowAboutDialog();
        }

        private void ShowAboutDialog()
        {
            // 创建关于对话框
            Form aboutForm = new Form
            {
                Text = "关于 FastHorse",
                Width = 500,
                Height = 400,
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MinimizeBox = false,
                MaximizeBox = false,
                ShowIcon = false,
                Font = new Font("Microsoft YaHei UI", 9F),
                BackColor = Color.White
            };

            // 主面板
            Panel mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(30),
                BackColor = Color.White
            };

            // 图标/标题
            Label lblTitle = new Label
            {
                Text = "⚡ FastHorse",
                Font = new Font("Microsoft YaHei UI", 20F, FontStyle.Bold),
                ForeColor = Color.FromArgb(99, 102, 241),
                AutoSize = true,
                Location = new Point(30, 30)
            };

            // 副标题
            Label lblSubtitle = new Label
            {
                Text = "SQL Server 脚本批量执行工具",
                Font = new Font("Microsoft YaHei UI", 11F),
                ForeColor = Color.FromArgb(100, 116, 139),
                AutoSize = true,
                Location = new Point(30, 75)
            };

            // 版本信息
            Label lblVersion = new Label
            {
                Text = "版本: 1.0.0 @Call me",
                Font = new Font("Microsoft YaHei UI", 9.5F),
                ForeColor = Color.FromArgb(148, 163, 184),
                AutoSize = true,
                Location = new Point(30, 110)
            };

            // 分隔线
            Panel divider = new Panel
            {
                BackColor = Color.FromArgb(226, 232, 240),
                Location = new Point(30, 145),
                Width = 420,
                Height = 1
            };

            // 功能介绍
            Label lblDescription = new Label
            {
                Text = "💡 功能介绍",
                Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                AutoSize = true,
                Location = new Point(30, 160)
            };

            RichTextBox txtDescription = new RichTextBox
            {
                Text = "FastHorse 是一款高效的 SQL Server 脚本批量执行工具，专为数据库管理员和开发人员设计。\n\n" +
                       "✓ 批量执行 SQL 脚本文件\n" +
                       "✓ 实时显示执行进度和状态\n" +
                       "✓ 详细的错误信息记录\n" +
                       "✓ 支持自定义 SQL 执行选项\n" +
                       "✓ 友好的用户界面和操作体验\n" +
                       "✓ 完整的执行日志和统计信息\n\n" +
                       "让数据库脚本执行变得简单、快速、可靠！",
                Font = new Font("Microsoft YaHei UI", 9F),
                ForeColor = Color.FromArgb(71, 85, 105),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None,
                ReadOnly = true,
                Location = new Point(30, 190),
                Width = 420,
                Height = 130,
                ScrollBars = RichTextBoxScrollBars.None
            };

            // 关闭按钮
            Button btnClose = new Button
            {
                Text = "确定",
                Font = new Font("Microsoft YaHei UI", 9.5F),
                BackColor = Color.FromArgb(99, 102, 241),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 100,
                Height = 38,
                Cursor = Cursors.Hand,
                Location = new Point(350, 315)
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => aboutForm.Close();
            AddHoverEffect(btnClose, Color.FromArgb(79, 70, 229));

            // 添加控件
            mainPanel.Controls.Add(lblTitle);
            mainPanel.Controls.Add(lblSubtitle);
            mainPanel.Controls.Add(lblVersion);
            mainPanel.Controls.Add(divider);
            mainPanel.Controls.Add(lblDescription);
            mainPanel.Controls.Add(txtDescription);
            mainPanel.Controls.Add(btnClose);

            aboutForm.Controls.Add(mainPanel);
            aboutForm.ShowDialog(this);
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
            
            // 清空文件列表的执行状态
            foreach (var fileInfo in fileList)
            {
                fileInfo.ExecutionStatus = "";
            }
            dgvFiles.Refresh();

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
                    // 更新文件列表状态为"执行中"
                    UpdateFileListStatus(fileName, "执行中");
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
                
                // 更新左侧文件列表的状态
                UpdateFileListStatus(record.FileName, status);
                
                // 不在这里筛选,等全部执行完成后再筛选
            }));
        }

        private void UpdateFileListStatus(string fileName, string status)
        {
            foreach (var fileInfo in fileList)
            {
                if (fileInfo.FileName == fileName)
                {
                    fileInfo.ExecutionStatus = status;
                    
                    // 刷新 DataGridView 以更新显示
                    dgvFiles.Refresh();
                    break;
                }
            }
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
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(5, 150, 105); // 深绿色
                    row.DefaultCellStyle.BackColor = Color.FromArgb(240, 253, 244); // 浅绿背景
                    row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(209, 250, 229); // 选中时的绿色背景
                    row.DefaultCellStyle.SelectionForeColor = Color.FromArgb(6, 95, 70); // 选中时的深绿色文字
                    break;
                case "失败":
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(220, 38, 38); // 红色
                    row.DefaultCellStyle.BackColor = Color.FromArgb(254, 242, 242); // 浅红背景
                    row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 226, 226); // 选中时的红色背景
                    row.DefaultCellStyle.SelectionForeColor = Color.FromArgb(153, 27, 27); // 选中时的深红色文字
                    break;
                case "执行中":
                case "等待执行":
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(37, 99, 235); // 蓝色
                    row.DefaultCellStyle.BackColor = Color.FromArgb(239, 246, 255); // 浅蓝背景
                    row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254); // 选中时的蓝色背景
                    row.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 58, 138); // 选中时的深蓝色文字
                    break;
                default:
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105); // 深灰色
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254); // 默认选中背景
                    row.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 58, 138); // 默认选中文字
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
            // 检查是否点击了"查看详情"按钮列
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var column = dgvExecutionLog.Columns[e.ColumnIndex];
                if (column.Name == "colViewDetails" || column is DataGridViewButtonColumn)
                {
                    var row = dgvExecutionLog.Rows[e.RowIndex];
                    if (row.DataBoundItem is ExecutionRecord record)
                    {
                        ShowExecutionDetails(record);
                    }
                }
            }
        }

        private void ShowExecutionDetails(ExecutionRecord record)
        {
            // 创建详情对话框
            Form detailForm = new Form
            {
                Text = $"执行详情 - {record.FileName}",
                Width = 900,
                Height = 650,
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.Sizable,
                MinimizeBox = false,
                MaximizeBox = true,
                ShowIcon = false,
                Font = new Font("Microsoft YaHei UI", 9F),
                BackColor = Color.FromArgb(248, 250, 252),
                MinimumSize = new Size(700, 500)
            };

            // 创建主滚动面板
            Panel scrollContainer = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.FromArgb(248, 250, 252),
                Padding = new Padding(0, 0, 0, 60) // 底部留出按钮空间
            };

            // 创建内容面板（居中）
            Panel contentPanel = new Panel
            {
                Width = 800,
                AutoSize = true,
                BackColor = Color.FromArgb(248, 250, 252),
                Padding = new Padding(0, 25, 0, 25)
            };

            // 顶部信息卡片面板
            Panel infoPanel = new Panel
            {
                BackColor = Color.White,
                Location = new Point(0, 0),
                Width = 800,
                Height = 140,
                BorderStyle = BorderStyle.FixedSingle
            };

            // 文件名标签
            Label lblFileName = new Label
            {
                Text = $"📄 {record.FileName}",
                Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                AutoSize = false,
                Size = new Size(760, 30),
                Location = new Point(20, 15),
                TextAlign = ContentAlignment.MiddleLeft
            };

            // 状态和时间信息面板
            Panel statusPanel = new Panel
            {
                Location = new Point(20, 50),
                Width = 760,
                Height = 75,
                BackColor = Color.White
            };

            // 执行状态标签
            Label lblStatus = new Label
            {
                Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(0, 5)
            };

            // 根据状态设置颜色和图标
            switch (record.Status)
            {
                case "成功":
                    lblStatus.ForeColor = Color.FromArgb(5, 150, 105);
                    lblStatus.Text = "✓ 执行成功";
                    break;
                case "失败":
                    lblStatus.ForeColor = Color.FromArgb(220, 38, 38);
                    lblStatus.Text = "✗ 执行失败";
                    break;
                case "执行中":
                    lblStatus.ForeColor = Color.FromArgb(37, 99, 235);
                    lblStatus.Text = "⏳ 执行中";
                    break;
                default:
                    lblStatus.ForeColor = Color.FromArgb(71, 85, 105);
                    lblStatus.Text = $"状态: {record.Status}";
                    break;
            }

            // 执行耗时标签
            Label lblDuration = new Label
            {
                Text = $"⏱️ 执行耗时: {record.DurationText}",
                Font = new Font("Microsoft YaHei UI", 9.5F),
                ForeColor = Color.FromArgb(100, 116, 139),
                AutoSize = true,
                Location = new Point(0, 35)
            };

            // 开始时间标签
            Label lblStartTime = new Label
            {
                Text = $"🕐 开始时间: {record.StartTime:yyyy-MM-dd HH:mm:ss}",
                Font = new Font("Microsoft YaHei UI", 9.5F),
                ForeColor = Color.FromArgb(100, 116, 139),
                AutoSize = true,
                Location = new Point(300, 35)
            };

            statusPanel.Controls.Add(lblStatus);
            statusPanel.Controls.Add(lblDuration);
            statusPanel.Controls.Add(lblStartTime);

            infoPanel.Controls.Add(lblFileName);
            infoPanel.Controls.Add(statusPanel);

            // 错误信息标签
            Label lblErrorTitle = new Label
            {
                Text = "📋 详细信息",
                Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                AutoSize = true,
                Location = new Point(0, 160)
            };

            // 错误信息容器面板（带边框）
            Panel errorPanel = new Panel
            {
                BackColor = Color.White,
                Location = new Point(0, 190),
                Width = 800,
                Height = 300,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(15)
            };

            // 错误信息文本框
            RichTextBox txtError = new RichTextBox
            {
                Text = string.IsNullOrEmpty(record.ErrorMessage) ? "✓ 执行成功，无错误信息" : record.ErrorMessage,
                Font = new Font("Consolas", 9.5F),
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                BackColor = record.Status == "失败" ? Color.FromArgb(254, 242, 242) : Color.FromArgb(249, 250, 251),
                ForeColor = record.Status == "失败" ? Color.FromArgb(153, 27, 27) : Color.FromArgb(71, 85, 105),
                Dock = DockStyle.Fill,
                WordWrap = true,
                ScrollBars = RichTextBoxScrollBars.Vertical
            };

            errorPanel.Controls.Add(txtError);

            // 添加控件到内容面板
            contentPanel.Controls.Add(infoPanel);
            contentPanel.Controls.Add(lblErrorTitle);
            contentPanel.Controls.Add(errorPanel);

            // 调整内容面板高度
            contentPanel.Height = 515;

            // 将内容面板居中放置在滚动容器中
            scrollContainer.Controls.Add(contentPanel);
            
            // 居中内容面板
            scrollContainer.Resize += (s, e) =>
            {
                contentPanel.Left = Math.Max(0, (scrollContainer.ClientSize.Width - contentPanel.Width) / 2);
            };
            contentPanel.Left = (scrollContainer.ClientSize.Width - contentPanel.Width) / 2;

            // 底部按钮面板
            Panel buttonPanel = new Panel
            {
                Height = 60,
                Dock = DockStyle.Bottom,
                BackColor = Color.FromArgb(248, 250, 252)
            };

            // 关闭按钮
            Button btnClose = new Button
            {
                Text = "关闭",
                Font = new Font("Microsoft YaHei UI", 9.5F),
                BackColor = Color.FromArgb(99, 102, 241),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 100,
                Height = 38,
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.None
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => detailForm.Close();
            AddHoverEffect(btnClose, Color.FromArgb(79, 70, 229));

            // 居中按钮
            buttonPanel.Resize += (s, e) =>
            {
                btnClose.Left = (buttonPanel.Width - btnClose.Width) / 2;
                btnClose.Top = (buttonPanel.Height - btnClose.Height) / 2;
            };
            btnClose.Left = (buttonPanel.Width - btnClose.Width) / 2;
            btnClose.Top = (buttonPanel.Height - btnClose.Height) / 2;

            buttonPanel.Controls.Add(btnClose);

            detailForm.Controls.Add(scrollContainer);
            detailForm.Controls.Add(buttonPanel);
            detailForm.ShowDialog(this);
        }

        private void dgvExecutionLog_SelectionChanged(object sender, EventArgs e)
        {
            // 当执行记录被选中时，联动显示对应的文件
            if (dgvExecutionLog.SelectedRows.Count > 0)
            {
                var selectedRow = dgvExecutionLog.SelectedRows[0];
                if (selectedRow.DataBoundItem is ExecutionRecord record)
                {
                    // 在文件列表中查找对应的文件
                    string fileName = record.FileName;
                    
                    // 遍历文件列表找到匹配的文件
                    for (int i = 0; i < dgvFiles.Rows.Count; i++)
                    {
                        var row = dgvFiles.Rows[i];
                        if (row.DataBoundItem is SqlFileInfo fileInfo)
                        {
                            if (fileInfo.FileName == fileName)
                            {
                                // 选中文件列表中的对应行
                                dgvFiles.ClearSelection();
                                dgvFiles.Rows[i].Selected = true;
                                dgvFiles.FirstDisplayedScrollingRowIndex = i;
                                
                                // 显示文件内容
                                try
                                {
                                    string sqlContent = FileEncodingHelper.ReadFileWithEncodingDetection(fileInfo.FilePath);
                                    
                                    // 应用 SQL 语法高亮
                                    ApplySqlSyntaxHighlight(sqlContent);
                                    
                                    lblFileContent.Text = $"📄 {fileInfo.FileName}";
                                    
                                    // 如果执行失败，高亮显示错误信息
                                    if (record.Status == "失败" && !string.IsNullOrEmpty(record.ErrorMessage))
                                    {
                                        // 在文件内容标题中添加错误提示
                                        lblFileContent.Text = $"📄 {fileInfo.FileName} ⚠️ 执行失败";
                                        lblFileContent.ForeColor = Color.FromArgb(239, 68, 68);
                                    }
                                    else if (record.Status == "成功")
                                    {
                                        lblFileContent.Text = $"📄 {fileInfo.FileName} ✓ 执行成功";
                                        lblFileContent.ForeColor = Color.FromArgb(16, 185, 129);
                                    }
                                    else
                                    {
                                        lblFileContent.ForeColor = Color.FromArgb(51, 65, 85);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"读取文件失败: {ex.Message}", "错误", 
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void lblFileList_Click(object sender, EventArgs e)
        {

        }

        private void lblExecutionSummary_Click(object sender, EventArgs e)
        {

        }

        private void dgvExecutionLog_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // 自定义绘制"查看详情"按钮
            if (e.ColumnIndex >= 0 && dgvExecutionLog.Columns[e.ColumnIndex].Name == "colViewDetails" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                // 绘制按钮背景
                Rectangle buttonRect = new Rectangle(
                    e.CellBounds.X + 5,
                    e.CellBounds.Y + 5,
                    e.CellBounds.Width - 10,
                    e.CellBounds.Height - 10
                );

                Color buttonColor = Color.FromArgb(99, 102, 241);
                if (e.State.HasFlag(DataGridViewElementStates.Selected))
                {
                    buttonColor = Color.FromArgb(79, 70, 229);
                }

                using (SolidBrush brush = new SolidBrush(buttonColor))
                {
                    e.Graphics.FillRectangle(brush, buttonRect);
                }

                // 绘制按钮文字
                TextRenderer.DrawText(
                    e.Graphics,
                    "查看详情",
                    new Font("Microsoft YaHei UI", 9F),
                    buttonRect,
                    Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );

                e.Handled = true;
            }
        }

        private void dgvFiles_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // 为文件列表添加状态颜色背景
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dgvFiles.Rows[e.RowIndex].DataBoundItem is SqlFileInfo fileInfo)
                {
                    if (!string.IsNullOrEmpty(fileInfo.ExecutionStatus))
                    {
                        Color backColor = Color.White;
                        Color foreColor = Color.FromArgb(71, 85, 105);

                        switch (fileInfo.ExecutionStatus)
                        {
                            case "成功":
                                backColor = Color.FromArgb(240, 253, 244);
                                foreColor = Color.FromArgb(5, 150, 105);
                                break;
                            case "失败":
                                backColor = Color.FromArgb(254, 242, 242);
                                foreColor = Color.FromArgb(220, 38, 38);
                                break;
                            case "执行中":
                                backColor = Color.FromArgb(239, 246, 255);
                                foreColor = Color.FromArgb(37, 99, 235);
                                break;
                        }

                        e.CellStyle.BackColor = backColor;
                        e.CellStyle.ForeColor = foreColor;
                        e.CellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
                        e.CellStyle.SelectionForeColor = foreColor;
                    }
                }
            }
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
