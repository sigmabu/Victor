using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MyUserControl
{
    public class CircularButton : Button
    {
        #region Public Custom Properties
        [Description("Circle Border Size"), Category("Circle")]
        public long BorderWidth { get; set; }

        [Description("Circle Border Color"), Category("Circle")]
        public Color BorderColor { get; set; }

        [Description("Mouse over Background Color"), Category("Circle")]
        public Color MouseOverColor { get; set; }


        [Description("Background Hatch Style Enable/Disable"), Category("Circle")]
        public bool HatchEnable { get; set; }

        [Description("Background Hatch Style"), Category("Circle")]
        public HatchStyle Style
        {
            get { return this.style; }
            set
            {
                this.style = value;
                this.Invalidate();
            }
        }
        private HatchStyle style;

        [Description("Circle Edge Line margin"), Category("Circle")]
        public long EdgeMargin { get; set; }
        #endregion

        #region Contructor

        private bool mouseFlag = false;

        public CircularButton()
        {
            this.Font = new Font("Segoe UI", 15, FontStyle.Bold);
            this.BorderColor = Color.DarkGreen;
            this.BorderWidth = 2;
            this.BackColor = Color.Transparent;//Color.LimeGreen;
            this.MouseOverColor = Color.Transparent; //Color.Lime;
            this.MinimumSize = new Size(50, 50);
            this.EdgeMargin = 4;
            this.DoubleBuffered = true;
        }
        ~CircularButton()
        {
            Dispose(false);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        #endregion

        #region Methods
        private void DrawCircle(PaintEventArgs e, bool flag)
        {
            ButtonRenderer.DrawParentBackground(e.Graphics, this.ClientRectangle, this);

            if (null != this.Image)
            {
                e.Graphics.DrawImage(this.Image, (this.Width - this.Image.Width) / 2, (this.Height - this.Image.Height) / 2);
                return;
            }

            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Brush brush;
            if (true == HatchEnable)
                brush = new HatchBrush(this.style, flag ? this.BackColor : this.MouseOverColor);
            else
                brush = new SolidBrush(flag ? this.BackColor : this.MouseOverColor);


            e.Graphics.FillEllipse(brush, EdgeMargin, EdgeMargin, (this.Width - EdgeMargin * 2), (this.Height - EdgeMargin * 2));


            using (Pen pen = new Pen(this.BorderColor, this.BorderWidth))
            {
                e.Graphics.DrawArc(pen, EdgeMargin, EdgeMargin, (this.Width - EdgeMargin * 2), (this.Height - EdgeMargin * 2), 0, 360);
            }

            using (Brush FontColor = new SolidBrush(this.ForeColor))
            {
                SizeF MS = e.Graphics.MeasureString(this.Text, this.Font);
                SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(100, this.ForeColor));
                //
                e.Graphics.DrawString(this.Text,
                    this.Font,
                    FontColor,
                    Convert.ToInt32(Width / 2 - MS.Width / 2),
                    Convert.ToInt32(Height / 2 - MS.Height / 2));
            }

            brush.Dispose();
        }
        #endregion

        #region Events
        protected override void OnMouseEnter(EventArgs e)
        {
            mouseFlag = true;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            mouseFlag = false;
            base.OnMouseLeave(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawCircle(e, mouseFlag);
        }
        #endregion
    }
}
