namespace Victor
{
    partial class vwMaint
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
            this.btn_Serial = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_ErrorList = new System.Windows.Forms.Button();
            this.btn_IOList = new System.Windows.Forms.Button();
            this.btn_Network = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pnl_Menu = new System.Windows.Forms.Panel();
            this.btn_MotorList = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label46
            // 
            this.label46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(86)))), ((int)(((byte)(29)))));
            this.label46.Dock = System.Windows.Forms.DockStyle.Top;
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label46.ForeColor = System.Drawing.SystemColors.Control;
            this.label46.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label46.Location = new System.Drawing.Point(0, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(1280, 30);
            this.label46.TabIndex = 452;
            this.label46.Text = "MAINTENANCE";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Serial
            // 
            this.btn_Serial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_Serial.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btn_Serial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Serial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_Serial.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btn_Serial.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Serial.Location = new System.Drawing.Point(31, 80);
            this.btn_Serial.Name = "btn_Serial";
            this.btn_Serial.Size = new System.Drawing.Size(323, 50);
            this.btn_Serial.TabIndex = 1;
            this.btn_Serial.Tag = "312";
            this.btn_Serial.Text = "Serial Comm";
            this.btn_Serial.UseVisualStyleBackColor = false;
            this.btn_Serial.Click += new System.EventHandler(this.Click_OptionButton);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(26, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Option";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_MotorList);
            this.panel1.Controls.Add(this.btn_ErrorList);
            this.panel1.Controls.Add(this.btn_IOList);
            this.panel1.Controls.Add(this.btn_Network);
            this.panel1.Controls.Add(this.btn_Serial);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(24, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(389, 679);
            this.panel1.TabIndex = 453;
            // 
            // btn_ErrorList
            // 
            this.btn_ErrorList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_ErrorList.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btn_ErrorList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ErrorList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_ErrorList.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btn_ErrorList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_ErrorList.Location = new System.Drawing.Point(31, 288);
            this.btn_ErrorList.Name = "btn_ErrorList";
            this.btn_ErrorList.Size = new System.Drawing.Size(323, 50);
            this.btn_ErrorList.TabIndex = 2;
            this.btn_ErrorList.Tag = "315";
            this.btn_ErrorList.Text = "Error List";
            this.btn_ErrorList.UseVisualStyleBackColor = false;
            this.btn_ErrorList.Click += new System.EventHandler(this.Click_OptionButton);
            // 
            // btn_IOList
            // 
            this.btn_IOList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_IOList.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btn_IOList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_IOList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_IOList.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btn_IOList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_IOList.Location = new System.Drawing.Point(31, 218);
            this.btn_IOList.Name = "btn_IOList";
            this.btn_IOList.Size = new System.Drawing.Size(323, 50);
            this.btn_IOList.TabIndex = 2;
            this.btn_IOList.Tag = "314";
            this.btn_IOList.Text = "In Out List";
            this.btn_IOList.UseVisualStyleBackColor = false;
            this.btn_IOList.Click += new System.EventHandler(this.Click_OptionButton);
            // 
            // btn_Network
            // 
            this.btn_Network.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_Network.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btn_Network.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Network.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_Network.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btn_Network.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Network.Location = new System.Drawing.Point(31, 151);
            this.btn_Network.Name = "btn_Network";
            this.btn_Network.Size = new System.Drawing.Size(323, 50);
            this.btn_Network.TabIndex = 2;
            this.btn_Network.Tag = "313";
            this.btn_Network.Text = "Network";
            this.btn_Network.UseVisualStyleBackColor = false;
            this.btn_Network.Click += new System.EventHandler(this.Click_OptionButton);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(452, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(389, 679);
            this.panel2.TabIndex = 453;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button3.Location = new System.Drawing.Point(31, 151);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(323, 50);
            this.button3.TabIndex = 2;
            this.button3.Tag = "2";
            this.button3.Text = "Optic # 2";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button4.Location = new System.Drawing.Point(31, 90);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(323, 50);
            this.button4.TabIndex = 1;
            this.button4.Tag = "1";
            this.button4.Text = "Optic #1";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(26, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 40);
            this.label2.TabIndex = 0;
            this.label2.Text = "Laser";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button5);
            this.panel3.Controls.Add(this.button6);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(872, 55);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(389, 679);
            this.panel3.TabIndex = 453;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button5.Location = new System.Drawing.Point(31, 151);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(323, 50);
            this.button5.TabIndex = 2;
            this.button5.Tag = "2";
            this.button5.Text = "Optic # 2";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button6.Location = new System.Drawing.Point(31, 90);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(323, 50);
            this.button6.TabIndex = 1;
            this.button6.Tag = "1";
            this.button6.Text = "Optic #1";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(26, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 40);
            this.label3.TabIndex = 0;
            this.label3.Text = "Motion";
            // 
            // pnl_Menu
            // 
            this.pnl_Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.pnl_Menu.Location = new System.Drawing.Point(0, 0);
            this.pnl_Menu.Name = "pnl_Menu";
            this.pnl_Menu.Size = new System.Drawing.Size(1280, 804);
            this.pnl_Menu.TabIndex = 454;
            // 
            // btn_MotorList
            // 
            this.btn_MotorList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_MotorList.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btn_MotorList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_MotorList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_MotorList.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btn_MotorList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_MotorList.Location = new System.Drawing.Point(31, 357);
            this.btn_MotorList.Name = "btn_MotorList";
            this.btn_MotorList.Size = new System.Drawing.Size(323, 50);
            this.btn_MotorList.TabIndex = 2;
            this.btn_MotorList.Tag = "316";
            this.btn_MotorList.Text = "Motor List";
            this.btn_MotorList.UseVisualStyleBackColor = false;
            this.btn_MotorList.Click += new System.EventHandler(this.Click_OptionButton);
            // 
            // vwMaint
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.pnl_Menu);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "vwMaint";
            this.Size = new System.Drawing.Size(1280, 804);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Button btn_Serial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Network;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnl_Menu;
        private System.Windows.Forms.Button btn_IOList;
        private System.Windows.Forms.Button btn_ErrorList;
        private System.Windows.Forms.Button btn_MotorList;
    }
}
