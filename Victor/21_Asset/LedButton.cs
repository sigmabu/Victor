using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace VMS23
{
    public class LedToggleButton : Button
    {
        private readonly Label ledLamp = new Label();
        private bool isOn = false;
        private Color onColor = Color.OrangeRed;
        private Color offColor = Color.DarkGray;

        public LedToggleButton()
        {
            base.AutoSize = false;
            this.Width = 160;
            this.Height = 60;
            // Text 를 약간 아래쪽에 표시.
            this.Padding = new Padding(0, 10, 0, 0);
            this.Font = new Font("Arial Narrow", 9, FontStyle.Bold);
            this.TextAlign = ContentAlignment.MiddleCenter;

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
    }
}
