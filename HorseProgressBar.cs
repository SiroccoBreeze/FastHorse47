using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FastHorse
{
    /// <summary>
    /// 带奔跑马动画的进度条控件
    /// </summary>
    public class HorseProgressBar : Control
    {
        private Timer animationTimer;
        private int animationFrame = 0;
        private int horsePosition = 0;
        private int progress = 0;
        private string progressText = "";

        // 马的动画帧（使用简化的图形表示）
        private readonly string[] horseFrames = new string[]
        {
            "🐴",  // 帧1
            "🐎",  // 帧2
        };

        public HorseProgressBar()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            
            // 初始化动画定时器
            animationTimer = new Timer();
            animationTimer.Interval = 150; // 150ms 切换一次动画帧
            animationTimer.Tick += AnimationTimer_Tick;
        }

        /// <summary>
        /// 进度值 (0-100)
        /// </summary>
        public int Progress
        {
            get => progress;
            set
            {
                progress = Math.Max(0, Math.Min(100, value));
                this.Invalidate();
            }
        }

        /// <summary>
        /// 进度文本
        /// </summary>
        public string ProgressText
        {
            get => progressText;
            set
            {
                progressText = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// 开始动画
        /// </summary>
        public void StartAnimation()
        {
            animationTimer.Start();
        }

        /// <summary>
        /// 停止动画
        /// </summary>
        public void StopAnimation()
        {
            animationTimer.Stop();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            // 切换动画帧
            animationFrame = (animationFrame + 1) % horseFrames.Length;
            
            // 移动马的位置
            horsePosition += 3;
            if (horsePosition > this.Width + 50)
            {
                horsePosition = -50;
            }
            
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // 清除背景（使用控件的背景色）
            using (SolidBrush clearBrush = new SolidBrush(this.BackColor))
            {
                g.FillRectangle(clearBrush, 0, 0, this.Width, this.Height);
            }

            // 绘制进度条背景
            using (SolidBrush bgBrush = new SolidBrush(Color.FromArgb(226, 232, 240)))
            {
                g.FillRoundedRectangle(bgBrush, 0, 0, this.Width, this.Height, 8);
            }

            // 绘制进度条
            if (progress > 0)
            {
                int progressWidth = (int)(this.Width * (progress / 100.0));
                using (LinearGradientBrush progressBrush = new LinearGradientBrush(
                    new Rectangle(0, 0, progressWidth, this.Height),
                    Color.FromArgb(59, 130, 246),
                    Color.FromArgb(37, 99, 235),
                    LinearGradientMode.Horizontal))
                {
                    g.FillRoundedRectangle(progressBrush, 0, 0, progressWidth, this.Height, 8);
                }
            }

            // 绘制奔跑的马
            string currentHorse = horseFrames[animationFrame];
            using (Font horseFont = new Font("Segoe UI Emoji", 20, FontStyle.Regular))
            using (SolidBrush horseBrush = new SolidBrush(Color.FromArgb(220, 38, 38)))
            {
                // 计算马的位置（让马在进度条上方稍微浮动）
                float horseX = horsePosition;
                float horseY = (this.Height - 30) / 2;
                
                // 添加阴影效果
                using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(50, 0, 0, 0)))
                {
                    g.DrawString(currentHorse, horseFont, shadowBrush, horseX + 2, horseY + 2);
                }
                
                g.DrawString(currentHorse, horseFont, horseBrush, horseX, horseY);
            }

            // 绘制进度文本
            if (!string.IsNullOrEmpty(progressText))
            {
                using (Font textFont = new Font("Microsoft YaHei UI", 9, FontStyle.Regular))
                using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(51, 65, 85)))
                {
                    SizeF textSize = g.MeasureString(progressText, textFont);
                    float textX = (this.Width - textSize.Width) / 2;
                    float textY = (this.Height - textSize.Height) / 2;
                    
                    // 文本阴影
                    using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(100, 255, 255, 255)))
                    {
                        g.DrawString(progressText, textFont, shadowBrush, textX + 1, textY + 1);
                    }
                    
                    g.DrawString(progressText, textFont, textBrush, textX, textY);
                }
            }

            // 绘制边框
            using (Pen borderPen = new Pen(Color.FromArgb(203, 213, 225), 1))
            {
                g.DrawRoundedRectangle(borderPen, 0, 0, this.Width - 1, this.Height - 1, 8);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                animationTimer?.Stop();
                animationTimer?.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    /// <summary>
    /// Graphics 扩展方法，用于绘制圆角矩形
    /// </summary>
    public static class GraphicsExtensions
    {
        public static void FillRoundedRectangle(this Graphics g, Brush brush, float x, float y, float width, float height, float radius)
        {
            using (GraphicsPath path = GetRoundedRectPath(x, y, width, height, radius))
            {
                g.FillPath(brush, path);
            }
        }

        public static void DrawRoundedRectangle(this Graphics g, Pen pen, float x, float y, float width, float height, float radius)
        {
            using (GraphicsPath path = GetRoundedRectPath(x, y, width, height, radius))
            {
                g.DrawPath(pen, path);
            }
        }

        private static GraphicsPath GetRoundedRectPath(float x, float y, float width, float height, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float diameter = radius * 2;
            
            path.AddArc(x, y, diameter, diameter, 180, 90);
            path.AddArc(x + width - diameter, y, diameter, diameter, 270, 90);
            path.AddArc(x + width - diameter, y + height - diameter, diameter, diameter, 0, 90);
            path.AddArc(x, y + height - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            
            return path;
        }
    }
}

