using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text;
using Newtonsoft.Json.Linq;


namespace Victor
{
    public partial class vwMotorList : UserControl
    {
        private string sMotorListPath;
        private string sFolderPath;
        private string sFileName;

        static string[,] sCsvData;
        static int nSelRow;

        public vwMotorList()
        {
            InitializeComponent();
            Init_View_Set();
        }
        private void Init_View_Set()
        {
            int i = 0;
            for (i = 0; i < mSerial_Env.nBaud.Length; i++)
            {
                cb_Baud.Items.Add(mSerial_Env.nBaud[i]);
            }
            for (i = 0; i < mSerial_Env.nData.Length; i++)
            {
                cb_Data.Items.Add(mSerial_Env.nData[i]);
            }
            for (i = 0; i < mSerial_Env.nStop.Length; i++)
            {
                cb_Stop.Items.Add(mSerial_Env.nStop[i]);
            }
            for (i = 0; i < mSerial_Env.nParity.Length; i++)
            {
                cb_Parity.Items.Add(mSerial_Env.nParity[i]);
            }

            nSelRow = 0;
            dGV_SerialList.ReadOnly = true;

            sMotorListPath = GVar.PATH_EQUIP_MotorList;
            int FindDot = sMotorListPath.LastIndexOf(".");
            int Lastsp = sMotorListPath.LastIndexOf("\\");

            sFileName = sMotorListPath.Substring(Lastsp + 1, FindDot - Lastsp - 1);
            sFolderPath = sMotorListPath.Replace(sFileName + ".csv", "");
            Read_File_SerialConfig();
            dGV_SerialList_SelNum(false);
        }



        public void Open()
        {
            switch (mViewPage.nRcpPage)
            {
                case 0:
                    Read_File_SerialConfig();

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

        public int Get_UI_SerialConfig()
        {
            sCsvData[nSelRow + 1, (int)eSerial.No] = tb_No.Text;
            sCsvData[nSelRow + 1, (int)eSerial.Port_Name] = tb_Name.Text ;
            sCsvData[nSelRow + 1, (int)eSerial.Baud_Rate] = cb_Baud.SelectedItem.ToString();
            sCsvData[nSelRow + 1, (int)eSerial.Data_bit] = cb_Data.SelectedItem.ToString();
            sCsvData[nSelRow + 1, (int)eSerial.Stop_bit] = cb_Stop.SelectedItem.ToString();
            sCsvData[nSelRow + 1, (int)eSerial.Parity_bit] = cb_Parity.SelectedItem.ToString();
            //sCsvData[nSelRow + 1, (int)eSerial.Flow_Control] = cb_Flow.SelectedItem.ToString();                        

            return 0;
        }

        public int Read_File_SerialConfig()
        {
            return 0;
            dGV_SerialList.DataSource = Display_File_SerialConfig(sMotorListPath);

            sCsvData = CCsv.OpenCSVFile(this.sMotorListPath);
            int nArrayCnt = 0;

            foreach (string str in sCsvData)
            {
                if (string.IsNullOrEmpty(sCsvData[nArrayCnt + 1, (int)eSerial.Port_Name]))
                {
                    return -1;
                }
                //CData.tSerial[0].nNo = sCsvData[1, (int)eSerial.No]; 
                CData.tSerial[nArrayCnt].sPort_Name = sCsvData[nArrayCnt + 1, (int)eSerial.Port_Name];
                CData.tSerial[nArrayCnt].sBaud_Rate = sCsvData[nArrayCnt + 1, (int)eSerial.Baud_Rate];
                CData.tSerial[nArrayCnt].sData_bit = sCsvData[nArrayCnt + 1, (int)eSerial.Data_bit];
                CData.tSerial[nArrayCnt].sStop_bit = sCsvData[nArrayCnt + 1, (int)eSerial.Stop_bit];
                CData.tSerial[nArrayCnt].sParity_bit = sCsvData[nArrayCnt + 1, (int)eSerial.Parity_bit];

                //CData.tSerial[nArrayCnt].sFlow_Control = sCsvData[nArrayCnt + 1, (int)eSerial.Flow_Control];
                nArrayCnt++;
            }

            dGV_SerialList.Rows[0].Selected = true;
            return 0;
        }
        public int Write_File_SerialConfig()
        {
            bool create = CCsv.SaveCSVFile(this.sMotorListPath, sCsvData, overwrite: true);
            return 0;
        }
                

        private void Click_Save(object sender, EventArgs e)
        {
            Get_UI_SerialConfig();
            Write_File_SerialConfig();
            Read_File_SerialConfig();
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
            foreach (DataGridViewColumn item in dGV_SerialList.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dGV_SerialList_SelNum(true);
        }
        private void dGV_SerialList_SelNum(bool bsel = false)
        {
            return;
            if (bsel == false)
            {
                dGV_SerialList.Rows[0].Selected = true;
            }
            DataGridViewRow row = dGV_SerialList.SelectedRows[0];   //선택된 Row 값 가져옴.
            nSelRow = row.Index;
            tb_No.Text      = row.Cells[(int)eSerial.No].Value.ToString();        // row의 컬럼(Cells[0]) = name
            tb_Name.Text    = row.Cells[(int)eSerial.Port_Name].Value.ToString();
            cb_Baud.Text    = row.Cells[(int)eSerial.Baud_Rate].Value.ToString();
            cb_Data.Text    = row.Cells[(int)eSerial.Data_bit].Value.ToString();
            cb_Stop.Text    = row.Cells[(int)eSerial.Stop_bit].Value.ToString();
            cb_Parity.Text  = row.Cells[(int)eSerial.Parity_bit].Value.ToString();
            //cb_Flow.Text    = row.Cells[6].Value.ToString();
        }
        
        private void Click_PortOpen(object sender, EventArgs e)
        {
            sCsvData = CCsv.OpenMotorCSVFile(this.sMotorListPath);
        }

        private void Click_PortClose(object sender, EventArgs e)
        {

        }

        public void PortOpen()
        {
            Console.WriteLine($"PortOpen");
        }
    }
}
