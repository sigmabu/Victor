namespace Victor
{
    partial class vwSerial
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Pnl_Item = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Open = new System.Windows.Forms.Button();
            this.btn_Write = new System.Windows.Forms.Button();
            this.tb_No = new System.Windows.Forms.TextBox();
            this.cb_Stop = new System.Windows.Forms.ComboBox();
            this.cb_Parity = new System.Windows.Forms.ComboBox();
            this.cb_Data = new System.Windows.Forms.ComboBox();
            this.cb_Baud = new System.Windows.Forms.ComboBox();
            this.tb_Name = new System.Windows.Forms.TextBox();
            this.radio_Save = new System.Windows.Forms.RadioButton();
            this.rTB_Read = new System.Windows.Forms.RichTextBox();
            this.rTB_Write = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_Data = new System.Windows.Forms.Label();
            this.lb_Baud = new System.Windows.Forms.Label();
            this.lb_Stop = new System.Windows.Forms.Label();
            this.lb_ComPort = new System.Windows.Forms.Label();
            this.lb_Parity = new System.Windows.Forms.Label();
            this.dGV_SerialList = new System.Windows.Forms.DataGridView();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.Pnl_Item.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_SerialList)).BeginInit();
            this.SuspendLayout();
            // 
            // Pnl_Item
            // 
            this.Pnl_Item.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.Pnl_Item.Controls.Add(this.button3);
            this.Pnl_Item.Controls.Add(this.button2);
            this.Pnl_Item.Controls.Add(this.button1);
            this.Pnl_Item.Controls.Add(this.groupBox1);
            this.Pnl_Item.Controls.Add(this.dGV_SerialList);
            this.Pnl_Item.Location = new System.Drawing.Point(0, 0);
            this.Pnl_Item.Name = "Pnl_Item";
            this.Pnl_Item.Size = new System.Drawing.Size(1280, 768);
            this.Pnl_Item.TabIndex = 460;
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(1127, 733);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 32);
            this.button3.TabIndex = 459;
            this.button3.Text = "Display";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(1143, 714);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 29);
            this.button2.TabIndex = 458;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.Click_Save);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(1174, 704);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 29);
            this.button1.TabIndex = 458;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.Click_Open);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.btn_Close);
            this.groupBox1.Controls.Add(this.btn_Open);
            this.groupBox1.Controls.Add(this.btn_Write);
            this.groupBox1.Controls.Add(this.tb_No);
            this.groupBox1.Controls.Add(this.cb_Stop);
            this.groupBox1.Controls.Add(this.cb_Parity);
            this.groupBox1.Controls.Add(this.cb_Data);
            this.groupBox1.Controls.Add(this.cb_Baud);
            this.groupBox1.Controls.Add(this.tb_Name);
            this.groupBox1.Controls.Add(this.radio_Save);
            this.groupBox1.Controls.Add(this.rTB_Read);
            this.groupBox1.Controls.Add(this.rTB_Write);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lb_Data);
            this.groupBox1.Controls.Add(this.lb_Baud);
            this.groupBox1.Controls.Add(this.lb_Stop);
            this.groupBox1.Controls.Add(this.lb_ComPort);
            this.groupBox1.Controls.Add(this.lb_Parity);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 155);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1257, 597);
            this.groupBox1.TabIndex = 463;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Port no                              ";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(200)))), ((int)(((byte)(30)))));
            this.button4.Location = new System.Drawing.Point(842, 128);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(115, 48);
            this.button4.TabIndex = 463;
            this.button4.Text = "Read";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_Close.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btn_Close.Location = new System.Drawing.Point(320, 131);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(115, 48);
            this.btn_Close.TabIndex = 463;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.Click_PortClose);
            // 
            // btn_Open
            // 
            this.btn_Open.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_Open.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_Open.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Open.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btn_Open.Location = new System.Drawing.Point(199, 131);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(115, 48);
            this.btn_Open.TabIndex = 463;
            this.btn_Open.Text = "Open";
            this.btn_Open.UseVisualStyleBackColor = false;
            this.btn_Open.Click += new System.EventHandler(this.Click_PortOpen);
            // 
            // btn_Write
            // 
            this.btn_Write.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_Write.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_Write.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Write.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(200)))), ((int)(((byte)(30)))));
            this.btn_Write.Location = new System.Drawing.Point(441, 131);
            this.btn_Write.Name = "btn_Write";
            this.btn_Write.Size = new System.Drawing.Size(115, 48);
            this.btn_Write.TabIndex = 463;
            this.btn_Write.Text = "Write";
            this.btn_Write.UseVisualStyleBackColor = false;
            // 
            // tb_No
            // 
            this.tb_No.Location = new System.Drawing.Point(88, 0);
            this.tb_No.Name = "tb_No";
            this.tb_No.Size = new System.Drawing.Size(87, 35);
            this.tb_No.TabIndex = 461;
            // 
            // cb_Stop
            // 
            this.cb_Stop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Stop.FormattingEnabled = true;
            this.cb_Stop.Location = new System.Drawing.Point(255, 82);
            this.cb_Stop.Name = "cb_Stop";
            this.cb_Stop.Size = new System.Drawing.Size(68, 37);
            this.cb_Stop.TabIndex = 462;
            // 
            // cb_Parity
            // 
            this.cb_Parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Parity.FormattingEnabled = true;
            this.cb_Parity.Location = new System.Drawing.Point(333, 82);
            this.cb_Parity.Name = "cb_Parity";
            this.cb_Parity.Size = new System.Drawing.Size(68, 37);
            this.cb_Parity.TabIndex = 462;
            // 
            // cb_Data
            // 
            this.cb_Data.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Data.FormattingEnabled = true;
            this.cb_Data.Location = new System.Drawing.Point(176, 81);
            this.cb_Data.Name = "cb_Data";
            this.cb_Data.Size = new System.Drawing.Size(68, 37);
            this.cb_Data.TabIndex = 462;
            // 
            // cb_Baud
            // 
            this.cb_Baud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Baud.FormattingEnabled = true;
            this.cb_Baud.Location = new System.Drawing.Point(93, 81);
            this.cb_Baud.Name = "cb_Baud";
            this.cb_Baud.Size = new System.Drawing.Size(68, 37);
            this.cb_Baud.TabIndex = 462;
            // 
            // tb_Name
            // 
            this.tb_Name.Location = new System.Drawing.Point(19, 82);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(68, 35);
            this.tb_Name.TabIndex = 461;
            // 
            // radio_Save
            // 
            this.radio_Save.Appearance = System.Windows.Forms.Appearance.Button;
            this.radio_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.radio_Save.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.radio_Save.FlatAppearance.CheckedBackColor = System.Drawing.Color.SteelBlue;
            this.radio_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radio_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.radio_Save.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radio_Save.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.radio_Save.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radio_Save.Location = new System.Drawing.Point(535, 69);
            this.radio_Save.Margin = new System.Windows.Forms.Padding(0);
            this.radio_Save.Name = "radio_Save";
            this.radio_Save.Padding = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.radio_Save.Size = new System.Drawing.Size(119, 51);
            this.radio_Save.TabIndex = 456;
            this.radio_Save.Tag = "11";
            this.radio_Save.Text = "Save";
            this.radio_Save.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radio_Save.UseVisualStyleBackColor = false;
            this.radio_Save.Click += new System.EventHandler(this.Click_Save);
            // 
            // rTB_Read
            // 
            this.rTB_Read.Location = new System.Drawing.Point(675, 185);
            this.rTB_Read.Name = "rTB_Read";
            this.rTB_Read.Size = new System.Drawing.Size(533, 381);
            this.rTB_Read.TabIndex = 460;
            this.rTB_Read.Text = "Read Data List";
            // 
            // rTB_Write
            // 
            this.rTB_Write.Location = new System.Drawing.Point(23, 185);
            this.rTB_Write.Name = "rTB_Write";
            this.rTB_Write.Size = new System.Drawing.Size(533, 381);
            this.rTB_Write.TabIndex = 460;
            this.rTB_Write.Text = "Write Data List";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label3.Location = new System.Drawing.Point(678, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 46);
            this.label3.TabIndex = 0;
            this.label3.Text = "Read Data  ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label2.Location = new System.Drawing.Point(25, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 46);
            this.label2.TabIndex = 0;
            this.label2.Text = "Write Data  ";
            // 
            // lb_Data
            // 
            this.lb_Data.AutoSize = true;
            this.lb_Data.Location = new System.Drawing.Point(177, 58);
            this.lb_Data.Name = "lb_Data";
            this.lb_Data.Size = new System.Drawing.Size(96, 29);
            this.lb_Data.TabIndex = 0;
            this.lb_Data.Text = "Data Bit";
            // 
            // lb_Baud
            // 
            this.lb_Baud.AutoSize = true;
            this.lb_Baud.Location = new System.Drawing.Point(84, 58);
            this.lb_Baud.Name = "lb_Baud";
            this.lb_Baud.Size = new System.Drawing.Size(125, 29);
            this.lb_Baud.TabIndex = 0;
            this.lb_Baud.Text = "Baud Rate";
            // 
            // lb_Stop
            // 
            this.lb_Stop.AutoSize = true;
            this.lb_Stop.Location = new System.Drawing.Point(256, 59);
            this.lb_Stop.Name = "lb_Stop";
            this.lb_Stop.Size = new System.Drawing.Size(97, 29);
            this.lb_Stop.TabIndex = 0;
            this.lb_Stop.Text = "Stop Bit";
            // 
            // lb_ComPort
            // 
            this.lb_ComPort.AutoSize = true;
            this.lb_ComPort.Location = new System.Drawing.Point(28, 58);
            this.lb_ComPort.Name = "lb_ComPort";
            this.lb_ComPort.Size = new System.Drawing.Size(78, 29);
            this.lb_ComPort.TabIndex = 0;
            this.lb_ComPort.Text = "Name";
            // 
            // lb_Parity
            // 
            this.lb_Parity.AutoSize = true;
            this.lb_Parity.Location = new System.Drawing.Point(332, 59);
            this.lb_Parity.Name = "lb_Parity";
            this.lb_Parity.Size = new System.Drawing.Size(107, 29);
            this.lb_Parity.TabIndex = 0;
            this.lb_Parity.Text = "Parity Bit";
            // 
            // dGV_SerialList
            // 
            this.dGV_SerialList.AllowUserToAddRows = false;
            this.dGV_SerialList.AllowUserToDeleteRows = false;
            this.dGV_SerialList.AllowUserToResizeColumns = false;
            this.dGV_SerialList.AllowUserToResizeRows = false;
            this.dGV_SerialList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGV_SerialList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dGV_SerialList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGV_SerialList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGV_SerialList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGV_SerialList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dGV_SerialList.Location = new System.Drawing.Point(12, 14);
            this.dGV_SerialList.Name = "dGV_SerialList";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGV_SerialList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dGV_SerialList.RowHeadersVisible = false;
            this.dGV_SerialList.RowHeadersWidth = 62;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dGV_SerialList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dGV_SerialList.RowTemplate.Height = 23;
            this.dGV_SerialList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGV_SerialList.Size = new System.Drawing.Size(1257, 125);
            this.dGV_SerialList.TabIndex = 457;
            this.dGV_SerialList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_SerialList_CellClick);
            // 
            // vwSerial
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Pnl_Item);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "vwSerial";
            this.Size = new System.Drawing.Size(1280, 768);
            this.Pnl_Item.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_SerialList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Pnl_Item;
        private System.Windows.Forms.RadioButton radio_Save;
        private System.Windows.Forms.DataGridView dGV_SerialList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox rTB_Write;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rTB_Read;
        private System.Windows.Forms.Label lb_ComPort;
        private System.Windows.Forms.Label lb_Data;
        private System.Windows.Forms.Label lb_Baud;
        private System.Windows.Forms.Label lb_Stop;
        private System.Windows.Forms.Label lb_Parity;
        private System.Windows.Forms.ComboBox cb_Baud;
        private System.Windows.Forms.TextBox tb_Name;
        private System.Windows.Forms.TextBox tb_No;
        private System.Windows.Forms.ComboBox cb_Parity;
        private System.Windows.Forms.ComboBox cb_Data;
        private System.Windows.Forms.ComboBox cb_Stop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Write;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Open;
        private System.IO.Ports.SerialPort serialPort1;
    }
}