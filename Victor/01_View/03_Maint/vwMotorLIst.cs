using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Diagnostics;


namespace Victor
{
    public partial class vwMotorList : UserControl
    {
        private string sMotorListPath;
        private string sFolderPath;
        private string sFileName;

        static string[,] csvData;
        static int nMotorCnt = 0;
        static int nSelRow;

        /// <summary>
        /// 모터 번호 Change 에 따른 동시 Display 모터 번호
        /// 모터 축번호는 1부터 시작
        /// </summary>
        int[,] nGridAxis =
        {
            {1, 2, 3, 4},
            {2, 3, 4, 5},
            {3, 4, 5, 6},
            {4, 5, 6, 7},
            {5, 6, 7, 8},
            {6, 7, 8, 1},
            {7, 8, 1, 2},
            {8, 1, 2, 3},
        };


        public vwMotorList()
        {
            InitializeComponent();
            Init_View_Set();
            Init_Timer();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            dGV_MotorList.ReadOnly = true;
            dGV_MotorList.CurrentCell = null;

            cb_2.FlatStyle = FlatStyle.Flat;
            cb_2.BackColor = Gcolor.ColorNotic;
            cb_2.ForeColor = Color.White;

        }

        private void Init_Timer()
        {
            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            t.Tick += new EventHandler(TimerEvent);
            t.Interval = 20;
            t.Start();
        }
        private void Init_View_Set()
        {

            sMotorListPath = GVar.PATH_EQUIP_MotorList;
            int FindDot = sMotorListPath.LastIndexOf(".");
            int Lastsp = sMotorListPath.LastIndexOf("\\");

            sFileName = sMotorListPath.Substring(Lastsp + 1, FindDot - Lastsp - 1);
            sFolderPath = sMotorListPath.Replace(sFileName + ".csv", "");
            if (Read_File_MotorList() == 0)
            {
                Process.GetCurrentProcess().Kill();
            }

            Init_Property_Setup();
            Init_MotorList_Grid_Setup();
            nSelRow = 0;
            Propert_Change(0, true);
        }

           

        private void Init_Property_Setup()
        {
            int i = 0;
            for (i = 0; i < (nMotorCnt - 1); i++)
            {
                cb_0.Items.Add(CData.tMotor[i].swAxis);
                cb_1.Items.Add(CData.tMotor[i].hwAxis);
                cb_2.Items.Add(CData.tMotor[i].sName);
            }
            for (i = 0; i < (int)mMotor_Env.sMode.Length; i++)
            {
                cb_4.Items.Add(mMotor_Env.sMode[i]);
            }
            for (i = 0; i < (int)mMotor_Env.sDir.Length; i++)
            {
                cb_6.Items.Add(mMotor_Env.sDir[i]);
            }
            for (i = 0; i < (int)mMotor_Env.sHome_Logic.Length; i++)
            {
                cb_9.Items.Add(mMotor_Env.sHome_Logic[i]);
            }
            for (i = 0; i < (int)mMotor_Env.sSen_Coil.Length; i++)
            {
                cb_10.Items.Add(mMotor_Env.sSen_Coil[i]);
                cb_11.Items.Add(mMotor_Env.sSen_Coil[i]);
                cb_12.Items.Add(mMotor_Env.sSen_Coil[i]);
            }
            for (i = 0; i < (int)mMotor_Env.sUse.Length; i++)
            {
                cb_13.Items.Add(mMotor_Env.sUse[i]);
            }
        }

        private void Init_MotorList_Grid_Setup()
        {
            dGV_MotorList.DoubleBuffered(true);

            var dt = new DataTable();

            dt.Columns.Add("Axis no");
            dt.Columns.Add("NAME");
            dt.Columns.Add("Servo");
            dt.Columns.Add("Command");
            dt.Columns.Add("Encoder");
            dt.Columns.Add("HD");
            dt.Columns.Add("Home");
            dt.Columns.Add("- Limit");
            dt.Columns.Add("+ Limit");
            dt.Columns.Add("Alarm");
            dt.Columns.Add("Z Phase");
            dt.Columns.Add("InPos");
            dt.Rows.Add("0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11");
            dt.Rows.Add("A1", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11");
            dt.Rows.Add("B1", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11");
            dt.Rows.Add("C1", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11");
            dGV_MotorList.DataSource = dt;

            dGV_MotorList.Columns[(int)eMotorListGrid.swAxis].Width = 70;
            dGV_MotorList.Columns[(int)eMotorListGrid.Name].Width = 110;
            dGV_MotorList.Columns[(int)eMotorListGrid.Servo].Width = 70;
            dGV_MotorList.Columns[(int)eMotorListGrid.Cmd_mm].Width = 120;
            dGV_MotorList.Columns[(int)eMotorListGrid.Enc_mm].Width = 120;
            dGV_MotorList.Columns[(int)eMotorListGrid.Home_End].Width = 130;
            dGV_MotorList.Columns[(int)eMotorListGrid.Sen_Home].Width = 110;
            dGV_MotorList.Columns[(int)eMotorListGrid.Sen_NLimit].Width = 110;
            dGV_MotorList.Columns[(int)eMotorListGrid.Sen_PLimit].Width = 110;
            dGV_MotorList.Columns[(int)eMotorListGrid.Alarm_In].Width = 100;
            dGV_MotorList.Columns[(int)eMotorListGrid.ZPhase_In].Width = 100;
            dGV_MotorList.Columns[(int)eMotorListGrid.Inpos_In].Width = 100;

            dGV_MotorList.Height = 120;

        }
        public void Open()
        {
            switch (mViewPage.nRcpPage)
            {
                case 0:
                    Read_File_MotorList();

                    break;
                case 312:
                    Init_View_Set();
                    break;
                case 313:


                    break;
                default: break;

            }
        }
        public void Close()
        {
            switch (mViewPage.nRcpPage)
            {
                case 0:
                    {
                    }
                    break;
                case 311:
                    {
                        //Pnl_Item.Controls.Remove(m_vw02Common);
                        //m_vw02Common.Close();                      
                    }
                    break;
                case 312:
                    {
                        //m_vw02Loader.Close();
                        //Pnl_Item.Controls.Remove(m_vw02Loader);
                    }
                    break;
                default: break;
            }
        }

        public int Get_UI_MotorEdit()
        {
            int nSelName = cb_2.SelectedIndex;

            csvData[nSelName + 1, (int)eMotor.swAxis] = cb_0.SelectedItem.ToString();
            csvData[nSelName + 1, (int)eMotor.hwAxis] = cb_1.SelectedItem.ToString();
            csvData[nSelName + 1, (int)eMotor.Name] = cb_2.SelectedItem.ToString();
            //csvData[nSelName + 1, (int)eMotor.Use] = tB_LeadPitch;
            csvData[nSelName + 1, (int)eMotor.Servo] = cb_4.SelectedIndex.ToString();
            csvData[nSelName + 1, (int)eMotor.Lead_Pitch] = tB_LeadPitch.Text;
            csvData[nSelName + 1, (int)eMotor.Mv_Dir] = cb_6.SelectedIndex.ToString();
            csvData[nSelName + 1, (int)eMotor.InPosWidth] = tB_Inposition.Text;
            csvData[nSelName + 1, (int)eMotor.PP1] = tB_PP1.Text;
            csvData[nSelName + 1, (int)eMotor.HomeLogic] = cb_9.SelectedIndex.ToString();
            csvData[nSelName + 1, (int)eMotor.Home_Coil] = cb_10.SelectedIndex.ToString();
            csvData[nSelName + 1, (int)eMotor.Limit_Coil] = cb_11.SelectedIndex.ToString();
            csvData[nSelName + 1, (int)eMotor.Alarm_Coil] = cb_12.SelectedIndex.ToString();
            csvData[nSelName + 1, (int)eMotor.Z_Phase] = cb_13.SelectedIndex.ToString();
            return 0;
        }

        public int Read_File_MotorList()
        {
            nMotorCnt = 0;
            int nArrayCnt = 0;
            //dGV_SerialList.DataSource = Display_File_SerialConfig(sMotorListPath);
            csvData = CSV.OpenMotorCSVFile(sMotorListPath, out nMotorCnt);
            if (csvData == null)
            {
                MessageBox.Show("Read_File_MotorList Error", " MotorList.csv 화일 Abnormal!!", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            foreach (string str in csvData)
            {
                if (string.IsNullOrEmpty(csvData[nArrayCnt + 1, (int)eMotor.swAxis]))
                {
                    return -1;
                }
                else if (nArrayCnt >= (nMotorCnt-1))
                {
                    break;                    
                }
                else {
                    CData.tMotor[nArrayCnt].swAxis          = int.Parse(csvData[nArrayCnt + 1, (int)eMotor.swAxis]);
                    CData.tMotor[nArrayCnt].hwAxis          = int.Parse(csvData[nArrayCnt + 1, (int)eMotor.hwAxis]);
                    CData.tMotor[nArrayCnt].sName           = csvData[nArrayCnt + 1, (int)eMotor.Name];
                    CData.tMotor[nArrayCnt].sUse            = csvData[nArrayCnt + 1, (int)eMotor.Use];
                    CData.tMotor[nArrayCnt].sMode           = csvData[nArrayCnt + 1, (int)eMotor.Servo];
                    CData.tMotor[nArrayCnt].nLead_Pitch     = int.Parse(csvData[nArrayCnt + 1, (int)eMotor.Lead_Pitch]);
                    CData.tMotor[nArrayCnt].sMv_Dir         = csvData[nArrayCnt + 1, (int)eMotor.Mv_Dir];
                    CData.tMotor[nArrayCnt].nInPosWidth     = int.Parse(csvData[nArrayCnt + 1, (int)eMotor.InPosWidth]);
                    CData.tMotor[nArrayCnt].nPP1            = int.Parse(csvData[nArrayCnt + 1, (int)eMotor.PP1]);
                    CData.tMotor[nArrayCnt].sHomeLogic      = csvData[nArrayCnt + 1, (int)eMotor.HomeLogic];
                    CData.tMotor[nArrayCnt].sHome_Coil      = csvData[nArrayCnt + 1, (int)eMotor.Home_Coil];
                    CData.tMotor[nArrayCnt].sLimit_Coil     = csvData[nArrayCnt + 1, (int)eMotor.Limit_Coil];
                    CData.tMotor[nArrayCnt].sAlarm_Coil     = csvData[nArrayCnt + 1, (int)eMotor.Alarm_Coil];
                    CData.tMotor[nArrayCnt].sZ_Phase        = csvData[nArrayCnt + 1, (int)eMotor.Z_Phase];

                    nArrayCnt++;
                }
            }
            //dGV_SerialList.Rows[0].Selected = true;
            return 1;
        }

        static int nEnc_Value;
        private void TimerEvent(Object myObject, EventArgs myEventArgs)
        {
            DataGridViewRow row = dGV_MotorList.Rows[0];
            row.Cells[(int)eMotorListGrid.Enc_mm].Value = nEnc_Value;
            if (nEnc_Value > 99999999) nEnc_Value = 0;
            else nEnc_Value++;

        }
        public int Write_File_MotorList()
        {
            bool create = CSV.SaveMotorCSVFile(this.sMotorListPath, csvData, overwrite: true);
            return 0;
        }                

        private void Click_Save(object sender, EventArgs e)
        {
            Get_UI_MotorEdit();
            Write_File_MotorList();
            Read_File_MotorList();

            int nSelMotorName = (int)cb_2.SelectedIndex;
            Propert_Change(nSelMotorName);
            MotorGrid_Change(nSelMotorName);
        }

        private void dGV_SerialList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewColumn item in dGV_MotorList.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dGV_MotorList.CurrentCell = null;


            //dGV_MotorListGrid_SelNum(true);
        }
        
        private void Click_PortOpen(object sender, EventArgs e)
        {
            int nLineCnt = 0;
            csvData = CSV.OpenMotorCSVFile(sMotorListPath, out nLineCnt);
        }


        private void Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nSelMotorName = (int)cb_2.SelectedIndex;

            Propert_Change(nSelMotorName);
            MotorGrid_Change(nSelMotorName);
        }
        private void Propert_Change(int nNum ,bool bInit_Falg = false)
        { 
            
            cb_0.Text           = csvData[nNum + 1, (int)eMotor.swAxis];
            cb_1.Text           = csvData[nNum + 1, (int)eMotor.hwAxis].ToString();
            if (bInit_Falg == true)
            {
                cb_2.SelectedItem = csvData[nNum + 1, (int)eMotor.Name].ToString();
            }
            tB_LeadPitch.Text   = csvData[nNum + 1, (int)eMotor.Lead_Pitch];
            cb_4.SelectedIndex = int.Parse(csvData[nNum + 1, (int)eMotor.Servo].ToString());
            tB_LeadPitch.Text   = csvData[nNum + 1, (int)eMotor.Lead_Pitch];
            cb_6.SelectedIndex = int.Parse(csvData[nNum + 1, (int)eMotor.Mv_Dir].ToString());
            tB_Inposition.Text  = csvData[nNum + 1, (int)eMotor.InPosWidth];
            tB_PP1.Text         = csvData[nNum + 1, (int)eMotor.PP1];
            cb_9.SelectedIndex = int.Parse(csvData[nNum + 1, (int)eMotor.HomeLogic].ToString());
            cb_10.SelectedIndex = int.Parse(csvData[nNum + 1, (int)eMotor.Home_Coil].ToString());
            cb_11.SelectedIndex = int.Parse(csvData[nNum + 1, (int)eMotor.Limit_Coil].ToString());
            cb_12.SelectedIndex = int.Parse(csvData[nNum + 1, (int)eMotor.Alarm_Coil].ToString());
            cb_13.SelectedIndex = int.Parse(csvData[nNum + 1, (int)eMotor.Z_Phase].ToString());
        }

        private void MotorGrid_Change(int nNum)
        {
            DataGridViewRow row;
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"num = {nNum} num + 1 = {nNum + 1}, i= {i} => {nGridAxis[nNum + 1, i]}");
                row = dGV_MotorList.Rows[i];
                row.Cells[(int)eMotorListGrid.swAxis].Value = csvData[nGridAxis[nNum , i], (int)eMotor.swAxis];
                row.Cells[(int)eMotorListGrid.Name].Value = csvData[nGridAxis[nNum , i], (int)eMotor.Name];
                row.Cells[(int)eMotorListGrid.Servo].Value = csvData[nGridAxis[nNum, i], (int)eMotor.Servo];
            }        

        }

        private void Grid_Leave(object sender, EventArgs e)
        {
            dGV_MotorList.CurrentCell = null;
        }

        static bool bClick_Flag = false;
        private void btn_NJ_MouseDown(object sender, MouseEventArgs e)
        {
            bClick_Flag = true;
            Utils.Delay(100);
            Console.WriteLine("btn_NJ_MouseDown");
            while (bClick_Flag)
            {                
                // ToDo : LoopEvent
                Application.DoEvents();
            }
            Console.WriteLine("btn_NJ_MouseDown Finish");

        }

        private void btn_PJ_MouseDown(object sender, MouseEventArgs e)
        {
            bClick_Flag = true;
            Utils.Delay(100);
            Console.WriteLine("btn_PJ_MouseDown");
            while (bClick_Flag)
            {
                // ToDo : LoopEvent
                Application.DoEvents();
            }
            Console.WriteLine("btn_PJ_MouseDown Finish");


        }

        private void btn_Jog_MouseUp(object sender, MouseEventArgs e)
        {
            bClick_Flag = false;

        }

    }
}
