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

        public vwMotorList()
        {
            InitializeComponent();
            Init_View_Set();
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
            //Init_MotorList_Grid_Setup();
            nSelRow = 0;
            Propert_Change(0, true);

            //dGV_MotorListGrid_SelNum(false);
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

            //dGV_MotorList.Columns[(int)eMotorListGrid.swAxis].Width = 70;
            //dGV_MotorList.Columns[(int)eMotorListGrid.Name].Width = 380;
            //dGV_MotorList.Columns[(int)eMotorListGrid.Coil].Width = 45;
            //dGV_MotorList.Columns[(int)eMotorListGrid.Part].Width = 100;

            //dGV_MotorList.Columns[(int)eMotorListGrid.swAxis].HeaderText = "Axis no";
            //dGV_MotorList.Columns[(int)eMotorListGrid.Name+1].HeaderText = "NAME";
            //dGV_MotorList.Columns[(int)eMotorListGrid.Servo+1].HeaderText = "Servo";
            //dGV_MotorList.Columns[(int)eMotorListGrid.Cmd_mm].HeaderText = "Command";
            //dGV_MotorList.Columns[(int)eMotorListGrid.Enc_mm].HeaderText = "Encoder";
            //dGV_MotorList.Columns[(int)eMotorListGrid.Home_End].HeaderText = "Home Complete";
            //dGV_MotorList.Columns[(int)eMotorListGrid.Sen_Home].HeaderText = "Home";
            //dGV_MotorList.Columns[(int)eMotorListGrid.Sen_NLimit].HeaderText = "- Limit";
            //dGV_MotorList.Columns[(int)eMotorListGrid.Sen_PLimit].HeaderText = "+ Limit";
            //dGV_MotorList.Columns[(int)eMotorListGrid.Alarm_In].HeaderText = "Alarm";
            //dGV_MotorList.Columns[(int)eMotorListGrid.ZPhase_In].HeaderText = "Z Phase";
            //dGV_MotorList.Columns[(int)eMotorListGrid.Inpos_In].HeaderText = "Inposition";

            dGV_MotorList.Columns[(int)eMotorListGrid.swAxis].Width = 40;
            dGV_MotorList.Columns[(int)eMotorListGrid.Name].Width = 40;
            dGV_MotorList.Columns[(int)eMotorListGrid.Servo].Width = 40;
            dGV_MotorList.Columns[(int)eMotorListGrid.Cmd_mm].Width = 40;
            dGV_MotorList.Columns[(int)eMotorListGrid.Enc_mm].Width = 40;
            dGV_MotorList.Columns[(int)eMotorListGrid.Home_End].Width = 40;
            dGV_MotorList.Columns[(int)eMotorListGrid.Sen_Home].Width = 40;
            dGV_MotorList.Columns[(int)eMotorListGrid.Sen_NLimit].Width = 40;
            dGV_MotorList.Columns[(int)eMotorListGrid.Sen_PLimit].Width = 40;
            dGV_MotorList.Columns[(int)eMotorListGrid.Alarm_In].Width = 40;
            dGV_MotorList.Columns[(int)eMotorListGrid.ZPhase_In].Width = 40;
            dGV_MotorList.Columns[(int)eMotorListGrid.Inpos_In].Width = 40;

            dGV_MotorList.RowTemplate.Height = 30;

            dGV_MotorList.ReadOnly = true;

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
            csvData[nSelName + 1, (int)eMotor.Mode] = cb_4.SelectedIndex.ToString();
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
                    CData.tMotor[nArrayCnt].sMode           = csvData[nArrayCnt + 1, (int)eMotor.Mode];
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
        }

        public DataTable Display_File_SerialConfig(string filePath)
        {
            var dt = new DataTable();

            // 첫번째 행을 읽어 컬럼명으로 세팅
            foreach (var headerLine in File.ReadLines(filePath,Encoding.Default).Take(1))
            {
                foreach (var headerItem in headerLine.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    dt.Columns.Add(headerItem.Trim());
                }
            }
            // 나머지 행을 읽어 데이터로 세팅
            foreach (var line in File.ReadLines(filePath, Encoding.Default).Skip(1))
            {
                if (line.Contains(GVar.EOF) || 
                    (line.Contains(",") == false) ||
                    string.IsNullOrEmpty(line))
                {
                    Console.WriteLine(line);
                }
                else
                {
                    dt.Rows.Add(line.Split(','));
                }
            }
            return dt;
        }

        private void dGV_SerialList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewColumn item in dGV_MotorList.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dGV_MotorListGrid_SelNum(true);
        }

        private void dGV_MotorListGrid_SelNum(bool bsel = false)
        {
            return;
            //if (bsel == false)
            //{
            //    dGV_SerialList.Rows[0].Selected = true;
            //}
            //DataGridViewRow row = dGV_SerialList.SelectedRows[0];   //선택된 Row 값 가져옴.
            //nSelRow = row.Index;
            //tb_No.Text      = row.Cells[(int)eSerial.No].Value.ToString();        // row의 컬럼(Cells[0]) = name
            //tb_Name.Text    = row.Cells[(int)eSerial.Port_Name].Value.ToString();
            //cb_2.Text    = row.Cells[(int)eSerial.Baud_Rate].Value.ToString();
            //cb_Data.Text    = row.Cells[(int)eSerial.Data_bit].Value.ToString();
            //cb_Stop.Text    = row.Cells[(int)eSerial.Stop_bit].Value.ToString();
            //cb_Parity.Text  = row.Cells[(int)eSerial.Parity_bit].Value.ToString();
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
            cb_4.SelectedIndex = int.Parse(csvData[nNum + 1, (int)eMotor.Mode].ToString());
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
    }
}
