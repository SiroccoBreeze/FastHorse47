using System;
using System.Drawing;
using System.Windows.Forms;

namespace FastHorse
{
    public partial class AuthorizationForm : Form
    {
        private TextBox txtAuthCode;
        private Button btnConfirm;
        private Label lblTitle;
        private Label lblContact;
        private Label lblPrompt;
        private Panel mainPanel;

        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "FastHorse - 授权验证";
            this.Width = 450;
            this.Height = 320;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ShowIcon = false;
            this.BackColor = Color.FromArgb(248, 250, 252);
            this.Font = new Font("Microsoft YaHei UI", 9F);

            // 主面板
            mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(40, 30, 40, 30)
            };

            // 标题
            lblTitle = new Label
            {
                Text = "⚡ FastHorse",
                Font = new Font("Microsoft YaHei UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(99, 102, 241),
                AutoSize = true,
                Location = new Point(40, 30)
            };

            // 联系信息
            lblContact = new Label
            {
                Text = "📞 6835 @call me",
                Font = new Font("Microsoft YaHei UI", 11F),
                ForeColor = Color.FromArgb(220, 38, 38),
                AutoSize = true,
                Location = new Point(40, 75)
            };

            // 提示信息
            lblPrompt = new Label
            {
                Text = "请输入授权码:",
                Font = new Font("Microsoft YaHei UI", 10F),
                ForeColor = Color.FromArgb(71, 85, 105),
                AutoSize = true,
                Location = new Point(40, 120)
            };

            // 授权码输入框
            txtAuthCode = new TextBox
            {
                Font = new Font("Consolas", 14F),
                Location = new Point(40, 150),
                Width = 350,
                Height = 35,
                MaxLength = 6,
                TextAlign = HorizontalAlignment.Center
            };
            txtAuthCode.KeyPress += TxtAuthCode_KeyPress;
            txtAuthCode.KeyDown += TxtAuthCode_KeyDown;

            // 确认按钮
            btnConfirm = new Button
            {
                Text = "确认",
                Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold),
                BackColor = Color.FromArgb(99, 102, 241),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 350,
                Height = 45,
                Location = new Point(40, 200),
                Cursor = Cursors.Hand
            };
            btnConfirm.FlatAppearance.BorderSize = 0;
            btnConfirm.Click += BtnConfirm_Click;
            btnConfirm.MouseEnter += (s, e) => btnConfirm.BackColor = Color.FromArgb(79, 70, 229);
            btnConfirm.MouseLeave += (s, e) => btnConfirm.BackColor = Color.FromArgb(99, 102, 241);

            // 添加控件
            mainPanel.Controls.Add(lblTitle);
            mainPanel.Controls.Add(lblContact);
            mainPanel.Controls.Add(lblPrompt);
            mainPanel.Controls.Add(txtAuthCode);
            mainPanel.Controls.Add(btnConfirm);

            this.Controls.Add(mainPanel);

            // 窗体加载时聚焦到输入框
            this.Load += (s, e) => txtAuthCode.Focus();
        }

        private void TxtAuthCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 只允许输入数字
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtAuthCode_KeyDown(object sender, KeyEventArgs e)
        {
            // 按回车键确认
            if (e.KeyCode == Keys.Enter)
            {
                BtnConfirm_Click(sender, e);
            }
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            string inputCode = txtAuthCode.Text.Trim();

            if (string.IsNullOrEmpty(inputCode))
            {
                MessageBox.Show("请输入授权码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAuthCode.Focus();
                return;
            }

            if (inputCode.Length != 6)
            {
                MessageBox.Show("授权码必须是6位数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAuthCode.Focus();
                return;
            }

            // 生成今日授权码
            string todayCode = GenerateTodayCode();

            if (inputCode == todayCode)
            {
                // 验证成功
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // 验证失败
                MessageBox.Show("授权码错误，请重试或联系 6835", "验证失败", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAuthCode.Text = "";
                txtAuthCode.Focus();
            }
        }

        /// <summary>
        /// 生成今日授权码
        /// 算法来源: Python版本的加密逻辑
        /// </summary>
        private string GenerateTodayCode()
        {
            // 获取当前日期
            DateTime today = DateTime.Now.Date;

            // 使用日期生成种子
            int seed = today.Year * 10001 + today.Month * 100 + today.Day;
            seed = (seed * 31) % 1000000; // 确保是6位数

            // 使用固定密钥进行混淆
            int secretKey = 6835;
            seed = (seed ^ secretKey) % 1000000;

            // 确保生成6位数字
            return seed.ToString("D6");
        }
    }
}

