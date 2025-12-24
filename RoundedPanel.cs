using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FastHorse
{
    public class RoundedPanel : Panel
    {
        private int cornerRadius = 12;
        private Color shadowColor = Color.FromArgb(100, 0, 0, 0);
        private int shadowOffset = 4;

        public int CornerRadius
        {
            get { return cornerRadius; }
            set
            {
                cornerRadius = value;
                this.Invalidate();
            }
        }

        public Color ShadowColor
        {
            get { return shadowColor; }
            set
            {
                shadowColor = value;
                this.Invalidate();
            }
        }

        public int ShadowOffset
        {
            get { return shadowOffset; }
            set
            {
                shadowOffset = value;
                this.Invalidate();
            }
        }

        public RoundedPanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | 
                     ControlStyles.UserPaint | 
                     ControlStyles.DoubleBuffer | 
                     ControlStyles.ResizeRedraw, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            Rectangle rect = this.ClientRectangle;
            rect.Width -= 1;
            rect.Height -= 1;

            // 绘制阴影
            if (shadowOffset > 0)
            {
                Rectangle shadowRect = rect;
                shadowRect.Offset(shadowOffset, shadowOffset);
                using (GraphicsPath shadowPath = CreateRoundedRectanglePath(shadowRect, cornerRadius))
                using (SolidBrush shadowBrush = new SolidBrush(shadowColor))
                {
                    g.FillPath(shadowBrush, shadowPath);
                }
            }

            // 绘制圆角矩形背景
            using (GraphicsPath path = CreateRoundedRectanglePath(rect, cornerRadius))
            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                g.FillPath(brush, path);
            }
        }

        private GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90); // 左上角
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90); // 右上角
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90); // 右下角
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90); // 左下角
            path.CloseFigure();

            return path;
        }
    }
}




