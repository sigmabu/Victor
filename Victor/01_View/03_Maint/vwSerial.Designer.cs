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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Pnl_Item = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dGV_SerialList = new System.Windows.Forms.DataGridView();
            this.radio_Save = new System.Windows.Forms.RadioButton();
            this.rTB_Write = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rTB_Read = new System.Windows.Forms.RichTextBox();
            this.lb_ComPort = new System.Windows.Forms.Label();
            this.lb_Baud = new System.Windows.Forms.Label();
            this.lb_Data = new System.Windows.Forms.Label();
            this.lb_Parity = new System.Windows.Forms.Label();
            this.lb_Stop = new System.Windows.Forms.Label();
            this.lb_Flow = new System.Windows.Forms.Label();
            this.tb_No = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.cb_Baud = new System.Windows.Forms.ComboBox();
            this.cb_Data = new System.Windows.Forms.ComboBox();
            this.cb_Parity = new System.Windows.Forms.ComboBox();
            this.cb_Stop = new System.Windows.Forms.ComboBox();
            this.cb_Flow = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Write = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.Pnl_Item.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_SerialList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pnl_Item
            // 
            this.Pnl_Item.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.Pnl_Item.Controls.Add(this.groupBox1);
            this.Pnl_Item.Controls.Add(this.button3);
            this.Pnl_Item.Controls.Add(this.button2);
            this.Pnl_Item.Controls.Add(this.button1);
            this.Pnl_Item.Controls.Add(this.dGV_SerialList);
            this.Pnl_Item.Location = new System.Drawing.Point(0, 0);
            this.Pnl_Item.Name = "Pnl_Item";
            this.Pnl_Item.Size = new System.Drawing.Size(1280, 768);
            this.Pnl_Item.TabIndex = 460;
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(1019, 137);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(214, 32);
            this.button3.TabIndex = 459;
            this.button3.Text = "Display";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(914, 140);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 29);
            this.button2.TabIndex = 458;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Click_Save);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(674, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(214, 29);
            this.button1.TabIndex = 458;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Click_Open);
            // 
            // dGV_SerialList
            // 
            this.dGV_SerialList.AllowUserToAddRows = false;
            this.dGV_SerialList.AllowUserToDeleteRows = false;
            this.dGV_SerialList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGV_SerialList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGV_SerialList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGV_SerialList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
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
            this.dGV_SerialList.RowTemplate.Height = 23;
            this.dGV_SerialList.Size = new System.Drawing.Size(1257, 125);
            this.dGV_SerialList.TabIndex = 457;
            // 
            // radio_Save
            // 
            this.radio_Save.Appearance = System.Windows.Forms.Appearance.Button;
            this.radio_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
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
            // rTB_Write
            // 
            this.rTB_Write.Location = new System.Drawing.Point(23, 182);
            this.rTB_Write.Name = "rTB_Write";
            this.rTB_Write.Size = new System.Drawing.Size(533, 336);
            this.rTB_Write.TabIndex = 460;
            this.rTB_Write.Text = "Write Data List";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label2.Location = new System.Drawing.Point(25, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "Write Data  ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label3.Location = new System.Drawing.Point(620, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 31);
            this.label3.TabIndex = 0;
            this.label3.Text = "Read Data  ";
            // 
            // rTB_Read
            // 
            this.rTB_Read.Location = new System.Drawing.Point(617, 182);
            this.rTB_Read.Name = "rTB_Read";
            this.rTB_Read.Size = new System.Drawing.Size(533, 336);
            this.rTB_Read.TabIndex = 460;
            this.rTB_Read.Text = "Read Data List";
            // 
            // lb_ComPort
            // 
            this.lb_ComPort.AutoSize = true;
            this.lb_ComPort.Location = new System.Drawing.Point(28, 58);
            this.lb_ComPort.Name = "lb_ComPort";
            this.lb_ComPort.Size = new System.Drawing.Size(51, 20);
            this.lb_ComPort.TabIndex = 0;
            this.lb_ComPort.Text = "Name";
            // 
            // lb_Baud
            // 
            this.lb_Baud.AutoSize = true;
            this.lb_Baud.Location = new System.Drawing.Point(84, 58);
            this.lb_Baud.Name = "lb_Baud";
            this.lb_Baud.Size = new System.Drawing.Size(86, 20);
            this.lb_Baud.TabIndex = 0;
            this.lb_Baud.Text = "Baud Rate";
            // 
            // lb_Data
            // 
            this.lb_Data.AutoSize = true;
            this.lb_Data.Location = new System.Drawing.Point(177, 58);
            this.lb_Data.Name = "lb_Data";
            this.lb_Data.Size = new System.Drawing.Size(67, 20);
            this.lb_Data.TabIndex = 0;
            this.lb_Data.Text = "Data Bit";
            // 
            // lb_Parity
            // 
            this.lb_Parity.AutoSize = true;
            this.lb_Parity.Location = new System.Drawing.Point(255, 58);
            this.lb_Parity.Name = "lb_Parity";
            this.lb_Parity.Size = new System.Drawing.Size(71, 20);
            this.lb_Parity.TabIndex = 0;
            this.lb_Parity.Text = "Parity Bit";
            // 
            // lb_Stop
            // 
            this.lb_Stop.AutoSize = true;
            this.lb_Stop.Location = new System.Drawing.Point(333, 58);
            this.lb_Stop.Name = "lb_Stop";
            this.lb_Stop.Size = new System.Drawing.Size(66, 20);
            this.lb_Stop.TabIndex = 0;
            this.lb_Stop.Text = "Stop Bit";
            // 
            // lb_Flow
            // 
            this.lb_Flow.AutoSize = true;
            this.lb_Flow.Location = new System.Drawing.Point(408, 58);
            this.lb_Flow.Name = "lb_Flow";
            this.lb_Flow.Size = new System.Drawing.Size(97, 20);
            this.lb_Flow.TabIndex = 0;
            this.lb_Flow.Text = "Flow Control";
            // 
            // tb_No
            // 
            this.tb_No.Location = new System.Drawing.Point(88, 0);
            this.tb_No.Name = "tb_No";
            this.tb_No.Size = new System.Drawing.Size(87, 26);
            this.tb_No.TabIndex = 461;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(19, 82);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(68, 26);
            this.textBox2.TabIndex = 461;
            // 
            // cb_Baud
            // 
            this.cb_Baud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Baud.FormattingEnabled = true;
            this.cb_Baud.Items.AddRange(new object[] {
            "300",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "74880",
            "115200"});
            this.cb_Baud.Location = new System.Drawing.Point(93, 81);
            this.cb_Baud.Name = "cb_Baud";
            this.cb_Baud.Size = new System.Drawing.Size(68, 28);
            this.cb_Baud.TabIndex = 462;
            // 
            // cb_Data
            // 
            this.cb_Data.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Data.FormattingEnabled = true;
            this.cb_Data.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cb_Data.Location = new System.Drawing.Point(176, 81);
            this.cb_Data.Name = "cb_Data";
            this.cb_Data.Size = new System.Drawing.Size(68, 28);
            this.cb_Data.TabIndex = 462;
            // 
            // cb_Parity
            // 
            this.cb_Parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Parity.FormattingEnabled = true;
            this.cb_Parity.Items.AddRange(new object[] {
            "ODD",
            "EVEN"});
            this.cb_Parity.Location = new System.Drawing.Point(256, 81);
            this.cb_Parity.Name = "cb_Parity";
            this.cb_Parity.Size = new System.Drawing.Size(68, 28);
            this.cb_Parity.TabIndex = 462;
            // 
            // cb_Stop
            // 
            this.cb_Stop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Stop.FormattingEnabled = true;
            this.cb_Stop.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb_Stop.Location = new System.Drawing.Point(332, 81);
            this.cb_Stop.Name = "cb_Stop";
            this.cb_Stop.Size = new System.Drawing.Size(68, 28);
            this.cb_Stop.TabIndex = 462;
            // 
            // cb_Flow
            // 
            this.cb_Flow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Flow.FormattingEnabled = true;
            this.cb_Flow.Items.AddRange(new object[] {
            "Xoff",
            "Xon"});
            this.cb_Flow.Location = new System.Drawing.Point(422, 81);
            this.cb_Flow.Name = "cb_Flow";
            this.cb_Flow.Size = new System.Drawing.Size(68, 28);
            this.cb_Flow.TabIndex = 462;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.btn_Write);
            this.groupBox1.Controls.Add(this.cb_Flow);
            this.groupBox1.Controls.Add(this.tb_No);
            this.groupBox1.Controls.Add(this.cb_Stop);
            this.groupBox1.Controls.Add(this.cb_Parity);
            this.groupBox1.Controls.Add(this.cb_Data);
            this.groupBox1.Controls.Add(this.cb_Baud);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.radio_Save);
            this.groupBox1.Controls.Add(this.rTB_Read);
            this.groupBox1.Controls.Add(this.rTB_Write);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lb_Data);
            this.groupBox1.Controls.Add(this.lb_Flow);
            this.groupBox1.Controls.Add(this.lb_Baud);
            this.groupBox1.Controls.Add(this.lb_Stop);
            this.groupBox1.Controls.Add(this.lb_ComPort);
            this.groupBox1.Controls.Add(this.lb_Parity);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(34, 175);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1199, 543);
            this.groupBox1.TabIndex = 463;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Port no                              ";
            // 
            // btn_Write
            // 
            this.btn_Write.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_Write.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_Write.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Write.ForeColor = System.Drawing.Color.White;
            this.btn_Write.Location = new System.Drawing.Point(176, 128);
            this.btn_Write.Name = "btn_Write";
            this.btn_Write.Size = new System.Drawing.Size(115, 48);
            this.btn_Write.TabIndex = 463;
            this.btn_Write.Text = "Write";
            this.btn_Write.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(784, 128);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(115, 48);
            this.button4.TabIndex = 463;
            this.button4.Text = "Read";
            this.button4.UseVisualStyleBackColor = false;
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
            ((System.ComponentModel.ISupportInitialize)(this.dGV_SerialList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Label lb_Flow;
        private System.Windows.Forms.Label lb_Baud;
        private System.Windows.Forms.Label lb_Stop;
        private System.Windows.Forms.Label lb_Parity;
        private System.Windows.Forms.ComboBox cb_Baud;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox tb_No;
        private System.Windows.Forms.ComboBox cb_Parity;
        private System.Windows.Forms.ComboBox cb_Data;
        private System.Windows.Forms.ComboBox cb_Flow;
        private System.Windows.Forms.ComboBox cb_Stop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Write;
        private System.Windows.Forms.Button button4;
    }
}