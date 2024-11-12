using System.Windows.Forms;

namespace Victor
{
    public partial class vwMain : UserControl
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label46 = new System.Windows.Forms.Label();
            this.pnl_Base = new System.Windows.Forms.Panel();
            this.tbText = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pnl_Menu = new System.Windows.Forms.Panel();
            this.roundConerButton1 = new Victor.RoundConerButton();
            this.ledToggleButton1 = new VMS23.LedToggleButton();
            this.orientedTextLabel1 = new VMS23.OrientedTextLabel();
            this.roundLabel1 = new MyUserControl.RoundLabel();
            this.roundBorderPanel1 = new MyUserControl.RoundBorderPanel();
            this.pnl_Base.SuspendLayout();
            this.SuspendLayout();
            // 
            // label46
            // 
            this.label46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label46.ForeColor = System.Drawing.SystemColors.Control;
            this.label46.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label46.Location = new System.Drawing.Point(-3, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(1280, 30);
            this.label46.TabIndex = 452;
            this.label46.Text = "MAIN";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl_Base
            // 
            this.pnl_Base.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.pnl_Base.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Base.Controls.Add(this.roundBorderPanel1);
            this.pnl_Base.Controls.Add(this.roundLabel1);
            this.pnl_Base.Controls.Add(this.orientedTextLabel1);
            this.pnl_Base.Controls.Add(this.ledToggleButton1);
            this.pnl_Base.Controls.Add(this.roundConerButton1);
            this.pnl_Base.Controls.Add(this.tbText);
            this.pnl_Base.Controls.Add(this.button2);
            this.pnl_Base.Controls.Add(this.button1);
            this.pnl_Base.Location = new System.Drawing.Point(3, 33);
            this.pnl_Base.Name = "pnl_Base";
            this.pnl_Base.Size = new System.Drawing.Size(1274, 768);
            this.pnl_Base.TabIndex = 453;
            // 
            // tbText
            // 
            this.tbText.Location = new System.Drawing.Point(371, 102);
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(788, 35);
            this.tbText.TabIndex = 3;
            this.tbText.Text = "InText";
            this.tbText.Click += new System.EventHandler(this.tbTest_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button2.Location = new System.Drawing.Point(122, 151);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(180, 50);
            this.button2.TabIndex = 2;
            this.button2.Tag = "2";
            this.button2.Text = "Auto # 2";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(122, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 50);
            this.button1.TabIndex = 1;
            this.button1.Tag = "1";
            this.button1.Text = "Auto #1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnl_Menu
            // 
            this.pnl_Menu.BackColor = System.Drawing.Color.Black;
            this.pnl_Menu.Location = new System.Drawing.Point(0, 0);
            this.pnl_Menu.Name = "pnl_Menu";
            this.pnl_Menu.Size = new System.Drawing.Size(1280, 804);
            this.pnl_Menu.TabIndex = 455;
            // 
            // roundConerButton1
            // 
            this.roundConerButton1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.roundConerButton1.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.roundConerButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.roundConerButton1.BorderRadius = 0;
            this.roundConerButton1.BorderSize = 0;
            this.roundConerButton1.FlatAppearance.BorderSize = 0;
            this.roundConerButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundConerButton1.ForeColor = System.Drawing.Color.White;
            this.roundConerButton1.Location = new System.Drawing.Point(960, 295);
            this.roundConerButton1.Name = "roundConerButton1";
            this.roundConerButton1.ShiftString = "";
            this.roundConerButton1.ShiftStringColor = System.Drawing.Color.Aqua;
            this.roundConerButton1.Size = new System.Drawing.Size(144, 40);
            this.roundConerButton1.TabIndex = 4;
            this.roundConerButton1.Text = "roundConerButton1";
            this.roundConerButton1.TextColor = System.Drawing.Color.White;
            this.roundConerButton1.UseVisualStyleBackColor = false;
            // 
            // ledToggleButton1
            // 
            this.ledToggleButton1.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold);
            this.ledToggleButton1.Location = new System.Drawing.Point(689, 289);
            this.ledToggleButton1.Name = "ledToggleButton1";
            this.ledToggleButton1.OffColor = System.Drawing.Color.DarkGray;
            this.ledToggleButton1.OnColor = System.Drawing.Color.OrangeRed;
            this.ledToggleButton1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.ledToggleButton1.SetLED = false;
            this.ledToggleButton1.Size = new System.Drawing.Size(241, 57);
            this.ledToggleButton1.TabIndex = 5;
            this.ledToggleButton1.Text = "ledToggleButton1";
            this.ledToggleButton1.Tickness = 5;
            this.ledToggleButton1.UseVisualStyleBackColor = true;
            // 
            // orientedTextLabel1
            // 
            this.orientedTextLabel1.AutoSize = true;
            this.orientedTextLabel1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.orientedTextLabel1.Location = new System.Drawing.Point(687, 365);
            this.orientedTextLabel1.Name = "orientedTextLabel1";
            this.orientedTextLabel1.RotationAngle = 0D;
            this.orientedTextLabel1.Size = new System.Drawing.Size(222, 29);
            this.orientedTextLabel1.TabIndex = 6;
            this.orientedTextLabel1.Text = "orientedTextLabel1";
            this.orientedTextLabel1.TextDirection = VMS23.Direction.Clockwise;
            this.orientedTextLabel1.TextOrientation = VMS23.Orientation.Rotate;
            // 
            // roundLabel1
            // 
            this.roundLabel1.AutoSize = true;
            this.roundLabel1.BackSideColor = System.Drawing.Color.LightGray;
            this.roundLabel1.BorderColor = System.Drawing.Color.DarkGray;
            this.roundLabel1.BorderWidth = 1;
            this.roundLabel1.CornerRadius = 10;
            this.roundLabel1.EnableRoundAtLeftBtm = false;
            this.roundLabel1.EnableRoundAtLeftTop = false;
            this.roundLabel1.EnableRoundAtRightBtm = false;
            this.roundLabel1.EnableRoundAtRightTop = false;
            this.roundLabel1.Location = new System.Drawing.Point(687, 413);
            this.roundLabel1.Name = "roundLabel1";
            this.roundLabel1.Size = new System.Drawing.Size(148, 29);
            this.roundLabel1.TabIndex = 7;
            this.roundLabel1.Text = "roundLabel1";
            this.roundLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // roundBorderPanel1
            // 
            this.roundBorderPanel1.BorderColor = System.Drawing.Color.White;
            this.roundBorderPanel1.BorderWidth = 5;
            this.roundBorderPanel1.EnableBorder = true;
            this.roundBorderPanel1.Fill = false;
            this.roundBorderPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.roundBorderPanel1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.roundBorderPanel1.Location = new System.Drawing.Point(690, 459);
            this.roundBorderPanel1.Name = "roundBorderPanel1";
            this.roundBorderPanel1.PaddingSize = 5;
            this.roundBorderPanel1.Radius = 10;
            this.roundBorderPanel1.Size = new System.Drawing.Size(218, 72);
            this.roundBorderPanel1.TabIndex = 8;
            // 
            // vwMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Controls.Add(this.pnl_Base);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.pnl_Menu);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "vwMain";
            this.Size = new System.Drawing.Size(1280, 804);
            this.pnl_Base.ResumeLayout(false);
            this.pnl_Base.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Panel pnl_Base;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel pnl_Menu;
        private Button button1;
        private TextBox tbText;
        private RoundConerButton roundConerButton1;
        private MyUserControl.RoundBorderPanel roundBorderPanel1;
        private MyUserControl.RoundLabel roundLabel1;
        private VMS23.OrientedTextLabel orientedTextLabel1;
        private VMS23.LedToggleButton ledToggleButton1;
    }
}
