namespace Victor
{
    partial class FrmMain
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.btnEXIT = new System.Windows.Forms.Button();
            this.rdb_Maint = new System.Windows.Forms.RadioButton();
            this.rdb_Main = new System.Windows.Forms.RadioButton();
            this.rdb_Recie = new System.Windows.Forms.RadioButton();
            this.pnl_Base = new System.Windows.Forms.Panel();
            this.lbl_SWVersion = new System.Windows.Forms.Label();
            this.lbl_Time = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.pnl_mather = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdb_Save02 = new System.Windows.Forms.RadioButton();
            this.rdb_Setup = new System.Windows.Forms.RadioButton();
            this.rdb_ImageSave01 = new System.Windows.Forms.RadioButton();
            this.rbt_BcrRead = new System.Windows.Forms.RadioButton();
            this.rdb_Grab02 = new System.Windows.Forms.RadioButton();
            this.rdb_Grab01 = new System.Windows.Forms.RadioButton();
            this.pb_Login = new System.Windows.Forms.PictureBox();
            this.pb_CI = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pnl_mather.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Login)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_CI)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEXIT
            // 
            this.btnEXIT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnEXIT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            resources.ApplyResources(this.btnEXIT, "btnEXIT");
            this.btnEXIT.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnEXIT.Name = "btnEXIT";
            this.btnEXIT.UseVisualStyleBackColor = false;
            this.btnEXIT.Click += new System.EventHandler(this.Click_Exit);
            // 
            // rdb_Maint
            // 
            resources.ApplyResources(this.rdb_Maint, "rdb_Maint");
            this.rdb_Maint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.rdb_Maint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.rdb_Maint.FlatAppearance.CheckedBackColor = System.Drawing.Color.SteelBlue;
            this.rdb_Maint.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.rdb_Maint.Name = "rdb_Maint";
            this.rdb_Maint.Tag = "311";
            this.rdb_Maint.UseVisualStyleBackColor = false;
            this.rdb_Maint.Click += new System.EventHandler(this.Click_MenuRadioButton);
            // 
            // rdb_Main
            // 
            resources.ApplyResources(this.rdb_Main, "rdb_Main");
            this.rdb_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.rdb_Main.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.rdb_Main.FlatAppearance.CheckedBackColor = System.Drawing.Color.SteelBlue;
            this.rdb_Main.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.rdb_Main.Name = "rdb_Main";
            this.rdb_Main.Tag = "111";
            this.rdb_Main.UseVisualStyleBackColor = false;
            this.rdb_Main.Click += new System.EventHandler(this.Click_MenuRadioButton);
            // 
            // rdb_Recie
            // 
            resources.ApplyResources(this.rdb_Recie, "rdb_Recie");
            this.rdb_Recie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.rdb_Recie.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.rdb_Recie.FlatAppearance.CheckedBackColor = System.Drawing.Color.SteelBlue;
            this.rdb_Recie.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.rdb_Recie.Name = "rdb_Recie";
            this.rdb_Recie.Tag = "211";
            this.rdb_Recie.UseVisualStyleBackColor = false;
            this.rdb_Recie.Click += new System.EventHandler(this.Click_MenuRadioButton);
            // 
            // pnl_Base
            // 
            this.pnl_Base.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            resources.ApplyResources(this.pnl_Base, "pnl_Base");
            this.pnl_Base.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Base.Name = "pnl_Base";
            // 
            // lbl_SWVersion
            // 
            resources.ApplyResources(this.lbl_SWVersion, "lbl_SWVersion");
            this.lbl_SWVersion.BackColor = System.Drawing.Color.Black;
            this.lbl_SWVersion.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_SWVersion.Name = "lbl_SWVersion";
            // 
            // lbl_Time
            // 
            resources.ApplyResources(this.lbl_Time, "lbl_Time");
            this.lbl_Time.BackColor = System.Drawing.Color.Black;
            this.lbl_Time.ForeColor = System.Drawing.Color.White;
            this.lbl_Time.Name = "lbl_Time";
            // 
            // radioButton1
            // 
            resources.ApplyResources(this.radioButton1, "radioButton1");
            this.radioButton1.BackColor = System.Drawing.Color.Red;
            this.radioButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.radioButton1.FlatAppearance.CheckedBackColor = System.Drawing.Color.SteelBlue;
            this.radioButton1.ForeColor = System.Drawing.Color.White;
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Tag = "3";
            this.radioButton1.UseVisualStyleBackColor = false;
            this.radioButton1.Click += new System.EventHandler(this.radioButton1_Click);
            // 
            // radioButton2
            // 
            resources.ApplyResources(this.radioButton2, "radioButton2");
            this.radioButton2.BackColor = System.Drawing.Color.Yellow;
            this.radioButton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.radioButton2.FlatAppearance.CheckedBackColor = System.Drawing.Color.SteelBlue;
            this.radioButton2.ForeColor = System.Drawing.Color.Black;
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Tag = "3";
            this.radioButton2.UseVisualStyleBackColor = false;
            // 
            // pnl_mather
            // 
            this.pnl_mather.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.pnl_mather.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_mather.Controls.Add(this.button2);
            this.pnl_mather.Controls.Add(this.richTextBox1);
            this.pnl_mather.Controls.Add(this.groupBox1);
            this.pnl_mather.Controls.Add(this.radioButton1);
            this.pnl_mather.Controls.Add(this.radioButton2);
            this.pnl_mather.Controls.Add(this.pb_Login);
            this.pnl_mather.Controls.Add(this.pb_CI);
            resources.ApplyResources(this.pnl_mather, "pnl_mather");
            this.pnl_mather.Name = "pnl_mather";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.richTextBox1.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.richTextBox1, "richTextBox1");
            this.richTextBox1.Name = "richTextBox1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.rdb_Save02);
            this.groupBox1.Controls.Add(this.rdb_Setup);
            this.groupBox1.Controls.Add(this.rdb_ImageSave01);
            this.groupBox1.Controls.Add(this.rbt_BcrRead);
            this.groupBox1.Controls.Add(this.rdb_Grab02);
            this.groupBox1.Controls.Add(this.rdb_Grab01);
            this.groupBox1.Controls.Add(this.btnEXIT);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // rdb_Save02
            // 
            resources.ApplyResources(this.rdb_Save02, "rdb_Save02");
            this.rdb_Save02.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.rdb_Save02.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.rdb_Save02.FlatAppearance.CheckedBackColor = System.Drawing.Color.SteelBlue;
            this.rdb_Save02.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.rdb_Save02.Name = "rdb_Save02";
            this.rdb_Save02.Tag = "105";
            this.rdb_Save02.UseVisualStyleBackColor = false;
            this.rdb_Save02.Click += new System.EventHandler(this.Click_MenuRadioButton);
            // 
            // rdb_Setup
            // 
            resources.ApplyResources(this.rdb_Setup, "rdb_Setup");
            this.rdb_Setup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.rdb_Setup.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.rdb_Setup.FlatAppearance.CheckedBackColor = System.Drawing.Color.SteelBlue;
            this.rdb_Setup.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.rdb_Setup.Name = "rdb_Setup";
            this.rdb_Setup.Tag = "106";
            this.rdb_Setup.UseVisualStyleBackColor = false;
            this.rdb_Setup.Click += new System.EventHandler(this.Click_MenuRadioButton);
            // 
            // rdb_ImageSave01
            // 
            resources.ApplyResources(this.rdb_ImageSave01, "rdb_ImageSave01");
            this.rdb_ImageSave01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.rdb_ImageSave01.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.rdb_ImageSave01.FlatAppearance.CheckedBackColor = System.Drawing.Color.SteelBlue;
            this.rdb_ImageSave01.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.rdb_ImageSave01.Name = "rdb_ImageSave01";
            this.rdb_ImageSave01.Tag = "103";
            this.rdb_ImageSave01.UseVisualStyleBackColor = false;
            this.rdb_ImageSave01.Click += new System.EventHandler(this.Click_MenuRadioButton);
            // 
            // rbt_BcrRead
            // 
            resources.ApplyResources(this.rbt_BcrRead, "rbt_BcrRead");
            this.rbt_BcrRead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.rbt_BcrRead.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.rbt_BcrRead.FlatAppearance.CheckedBackColor = System.Drawing.Color.SteelBlue;
            this.rbt_BcrRead.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.rbt_BcrRead.Name = "rbt_BcrRead";
            this.rbt_BcrRead.Tag = "101";
            this.rbt_BcrRead.UseVisualStyleBackColor = false;
            this.rbt_BcrRead.Click += new System.EventHandler(this.Click_MenuRadioButton);
            // 
            // rdb_Grab02
            // 
            resources.ApplyResources(this.rdb_Grab02, "rdb_Grab02");
            this.rdb_Grab02.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.rdb_Grab02.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.rdb_Grab02.FlatAppearance.CheckedBackColor = System.Drawing.Color.SteelBlue;
            this.rdb_Grab02.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.rdb_Grab02.Name = "rdb_Grab02";
            this.rdb_Grab02.Tag = "104";
            this.rdb_Grab02.UseVisualStyleBackColor = false;
            this.rdb_Grab02.Click += new System.EventHandler(this.Click_MenuRadioButton);
            // 
            // rdb_Grab01
            // 
            resources.ApplyResources(this.rdb_Grab01, "rdb_Grab01");
            this.rdb_Grab01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.rdb_Grab01.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.rdb_Grab01.FlatAppearance.CheckedBackColor = System.Drawing.Color.SteelBlue;
            this.rdb_Grab01.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.rdb_Grab01.Name = "rdb_Grab01";
            this.rdb_Grab01.Tag = "102";
            this.rdb_Grab01.UseVisualStyleBackColor = false;
            this.rdb_Grab01.Click += new System.EventHandler(this.Click_MenuRadioButton);
            // 
            // pb_Login
            // 
            resources.ApplyResources(this.pb_Login, "pb_Login");
            this.pb_Login.Name = "pb_Login";
            this.pb_Login.TabStop = false;
            // 
            // pb_CI
            // 
            this.pb_CI.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.pb_CI, "pb_CI");
            this.pb_CI.Name = "pb_CI";
            this.pb_CI.TabStop = false;
            this.pb_CI.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown_CI);
            this.pb_CI.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove_CI);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this, "$this");
            this.ControlBox = false;
            this.Controls.Add(this.lbl_Time);
            this.Controls.Add(this.lbl_SWVersion);
            this.Controls.Add(this.pnl_Base);
            this.Controls.Add(this.rdb_Maint);
            this.Controls.Add(this.pnl_mather);
            this.Controls.Add(this.rdb_Main);
            this.Controls.Add(this.rdb_Recie);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.pnl_mather.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Login)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_CI)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEXIT;
        private System.Windows.Forms.RadioButton rdb_Maint;
        private System.Windows.Forms.RadioButton rdb_Main;
        private System.Windows.Forms.RadioButton rdb_Recie;
        private System.Windows.Forms.Panel pnl_Base;
        private System.Windows.Forms.Label lbl_SWVersion;
        private System.Windows.Forms.Label lbl_Time;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Panel pnl_mather;
        private System.Windows.Forms.PictureBox pb_CI;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pb_Login;
        private System.Windows.Forms.RadioButton rbt_BcrRead;
        private System.Windows.Forms.RadioButton rdb_Setup;
        private System.Windows.Forms.RadioButton rdb_Save02;
        private System.Windows.Forms.RadioButton rdb_ImageSave01;
        private System.Windows.Forms.RadioButton rdb_Grab02;
        private System.Windows.Forms.RadioButton rdb_Grab01;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

