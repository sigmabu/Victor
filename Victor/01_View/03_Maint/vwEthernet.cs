using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.IO.Ports;
using System.Net.Sockets;
using System.Threading;


namespace Victor
{
    public partial class vwEthernet : UserControl
    {
        private string sEthernetPath;
        private string sFolderPath;
        private string sFileName;

        private static string[,] sCsvData;
        static int nSelRow;

        TcpListener Server;
        TcpClient Client;

        StreamReader Reader;
        StreamWriter Writer;
        NetworkStream stream;

        Thread ReceiveThread;

        bool Connected;

        public vwEthernet()
        {
            InitializeComponent();
            Init_View_Set();
        }
        private void Init_View_Set()
        {
            int i = 0;
            for (i = 0; i < mEthernet_Env.sHost.Length; i++)
            {
                cb_Host.Items.Add(mEthernet_Env.sHost[i]);
            }
            for (i = 0; i < mEthernet_Env.sProtocol.Length; i++)
            {
                cb_Proc.Items.Add(mEthernet_Env.sProtocol[i]);
            }

            nSelRow = 0;
            dGV_EthernetList.ReadOnly = true;

            sEthernetPath = GVar.PATH_CONFIG_Ethernet;
            int FindDot = sEthernetPath.LastIndexOf(".");
            int Lastsp = sEthernetPath.LastIndexOf("\\");

            sFileName = sEthernetPath.Substring(Lastsp + 1, FindDot - Lastsp - 1);
            sFolderPath = sEthernetPath.Replace(sFileName + ".csv", "");
            Read_File_EthernetConfig();
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
                    Read_File_EthernetConfig();

                    break;
                case 312:
                    Read_File_EthernetConfig();
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

            bool create = CCsv.SaveCSVFile(this.sEthernetPath, sCsvData, overwrite: true);
        }
        public int Get_UI_SerialConfig()
        {
            sCsvData[nSelRow + 1, (int)eEthernet.No] = tb_No.Text;
            sCsvData[nSelRow + 1, (int)eEthernet.Port_Name] = tb_Name.Text ;
            sCsvData[nSelRow + 1, (int)eEthernet.IPaddress] = tb_IP.Text;
            sCsvData[nSelRow + 1, (int)eEthernet.Port_no] = tb_Port.Text;
            sCsvData[nSelRow + 1, (int)eEthernet.Host] = cb_Host.SelectedItem.ToString();
            sCsvData[nSelRow + 1, (int)eEthernet.Protocol] = cb_Proc.SelectedItem.ToString();

            return 0;
        }

        public int Read_File_EthernetConfig()
        {
            dGV_EthernetList.DataSource = Display_File_SerialConfig(sEthernetPath);

            sCsvData = CCsv.OpenCSVFile(this.sEthernetPath);
            int nArrayCnt = 0;

            foreach (string str in sCsvData)
            {
                if (string.IsNullOrEmpty(sCsvData[nArrayCnt + 1, (int)eEthernet.Port_Name]))
                {
                    return -1;
                }
                CData.tEthernet[nArrayCnt].sName = sCsvData[nArrayCnt + 1, (int)eEthernet.Port_Name];
                CData.tEthernet[nArrayCnt].sIPaddress = sCsvData[nArrayCnt + 1, (int)eEthernet.IPaddress];
                CData.tEthernet[nArrayCnt].sPort = sCsvData[nArrayCnt + 1, (int)eEthernet.Port_no];
                CData.tEthernet[nArrayCnt].sHost = sCsvData[nArrayCnt + 1, (int)eEthernet.Host];
                CData.tEthernet[nArrayCnt].sProtocol = sCsvData[nArrayCnt + 1, (int)eEthernet.Protocol];

                //CData.tSerial[nArrayCnt].sFlow_Control = sCsvData[nArrayCnt + 1, (int)eEthernet.Flow_Control];
                nArrayCnt++;
            }

            dGV_EthernetList.Rows[0].Selected = true;
            return 0;
        }
        public int Write_File_SerialConfig()
        {
            bool create = CCsv.SaveCSVFile(this.sEthernetPath, sCsvData, overwrite: true);
            return 0;
        }


        
        private void Click_Open(object sender, EventArgs e)
        {
            Read_File_EthernetConfig();
            //Display_File_SerialConfig();

        }
        private void Click_Save(object sender, EventArgs e)
        {
            Get_UI_SerialConfig();
            Write_File_SerialConfig();
            Read_File_EthernetConfig();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dGV_EthernetList.DataSource = Display_File_SerialConfig(sEthernetPath);
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
            DataGridViewRow row = dGV_EthernetList.SelectedRows[0];   //선택된 Row 값 가져옴.
            nSelRow = row.Index;
            tb_No.Text      = row.Cells[(int)eEthernet.No].Value.ToString();        // row의 컬럼(Cells[0]) = name
            tb_Name.Text    = row.Cells[(int)eEthernet.Port_Name].Value.ToString();
            tb_IP.Text    = row.Cells[(int)eEthernet.IPaddress].Value.ToString();
            tb_Port.Text    = row.Cells[(int)eEthernet.Port_no].Value.ToString();
            cb_Host.Text    = row.Cells[(int)eEthernet.Host].Value.ToString();
            cb_Proc.Text  = row.Cells[(int)eEthernet.Protocol].Value.ToString();
      
        }

        //https://soeun-87.tistory.com/31
        //https://yeolco.tistory.com/31?category=757612
        private void Click_PortOpen(object sender, EventArgs e)
        {
            string[] PortNames = SerialPort.GetPortNames();
            foreach (string portnumber in PortNames)
            {
                Console.WriteLine($"Port {portnumber}");
            }

            //if (m232_01.IsOpen == false) //닫혀있을때
            //{
            //    try
            //    {
            //        m232_01.PortName = tb_Name.Text.ToString(); //콤보박스에서 고른 것을 포트네임으로 넣어준다
            //        m232_01.BaudRate = int.Parse(cb_Baud.SelectedItem.ToString()); //콤보박스에서 고른 것(string)을 int로 변경해서 넣어준다.
            //        m232_01.DataBits = int.Parse(cb_Data.SelectedItem.ToString()); // 8비트 데이터 전송은 고정
            //        m232_01.StopBits = StopBits.One; // stop비트는 1로 고정
            //        m232_01.Parity = Parity.None; // 패리티비트는 없는 걸로

            //        m232_01.Open(); // 포트를 열어준다
            //    }
            //    catch (Exception Err)
            //    {
            //        MessageBox.Show(Err.ToString());
            //    }
            //}
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
