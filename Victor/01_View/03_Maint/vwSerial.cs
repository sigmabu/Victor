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
using Microsoft.VisualBasic.FileIO;
using Victor;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.Button;


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
                    Load_CfgDefaultData();

                    break;
                case 312:
                    Load_CfgData();
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
        }

        private void radio_Save_Click(object sender, EventArgs e)
        {

        }

        private void radio_Save_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FileFolder_Exist()
        {

            if (!Directory.Exists(this.sFolderPath))
            {
                Directory.CreateDirectory(this.sFolderPath);
            }

            FileInfo fileInfo = new FileInfo(sSerialPath);
            if (!fileInfo.Exists)// 파일이 있는지 체크
            {
                //log("File이 없습니다.");
            }
        }

        List<String> x = new List<string>();
        List<String> y = new List<string>();

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            StreamReader file = new StreamReader(GVar.PATH_CONFIG_Serial);

            DataTable dt = new DataTable();
            dt.Columns.Add("Set Value");
            dt.Columns.Add("설명");

            while (!file.EndOfStream)
            {
                string line = file.ReadLine();

                string[] data = line.Split(',');
                dt.Rows.Add(data[0], data[1]);

                x.Add(data[0]);
                y.Add(data[0]);
            }
            dataGridView1.DataSource = dt;
        }

        public int Get_UI_SerialConfig()
        {
            return 0;
        }

        public int Read_File_SerialConfig()
        {
            FileInfo fileInfo = new FileInfo("path");

            if (!fileInfo.Exists)// 파일이 있는지 체크
            {
                //log("File이 없습니다.")
            }

            //using (FileStream fs = new FileStream("path"))
            //{
            //    using (StreamReader sr = new StreamReader(fs, Encoding.UTF8, false))
            //    {
            //        string strLineValue = null;    // 한번씩 읽어올 문자열
            //        string[] values = null;        // 문자열을 나눔
            //        while ((strLineValue = sr.ReadLine()) != null)
            //        {
            //            values = strLineValue.Split(',');    // ,로 Split을해 데이터를 나눈다.
            //            if (values[0].Contains("#"))        // #이 있을 경우에는 데이터 필드
            //                continue;

            //            foreach (var data in datalist)
            //            {
            //                data.data1 = values[0];
            //                data.data2 = values[1];
            //            }
            //        }
            //    }
            //}

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

        static string[,] sCsvData;
        private void Click_Open(object sender, EventArgs e)
        {
            sCsvData = CCsv.OpenCSVFile(this.sSerialPath);
        }
        private void Click_Save(object sender, EventArgs e)
        {
            //Get_UiData();
            //Save_UiData();
            bool create = CCsv.SaveCSVFile(this.sSerialPath, sCsvData, overwrite: true);
        }
    }
}
