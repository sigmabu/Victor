using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Victor
{
    public partial class RoundConerButton : Button
    {
        // Fields.
        private int borderSize = 0;
        private int borderRadius = 0;
        private Color borderColor = Color.PaleVioletRed;
        private string shiftString = string.Empty;
        private Color shiftStringColor = Color.Aqua;

        // Properties.
        [Category("Rounded Corner Button")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        [Category("Rounded Corner Button")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                borderRadius = value;
                this.Invalidate();
            }
        }

        [Category("Rounded Corner Button")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        [Category("Rounded Corner Button")]
        public Color BackgroundColor
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }

        [Category("Rounded Corner Button")]
        public Color TextColor
        {
            get { return this.ForeColor; }
            set { this.ForeColor = value; }
        }

        [Category("Rounded Corner Button")]
        public string ShiftString
        {
            get { return this.shiftString; }
            set { this.shiftString = value; }
        }

        [Category("Rounded Corner Button")]
        public Color ShiftStringColor
        {
            get { return this.shiftStringColor; }
            set { this.shiftStringColor = value; }
        }

        // Constructor.
        public RoundConerButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150, 40);
            this.BackColor = Color.MediumSlateBlue;
            this.ForeColor = Color.White;
            this.Resize += new EventHandler(button_Resize);
        }

        // Methods.
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
            int smoothSize = 2;
            if (borderSize > 0)
                smoothSize = borderSize;

            // Rounded button.
            if (borderRadius > 2)
            {
                using (GraphicsPath pathSurface = getFigurePath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = getFigurePath(rectBorder, borderRadius - borderSize))
                using (Pen penSurface = new Pen(this.Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    // Button surface.
                    this.Region = new Region(pathSurface);
                    // Draw surface border for HD result.
                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    // Button border.
                    if (borderSize >= 1)
                    {
                        //Draw control border.
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                    }
                }
            }
            // Normal button.
            else
            {
                pevent.Graphics.SmoothingMode = SmoothingMode.None;
                // Button surface.
                this.Region = new Region(rectSurface);
                // Button border.
                if (borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }

            // Shift 용 문자 표시.
            using (Pen penText = new Pen(Color.White, 2))
            {
                pevent.Graphics.DrawString(shiftString, new Font("Arial", 11), new SolidBrush(shiftStringColor), 5, 5);
            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(container_BackColorChanged);
        }

        private GraphicsPath getFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void container_BackColorChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void button_Resize(object sender, EventArgs e)
        {
            if (borderRadius > this.Height)
            {
                borderRadius = this.Height;
            }
        }
    }
}