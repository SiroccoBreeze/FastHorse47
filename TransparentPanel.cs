using System.Drawing;
using System.Windows.Forms;

namespace FastHorse
{
    public class TransparentPanel : Panel
    {
        private int alpha = 200;

        public int Alpha
        {
            get { return alpha; }
            set
            {
                alpha = value;
                this.Invalidate();
            }
        }

        public TransparentPanel()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, false);
            SetStyle(ControlStyles.Opaque, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (Brush brush = new SolidBrush(Color.FromArgb(alpha, 0, 0, 0)))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
            base.OnPaint(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // 不绘制背景，让父控件显示
        }
    }
}

