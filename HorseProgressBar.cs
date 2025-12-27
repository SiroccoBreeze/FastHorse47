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
        private int progress = 0;
        private string progressText = "";

        // 马的动画帧 - 使用朝右的图标组合
        // 使用 Unicode 右向左标记 (U+202B) 来翻转 emoji 方向
        private readonly string[] horseFrames = new string[]
        {
            "\u202B🐴\u202C",  // 帧1 - 朝右的马
            "\u202B🐎\u202C",  // 帧2 - 朝右的奔马
            "\u202B🏇\u202C",  // 帧3 - 朝右的骑马
            "\u202B🐎\u202C",  // 帧4 - 朝右的奔马
            "\u202B🐴\u202C",  // 帧5 - 朝右的马
            "\u202B🏇\u202C",  // 帧6 - 朝右的骑马
        };

        public HorseProgressBar()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);

            // 初始化动画定时器
            animationTimer = new Timer();
            animationTimer.Interval = 80; // 80ms 切换一次动画帧，更流畅
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

            // 重绘控件
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

            // 绘制进度条背景 - 使用渐变效果
            using (LinearGradientBrush bgBrush = new LinearGradientBrush(
                new Rectangle(0, 0, this.Width, this.Height),
                Color.FromArgb(241, 245, 249),
                Color.FromArgb(226, 232, 240),
                LinearGradientMode.Vertical))
            {
                g.FillRoundedRectangle(bgBrush, 0, 0, this.Width, this.Height, 10);
            }

            // 绘制进度条 - 使用更鲜艳的渐变色
            if (progress > 0)
            {
                int progressWidth = (int)(this.Width * (progress / 100.0));

                // 主渐变色
                using (LinearGradientBrush progressBrush = new LinearGradientBrush(
                    new Rectangle(0, 0, progressWidth, this.Height),
                    Color.FromArgb(16, 185, 129),  // 绿色
                    Color.FromArgb(5, 150, 105),   // 深绿色
                    LinearGradientMode.Horizontal))
                {
                    g.FillRoundedRectangle(progressBrush, 0, 0, progressWidth, this.Height, 10);
                }

                // 添加高光效果
                using (LinearGradientBrush highlightBrush = new LinearGradientBrush(
                    new Rectangle(0, 0, progressWidth, this.Height / 2),
                    Color.FromArgb(80, 255, 255, 255),
                    Color.FromArgb(0, 255, 255, 255),
                    LinearGradientMode.Vertical))
                {
                    GraphicsPath highlightPath = new GraphicsPath();
                    highlightPath.AddArc(0, 0, 20, 20, 180, 90);
                    highlightPath.AddArc(progressWidth - 20, 0, 20, 20, 270, 90);
                    highlightPath.AddLine(progressWidth, 10, progressWidth, this.Height / 2);
                    highlightPath.AddLine(progressWidth, this.Height / 2, 0, this.Height / 2);
                    highlightPath.CloseFigure();
                    g.FillPath(highlightBrush, highlightPath);
                }
            }

            // 绘制奔跑的马 - 马的位置跟随进度条
            if (progress > 0)
            {
                string currentHorse = horseFrames[animationFrame];
                using (Font horseFont = new Font("Segoe UI Emoji", 28, FontStyle.Regular))
                {
                    // 计算马的位置 - 跟随进度条的实际进度
                    int progressWidth = (int)(this.Width * (progress / 100.0));
                    float horseX = Math.Max(8, progressWidth - 35); // 马在进度条末端
                    float horseY = (this.Height - 32) / 2 - 2; // 稍微向上偏移

                    // 绘制外发光效果（更大范围）
                    using (SolidBrush outerGlowBrush = new SolidBrush(Color.FromArgb(40, 255, 215, 0)))
                    {
                        for (int i = -3; i <= 3; i++)
                        {
                            for (int j = -3; j <= 3; j++)
                            {
                                if (i != 0 || j != 0)
                                {
                                    g.DrawString(currentHorse, horseFont, outerGlowBrush, horseX + i, horseY + j);
                                }
                            }
                        }
                    }

                    // 绘制内发光效果
                    using (SolidBrush innerGlowBrush = new SolidBrush(Color.FromArgb(120, 255, 215, 0)))
                    {
                        g.DrawString(currentHorse, horseFont, innerGlowBrush, horseX - 1, horseY - 1);
                        g.DrawString(currentHorse, horseFont, innerGlowBrush, horseX + 1, horseY - 1);
                        g.DrawString(currentHorse, horseFont, innerGlowBrush, horseX - 1, horseY + 1);
                        g.DrawString(currentHorse, horseFont, innerGlowBrush, horseX + 1, horseY + 1);
                    }

                    // 添加阴影效果
                    using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(80, 0, 0, 0)))
                    {
                        g.DrawString(currentHorse, horseFont, shadowBrush, horseX + 2, horseY + 3);
                    }

                    // 绘制马 - 使用金色
                    using (SolidBrush horseBrush = new SolidBrush(Color.FromArgb(255, 193, 7)))
                    {
                        g.DrawString(currentHorse, horseFont, horseBrush, horseX, horseY);
                    }
                }
            }

            // 绘制进度文本
            if (!string.IsNullOrEmpty(progressText))
            {
                using (Font textFont = new Font("Microsoft YaHei UI", 9.5F, FontStyle.Bold))
                {
                    SizeF textSize = g.MeasureString(progressText, textFont);
                    float textX = (this.Width - textSize.Width) / 2;
                    float textY = (this.Height - textSize.Height) / 2;

                    // 文本外描边
                    using (SolidBrush outlineBrush = new SolidBrush(Color.FromArgb(150, 0, 0, 0)))
                    {
                        g.DrawString(progressText, textFont, outlineBrush, textX - 1, textY);
                        g.DrawString(progressText, textFont, outlineBrush, textX + 1, textY);
                        g.DrawString(progressText, textFont, outlineBrush, textX, textY - 1);
                        g.DrawString(progressText, textFont, outlineBrush, textX, textY + 1);
                    }

                    // 文本主体 - 白色
                    using (SolidBrush textBrush = new SolidBrush(Color.White))
                    {
                        g.DrawString(progressText, textFont, textBrush, textX, textY);
                    }
                }
            }

            // 绘制边框 - 使用更精致的边框
            using (Pen borderPen = new Pen(Color.FromArgb(203, 213, 225), 2))
            {
                g.DrawRoundedRectangle(borderPen, 1, 1, this.Width - 2, this.Height - 2, 10);
            }

            // 绘制内阴影效果
            using (Pen innerShadowPen = new Pen(Color.FromArgb(30, 0, 0, 0), 1))
            {
                g.DrawRoundedRectangle(innerShadowPen, 2, 2, this.Width - 4, this.Height - 4, 9);
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

