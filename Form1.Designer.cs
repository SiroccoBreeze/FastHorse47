namespace FastHorse
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnExecute = new System.Windows.Forms.Button();
            this.btnSqlOptions = new System.Windows.Forms.Button();
            this.btnDbConfig = new System.Windows.Forms.Button();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.lblExecutionStats = new System.Windows.Forms.Label();
            this.lblDbInfo = new System.Windows.Forms.Label();
            this.lblFolderPath = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelFileList = new System.Windows.Forms.Panel();
            this.dgvFiles = new System.Windows.Forms.DataGridView();
            this.colFileListName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelFileListHeader = new System.Windows.Forms.Panel();
            this.lblFileCount = new System.Windows.Forms.Label();
            this.lblFileList = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panelFileContent = new System.Windows.Forms.Panel();
            this.txtFileContent = new System.Windows.Forms.RichTextBox();
            this.panelFileContentHeader = new System.Windows.Forms.Panel();
            this.lblFileContent = new System.Windows.Forms.Label();
            this.panelExecutionLog = new System.Windows.Forms.Panel();
            this.dgvExecutionLog = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelExecutionHeader = new System.Windows.Forms.Panel();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.chkShowPending = new System.Windows.Forms.CheckBox();
            this.txtExecutionSearch = new System.Windows.Forms.TextBox();
            this.lblExecutionLog = new System.Windows.Forms.Label();
            this.lblSearchKeyword = new System.Windows.Forms.Label();
            this.lblExecutionSummary = new System.Windows.Forms.Label();
            this.chkShowFailed = new System.Windows.Forms.CheckBox();
            this.chkShowSuccess = new System.Windows.Forms.CheckBox();
            this.panelOverlay = new FastHorse.TransparentPanel();
            this.panelOverlayContent = new FastHorse.RoundedPanel();
            this.lblOverlayMessage = new System.Windows.Forms.Label();
            this.lblOverlayProgress = new System.Windows.Forms.Label();
            this.progressBarOverlay = new System.Windows.Forms.ProgressBar();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelFileList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            this.panelFileListHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panelFileContent.SuspendLayout();
            this.panelFileContentHeader.SuspendLayout();
            this.panelExecutionLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExecutionLog)).BeginInit();
            this.panelExecutionHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.panelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTop.Controls.Add(this.btnExecute);
            this.panelTop.Controls.Add(this.btnSqlOptions);
            this.panelTop.Controls.Add(this.btnDbConfig);
            this.panelTop.Controls.Add(this.btnSelectFolder);
            this.panelTop.Controls.Add(this.lblExecutionStats);
            this.panelTop.Controls.Add(this.lblDbInfo);
            this.panelTop.Controls.Add(this.lblFolderPath);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(28, 21, 28, 21);
            this.panelTop.Size = new System.Drawing.Size(1925, 107);
            this.panelTop.TabIndex = 0;
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(211)))), ((int)(((byte)(153)))));
            this.btnExecute.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExecute.Enabled = false;
            this.btnExecute.FlatAppearance.BorderSize = 0;
            this.btnExecute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExecute.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExecute.ForeColor = System.Drawing.Color.White;
            this.btnExecute.Location = new System.Drawing.Point(1777, 12);
            this.btnExecute.Margin = new System.Windows.Forms.Padding(4);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(79, 47);
            this.btnExecute.TabIndex = 2;
            this.btnExecute.Text = "▶";
            this.btnExecute.UseVisualStyleBackColor = false;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnSqlOptions
            // 
            this.btnSqlOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(126)))), ((int)(((byte)(176)))));
            this.btnSqlOptions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSqlOptions.FlatAppearance.BorderSize = 0;
            this.btnSqlOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSqlOptions.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSqlOptions.ForeColor = System.Drawing.Color.White;
            this.btnSqlOptions.Location = new System.Drawing.Point(414, 12);
            this.btnSqlOptions.Margin = new System.Windows.Forms.Padding(4);
            this.btnSqlOptions.Name = "btnSqlOptions";
            this.btnSqlOptions.Size = new System.Drawing.Size(169, 47);
            this.btnSqlOptions.TabIndex = 6;
            this.btnSqlOptions.Text = "⚙️ 查询选项";
            this.btnSqlOptions.UseVisualStyleBackColor = false;
            this.btnSqlOptions.Click += new System.EventHandler(this.btnSqlOptions_Click);
            // 
            // btnDbConfig
            // 
            this.btnDbConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(126)))), ((int)(((byte)(176)))));
            this.btnDbConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDbConfig.FlatAppearance.BorderSize = 0;
            this.btnDbConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDbConfig.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDbConfig.ForeColor = System.Drawing.Color.White;
            this.btnDbConfig.Location = new System.Drawing.Point(227, 12);
            this.btnDbConfig.Margin = new System.Windows.Forms.Padding(4);
            this.btnDbConfig.Name = "btnDbConfig";
            this.btnDbConfig.Size = new System.Drawing.Size(169, 47);
            this.btnDbConfig.TabIndex = 1;
            this.btnDbConfig.Text = "⚙️ 数据库配置";
            this.btnDbConfig.UseVisualStyleBackColor = false;
            this.btnDbConfig.Click += new System.EventHandler(this.btnDbConfig_Click);
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(126)))), ((int)(((byte)(176)))));
            this.btnSelectFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectFolder.FlatAppearance.BorderSize = 0;
            this.btnSelectFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectFolder.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectFolder.ForeColor = System.Drawing.Color.White;
            this.btnSelectFolder.Location = new System.Drawing.Point(32, 9);
            this.btnSelectFolder.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(173, 50);
            this.btnSelectFolder.TabIndex = 0;
            this.btnSelectFolder.Text = "📁 选择文件夹";
            this.btnSelectFolder.UseVisualStyleBackColor = false;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // lblExecutionStats
            // 
            this.lblExecutionStats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExecutionStats.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExecutionStats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblExecutionStats.Location = new System.Drawing.Point(1572, 63);
            this.lblExecutionStats.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExecutionStats.Name = "lblExecutionStats";
            this.lblExecutionStats.Size = new System.Drawing.Size(257, 35);
            this.lblExecutionStats.TabIndex = 5;
            this.lblExecutionStats.Text = "待执行";
            this.lblExecutionStats.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDbInfo
            // 
            this.lblDbInfo.AutoSize = true;
            this.lblDbInfo.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDbInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDbInfo.Location = new System.Drawing.Point(591, 23);
            this.lblDbInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDbInfo.Name = "lblDbInfo";
            this.lblDbInfo.Size = new System.Drawing.Size(184, 28);
            this.lblDbInfo.TabIndex = 4;
            this.lblDbInfo.Text = "🔌 数据库: 未配置";
            // 
            // lblFolderPath
            // 
            this.lblFolderPath.AutoSize = true;
            this.lblFolderPath.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFolderPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblFolderPath.Location = new System.Drawing.Point(32, 63);
            this.lblFolderPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFolderPath.Name = "lblFolderPath";
            this.lblFolderPath.Size = new System.Drawing.Size(173, 28);
            this.lblFolderPath.TabIndex = 3;
            this.lblFolderPath.Text = "📁 未选择文件夹";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 107);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelFileList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1925, 1020);
            this.splitContainer1.SplitterDistance = 420;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 1;
            // 
            // panelFileList
            // 
            this.panelFileList.BackColor = System.Drawing.Color.White;
            this.panelFileList.Controls.Add(this.dgvFiles);
            this.panelFileList.Controls.Add(this.panelFileListHeader);
            this.panelFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFileList.Location = new System.Drawing.Point(0, 0);
            this.panelFileList.Margin = new System.Windows.Forms.Padding(4);
            this.panelFileList.Name = "panelFileList";
            this.panelFileList.Padding = new System.Windows.Forms.Padding(1);
            this.panelFileList.Size = new System.Drawing.Size(420, 1020);
            this.panelFileList.TabIndex = 0;
            // 
            // dgvFiles
            // 
            this.dgvFiles.AllowUserToAddRows = false;
            this.dgvFiles.AllowUserToDeleteRows = false;
            this.dgvFiles.AllowUserToResizeRows = false;
            this.dgvFiles.BackgroundColor = System.Drawing.Color.White;
            this.dgvFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFiles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFiles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFiles.ColumnHeadersHeight = 35;
            this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFileListName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFiles.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFiles.EnableHeadersVisualStyles = false;
            this.dgvFiles.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvFiles.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvFiles.Location = new System.Drawing.Point(1, 57);
            this.dgvFiles.MultiSelect = false;
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.ReadOnly = true;
            this.dgvFiles.RowHeadersVisible = false;
            this.dgvFiles.RowHeadersWidth = 72;
            this.dgvFiles.RowTemplate.Height = 30;
            this.dgvFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFiles.Size = new System.Drawing.Size(418, 962);
            this.dgvFiles.TabIndex = 1;
            this.dgvFiles.SelectionChanged += new System.EventHandler(this.dgvFiles_SelectionChanged);
            // 
            // colFileListName
            // 
            this.colFileListName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFileListName.DataPropertyName = "FileName";
            this.colFileListName.HeaderText = "文件名称";
            this.colFileListName.MinimumWidth = 9;
            this.colFileListName.Name = "colFileListName";
            this.colFileListName.ReadOnly = true;
            // 
            // panelFileListHeader
            // 
            this.panelFileListHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.panelFileListHeader.Controls.Add(this.lblFileCount);
            this.panelFileListHeader.Controls.Add(this.lblFileList);
            this.panelFileListHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFileListHeader.Location = new System.Drawing.Point(1, 1);
            this.panelFileListHeader.Margin = new System.Windows.Forms.Padding(4);
            this.panelFileListHeader.Name = "panelFileListHeader";
            this.panelFileListHeader.Padding = new System.Windows.Forms.Padding(21, 14, 21, 14);
            this.panelFileListHeader.Size = new System.Drawing.Size(418, 56);
            this.panelFileListHeader.TabIndex = 0;
            // 
            // lblFileCount
            // 
            this.lblFileCount.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblFileCount.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFileCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblFileCount.Location = new System.Drawing.Point(280, 14);
            this.lblFileCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFileCount.Name = "lblFileCount";
            this.lblFileCount.Size = new System.Drawing.Size(117, 28);
            this.lblFileCount.TabIndex = 1;
            this.lblFileCount.Text = "0 个文件";
            this.lblFileCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFileList
            // 
            this.lblFileList.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblFileList.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.714286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFileList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblFileList.Location = new System.Drawing.Point(21, 14);
            this.lblFileList.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFileList.Name = "lblFileList";
            this.lblFileList.Size = new System.Drawing.Size(206, 28);
            this.lblFileList.TabIndex = 0;
            this.lblFileList.Text = "📋 文件列表";
            this.lblFileList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFileList.Click += new System.EventHandler(this.lblFileList_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panelFileContent);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panelExecutionLog);
            this.splitContainer2.Size = new System.Drawing.Size(1499, 1020);
            this.splitContainer2.SplitterDistance = 433;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 0;
            // 
            // panelFileContent
            // 
            this.panelFileContent.BackColor = System.Drawing.Color.White;
            this.panelFileContent.Controls.Add(this.txtFileContent);
            this.panelFileContent.Controls.Add(this.panelFileContentHeader);
            this.panelFileContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFileContent.Location = new System.Drawing.Point(0, 0);
            this.panelFileContent.Margin = new System.Windows.Forms.Padding(4);
            this.panelFileContent.Name = "panelFileContent";
            this.panelFileContent.Padding = new System.Windows.Forms.Padding(1);
            this.panelFileContent.Size = new System.Drawing.Size(1499, 433);
            this.panelFileContent.TabIndex = 0;
            // 
            // txtFileContent
            // 
            this.txtFileContent.BackColor = System.Drawing.SystemColors.Window;
            this.txtFileContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFileContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFileContent.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileContent.Location = new System.Drawing.Point(1, 57);
            this.txtFileContent.Margin = new System.Windows.Forms.Padding(4);
            this.txtFileContent.Name = "txtFileContent";
            this.txtFileContent.ReadOnly = true;
            this.txtFileContent.Size = new System.Drawing.Size(1497, 375);
            this.txtFileContent.TabIndex = 1;
            this.txtFileContent.Text = "";
            // 
            // panelFileContentHeader
            // 
            this.panelFileContentHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.panelFileContentHeader.Controls.Add(this.lblFileContent);
            this.panelFileContentHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFileContentHeader.Location = new System.Drawing.Point(1, 1);
            this.panelFileContentHeader.Margin = new System.Windows.Forms.Padding(4);
            this.panelFileContentHeader.Name = "panelFileContentHeader";
            this.panelFileContentHeader.Padding = new System.Windows.Forms.Padding(21, 14, 21, 14);
            this.panelFileContentHeader.Size = new System.Drawing.Size(1497, 56);
            this.panelFileContentHeader.TabIndex = 0;
            // 
            // lblFileContent
            // 
            this.lblFileContent.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblFileContent.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.714286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFileContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblFileContent.Location = new System.Drawing.Point(21, 14);
            this.lblFileContent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFileContent.Name = "lblFileContent";
            this.lblFileContent.Size = new System.Drawing.Size(412, 28);
            this.lblFileContent.TabIndex = 0;
            this.lblFileContent.Text = "📄 文件内容";
            this.lblFileContent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelExecutionLog
            // 
            this.panelExecutionLog.BackColor = System.Drawing.Color.White;
            this.panelExecutionLog.Controls.Add(this.dgvExecutionLog);
            this.panelExecutionLog.Controls.Add(this.panelExecutionHeader);
            this.panelExecutionLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExecutionLog.Location = new System.Drawing.Point(0, 0);
            this.panelExecutionLog.Margin = new System.Windows.Forms.Padding(4);
            this.panelExecutionLog.Name = "panelExecutionLog";
            this.panelExecutionLog.Padding = new System.Windows.Forms.Padding(1);
            this.panelExecutionLog.Size = new System.Drawing.Size(1499, 581);
            this.panelExecutionLog.TabIndex = 0;
            // 
            // dgvExecutionLog
            // 
            this.dgvExecutionLog.AllowUserToAddRows = false;
            this.dgvExecutionLog.AllowUserToDeleteRows = false;
            this.dgvExecutionLog.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.dgvExecutionLog.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvExecutionLog.BackgroundColor = System.Drawing.Color.White;
            this.dgvExecutionLog.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExecutionLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvExecutionLog.ColumnHeadersHeight = 40;
            this.dgvExecutionLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvExecutionLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvExecutionLog.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvExecutionLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExecutionLog.EnableHeadersVisualStyles = false;
            this.dgvExecutionLog.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvExecutionLog.Location = new System.Drawing.Point(1, 53);
            this.dgvExecutionLog.Margin = new System.Windows.Forms.Padding(4);
            this.dgvExecutionLog.MultiSelect = false;
            this.dgvExecutionLog.Name = "dgvExecutionLog";
            this.dgvExecutionLog.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExecutionLog.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvExecutionLog.RowHeadersVisible = false;
            this.dgvExecutionLog.RowHeadersWidth = 51;
            this.dgvExecutionLog.RowTemplate.Height = 35;
            this.dgvExecutionLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExecutionLog.Size = new System.Drawing.Size(1497, 527);
            this.dgvExecutionLog.TabIndex = 2;
            this.dgvExecutionLog.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExecutionLog_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "FileName";
            this.Column1.HeaderText = "文件名称";
            this.Column1.MinimumWidth = 9;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 350;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "DurationText";
            this.Column2.HeaderText = "执行耗时";
            this.Column2.MinimumWidth = 9;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 175;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Status";
            this.Column3.HeaderText = "执行状态";
            this.Column3.MinimumWidth = 9;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 175;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.DataPropertyName = "ErrorMessage";
            this.Column4.HeaderText = "错误详情";
            this.Column4.MinimumWidth = 9;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // panelExecutionHeader
            // 
            this.panelExecutionHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.panelExecutionHeader.Controls.Add(this.btnClearSearch);
            this.panelExecutionHeader.Controls.Add(this.chkShowPending);
            this.panelExecutionHeader.Controls.Add(this.txtExecutionSearch);
            this.panelExecutionHeader.Controls.Add(this.lblExecutionLog);
            this.panelExecutionHeader.Controls.Add(this.lblSearchKeyword);
            this.panelExecutionHeader.Controls.Add(this.lblExecutionSummary);
            this.panelExecutionHeader.Controls.Add(this.chkShowFailed);
            this.panelExecutionHeader.Controls.Add(this.chkShowSuccess);
            this.panelExecutionHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelExecutionHeader.Location = new System.Drawing.Point(1, 1);
            this.panelExecutionHeader.Margin = new System.Windows.Forms.Padding(4);
            this.panelExecutionHeader.Name = "panelExecutionHeader";
            this.panelExecutionHeader.Padding = new System.Windows.Forms.Padding(21, 14, 21, 14);
            this.panelExecutionHeader.Size = new System.Drawing.Size(1497, 52);
            this.panelExecutionHeader.TabIndex = 0;
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnClearSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearSearch.FlatAppearance.BorderSize = 0;
            this.btnClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearSearch.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClearSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnClearSearch.Location = new System.Drawing.Point(1028, 7);
            this.btnClearSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(67, 34);
            this.btnClearSearch.TabIndex = 5;
            this.btnClearSearch.Text = "清除";
            this.btnClearSearch.UseVisualStyleBackColor = false;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // chkShowPending
            // 
            this.chkShowPending.AutoSize = true;
            this.chkShowPending.Checked = true;
            this.chkShowPending.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowPending.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkShowPending.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.chkShowPending.Location = new System.Drawing.Point(145, 10);
            this.chkShowPending.Margin = new System.Windows.Forms.Padding(4);
            this.chkShowPending.Name = "chkShowPending";
            this.chkShowPending.Size = new System.Drawing.Size(136, 32);
            this.chkShowPending.TabIndex = 0;
            this.chkShowPending.Text = "⏳ 进行中";
            this.chkShowPending.UseVisualStyleBackColor = true;
            this.chkShowPending.CheckedChanged += new System.EventHandler(this.chkShowPending_CheckedChanged);
            // 
            // txtExecutionSearch
            // 
            this.txtExecutionSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExecutionSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExecutionSearch.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtExecutionSearch.Location = new System.Drawing.Point(691, 8);
            this.txtExecutionSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtExecutionSearch.Name = "txtExecutionSearch";
            this.txtExecutionSearch.Size = new System.Drawing.Size(329, 34);
            this.txtExecutionSearch.TabIndex = 4;
            this.txtExecutionSearch.TextChanged += new System.EventHandler(this.txtExecutionSearch_TextChanged);
            // 
            // lblExecutionLog
            // 
            this.lblExecutionLog.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblExecutionLog.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.714286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExecutionLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblExecutionLog.Location = new System.Drawing.Point(21, 14);
            this.lblExecutionLog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExecutionLog.Name = "lblExecutionLog";
            this.lblExecutionLog.Size = new System.Drawing.Size(116, 24);
            this.lblExecutionLog.TabIndex = 0;
            this.lblExecutionLog.Text = "📊 执行记录";
            this.lblExecutionLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblExecutionLog.Click += new System.EventHandler(this.lblExecutionLog_Click);
            // 
            // lblSearchKeyword
            // 
            this.lblSearchKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearchKeyword.AutoSize = true;
            this.lblSearchKeyword.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSearchKeyword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSearchKeyword.Location = new System.Drawing.Point(575, 11);
            this.lblSearchKeyword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearchKeyword.Name = "lblSearchKeyword";
            this.lblSearchKeyword.Size = new System.Drawing.Size(131, 28);
            this.lblSearchKeyword.TabIndex = 3;
            this.lblSearchKeyword.Text = "🔍 关键字：";
            // 
            // lblExecutionSummary
            // 
            this.lblExecutionSummary.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblExecutionSummary.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.714286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExecutionSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblExecutionSummary.Location = new System.Drawing.Point(1235, 14);
            this.lblExecutionSummary.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExecutionSummary.Name = "lblExecutionSummary";
            this.lblExecutionSummary.Size = new System.Drawing.Size(241, 24);
            this.lblExecutionSummary.TabIndex = 1;
            this.lblExecutionSummary.Text = "共 0 条 | ✓ 0 | ✗ 0 | ⏳ 0";
            this.lblExecutionSummary.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblExecutionSummary.Click += new System.EventHandler(this.lblExecutionSummary_Click);
            // 
            // chkShowFailed
            // 
            this.chkShowFailed.AutoSize = true;
            this.chkShowFailed.Checked = true;
            this.chkShowFailed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowFailed.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkShowFailed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.chkShowFailed.Location = new System.Drawing.Point(387, 10);
            this.chkShowFailed.Margin = new System.Windows.Forms.Padding(4);
            this.chkShowFailed.Name = "chkShowFailed";
            this.chkShowFailed.Size = new System.Drawing.Size(100, 32);
            this.chkShowFailed.TabIndex = 2;
            this.chkShowFailed.Text = "✗ 失败";
            this.chkShowFailed.UseVisualStyleBackColor = true;
            this.chkShowFailed.CheckedChanged += new System.EventHandler(this.chkShowFailed_CheckedChanged);
            // 
            // chkShowSuccess
            // 
            this.chkShowSuccess.AutoSize = true;
            this.chkShowSuccess.Checked = true;
            this.chkShowSuccess.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowSuccess.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkShowSuccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.chkShowSuccess.Location = new System.Drawing.Point(280, 12);
            this.chkShowSuccess.Margin = new System.Windows.Forms.Padding(4);
            this.chkShowSuccess.Name = "chkShowSuccess";
            this.chkShowSuccess.Size = new System.Drawing.Size(99, 32);
            this.chkShowSuccess.TabIndex = 1;
            this.chkShowSuccess.Text = "✓ 成功";
            this.chkShowSuccess.UseVisualStyleBackColor = true;
            this.chkShowSuccess.CheckedChanged += new System.EventHandler(this.chkShowSuccess_CheckedChanged);
            // 
            // panelOverlay
            // 
            this.panelOverlay.Alpha = 200;
            this.panelOverlay.Controls.Add(this.panelOverlayContent);
            this.panelOverlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOverlay.Location = new System.Drawing.Point(0, 0);
            this.panelOverlay.Name = "panelOverlay";
            this.panelOverlay.Size = new System.Drawing.Size(1925, 1127);
            this.panelOverlay.TabIndex = 2;
            this.panelOverlay.Visible = false;
            this.panelOverlay.Enabled = true;
            // 
            // panelOverlayContent
            // 
            this.panelOverlayContent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelOverlayContent.BackColor = System.Drawing.Color.White;
            this.panelOverlayContent.CornerRadius = 12;
            this.panelOverlayContent.Controls.Add(this.lblOverlayMessage);
            this.panelOverlayContent.Controls.Add(this.lblOverlayProgress);
            this.panelOverlayContent.Controls.Add(this.progressBarOverlay);
            this.panelOverlayContent.Location = new System.Drawing.Point(612, 450);
            this.panelOverlayContent.Name = "panelOverlayContent";
            this.panelOverlayContent.Padding = new System.Windows.Forms.Padding(30);
            this.panelOverlayContent.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelOverlayContent.ShadowOffset = 8;
            this.panelOverlayContent.Size = new System.Drawing.Size(700, 200);
            this.panelOverlayContent.TabIndex = 2;
            // 
            // lblOverlayMessage
            // 
            this.lblOverlayMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOverlayMessage.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOverlayMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblOverlayMessage.Location = new System.Drawing.Point(30, 30);
            this.lblOverlayMessage.Name = "lblOverlayMessage";
            this.lblOverlayMessage.Size = new System.Drawing.Size(640, 45);
            this.lblOverlayMessage.TabIndex = 1;
            this.lblOverlayMessage.Text = "正在执行脚本...";
            this.lblOverlayMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOverlayProgress
            // 
            this.lblOverlayProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOverlayProgress.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOverlayProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblOverlayProgress.Location = new System.Drawing.Point(30, 85);
            this.lblOverlayProgress.Name = "lblOverlayProgress";
            this.lblOverlayProgress.Size = new System.Drawing.Size(640, 30);
            this.lblOverlayProgress.TabIndex = 2;
            this.lblOverlayProgress.Text = "准备中...";
            this.lblOverlayProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBarOverlay
            // 
            this.progressBarOverlay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarOverlay.Location = new System.Drawing.Point(30, 135);
            this.progressBarOverlay.MarqueeAnimationSpeed = 50;
            this.progressBarOverlay.Name = "progressBarOverlay";
            this.progressBarOverlay.Size = new System.Drawing.Size(640, 30);
            this.progressBarOverlay.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarOverlay.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1925, 1127);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelOverlay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1751, 982);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL Server 脚本批量执行工具 - FastHorse";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelFileList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            this.panelFileListHeader.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panelFileContent.ResumeLayout(false);
            this.panelFileContentHeader.ResumeLayout(false);
            this.panelExecutionLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExecutionLog)).EndInit();
            this.panelExecutionHeader.ResumeLayout(false);
            this.panelExecutionHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button btnSqlOptions;
        private System.Windows.Forms.Button btnDbConfig;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.Label lblDbInfo;
        private System.Windows.Forms.Label lblFolderPath;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelFileList;
        private System.Windows.Forms.DataGridView dgvFiles;
        private System.Windows.Forms.Panel panelFileListHeader;
        private System.Windows.Forms.Label lblFileCount;
        private System.Windows.Forms.Label lblFileList;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panelFileContent;
        private System.Windows.Forms.RichTextBox txtFileContent;
        private System.Windows.Forms.Panel panelFileContentHeader;
        private System.Windows.Forms.Label lblFileContent;
        private System.Windows.Forms.Panel panelExecutionLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExecuteTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colErrorMessage;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.TextBox txtExecutionSearch;
        private System.Windows.Forms.Label lblSearchKeyword;
        private System.Windows.Forms.Panel panelExecutionHeader;
        private System.Windows.Forms.Label lblExecutionSummary;
        private System.Windows.Forms.Label lblExecutionLog;
        private System.Windows.Forms.DataGridView dgvExecutionLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.CheckBox chkShowPending;
        private System.Windows.Forms.CheckBox chkShowFailed;
        private System.Windows.Forms.CheckBox chkShowSuccess;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileListName;
        private System.Windows.Forms.Label lblExecutionStats;
        private FastHorse.TransparentPanel panelOverlay;
        private FastHorse.RoundedPanel panelOverlayContent;
        private System.Windows.Forms.Label lblOverlayMessage;
        private System.Windows.Forms.Label lblOverlayProgress;
        private System.Windows.Forms.ProgressBar progressBarOverlay;
    }
}
