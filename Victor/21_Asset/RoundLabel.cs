using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MyUserControl
{
    public class RoundLabel : Label
    {
        [Browsable(true)]
        [Category("Custom")]
        [Description("Corner Radius")]
        public int CornerRadius { get; set; } = 10;

        [Browsable(true)]
        [Category("Custom")]
        [Description("Border Width")]
        public int BorderWidth { get; set; } = 1;

        [Browsable(true)]
        [Category("Custom")]
        [Description("Border Color")]
        public Color BorderColor { get; set; } = Color.DarkGray;

        [Browsable(true)]
        [Category("Custom")]
        [Description("Label BackColor")]
        public Color BackSideColor { get; set; } = Color.LightGray;

        [Browsable(true)]
        [Category("Custom")]
        [Description("Round Left-Top Corner")]
        public bool EnableRoundAtLeftTop { get; set; } = false;

        [Browsable(true)]
        [Category("Custom")]
        [Description("Round Right-Top Corner")]
        public bool EnableRoundAtRightTop { get; set; } = false;

        [Browsable(true)]
        [Category("Custom")]
        [Description("Round Left-BTM Corner")]
        public bool EnableRoundAtLeftBtm { get; set; } = false;

        [Browsable(true)]
        [Category("Custom")]
        [Description("Round Right-BTM Corner")]
        public bool EnableRoundAtRightBtm { get; set; } = false;

        public RoundLabel()
        {
            this.DoubleBuffered = true;
            this.TextAlign = ContentAlignment.MiddleCenter;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var graphicsPath = getRoundRectangle(this.ClientRectangle))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                var brush = new SolidBrush(BackSideColor);
                var pen = new Pen(BorderColor, BorderWidth);
                e.Graphics.FillPath(brush, graphicsPath);
                e.Graphics.DrawPath(pen, graphicsPath);

                TextRenderer.DrawText(e.Graphics, Text, this.Font, this.ClientRectangle, this.ForeColor);
            }
        }

        private GraphicsPath getRoundRectangle(Rectangle rectangle)
        {
            GraphicsPath path = new GraphicsPath();

            //path.AddArc(rectangle.X, rectangle.Y, cornerRadius, cornerRadius, 180, 90);

            int left = rectangle.X;
            int top = rectangle.Y;
            int right = rectangle.X + rectangle.Width - BorderWidth;
            int bottom = rectangle.Y + rectangle.Height - BorderWidth;

            // 좌측 상단.
            if (EnableRoundAtLeftTop)
            {
                path.AddArc(rectangle.X, rectangle.Y, CornerRadius, CornerRadius, 180, 90);
            }
            else
            {
                path.AddLine(left, top + CornerRadius, left, top);
                path.AddLine(left, top, left + CornerRadius, top);
            }
            // 우측 상단.
            if (EnableRoundAtRightTop)
            {
                path.AddArc(rectangle.X + rectangle.Width - CornerRadius - BorderWidth, rectangle.Y, CornerRadius, CornerRadius, 270, 90);
            }
            else
            {
                path.AddLine(right - CornerRadius, top, right, top);
                path.AddLine(right, top, right, top + CornerRadius);
            }
            // 우측 하단.
            if (EnableRoundAtRightBtm)
            {
                path.AddArc(rectangle.X + rectangle.Width - CornerRadius - BorderWidth, rectangle.Y + rectangle.Height - CornerRadius - BorderWidth, CornerRadius, CornerRadius, 0, 90);
            }
            else
            {
                path.AddLine(right, bottom - CornerRadius, right, bottom);
                path.AddLine(right, bottom, right - CornerRadius, bottom);
            }
            // 좌측 하단.
            if (EnableRoundAtLeftBtm)
            {
                path.AddArc(rectangle.X, rectangle.Y + rectangle.Height - CornerRadius - BorderWidth, CornerRadius, CornerRadius, 90, 90);
            }
            else
            {
                path.AddLine(left + CornerRadius, bottom, left, bottom);
                path.AddLine(left, bottom, left, bottom - CornerRadius);
            }

            path.CloseAllFigures();
            return path;
        }
    }
}
