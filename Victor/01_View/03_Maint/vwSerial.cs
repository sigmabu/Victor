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


namespace Victor
{
    public partial class vwSerial : UserControl
    {

        private string sSerialPath;
        private string sFolderPath;
        private string sFileName;

        public vwSerial()
        {
            InitializeComponent();
            sSerialPath = GVar.PATH_CONFIG_Serial;
            int FindDot = sSerialPath.LastIndexOf(".");
            int Lastsp = sSerialPath.LastIndexOf("\\");

            sFileName = sSerialPath.Substring(Lastsp + 1, FindDot - Lastsp - 1);
            sFolderPath = sSerialPath.Replace(sFileName + ".csv", "");
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

        private void Load_CfgDefaultData()
        {
        }
        private void Load_CfgData()
        {
        }

        private void Get_UiData()
        {
        }

        private void Save_UiData()
        {

            bool create = CCsv.SaveCSVFile(this.sSerialPath, sCsvData, overwrite: true);
        }

        private void Display_File_SerialConfig()
        {
            int nCount = 0;
        //    DataTable dt = new DataTable();
        //    foreach (var vr in CData.tSerial)
        //    {
        //        dt.Columns.Add("Set Value");
        //        dt.Columns.Add("설명");
        //    }
        //https://okky.kr/questions/1161729

        //    dt.Columns.Add(new DataColumn("FileName"));

        //    dt.Columns.Add(new DataColumn("PDF"));

        //    dt.Columns.Add(new DataColumn("CopyCount"));

        //    dt.Columns.Add(new DataColumn("WaterMark"));

        //    DataRow dr = dt.NewRow(); 
        //            dt.rows.Add(dr); 
        //            dt["FileName"] = "Newfile"; 
        //            dt["PDF"] = true; 
        //            dt["CopyCount"] = 1; 
        //            dt["WaterMark"] = true;


        //    dr = dt.NewRow(); dt.rows.Add(dr); dt["FileName"] = "Newfile"; dt["PDF"] = true; dt["CopyCount"] = 2;

        //    dataGridView1.DataSource = new BindingSource() { DataSource = dt };

        }

        static string[,] sCsvData;
        public int Get_UI_SerialConfig()
        {
            return 0;
        }

        public int Read_File_SerialConfig()
        {
            dGV_SerialList.DataSource = readCSV(sSerialPath);

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
            using (StreamWriter wr = new StreamWriter("path"))
            {
                wr.WriteLine("#TYPE,MoveSpeed");

                //foreach (var data in datalist)
                //{
                //    wr.WriteLine("{0},{1}", data.data1, data.data2);
                //}
            }
            return 0;
        }


        
        private void Click_Open(object sender, EventArgs e)
        {
            Read_File_SerialConfig();
            Display_File_SerialConfig();

        }
        private void Click_Save(object sender, EventArgs e)
        {
            //Get_UiData();
            Save_UiData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dGV_SerialList.DataSource = readCSV(sSerialPath);
        }

        public DataTable readCSV(string filePath)
        {
            int nRowCnt = 0;
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
                    nRowCnt++;
                }
            }
            return dt;
        }

        public DataTable readCSV_(string filePath)
        { 
            var dt = new DataTable();

            // 첫번째 행을 읽어 컬럼명으로 세팅
            File.ReadLines(filePath).Take(1)
                .SelectMany(x => x.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                .ToList()
                .ForEach(x => dt.Columns.Add(x.Trim()));

            // 나머지 행을 읽어 데이터로 세팅
            File.ReadLines(filePath).Skip(1)
                .Select(x => x.Split(','))
                .ToList()
                .ForEach(line => dt.Rows.Add(line));
            return dt;
        }
    }
}
