using System;
using System.Windows.Forms;

namespace FastHorse
{
    public partial class SqlOptionsForm : Form
    {
        private CheckBox chkAnsiNulls;
        private CheckBox chkQuotedIdentifier;
        private Button btnOK;
        private Button btnCancel;
        private Label lblTitle;
        private Label lblDescription;

        public bool SetAnsiNulls { get; private set; }
        public bool SetQuotedIdentifier { get; private set; }

        public SqlOptionsForm(bool setAnsiNulls = false, bool setQuotedIdentifier = false)
        {
            SetAnsiNulls = setAnsiNulls;
            SetQuotedIdentifier = setQuotedIdentifier;
            InitializeComponent();
            LoadOptions();
        }

        private void InitializeComponent()
        {
            this.chkAnsiNulls = new System.Windows.Forms.CheckBox();
            this.chkQuotedIdentifier = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkAnsiNulls
            // 
            this.chkAnsiNulls.AutoSize = true;
            this.chkAnsiNulls.Checked = true;
            this.chkAnsiNulls.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAnsiNulls.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkAnsiNulls.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.chkAnsiNulls.Location = new System.Drawing.Point(40, 100);
            this.chkAnsiNulls.Name = "chkAnsiNulls";
            this.chkAnsiNulls.Size = new System.Drawing.Size(206, 32);
            this.chkAnsiNulls.TabIndex = 2;
            this.chkAnsiNulls.Text = "SET ANSI_NULLS";
            this.chkAnsiNulls.UseVisualStyleBackColor = true;
            // 
            // chkQuotedIdentifier
            // 
            this.chkQuotedIdentifier.AutoSize = true;
            this.chkQuotedIdentifier.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkQuotedIdentifier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.chkQuotedIdentifier.Location = new System.Drawing.Point(40, 140);
            this.chkQuotedIdentifier.Name = "chkQuotedIdentifier";
            this.chkQuotedIdentifier.Size = new System.Drawing.Size(291, 32);
            this.chkQuotedIdentifier.TabIndex = 3;
            this.chkQuotedIdentifier.Text = "SET QUOTED_IDENTIFIER";
            this.chkQuotedIdentifier.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(211)))), ((int)(((byte)(153)))));
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(200, 200);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 40);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnCancel.Location = new System.Drawing.Point(320, 200);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(164, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "SQL 执行选项";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDescription.Location = new System.Drawing.Point(20, 55);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(403, 28);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "选择要在执行SQL脚本前添加的SET选项：";
            // 
            // SqlOptionsForm
            // 
            this.AcceptButton = this.btnOK;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(450, 270);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkQuotedIdentifier);
            this.Controls.Add(this.chkAnsiNulls);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SqlOptionsForm";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "⚙️ SQL 执行选项";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void LoadOptions()
        {
            chkAnsiNulls.Checked = SetAnsiNulls;
            chkQuotedIdentifier.Checked = SetQuotedIdentifier;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SetAnsiNulls = chkAnsiNulls.Checked;
            SetQuotedIdentifier = chkQuotedIdentifier.Checked;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

