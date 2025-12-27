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
            this.chkMultiThread = new System.Windows.Forms.CheckBox();
            this.btnAbout = new System.Windows.Forms.Button();
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panelFileContent = new System.Windows.Forms.Panel();
            this.txtFileContent = new FastHorse.LineNumberRichTextBox();
            this.panelExecutionLog = new System.Windows.Forms.Panel();
            this.dgvExecutionLog = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colViewDetails = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panelExecutionHeader = new System.Windows.Forms.Panel();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.txtExecutionSearch = new System.Windows.Forms.TextBox();
            this.lblExecutionLog = new System.Windows.Forms.Label();
            this.lblSearchKeyword = new System.Windows.Forms.Label();
            this.lblExecutionSummary = new System.Windows.Forms.Label();
            this.chkShowFailed = new System.Windows.Forms.CheckBox();
            this.chkShowSuccess = new System.Windows.Forms.CheckBox();
            this.panelOverlay = new FastHorse.TransparentPanel();
            this.panelOverlayContent = new FastHorse.RoundedPanel();
            this.lblOverlayMessage = new System.Windows.Forms.Label();
            this.lblOverlayDatabaseInfo = new System.Windows.Forms.Label();
            this.lblOverlayProgress = new System.Windows.Forms.Label();
            this.progressBarOverlay = new FastHorse.HorseProgressBar();
            this.lblFileList = new System.Windows.Forms.Label();
            this.lblFileCount = new System.Windows.Forms.Label();
            this.panelFileListHeader = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelFileList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panelExecutionLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExecutionLog)).BeginInit();
            this.panelExecutionHeader.SuspendLayout();
            this.panelOverlay.SuspendLayout();
            this.panelOverlayContent.SuspendLayout();
            this.panelFileListHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.panelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTop.Controls.Add(this.chkMultiThread);
            this.panelTop.Controls.Add(this.btnAbout);
            this.panelTop.Controls.Add(this.btnExecute);
            this.panelTop.Controls.Add(this.btnSqlOptions);
            this.panelTop.Controls.Add(this.btnDbConfig);
            this.panelTop.Controls.Add(this.btnSelectFolder);
            this.panelTop.Controls.Add(this.lblExecutionStats);
            this.panelTop.Controls.Add(this.lblDbInfo);
            this.panelTop.Controls.Add(this.lblFolderPath);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.panelTop.Size = new System.Drawing.Size(1400, 77);
            this.panelTop.TabIndex = 0;
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAbout.ForeColor = System.Drawing.Color.White;
            this.btnAbout.Location = new System.Drawing.Point(1355, 9);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(36, 34);
            this.btnAbout.TabIndex = 7;
            this.btnAbout.Text = "ℹ️";
            this.btnAbout.UseVisualStyleBackColor = false;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // chkMultiThread
            // 
            this.chkMultiThread.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkMultiThread.AutoSize = true;
            this.chkMultiThread.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkMultiThread.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.chkMultiThread.Location = new System.Drawing.Point(1165, 15);
            this.chkMultiThread.Name = "chkMultiThread";
            this.chkMultiThread.Size = new System.Drawing.Size(120, 24);
            this.chkMultiThread.TabIndex = 8;
            this.chkMultiThread.Text = "⚡ 多线程执行";
            this.chkMultiThread.UseVisualStyleBackColor = true;
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnExecute.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExecute.Enabled = false;
            this.btnExecute.FlatAppearance.BorderSize = 0;
            this.btnExecute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExecute.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExecute.ForeColor = System.Drawing.Color.White;
            this.btnExecute.Location = new System.Drawing.Point(1291, 9);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(57, 34);
            this.btnExecute.TabIndex = 2;
            this.btnExecute.Text = "▶";
            this.btnExecute.UseVisualStyleBackColor = false;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnSqlOptions
            // 
            this.btnSqlOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnSqlOptions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSqlOptions.FlatAppearance.BorderSize = 0;
            this.btnSqlOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSqlOptions.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSqlOptions.ForeColor = System.Drawing.Color.White;
            this.btnSqlOptions.Location = new System.Drawing.Point(301, 9);
            this.btnSqlOptions.Name = "btnSqlOptions";
            this.btnSqlOptions.Size = new System.Drawing.Size(123, 34);
            this.btnSqlOptions.TabIndex = 6;
            this.btnSqlOptions.Text = "⚙️ 查询选项";
            this.btnSqlOptions.UseVisualStyleBackColor = false;
            this.btnSqlOptions.Click += new System.EventHandler(this.btnSqlOptions_Click);
            // 
            // btnDbConfig
            // 
            this.btnDbConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnDbConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDbConfig.FlatAppearance.BorderSize = 0;
            this.btnDbConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDbConfig.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDbConfig.ForeColor = System.Drawing.Color.White;
            this.btnDbConfig.Location = new System.Drawing.Point(165, 9);
            this.btnDbConfig.Name = "btnDbConfig";
            this.btnDbConfig.Size = new System.Drawing.Size(123, 34);
            this.btnDbConfig.TabIndex = 1;
            this.btnDbConfig.Text = "⚙️ 数据库配置";
            this.btnDbConfig.UseVisualStyleBackColor = false;
            this.btnDbConfig.Click += new System.EventHandler(this.btnDbConfig_Click);
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(241)))));
            this.btnSelectFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectFolder.FlatAppearance.BorderSize = 0;
            this.btnSelectFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectFolder.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectFolder.ForeColor = System.Drawing.Color.White;
            this.btnSelectFolder.Location = new System.Drawing.Point(23, 6);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(126, 36);
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
            this.lblExecutionStats.Location = new System.Drawing.Point(1142, 45);
            this.lblExecutionStats.Name = "lblExecutionStats";
            this.lblExecutionStats.Size = new System.Drawing.Size(187, 25);
            this.lblExecutionStats.TabIndex = 5;
            this.lblExecutionStats.Text = "待执行";
            this.lblExecutionStats.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDbInfo
            // 
            this.lblDbInfo.AutoSize = true;
            this.lblDbInfo.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDbInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDbInfo.Location = new System.Drawing.Point(430, 16);
            this.lblDbInfo.Name = "lblDbInfo";
            this.lblDbInfo.Size = new System.Drawing.Size(132, 20);
            this.lblDbInfo.TabIndex = 4;
            this.lblDbInfo.Text = "🔌 数据库: 未配置";
            // 
            // lblFolderPath
            // 
            this.lblFolderPath.AutoSize = true;
            this.lblFolderPath.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFolderPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblFolderPath.Location = new System.Drawing.Point(23, 45);
            this.lblFolderPath.Name = "lblFolderPath";
            this.lblFolderPath.Size = new System.Drawing.Size(124, 20);
            this.lblFolderPath.TabIndex = 3;
            this.lblFolderPath.Text = "📁 未选择文件夹";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 77);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelFileList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1400, 728);
            this.splitContainer1.SplitterDistance = 305;
            this.splitContainer1.TabIndex = 1;
            // 
            // panelFileList
            // 
            this.panelFileList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.panelFileList.Controls.Add(this.dgvFiles);
            this.panelFileList.Controls.Add(this.panelFileListHeader);
            this.panelFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFileList.Location = new System.Drawing.Point(0, 0);
            this.panelFileList.Name = "panelFileList";
            this.panelFileList.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.panelFileList.Size = new System.Drawing.Size(305, 728);
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFiles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFiles.ColumnHeadersHeight = 35;
            this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvFiles.ColumnHeadersVisible = false;
            this.dgvFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFileListName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFiles.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFiles.EnableHeadersVisualStyles = false;
            this.dgvFiles.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvFiles.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvFiles.Location = new System.Drawing.Point(1, 41);
            this.dgvFiles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvFiles.MultiSelect = false;
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.ReadOnly = true;
            this.dgvFiles.RowHeadersVisible = false;
            this.dgvFiles.RowHeadersWidth = 72;
            this.dgvFiles.RowTemplate.Height = 30;
            this.dgvFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFiles.Size = new System.Drawing.Size(303, 686);
            this.dgvFiles.TabIndex = 1;
            this.dgvFiles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFiles_CellDoubleClick);
            this.dgvFiles.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvFiles_CellPainting);
            this.dgvFiles.SelectionChanged += new System.EventHandler(this.dgvFiles_SelectionChanged);
            // 
            // colFileListName
            // 
            this.colFileListName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFileListName.DataPropertyName = "DisplayName";
            this.colFileListName.HeaderText = "文件名称";
            this.colFileListName.MinimumWidth = 9;
            this.colFileListName.Name = "colFileListName";
            this.colFileListName.ReadOnly = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
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
            this.splitContainer2.Size = new System.Drawing.Size(1091, 728);
            this.splitContainer2.SplitterDistance = 309;
            this.splitContainer2.TabIndex = 0;
            // 
            // panelFileContent
            // 
            this.panelFileContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.panelFileContent.Controls.Add(this.txtFileContent);
            this.panelFileContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFileContent.Location = new System.Drawing.Point(0, 0);
            this.panelFileContent.Name = "panelFileContent";
            this.panelFileContent.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.panelFileContent.Size = new System.Drawing.Size(1091, 309);
            this.panelFileContent.TabIndex = 0;
            // 
            // txtFileContent
            // 
            this.txtFileContent.BackColor = System.Drawing.Color.White;
            this.txtFileContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFileContent.Location = new System.Drawing.Point(1, 1);
            this.txtFileContent.Name = "txtFileContent";
            this.txtFileContent.ReadOnlyText = true;
            this.txtFileContent.Size = new System.Drawing.Size(1089, 307);
            this.txtFileContent.TabIndex = 1;
            this.txtFileContent.TextBackColor = System.Drawing.Color.White;
            this.txtFileContent.TextFont = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileContent.TextForeColor = System.Drawing.SystemColors.WindowText;
            // 
            // panelExecutionLog
            // 
            this.panelExecutionLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.panelExecutionLog.Controls.Add(this.dgvExecutionLog);
            this.panelExecutionLog.Controls.Add(this.panelExecutionHeader);
            this.panelExecutionLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExecutionLog.Location = new System.Drawing.Point(0, 0);
            this.panelExecutionLog.Name = "panelExecutionLog";
            this.panelExecutionLog.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.panelExecutionLog.Size = new System.Drawing.Size(1091, 415);
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
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExecutionLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvExecutionLog.ColumnHeadersHeight = 40;
            this.dgvExecutionLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvExecutionLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.colViewDetails});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvExecutionLog.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvExecutionLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExecutionLog.EnableHeadersVisualStyles = false;
            this.dgvExecutionLog.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.dgvExecutionLog.Location = new System.Drawing.Point(1, 38);
            this.dgvExecutionLog.MultiSelect = false;
            this.dgvExecutionLog.Name = "dgvExecutionLog";
            this.dgvExecutionLog.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExecutionLog.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvExecutionLog.RowHeadersVisible = false;
            this.dgvExecutionLog.RowHeadersWidth = 51;
            this.dgvExecutionLog.RowTemplate.Height = 35;
            this.dgvExecutionLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExecutionLog.Size = new System.Drawing.Size(1089, 376);
            this.dgvExecutionLog.TabIndex = 2;
            this.dgvExecutionLog.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExecutionLog_CellContentClick);
            this.dgvExecutionLog.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvExecutionLog_CellPainting);
            this.dgvExecutionLog.SelectionChanged += new System.EventHandler(this.dgvExecutionLog_SelectionChanged);
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
            // colViewDetails
            // 
            this.colViewDetails.HeaderText = "操作";
            this.colViewDetails.MinimumWidth = 9;
            this.colViewDetails.Name = "colViewDetails";
            this.colViewDetails.ReadOnly = true;
            this.colViewDetails.Text = "查看详情";
            this.colViewDetails.UseColumnTextForButtonValue = true;
            // 
            // panelExecutionHeader
            // 
            this.panelExecutionHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.panelExecutionHeader.Controls.Add(this.btnShowAll);
            this.panelExecutionHeader.Controls.Add(this.btnClearSearch);
            this.panelExecutionHeader.Controls.Add(this.txtExecutionSearch);
            this.panelExecutionHeader.Controls.Add(this.lblExecutionLog);
            this.panelExecutionHeader.Controls.Add(this.lblSearchKeyword);
            this.panelExecutionHeader.Controls.Add(this.lblExecutionSummary);
            this.panelExecutionHeader.Controls.Add(this.chkShowFailed);
            this.panelExecutionHeader.Controls.Add(this.chkShowSuccess);
            this.panelExecutionHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelExecutionHeader.Location = new System.Drawing.Point(1, 1);
            this.panelExecutionHeader.Name = "panelExecutionHeader";
            this.panelExecutionHeader.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.panelExecutionHeader.Size = new System.Drawing.Size(1089, 37);
            this.panelExecutionHeader.TabIndex = 0;
            // 
            // btnShowAll
            // 
            this.btnShowAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(241)))));
            this.btnShowAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowAll.FlatAppearance.BorderSize = 0;
            this.btnShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAll.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnShowAll.ForeColor = System.Drawing.Color.White;
            this.btnShowAll.Location = new System.Drawing.Point(105, 6);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(54, 24);
            this.btnShowAll.TabIndex = 7;
            this.btnShowAll.Text = "📋 全部";
            this.btnShowAll.UseVisualStyleBackColor = false;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
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
            this.btnClearSearch.Location = new System.Drawing.Point(750, 5);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(49, 24);
            this.btnClearSearch.TabIndex = 5;
            this.btnClearSearch.Text = "清除";
            this.btnClearSearch.UseVisualStyleBackColor = false;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // txtExecutionSearch
            // 
            this.txtExecutionSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExecutionSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExecutionSearch.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtExecutionSearch.Location = new System.Drawing.Point(505, 6);
            this.txtExecutionSearch.Name = "txtExecutionSearch";
            this.txtExecutionSearch.Size = new System.Drawing.Size(240, 27);
            this.txtExecutionSearch.TabIndex = 4;
            this.txtExecutionSearch.TextChanged += new System.EventHandler(this.txtExecutionSearch_TextChanged);
            // 
            // lblExecutionLog
            // 
            this.lblExecutionLog.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblExecutionLog.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.714286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExecutionLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblExecutionLog.Location = new System.Drawing.Point(15, 10);
            this.lblExecutionLog.Name = "lblExecutionLog";
            this.lblExecutionLog.Size = new System.Drawing.Size(84, 17);
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
            this.lblSearchKeyword.Location = new System.Drawing.Point(420, 8);
            this.lblSearchKeyword.Name = "lblSearchKeyword";
            this.lblSearchKeyword.Size = new System.Drawing.Size(94, 20);
            this.lblSearchKeyword.TabIndex = 3;
            this.lblSearchKeyword.Text = "🔍 关键字：";
            // 
            // lblExecutionSummary
            // 
            this.lblExecutionSummary.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblExecutionSummary.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.714286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExecutionSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblExecutionSummary.Location = new System.Drawing.Point(899, 10);
            this.lblExecutionSummary.Name = "lblExecutionSummary";
            this.lblExecutionSummary.Size = new System.Drawing.Size(175, 17);
            this.lblExecutionSummary.TabIndex = 1;
            this.lblExecutionSummary.Text = "共 0 条 | ✓ 0 | ✗ 0 | ⏳ 0";
            this.lblExecutionSummary.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblExecutionSummary.Click += new System.EventHandler(this.lblExecutionSummary_Click);
            // 
            // chkShowFailed
            // 
            this.chkShowFailed.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkShowFailed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.chkShowFailed.Checked = true;
            this.chkShowFailed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkShowFailed.FlatAppearance.BorderSize = 0;
            this.chkShowFailed.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.chkShowFailed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkShowFailed.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkShowFailed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.chkShowFailed.Location = new System.Drawing.Point(235, 6);
            this.chkShowFailed.Name = "chkShowFailed";
            this.chkShowFailed.Size = new System.Drawing.Size(64, 24);
            this.chkShowFailed.TabIndex = 2;
            this.chkShowFailed.Text = "✗ 失败";
            this.chkShowFailed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkShowFailed.UseVisualStyleBackColor = false;
            this.chkShowFailed.CheckedChanged += new System.EventHandler(this.chkShowFailed_CheckedChanged);
            // 
            // chkShowSuccess
            // 
            this.chkShowSuccess.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkShowSuccess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.chkShowSuccess.Checked = true;
            this.chkShowSuccess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkShowSuccess.FlatAppearance.BorderSize = 0;
            this.chkShowSuccess.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.chkShowSuccess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkShowSuccess.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkShowSuccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.chkShowSuccess.Location = new System.Drawing.Point(165, 6);
            this.chkShowSuccess.Name = "chkShowSuccess";
            this.chkShowSuccess.Size = new System.Drawing.Size(64, 24);
            this.chkShowSuccess.TabIndex = 1;
            this.chkShowSuccess.Text = "✓ 成功";
            this.chkShowSuccess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkShowSuccess.UseVisualStyleBackColor = false;
            this.chkShowSuccess.CheckedChanged += new System.EventHandler(this.chkShowSuccess_CheckedChanged);
            // 
            // panelOverlay
            // 
            this.panelOverlay.Alpha = 200;
            this.panelOverlay.Controls.Add(this.panelOverlayContent);
            this.panelOverlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOverlay.Location = new System.Drawing.Point(0, 0);
            this.panelOverlay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelOverlay.Name = "panelOverlay";
            this.panelOverlay.Size = new System.Drawing.Size(1400, 805);
            this.panelOverlay.TabIndex = 3;
            this.panelOverlay.Visible = false;
            // 
            // panelOverlayContent
            // 
            this.panelOverlayContent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelOverlayContent.BackColor = System.Drawing.Color.White;
            this.panelOverlayContent.Controls.Add(this.lblOverlayMessage);
            this.panelOverlayContent.Controls.Add(this.lblOverlayDatabaseInfo);
            this.panelOverlayContent.Controls.Add(this.lblOverlayProgress);
            this.panelOverlayContent.Controls.Add(this.progressBarOverlay);
            this.panelOverlayContent.CornerRadius = 12;
            this.panelOverlayContent.Location = new System.Drawing.Point(350, 300);
            this.panelOverlayContent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelOverlayContent.Name = "panelOverlayContent";
            this.panelOverlayContent.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.panelOverlayContent.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelOverlayContent.ShadowOffset = 8;
            this.panelOverlayContent.Size = new System.Drawing.Size(700, 250);
            this.panelOverlayContent.TabIndex = 2;
            // 
            // lblOverlayMessage
            // 
            this.lblOverlayMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOverlayMessage.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOverlayMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblOverlayMessage.Location = new System.Drawing.Point(30, 25);
            this.lblOverlayMessage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOverlayMessage.Name = "lblOverlayMessage";
            this.lblOverlayMessage.Size = new System.Drawing.Size(640, 35);
            this.lblOverlayMessage.TabIndex = 1;
            this.lblOverlayMessage.Text = "正在执行脚本...";
            this.lblOverlayMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOverlayDatabaseInfo
            // 
            this.lblOverlayDatabaseInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOverlayDatabaseInfo.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOverlayDatabaseInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblOverlayDatabaseInfo.Location = new System.Drawing.Point(30, 65);
            this.lblOverlayDatabaseInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOverlayDatabaseInfo.Name = "lblOverlayDatabaseInfo";
            this.lblOverlayDatabaseInfo.Size = new System.Drawing.Size(640, 30);
            this.lblOverlayDatabaseInfo.TabIndex = 3;
            this.lblOverlayDatabaseInfo.Text = "📊 数据库: localhost / master";
            this.lblOverlayDatabaseInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOverlayProgress
            // 
            this.lblOverlayProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOverlayProgress.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOverlayProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblOverlayProgress.Location = new System.Drawing.Point(30, 105);
            this.lblOverlayProgress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
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
            this.progressBarOverlay.BackColor = System.Drawing.Color.White;
            this.progressBarOverlay.Location = new System.Drawing.Point(30, 160);
            this.progressBarOverlay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.progressBarOverlay.Name = "progressBarOverlay";
            this.progressBarOverlay.Progress = 0;
            this.progressBarOverlay.ProgressText = "";
            this.progressBarOverlay.Size = new System.Drawing.Size(640, 45);
            this.progressBarOverlay.TabIndex = 0;
            // 
            // lblFileList
            // 
            this.lblFileList.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblFileList.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.714286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFileList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblFileList.Location = new System.Drawing.Point(15, 10);
            this.lblFileList.Name = "lblFileList";
            this.lblFileList.Size = new System.Drawing.Size(150, 20);
            this.lblFileList.TabIndex = 0;
            this.lblFileList.Text = "📋 文件列表";
            this.lblFileList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFileList.Click += new System.EventHandler(this.lblFileList_Click);
            // 
            // lblFileCount
            // 
            this.lblFileCount.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblFileCount.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFileCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblFileCount.Location = new System.Drawing.Point(203, 10);
            this.lblFileCount.Name = "lblFileCount";
            this.lblFileCount.Size = new System.Drawing.Size(85, 20);
            this.lblFileCount.TabIndex = 1;
            this.lblFileCount.Text = "0 个文件";
            this.lblFileCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelFileListHeader
            // 
            this.panelFileListHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.panelFileListHeader.Controls.Add(this.lblFileCount);
            this.panelFileListHeader.Controls.Add(this.lblFileList);
            this.panelFileListHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFileListHeader.Location = new System.Drawing.Point(1, 1);
            this.panelFileListHeader.Name = "panelFileListHeader";
            this.panelFileListHeader.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.panelFileListHeader.Size = new System.Drawing.Size(303, 40);
            this.panelFileListHeader.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1400, 805);
            this.Controls.Add(this.panelOverlay);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1278, 715);
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
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panelExecutionLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExecutionLog)).EndInit();
            this.panelExecutionHeader.ResumeLayout(false);
            this.panelExecutionHeader.PerformLayout();
            this.panelOverlay.ResumeLayout(false);
            this.panelOverlayContent.ResumeLayout(false);
            this.panelFileListHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button btnSqlOptions;
        private System.Windows.Forms.Button btnDbConfig;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.CheckBox chkMultiThread;
        private System.Windows.Forms.Label lblDbInfo;
        private System.Windows.Forms.Label lblFolderPath;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelFileList;
        private System.Windows.Forms.DataGridView dgvFiles;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panelFileContent;
        private FastHorse.LineNumberRichTextBox txtFileContent;
        private System.Windows.Forms.Panel panelExecutionLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExecuteTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colErrorMessage;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.Button btnShowAll;
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
        private System.Windows.Forms.DataGridViewButtonColumn colViewDetails;
        private System.Windows.Forms.CheckBox chkShowFailed;
        private System.Windows.Forms.CheckBox chkShowSuccess;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileListName;
        private System.Windows.Forms.Label lblExecutionStats;
        private FastHorse.TransparentPanel panelOverlay;
        private FastHorse.RoundedPanel panelOverlayContent;
        private System.Windows.Forms.Label lblOverlayMessage;
        private System.Windows.Forms.Label lblOverlayDatabaseInfo;
        private System.Windows.Forms.Label lblOverlayProgress;
        private FastHorse.HorseProgressBar progressBarOverlay;
        private System.Windows.Forms.Panel panelFileListHeader;
        private System.Windows.Forms.Label lblFileCount;
        private System.Windows.Forms.Label lblFileList;
    }
}
