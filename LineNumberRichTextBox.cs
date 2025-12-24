using System;
using System.Drawing;
using System.Windows.Forms;

namespace FastHorse
{
    /// <summary>
    /// 带行号的 RichTextBox 控件
    /// </summary>
    public class LineNumberRichTextBox : Panel
    {
        private RichTextBox textBox;
        private Panel lineNumberPanel;

        public RichTextBox TextBox => textBox;

        public LineNumberRichTextBox()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // 设置面板属性
            this.BorderStyle = BorderStyle.None;
            this.BackColor = Color.White;

            // 创建行号面板
            lineNumberPanel = new Panel
            {
                Dock = DockStyle.Left,
                Width = 50,
                BackColor = Color.FromArgb(241, 245, 249),
                BorderStyle = BorderStyle.None
            };
            lineNumberPanel.Paint += LineNumberPanel_Paint;

            // 创建文本框
            textBox = new RichTextBox
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.None,
                Font = new Font("Consolas", 9.75F),
                ReadOnly = true,
                WordWrap = false,
                BackColor = Color.White,
                ScrollBars = RichTextBoxScrollBars.Both
            };

            // 绑定事件
            textBox.VScroll += TextBox_VScroll;
            textBox.TextChanged += TextBox_TextChanged;
            textBox.Resize += TextBox_Resize;
            textBox.FontChanged += TextBox_FontChanged;

            // 添加控件
            this.Controls.Add(textBox);
            this.Controls.Add(lineNumberPanel);
        }

        private void TextBox_VScroll(object sender, EventArgs e)
        {
            lineNumberPanel.Invalidate();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            lineNumberPanel.Invalidate();
        }

        private void TextBox_Resize(object sender, EventArgs e)
        {
            lineNumberPanel.Invalidate();
        }

        private void TextBox_FontChanged(object sender, EventArgs e)
        {
            lineNumberPanel.Invalidate();
        }

        private void LineNumberPanel_Paint(object sender, PaintEventArgs e)
        {
            if (textBox.Text.Length == 0)
                return;

            // 获取第一个可见字符的索引
            int firstCharIndex = textBox.GetCharIndexFromPosition(new Point(1, 1));
            int firstLineIndex = textBox.GetLineFromCharIndex(firstCharIndex);

            // 获取第一行的位置
            Point firstLinePos = textBox.GetPositionFromCharIndex(textBox.GetFirstCharIndexFromLine(firstLineIndex));

            // 设置字体和颜色
            using (Font font = new Font(textBox.Font.FontFamily, textBox.Font.Size))
            using (Brush brush = new SolidBrush(Color.FromArgb(100, 116, 139)))
            {
                int lineHeight = TextRenderer.MeasureText("0", font).Height;
                int currentY = firstLinePos.Y;
                int lineNumber = firstLineIndex + 1;

                // 绘制可见的行号
                while (currentY < textBox.Height && lineNumber <= textBox.Lines.Length)
                {
                    string lineNumberText = lineNumber.ToString();
                    
                    // 右对齐行号
                    SizeF textSize = e.Graphics.MeasureString(lineNumberText, font);
                    float x = lineNumberPanel.Width - textSize.Width - 10;
                    float y = currentY;

                    e.Graphics.DrawString(lineNumberText, font, brush, x, y);

                    currentY += lineHeight;
                    lineNumber++;
                }
            }

            // 绘制右侧分隔线
            using (Pen pen = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                e.Graphics.DrawLine(pen, lineNumberPanel.Width - 1, 0, lineNumberPanel.Width - 1, lineNumberPanel.Height);
            }
        }

        // 公开常用属性
        public new string Text
        {
            get => textBox.Text;
            set => textBox.Text = value;
        }

        public Font TextFont
        {
            get => textBox.Font;
            set => textBox.Font = value;
        }

        public Color TextBackColor
        {
            get => textBox.BackColor;
            set => textBox.BackColor = value;
        }

        public Color TextForeColor
        {
            get => textBox.ForeColor;
            set => textBox.ForeColor = value;
        }

        public bool ReadOnlyText
        {
            get => textBox.ReadOnly;
            set => textBox.ReadOnly = value;
        }

        public void ApplySyntaxHighlight(string sqlText)
        {
            SqlSyntaxHighlighter.ApplySyntaxHighlight(textBox, sqlText);
            lineNumberPanel.Invalidate();
        }

        public void ApplyFastSyntaxHighlight(string sqlText)
        {
            SqlSyntaxHighlighter.ApplyFastSyntaxHighlight(textBox, sqlText);
            lineNumberPanel.Invalidate();
        }
    }
}

