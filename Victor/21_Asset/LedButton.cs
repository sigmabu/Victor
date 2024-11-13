using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MyUserControl
{
    public partial class LedToggleButton : Button
    {
        private readonly Label ledLamp = new Label();
        private bool isOn = false;
        private Color onColor = Color.OrangeRed;
        private Color offColor = Color.DarkGray;

        private int borderSize = 0;
        private int borderRadius = 0;
        private Color borderColor = Color.PaleVioletRed;

        public LedToggleButton()
        {
            base.AutoSize = false;
            this.Width = 160;
            this.Height = 60;
            // Text 를 약간 아래쪽에 표시.
            this.Padding = new Padding(0, 10, 0, 0);
            this.Font = new Font("Arial Narrow", 9, FontStyle.Bold);
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.FlatAppearance.BorderSize = 0;

            ledLamp.Width = this.Width - 16;
            ledLamp.Height = 5;
            ledLamp.Location = new Point(8, 6);
            ledLamp.BackColor = offColor;

            // Click Event.
            //label.Click += (sender, args) => InvokeOnClick(this, args);
            this.Controls.Add(ledLamp);
        }

        ~LedToggleButton()
        {
            Dispose(true);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //this.timer.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            ledLamp.Width = this.Width - 16;
        }

        protected override void OnClick(EventArgs e)
        {
            this.Enabled = false;
            base.OnClick(e);
            this.Enabled = true;
        }

        #region => Property.
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

        [Description("Set LED Status"), Category("LED")]
        public bool SetLED
        {
            get
            {
                return isOn;
            }
            set
            {
                isOn = value;
                ledLamp.BackColor = isOn ? onColor : offColor;
                this.Invalidate();
            }
        }
        [Description("LED Tickness"), Category("LED")]
        public int Tickness
        {
            get
            {
                return ledLamp.Height;
            }
            set
            {
                ledLamp.Height = value;
                this.Invalidate();
            }
        }
        [Description("Color when LED is on."), Category("LED")]
        public Color OnColor
        {
            get
            {
                return onColor;
            }
            set
            {
                onColor = value;
                this.Invalidate();
            }
        }
        [Description("Color when LED is off."), Category("LED")]
        public Color OffColor
        {
            get
            {
                return offColor;
            }
            set
            {
                offColor = value;
                this.Invalidate();
            }
        }
        #endregion

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
            int smoothSize = 2;

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

    }
}
