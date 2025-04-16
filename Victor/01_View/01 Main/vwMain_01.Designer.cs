using System.Windows.Forms;

namespace Victor
{
    public partial class vwMain_01 : UserControl
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label46 = new System.Windows.Forms.Label();
            this.pnl_Base = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart4 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tbText = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pnl_Menu = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbInt = new System.Windows.Forms.TextBox();
            this.tbFloat = new System.Windows.Forms.TextBox();
            this.roundBorderPanel1 = new MyUserControl.RoundBorderPanel();
            this.roundLabel1 = new MyUserControl.RoundLabel();
            this.orientedTextLabel1 = new Victor.OrientedTextLabel();
            this.ledToggleButton1 = new MyUserControl.LedToggleButton();
            this.roundConerButton1 = new Victor.RoundConerButton();
            this.pnl_Base.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).BeginInit();
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
            this.pnl_Base.Controls.Add(this.tableLayoutPanel1);
            this.pnl_Base.Controls.Add(this.roundBorderPanel1);
            this.pnl_Base.Controls.Add(this.roundLabel1);
            this.pnl_Base.Controls.Add(this.orientedTextLabel1);
            this.pnl_Base.Controls.Add(this.ledToggleButton1);
            this.pnl_Base.Controls.Add(this.roundConerButton1);
            this.pnl_Base.Controls.Add(this.tbFloat);
            this.pnl_Base.Controls.Add(this.tbInt);
            this.pnl_Base.Controls.Add(this.tbText);
            this.pnl_Base.Controls.Add(this.button2);
            this.pnl_Base.Controls.Add(this.button1);
            this.pnl_Base.Location = new System.Drawing.Point(3, 33);
            this.pnl_Base.Name = "pnl_Base";
            this.pnl_Base.Size = new System.Drawing.Size(1274, 768);
            this.pnl_Base.TabIndex = 453;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.chart1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chart2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chart3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chart4, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1031, 751);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // chart1
            // 
            chartArea5.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chart1.Legends.Add(legend5);
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chart1.Series.Add(series5);
            this.chart1.Size = new System.Drawing.Size(509, 369);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea6.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chart2.Legends.Add(legend6);
            this.chart2.Location = new System.Drawing.Point(518, 3);
            this.chart2.Name = "chart2";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "Series2";
            this.chart2.Series.Add(series6);
            this.chart2.Size = new System.Drawing.Size(509, 369);
            this.chart2.TabIndex = 0;
            this.chart2.Text = "chart2";
            // 
            // chart3
            // 
            chartArea7.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.chart3.Legends.Add(legend7);
            this.chart3.Location = new System.Drawing.Point(3, 378);
            this.chart3.Name = "chart3";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Series3";
            this.chart3.Series.Add(series7);
            this.chart3.Size = new System.Drawing.Size(509, 370);
            this.chart3.TabIndex = 0;
            this.chart3.Text = "chart3";
            // 
            // chart4
            // 
            chartArea8.Name = "ChartArea1";
            this.chart4.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.chart4.Legends.Add(legend8);
            this.chart4.Location = new System.Drawing.Point(518, 378);
            this.chart4.Name = "chart4";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "Series4";
            this.chart4.Series.Add(series8);
            this.chart4.Size = new System.Drawing.Size(509, 370);
            this.chart4.TabIndex = 0;
            this.chart4.Text = "chart4";
            // 
            // tbText
            // 
            this.tbText.Location = new System.Drawing.Point(1078, 151);
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(181, 35);
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
            this.button2.Location = new System.Drawing.Point(1078, 74);
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
            this.button1.Location = new System.Drawing.Point(1078, 18);
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
            // timer1
            // 
            this.timer1.Interval = 33;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tbInt
            // 
            this.tbInt.Location = new System.Drawing.Point(1077, 192);
            this.tbInt.Name = "tbInt";
            this.tbInt.Size = new System.Drawing.Size(181, 35);
            this.tbInt.TabIndex = 3;
            this.tbInt.Text = "1234";
            this.tbInt.Click += new System.EventHandler(this.tbTest_Click);
            // 
            // tbFloat
            // 
            this.tbFloat.Location = new System.Drawing.Point(1077, 233);
            this.tbFloat.Name = "tbFloat";
            this.tbFloat.Size = new System.Drawing.Size(181, 35);
            this.tbFloat.TabIndex = 3;
            this.tbFloat.Text = "8.345";
            this.tbFloat.Click += new System.EventHandler(this.tbTest_Click);
            // 
            // roundBorderPanel1
            // 
            this.roundBorderPanel1.BorderColor = System.Drawing.Color.White;
            this.roundBorderPanel1.BorderWidth = 5;
            this.roundBorderPanel1.EnableBorder = true;
            this.roundBorderPanel1.Fill = false;
            this.roundBorderPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.roundBorderPanel1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.roundBorderPanel1.Location = new System.Drawing.Point(1040, 397);
            this.roundBorderPanel1.Name = "roundBorderPanel1";
            this.roundBorderPanel1.PaddingSize = 5;
            this.roundBorderPanel1.Radius = 10;
            this.roundBorderPanel1.Size = new System.Drawing.Size(218, 72);
            this.roundBorderPanel1.TabIndex = 8;
            this.roundBorderPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.roundBorderPanel1_Paint);
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
            this.roundLabel1.Location = new System.Drawing.Point(1036, 577);
            this.roundLabel1.Name = "roundLabel1";
            this.roundLabel1.Size = new System.Drawing.Size(148, 29);
            this.roundLabel1.TabIndex = 7;
            this.roundLabel1.Text = "roundLabel1";
            this.roundLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // orientedTextLabel1
            // 
            this.orientedTextLabel1.AutoSize = true;
            this.orientedTextLabel1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.orientedTextLabel1.Location = new System.Drawing.Point(1036, 545);
            this.orientedTextLabel1.Name = "orientedTextLabel1";
            this.orientedTextLabel1.RotationAngle = 0D;
            this.orientedTextLabel1.Size = new System.Drawing.Size(222, 29);
            this.orientedTextLabel1.TabIndex = 6;
            this.orientedTextLabel1.Text = "orientedTextLabel1";
            this.orientedTextLabel1.TextDirection = Victor.Direction.Clockwise;
            this.orientedTextLabel1.TextOrientation = Victor.Orientation.Rotate;
            // 
            // ledToggleButton1
            // 
            this.ledToggleButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.ledToggleButton1.BorderRadius = 1;
            this.ledToggleButton1.BorderSize = 0;
            this.ledToggleButton1.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold);
            this.ledToggleButton1.Location = new System.Drawing.Point(1040, 485);
            this.ledToggleButton1.Name = "ledToggleButton1";
            this.ledToggleButton1.OffColor = System.Drawing.Color.DarkGray;
            this.ledToggleButton1.OnColor = System.Drawing.Color.OrangeRed;
            this.ledToggleButton1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.ledToggleButton1.SetLED = false;
            this.ledToggleButton1.Size = new System.Drawing.Size(218, 57);
            this.ledToggleButton1.TabIndex = 5;
            this.ledToggleButton1.Text = "ledToggleButton1";
            this.ledToggleButton1.Tickness = 5;
            this.ledToggleButton1.UseVisualStyleBackColor = true;
            // 
            // roundConerButton1
            // 
            this.roundConerButton1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.roundConerButton1.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.roundConerButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.roundConerButton1.BorderRadius = 10;
            this.roundConerButton1.BorderSize = 0;
            this.roundConerButton1.FlatAppearance.BorderSize = 0;
            this.roundConerButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundConerButton1.ForeColor = System.Drawing.Color.White;
            this.roundConerButton1.Location = new System.Drawing.Point(1037, 615);
            this.roundConerButton1.Name = "roundConerButton1";
            this.roundConerButton1.ShiftString = "";
            this.roundConerButton1.ShiftStringColor = System.Drawing.Color.Aqua;
            this.roundConerButton1.Size = new System.Drawing.Size(144, 40);
            this.roundConerButton1.TabIndex = 4;
            this.roundConerButton1.Text = "vwMain_01";
            this.roundConerButton1.TextColor = System.Drawing.Color.White;
            this.roundConerButton1.UseVisualStyleBackColor = false;
            this.roundConerButton1.Click += new System.EventHandler(this.roundConerButton1_Click);
            // 
            // vwMain_01
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Controls.Add(this.pnl_Base);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.pnl_Menu);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "vwMain_01";
            this.Size = new System.Drawing.Size(1280, 804);
            this.Load += new System.EventHandler(this.vwMain_Load);
            this.pnl_Base.ResumeLayout(false);
            this.pnl_Base.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).EndInit();
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
        private Victor.OrientedTextLabel orientedTextLabel1;
        private MyUserControl.LedToggleButton ledToggleButton1;
        private Timer timer1;
        private TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart4;
        private TextBox tbFloat;
        private TextBox tbInt;
    }
}
