namespace Victor
{
    partial class vwEthernet
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
            _Release();
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Pnl_Item = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_Proc = new System.Windows.Forms.ComboBox();
            this.cb_Host = new System.Windows.Forms.ComboBox();
            this.btn_WriteClient = new System.Windows.Forms.Button();
            this.btn_ServerDisconn = new System.Windows.Forms.Button();
            this.btn_ServerConn = new System.Windows.Forms.Button();
            this.btn_WriteServer = new System.Windows.Forms.Button();
            this.tb_No = new System.Windows.Forms.TextBox();
            this.tb_Port = new System.Windows.Forms.TextBox();
            this.tb_IP = new System.Windows.Forms.TextBox();
            this.tb_Name = new System.Windows.Forms.TextBox();
            this.radio_Save = new System.Windows.Forms.RadioButton();
            this.rTB_ClientData = new System.Windows.Forms.RichTextBox();
            this.rTB_ServerData = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_Portno = new System.Windows.Forms.Label();
            this.lb_IP = new System.Windows.Forms.Label();
            this.lb_Host = new System.Windows.Forms.Label();
            this.lb_IPaddress = new System.Windows.Forms.Label();
            this.lb_Protocol = new System.Windows.Forms.Label();
            this.dGV_EthernetList = new System.Windows.Forms.DataGridView();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.rTB_ServerStatus = new System.Windows.Forms.RichTextBox();
            this.rTB_ClientStatus = new System.Windows.Forms.RichTextBox();
            this.btn_ClientConn = new System.Windows.Forms.Button();
            this.btn_ClientDisconn = new System.Windows.Forms.Button();
            this.Pnl_Item.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_EthernetList)).BeginInit();
            this.SuspendLayout();
            // 
            // Pnl_Item
            // 
            this.Pnl_Item.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.Pnl_Item.Controls.Add(this.button3);
            this.Pnl_Item.Controls.Add(this.button2);
            this.Pnl_Item.Controls.Add(this.button1);
            this.Pnl_Item.Controls.Add(this.groupBox1);
            this.Pnl_Item.Controls.Add(this.dGV_EthernetList);
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
            this.groupBox1.Controls.Add(this.cb_Proc);
            this.groupBox1.Controls.Add(this.cb_Host);
            this.groupBox1.Controls.Add(this.btn_WriteClient);
            this.groupBox1.Controls.Add(this.btn_ClientDisconn);
            this.groupBox1.Controls.Add(this.btn_ClientConn);
            this.groupBox1.Controls.Add(this.btn_ServerDisconn);
            this.groupBox1.Controls.Add(this.btn_ServerConn);
            this.groupBox1.Controls.Add(this.btn_WriteServer);
            this.groupBox1.Controls.Add(this.tb_No);
            this.groupBox1.Controls.Add(this.tb_Port);
            this.groupBox1.Controls.Add(this.tb_IP);
            this.groupBox1.Controls.Add(this.tb_Name);
            this.groupBox1.Controls.Add(this.radio_Save);
            this.groupBox1.Controls.Add(this.rTB_ClientData);
            this.groupBox1.Controls.Add(this.rTB_ClientStatus);
            this.groupBox1.Controls.Add(this.rTB_ServerStatus);
            this.groupBox1.Controls.Add(this.rTB_ServerData);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lb_Portno);
            this.groupBox1.Controls.Add(this.lb_IP);
            this.groupBox1.Controls.Add(this.lb_Host);
            this.groupBox1.Controls.Add(this.lb_IPaddress);
            this.groupBox1.Controls.Add(this.lb_Protocol);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 155);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1257, 597);
            this.groupBox1.TabIndex = 463;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IP no                       ";
            // 
            // cb_Proc
            // 
            this.cb_Proc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Proc.FormattingEnabled = true;
            this.cb_Proc.Location = new System.Drawing.Point(378, 82);
            this.cb_Proc.Name = "cb_Proc";
            this.cb_Proc.Size = new System.Drawing.Size(68, 37);
            this.cb_Proc.TabIndex = 464;
            // 
            // cb_Host
            // 
            this.cb_Host.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Host.FormattingEnabled = true;
            this.cb_Host.Location = new System.Drawing.Point(306, 81);
            this.cb_Host.Name = "cb_Host";
            this.cb_Host.Size = new System.Drawing.Size(68, 37);
            this.cb_Host.TabIndex = 464;
            // 
            // btn_WriteClient
            // 
            this.btn_WriteClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_WriteClient.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_WriteClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_WriteClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(200)))), ((int)(((byte)(30)))));
            this.btn_WriteClient.Location = new System.Drawing.Point(1093, 131);
            this.btn_WriteClient.Name = "btn_WriteClient";
            this.btn_WriteClient.Size = new System.Drawing.Size(115, 48);
            this.btn_WriteClient.TabIndex = 463;
            this.btn_WriteClient.Text = "Write";
            this.btn_WriteClient.UseVisualStyleBackColor = false;
            this.btn_WriteClient.Click += new System.EventHandler(this.Click_ClientWrite);
            // 
            // btn_ServerDisconn
            // 
            this.btn_ServerDisconn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_ServerDisconn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_ServerDisconn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ServerDisconn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btn_ServerDisconn.Location = new System.Drawing.Point(320, 131);
            this.btn_ServerDisconn.Name = "btn_ServerDisconn";
            this.btn_ServerDisconn.Size = new System.Drawing.Size(115, 48);
            this.btn_ServerDisconn.TabIndex = 463;
            this.btn_ServerDisconn.Text = "DisCon";
            this.btn_ServerDisconn.UseVisualStyleBackColor = false;
            this.btn_ServerDisconn.Click += new System.EventHandler(this.Click_PortClose);
            // 
            // btn_ServerConn
            // 
            this.btn_ServerConn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_ServerConn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_ServerConn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ServerConn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btn_ServerConn.Location = new System.Drawing.Point(199, 131);
            this.btn_ServerConn.Name = "btn_ServerConn";
            this.btn_ServerConn.Size = new System.Drawing.Size(115, 48);
            this.btn_ServerConn.TabIndex = 463;
            this.btn_ServerConn.Text = "Connect";
            this.btn_ServerConn.UseVisualStyleBackColor = false;
            this.btn_ServerConn.Click += new System.EventHandler(this.Click_PortOpen);
            // 
            // btn_WriteServer
            // 
            this.btn_WriteServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_WriteServer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_WriteServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_WriteServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(200)))), ((int)(((byte)(30)))));
            this.btn_WriteServer.Location = new System.Drawing.Point(441, 131);
            this.btn_WriteServer.Name = "btn_WriteServer";
            this.btn_WriteServer.Size = new System.Drawing.Size(115, 48);
            this.btn_WriteServer.TabIndex = 463;
            this.btn_WriteServer.Text = "Write";
            this.btn_WriteServer.UseVisualStyleBackColor = false;
            this.btn_WriteServer.Click += new System.EventHandler(this.Click_ServerWrite);
            // 
            // tb_No
            // 
            this.tb_No.Location = new System.Drawing.Point(88, 0);
            this.tb_No.Name = "tb_No";
            this.tb_No.Size = new System.Drawing.Size(87, 35);
            this.tb_No.TabIndex = 461;
            this.tb_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Port
            // 
            this.tb_Port.Location = new System.Drawing.Point(231, 82);
            this.tb_Port.Name = "tb_Port";
            this.tb_Port.Size = new System.Drawing.Size(68, 35);
            this.tb_Port.TabIndex = 461;
            this.tb_Port.Text = "1000";
            this.tb_Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_IP
            // 
            this.tb_IP.Location = new System.Drawing.Point(93, 82);
            this.tb_IP.Name = "tb_IP";
            this.tb_IP.Size = new System.Drawing.Size(134, 35);
            this.tb_IP.TabIndex = 461;
            this.tb_IP.Text = "192.168.0.1";
            this.tb_IP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Name
            // 
            this.tb_Name.Location = new System.Drawing.Point(19, 82);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(68, 35);
            this.tb_Name.TabIndex = 461;
            this.tb_Name.Text = "Net00";
            this.tb_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // rTB_ClientData
            // 
            this.rTB_ClientData.Location = new System.Drawing.Point(675, 185);
            this.rTB_ClientData.Name = "rTB_ClientData";
            this.rTB_ClientData.Size = new System.Drawing.Size(533, 325);
            this.rTB_ClientData.TabIndex = 460;
            this.rTB_ClientData.Text = "Client Data";
            // 
            // rTB_ServerData
            // 
            this.rTB_ServerData.Location = new System.Drawing.Point(23, 185);
            this.rTB_ServerData.Name = "rTB_ServerData";
            this.rTB_ServerData.Size = new System.Drawing.Size(533, 325);
            this.rTB_ServerData.TabIndex = 460;
            this.rTB_ServerData.Text = "Server Data";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label3.Location = new System.Drawing.Point(678, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 46);
            this.label3.TabIndex = 0;
            this.label3.Text = "Client";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label2.Location = new System.Drawing.Point(25, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 46);
            this.label2.TabIndex = 0;
            this.label2.Text = "Server";
            // 
            // lb_Portno
            // 
            this.lb_Portno.AutoSize = true;
            this.lb_Portno.Location = new System.Drawing.Point(239, 58);
            this.lb_Portno.Name = "lb_Portno";
            this.lb_Portno.Size = new System.Drawing.Size(90, 29);
            this.lb_Portno.TabIndex = 0;
            this.lb_Portno.Text = "Port no";
            // 
            // lb_IP
            // 
            this.lb_IP.AutoSize = true;
            this.lb_IP.Location = new System.Drawing.Point(84, 58);
            this.lb_IP.Name = "lb_IP";
            this.lb_IP.Size = new System.Drawing.Size(130, 29);
            this.lb_IP.TabIndex = 0;
            this.lb_IP.Text = "IP Address";
            // 
            // lb_Host
            // 
            this.lb_Host.AutoSize = true;
            this.lb_Host.Location = new System.Drawing.Point(319, 59);
            this.lb_Host.Name = "lb_Host";
            this.lb_Host.Size = new System.Drawing.Size(62, 29);
            this.lb_Host.TabIndex = 0;
            this.lb_Host.Text = "Host";
            // 
            // lb_IPaddress
            // 
            this.lb_IPaddress.AutoSize = true;
            this.lb_IPaddress.Location = new System.Drawing.Point(28, 58);
            this.lb_IPaddress.Name = "lb_IPaddress";
            this.lb_IPaddress.Size = new System.Drawing.Size(78, 29);
            this.lb_IPaddress.TabIndex = 0;
            this.lb_IPaddress.Text = "Name";
            // 
            // lb_Protocol
            // 
            this.lb_Protocol.AutoSize = true;
            this.lb_Protocol.Location = new System.Drawing.Point(377, 59);
            this.lb_Protocol.Name = "lb_Protocol";
            this.lb_Protocol.Size = new System.Drawing.Size(103, 29);
            this.lb_Protocol.TabIndex = 0;
            this.lb_Protocol.Text = "Protocol";
            // 
            // dGV_EthernetList
            // 
            this.dGV_EthernetList.AllowUserToAddRows = false;
            this.dGV_EthernetList.AllowUserToDeleteRows = false;
            this.dGV_EthernetList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGV_EthernetList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dGV_EthernetList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGV_EthernetList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dGV_EthernetList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGV_EthernetList.DefaultCellStyle = dataGridViewCellStyle6;
            this.dGV_EthernetList.Location = new System.Drawing.Point(12, 14);
            this.dGV_EthernetList.Name = "dGV_EthernetList";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGV_EthernetList.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dGV_EthernetList.RowHeadersVisible = false;
            this.dGV_EthernetList.RowHeadersWidth = 62;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dGV_EthernetList.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dGV_EthernetList.RowTemplate.Height = 23;
            this.dGV_EthernetList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGV_EthernetList.Size = new System.Drawing.Size(1257, 125);
            this.dGV_EthernetList.TabIndex = 457;
            this.dGV_EthernetList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_EthernetList_CellClick);
            // 
            // rTB_ServerStatus
            // 
            this.rTB_ServerStatus.Location = new System.Drawing.Point(23, 516);
            this.rTB_ServerStatus.Name = "rTB_ServerStatus";
            this.rTB_ServerStatus.Size = new System.Drawing.Size(533, 50);
            this.rTB_ServerStatus.TabIndex = 460;
            this.rTB_ServerStatus.Text = "Server Status";
            // 
            // rTB_ClientStatus
            // 
            this.rTB_ClientStatus.Location = new System.Drawing.Point(675, 522);
            this.rTB_ClientStatus.Name = "rTB_ClientStatus";
            this.rTB_ClientStatus.Size = new System.Drawing.Size(533, 50);
            this.rTB_ClientStatus.TabIndex = 460;
            this.rTB_ClientStatus.Text = "Client Statue";
            // 
            // btn_ClientConn
            // 
            this.btn_ClientConn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_ClientConn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_ClientConn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ClientConn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btn_ClientConn.Location = new System.Drawing.Point(851, 131);
            this.btn_ClientConn.Name = "btn_ClientConn";
            this.btn_ClientConn.Size = new System.Drawing.Size(115, 48);
            this.btn_ClientConn.TabIndex = 463;
            this.btn_ClientConn.Text = "Connect";
            this.btn_ClientConn.UseVisualStyleBackColor = false;
            this.btn_ClientConn.Click += new System.EventHandler(this.Click_PortOpen);
            // 
            // btn_ClientDisconn
            // 
            this.btn_ClientDisconn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_ClientDisconn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_ClientDisconn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ClientDisconn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btn_ClientDisconn.Location = new System.Drawing.Point(972, 131);
            this.btn_ClientDisconn.Name = "btn_ClientDisconn";
            this.btn_ClientDisconn.Size = new System.Drawing.Size(115, 48);
            this.btn_ClientDisconn.TabIndex = 463;
            this.btn_ClientDisconn.Text = "DisCon";
            this.btn_ClientDisconn.UseVisualStyleBackColor = false;
            this.btn_ClientDisconn.Click += new System.EventHandler(this.Click_PortClose);
            // 
            // vwEthernet
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Pnl_Item);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "vwEthernet";
            this.Size = new System.Drawing.Size(1280, 768);
            this.Pnl_Item.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_EthernetList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Pnl_Item;
        private System.Windows.Forms.RadioButton radio_Save;
        private System.Windows.Forms.DataGridView dGV_EthernetList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox rTB_ServerData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rTB_ClientData;
        private System.Windows.Forms.Label lb_IPaddress;
        private System.Windows.Forms.Label lb_Portno;
        private System.Windows.Forms.Label lb_IP;
        private System.Windows.Forms.Label lb_Host;
        private System.Windows.Forms.Label lb_Protocol;
        private System.Windows.Forms.TextBox tb_Name;
        private System.Windows.Forms.TextBox tb_No;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_WriteServer;
        private System.Windows.Forms.Button btn_WriteClient;
        private System.Windows.Forms.Button btn_ServerDisconn;
        private System.Windows.Forms.Button btn_ServerConn;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox tb_Port;
        private System.Windows.Forms.TextBox tb_IP;
        private System.Windows.Forms.ComboBox cb_Proc;
        private System.Windows.Forms.ComboBox cb_Host;
        private System.Windows.Forms.RichTextBox rTB_ServerStatus;
        private System.Windows.Forms.RichTextBox rTB_ClientStatus;
        private System.Windows.Forms.Button btn_ClientDisconn;
        private System.Windows.Forms.Button btn_ClientConn;
    }
}