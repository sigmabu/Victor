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
            this.panel6 = new System.Windows.Forms.Panel();
            this.lbl_Main = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.btn_printScreen = new System.Windows.Forms.Button();
            this.pnlRecipe = new System.Windows.Forms.Panel();
            this.lbl_RecipeGroup = new System.Windows.Forms.Label();
            this.lblRecipeName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblInformation = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lbl_SWVersion = new System.Windows.Forms.Label();
            this.lbl_Time = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.pnl_mather = new System.Windows.Forms.Panel();
            this.pb_Login = new System.Windows.Forms.PictureBox();
            this.pb_CI = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.pnlRecipe.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnl_mather.SuspendLayout();
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
            this.rdb_Maint.Tag = "31";
            this.rdb_Maint.UseVisualStyleBackColor = false;
            this.rdb_Maint.CheckedChanged += new System.EventHandler(this.rdb_Menu_CheckedChanged);
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
            this.rdb_Main.Tag = "11";
            this.rdb_Main.UseVisualStyleBackColor = false;
            this.rdb_Main.CheckedChanged += new System.EventHandler(this.rdb_Menu_CheckedChanged);
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
            this.rdb_Recie.Tag = "21";
            this.rdb_Recie.UseVisualStyleBackColor = false;
            this.rdb_Recie.CheckedChanged += new System.EventHandler(this.rdb_Menu_CheckedChanged);
            this.rdb_Recie.Click += new System.EventHandler(this.Click_MenuRadioButton);
            // 
            // pnl_Base
            // 
            this.pnl_Base.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            resources.ApplyResources(this.pnl_Base, "pnl_Base");
            this.pnl_Base.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Base.Name = "pnl_Base";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.lbl_Main);
            this.panel6.Controls.Add(this.label3);
            resources.ApplyResources(this.panel6, "panel6");
            this.panel6.Name = "panel6";
            // 
            // lbl_Main
            // 
            resources.ApplyResources(this.lbl_Main, "lbl_Main");
            this.lbl_Main.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbl_Main.Name = "lbl_Main";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Name = "label3";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.lblMessage);
            this.panel5.Controls.Add(this.label19);
            this.panel5.Controls.Add(this.btn_printScreen);
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.Name = "panel5";
            // 
            // lblMessage
            // 
            resources.ApplyResources(this.lblMessage, "lblMessage");
            this.lblMessage.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblMessage.Name = "lblMessage";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label19.Name = "label19";
            // 
            // btn_printScreen
            // 
            this.btn_printScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            resources.ApplyResources(this.btn_printScreen, "btn_printScreen");
            this.btn_printScreen.FlatAppearance.BorderSize = 0;
            this.btn_printScreen.Name = "btn_printScreen";
            this.btn_printScreen.UseVisualStyleBackColor = false;
            // 
            // pnlRecipe
            // 
            this.pnlRecipe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.pnlRecipe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRecipe.Controls.Add(this.lbl_RecipeGroup);
            this.pnlRecipe.Controls.Add(this.lblRecipeName);
            this.pnlRecipe.Controls.Add(this.label7);
            this.pnlRecipe.Controls.Add(this.label11);
            resources.ApplyResources(this.pnlRecipe, "pnlRecipe");
            this.pnlRecipe.Name = "pnlRecipe";
            this.pnlRecipe.Click += new System.EventHandler(this.Click_TitleRecipe);
            // 
            // lbl_RecipeGroup
            // 
            resources.ApplyResources(this.lbl_RecipeGroup, "lbl_RecipeGroup");
            this.lbl_RecipeGroup.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbl_RecipeGroup.Name = "lbl_RecipeGroup";
            // 
            // lblRecipeName
            // 
            resources.ApplyResources(this.lblRecipeName, "lblRecipeName");
            this.lblRecipeName.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblRecipeName.Name = "lblRecipeName";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label7.Name = "label7";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label11.Name = "label11";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblInformation);
            this.panel4.Controls.Add(this.lblError);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.label17);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // lblInformation
            // 
            resources.ApplyResources(this.lblInformation, "lblInformation");
            this.lblInformation.ForeColor = System.Drawing.Color.Yellow;
            this.lblInformation.Name = "lblInformation";
            // 
            // lblError
            // 
            resources.ApplyResources(this.lblError, "lblError");
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblError.Name = "lblError";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label16.Name = "label16";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label17.Name = "label17";
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
            this.pnl_mather.BackColor = System.Drawing.Color.Black;
            this.pnl_mather.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_mather.Controls.Add(this.pb_Login);
            this.pnl_mather.Controls.Add(this.pb_CI);
            resources.ApplyResources(this.pnl_mather, "pnl_mather");
            this.pnl_mather.Name = "pnl_mather";
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
            // FrmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this, "$this");
            this.ControlBox = false;
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.lbl_Time);
            this.Controls.Add(this.lbl_SWVersion);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pnlRecipe);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.pnl_Base);
            this.Controls.Add(this.rdb_Maint);
            this.Controls.Add(this.rdb_Main);
            this.Controls.Add(this.rdb_Recie);
            this.Controls.Add(this.btnEXIT);
            this.Controls.Add(this.pnl_mather);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.pnlRecipe.ResumeLayout(false);
            this.pnlRecipe.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnl_mather.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lbl_Main;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btn_printScreen;
        private System.Windows.Forms.Panel pnlRecipe;
        private System.Windows.Forms.Label lbl_RecipeGroup;
        private System.Windows.Forms.Label lblRecipeName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblInformation;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lbl_SWVersion;
        private System.Windows.Forms.Label lbl_Time;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Panel pnl_mather;
        private System.Windows.Forms.PictureBox pb_CI;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pb_Login;
    }
}

