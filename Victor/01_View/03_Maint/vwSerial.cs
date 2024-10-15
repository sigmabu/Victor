using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Build.Tasks;
using Microsoft.VisualBasic.FileIO;
using Victor;
using static System.Net.Mime.MediaTypeNames;


namespace Victor
{
    public partial class vwSerial : UserControl
    {
        private string sSerialPath;
        private string sFolderPath;
        private string sFileName;

        static string[,] sCsvData;
        static int nSelRow;


        public vwSerial()
        {
            InitializeComponent();
            nSelRow = 0;
            dGV_SerialList.ReadOnly = true;

            sSerialPath = GVar.PATH_CONFIG_Serial;
            int FindDot = sSerialPath.LastIndexOf(".");
            int Lastsp = sSerialPath.LastIndexOf("\\");

            sFileName = sSerialPath.Substring(Lastsp + 1, FindDot - Lastsp - 1);
            sFolderPath = sSerialPath.Replace(sFileName + ".csv", "");
            Read_File_SerialConfig();
        }

        string EnumToString(eRecipGroup eGroup)
        {
            return eGroup.ToString();
        }

        public void Open()
        {
            switch (mViewPage.nRcpPage)
            {
                case 0:
                    Read_File_SerialConfig();

                    break;
                case 312:
                    Read_File_SerialConfig();
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


        private void Save_UiData()
        {

            bool create = CCsv.SaveCSVFile(this.sSerialPath, sCsvData, overwrite: true);
        }
        public int Get_UI_SerialConfig()
        {
            sCsvData[nSelRow + 1, (int)eSerial.No] = tb_No.Text;
            sCsvData[nSelRow + 1, (int)eSerial.Port_Name] = tb_Name.Text ;
            sCsvData[nSelRow + 1, (int)eSerial.Baud_Rate] = cb_Baud.SelectedItem.ToString();
            sCsvData[nSelRow + 1, (int)eSerial.Data_bit] = cb_Data.SelectedItem.ToString();
            sCsvData[nSelRow + 1, (int)eSerial.Parity_bit] = cb_Parity.SelectedItem.ToString();
            sCsvData[nSelRow + 1, (int)eSerial.Stop_bit] = cb_Stop.SelectedItem.ToString();
            sCsvData[nSelRow + 1, (int)eSerial.Flow_Control] = cb_Flow.SelectedItem.ToString();                        

            return 0;
        }

        public int Read_File_SerialConfig()
        {
            dGV_SerialList.DataSource = Display_File_SerialConfig(sSerialPath);

            sCsvData = CCsv.OpenCSVFile(this.sSerialPath);
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
                CData.tSerial[nArrayCnt].sParity_bit = sCsvData[nArrayCnt + 1, (int)eSerial.Parity_bit];
                CData.tSerial[nArrayCnt].sStop_bit = sCsvData[nArrayCnt + 1, (int)eSerial.Stop_bit];
                CData.tSerial[nArrayCnt].sFlow_Control = sCsvData[nArrayCnt + 1, (int)eSerial.Flow_Control];
                nArrayCnt++;
            }

            return 0;
        }
        public int Write_File_SerialConfig()
        {
            bool create = CCsv.SaveCSVFile(this.sSerialPath, sCsvData, overwrite: true);
            return 0;
        }


        
        private void Click_Open(object sender, EventArgs e)
        {
            Read_File_SerialConfig();
            //Display_File_SerialConfig();

        }
        private void Click_Save(object sender, EventArgs e)
        {
            Get_UI_SerialConfig();
            Write_File_SerialConfig();
            Read_File_SerialConfig();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dGV_SerialList.DataSource = Display_File_SerialConfig(sSerialPath);
        }

        public DataTable Display_File_SerialConfig(string filePath)
        {
            var dt = new DataTable();

            // 첫번째 행을 읽어 컬럼명으로 세팅
            foreach (var headerLine in File.ReadLines(filePath).Take(1))
            {
                foreach (var headerItem in headerLine.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    dt.Columns.Add(headerItem.Trim());
                }
            }
            // 나머지 행을 읽어 데이터로 세팅
            foreach (var line in File.ReadLines(filePath).Skip(1))
            {
                if (line.Contains("EOF") || 
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
            DataGridViewRow row = dGV_SerialList.SelectedRows[0];   //선택된 Row 값 가져옴.
            nSelRow = row.Index;
            tb_No.Text      = row.Cells[0].Value.ToString();        // row의 컬럼(Cells[0]) = name
            tb_Name.Text    = row.Cells[1].Value.ToString();
            cb_Baud.Text    = row.Cells[2].Value.ToString();
            cb_Data.Text    = row.Cells[3].Value.ToString();
            cb_Parity.Text  = row.Cells[4].Value.ToString();
            cb_Stop.Text    = row.Cells[5].Value.ToString();
            cb_Flow.Text    = row.Cells[6].Value.ToString();
        }

        private void Click_PortOpen(object sender, EventArgs e)
        {

        }

        private void Click_PortClose(object sender, EventArgs e)
        {

        }
    }
}
