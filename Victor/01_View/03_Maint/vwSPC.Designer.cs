namespace Victor
{
    partial class vwSPC
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Pnl_Item = new System.Windows.Forms.Panel();
            this.grp_Chart = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbChartsel = new System.Windows.Forms.ComboBox();
            this.chart_Spc = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rTB_SpcData = new System.Windows.Forms.RichTextBox();
            this.rTB_SpcName = new System.Windows.Forms.RichTextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.grp_Error = new System.Windows.Forms.GroupBox();
            this.dGV_DataList = new System.Windows.Forms.DataGridView();
            this.Pnl_Item.SuspendLayout();
            this.grp_Chart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Spc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.grp_Error.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_DataList)).BeginInit();
            this.SuspendLayout();
            // 
            // Pnl_Item
            // 
            this.Pnl_Item.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.Pnl_Item.Controls.Add(this.grp_Chart);
            this.Pnl_Item.Controls.Add(this.groupBox2);
            this.Pnl_Item.Controls.Add(this.grp_Error);
            this.Pnl_Item.Location = new System.Drawing.Point(0, 0);
            this.Pnl_Item.Name = "Pnl_Item";
            this.Pnl_Item.Size = new System.Drawing.Size(1280, 768);
            this.Pnl_Item.TabIndex = 460;
            // 
            // grp_Chart
            // 
            this.grp_Chart.Controls.Add(this.label1);
            this.grp_Chart.Controls.Add(this.cbChartsel);
            this.grp_Chart.Controls.Add(this.chart_Spc);
            this.grp_Chart.Controls.Add(this.pictureBox1);
            this.grp_Chart.ForeColor = System.Drawing.Color.White;
            this.grp_Chart.Location = new System.Drawing.Point(3, 3);
            this.grp_Chart.Name = "grp_Chart";
            this.grp_Chart.Size = new System.Drawing.Size(630, 466);
            this.grp_Chart.TabIndex = 463;
            this.grp_Chart.TabStop = false;
            this.grp_Chart.Text = "Chart";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(362, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Chart 선택";
            // 
            // cbChartsel
            // 
            this.cbChartsel.FormattingEnabled = true;
            this.cbChartsel.Location = new System.Drawing.Point(444, 20);
            this.cbChartsel.Name = "cbChartsel";
            this.cbChartsel.Size = new System.Drawing.Size(180, 28);
            this.cbChartsel.TabIndex = 3;
            this.cbChartsel.SelectedIndexChanged += new System.EventHandler(this.cbChartsel_SelectedIndexChanged);
            // 
            // chart_Spc
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_Spc.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_Spc.Legends.Add(legend1);
            this.chart_Spc.Location = new System.Drawing.Point(84, 54);
            this.chart_Spc.Name = "chart_Spc";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart_Spc.Series.Add(series1);
            this.chart_Spc.Size = new System.Drawing.Size(486, 398);
            this.chart_Spc.TabIndex = 2;
            this.chart_Spc.Text = "chart1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(11, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(0, 0);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rTB_SpcData);
            this.groupBox2.Controls.Add(this.rTB_SpcName);
            this.groupBox2.Controls.Add(this.btn_Save);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(639, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(630, 466);
            this.groupBox2.TabIndex = 463;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "List Detail";
            // 
            // rTB_SpcData
            // 
            this.rTB_SpcData.Location = new System.Drawing.Point(12, 67);
            this.rTB_SpcData.Name = "rTB_SpcData";
            this.rTB_SpcData.Size = new System.Drawing.Size(488, 385);
            this.rTB_SpcData.TabIndex = 462;
            this.rTB_SpcData.Text = "Data List";
            // 
            // rTB_SpcName
            // 
            this.rTB_SpcName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTB_SpcName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rTB_SpcName.Location = new System.Drawing.Point(12, 29);
            this.rTB_SpcName.Name = "rTB_SpcName";
            this.rTB_SpcName.Size = new System.Drawing.Size(612, 30);
            this.rTB_SpcName.TabIndex = 461;
            this.rTB_SpcName.Text = "Data Title";
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_Save.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.ForeColor = System.Drawing.Color.White;
            this.btn_Save.Location = new System.Drawing.Point(506, 68);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(104, 67);
            this.btn_Save.TabIndex = 463;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.Click_Output);
            // 
            // grp_Error
            // 
            this.grp_Error.Controls.Add(this.dGV_DataList);
            this.grp_Error.ForeColor = System.Drawing.Color.LawnGreen;
            this.grp_Error.Location = new System.Drawing.Point(3, 475);
            this.grp_Error.Name = "grp_Error";
            this.grp_Error.Size = new System.Drawing.Size(1266, 290);
            this.grp_Error.TabIndex = 463;
            this.grp_Error.TabStop = false;
            this.grp_Error.Text = "Data collect";
            // 
            // dGV_DataList
            // 
            this.dGV_DataList.AllowUserToAddRows = false;
            this.dGV_DataList.AllowUserToDeleteRows = false;
            this.dGV_DataList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.dGV_DataList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dGV_DataList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGV_DataList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGV_DataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGV_DataList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dGV_DataList.Location = new System.Drawing.Point(8, 25);
            this.dGV_DataList.Name = "dGV_DataList";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGV_DataList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dGV_DataList.RowHeadersVisible = false;
            this.dGV_DataList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dGV_DataList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dGV_DataList.RowTemplate.Height = 23;
            this.dGV_DataList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGV_DataList.Size = new System.Drawing.Size(1252, 259);
            this.dGV_DataList.TabIndex = 457;
            this.dGV_DataList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_SpcList_CellClick);
            this.dGV_DataList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown);
            // 
            // vwSPC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Pnl_Item);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "vwSPC";
            this.Size = new System.Drawing.Size(1280, 768);
            this.Pnl_Item.ResumeLayout(false);
            this.grp_Chart.ResumeLayout(false);
            this.grp_Chart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Spc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.grp_Error.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_DataList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Pnl_Item;
        private System.Windows.Forms.DataGridView dGV_DataList;
        private System.Windows.Forms.GroupBox grp_Error;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.GroupBox grp_Chart;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox rTB_SpcData;
        private System.Windows.Forms.RichTextBox rTB_SpcName;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Spc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbChartsel;
    }
}