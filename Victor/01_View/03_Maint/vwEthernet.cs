using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Runtime.InteropServices;


namespace Victor
{
    public partial class vwEthernet : UserControl
    {
        private string sEthernetPath;
        private string sFolderPath;
        private string sFileName;

        private static string[,] sCsvData;
        static int nSelRow;

        #region 서버용 설정 변수
        // 데이타 읽기 위한 스트림리더
        public StreamReader streamServerReader { get; private set; }

        // 데이타 쓰기 위한 스트림라이터
        public StreamWriter streamServerWriter { get; private set; }

        private static Thread thread_Server;
        #endregion

        #region 클라이언트용 변수

        // 데이타 읽기 위한 스트림리더
        public StreamReader streamClientReader { get; private set; }

        // 데이타 쓰기 위한 스트림라이터
        public StreamWriter streamClientWriter { get; private set; }
        private static Thread thread_Client;
        #endregion

        public vwEthernet()
        {
            InitializeComponent();
            Init_View_Set();
        }

        private bool _Release()
        {
            Thread_Server_Stop();

            Thread_Client_Stop();

            return true;
        }

        #region Server 함수
        /// <summary>
        /// Server 함수
        /// https://unininu.tistory.com/475
        /// 
        /// </summary>
        /// 

        private void Thread_Server_Start()
        {
            thread_Server = new Thread(Server_Open); // Thread 객채 생성, Form과는 별도 쓰레드에서 connect 함수가 실행됨.
            thread_Server.IsBackground = true; // Form이 종료되면 thread1도 종료.
            thread_Server.Start(); // thread1 시작.
        }

        private void Thread_Server_Stop()
        {
            if (thread_Server != null)
            {
                thread_Server.Abort();
                thread_Server = null;
            }
        }

        private void Server_Open()  // thread1에 연결된 함수. 메인폼과는 별도로 동작한다.
        {
            Console.WriteLine($"Input Value {IPAddress.Parse(tb_IP.Text)},{int.Parse(tb_Port.Text)}");
            TcpListener tcpListener1 = new TcpListener(IPAddress.Parse(tb_IP.Text), int.Parse(tb_Port.Text)); // 서버 객체 생성 및 IP주소와 Port번호를 할당
            tcpListener1.Start();  // 서버 시작
            writeServer_RichTextbox("서버 준비...클라이언트 기다리는 중...");

            TcpClient tcpClient1 = tcpListener1.AcceptTcpClient(); // 클라이언트 접속 확인
            writeServer_RichTextbox("클라이언트 연결됨...");

            streamServerReader = new StreamReader(tcpClient1.GetStream());  // 읽기 스트림 연결
            streamServerWriter = new StreamWriter(tcpClient1.GetStream());  // 쓰기 스트림 연결
            streamServerWriter.AutoFlush = true;  // 쓰기 버퍼 자동으로 뭔가 처리..

            while (tcpClient1.Connected)  // 클라이언트가 연결되어 있는 동안
            {
                string receiveData1 = streamServerReader.ReadLine();  // 수신 데이타를 읽어서 receiveData1 변수에 저장
                writeServer_RichTextbox(receiveData1); // 데이타를 수신창에 쓰기                  
            }
        }

        private void writeServer_RichTextbox(string str)  // richTextbox1 에 쓰기 함수
        {
            rTB_ServerStatus.Invoke((MethodInvoker)delegate { rTB_ServerStatus.AppendText(str + "\r\n"); }); // 데이타를 수신창에 표시, 반드시 invoke 사용. 충돌피함.
            rTB_ServerStatus.Invoke((MethodInvoker)delegate { rTB_ServerStatus.ScrollToCaret(); });  // 스크롤을 젤 밑으로.
        }

        private void Click_ServerWrite(object sender, EventArgs e)
        {
            string sendData1 = rTB_ServerData.Text;  // testBox3 의 내용을 sendData1 변수에 저장
            streamServerWriter.WriteLine(sendData1);  // 스트림라이터를 통해 데이타를 전송
        }

        #endregion

        #region Client 함수
        /// <summary>
        /// Client 함수
        /// https://unininu.tistory.com/475
        /// 
        /// </summary>
        ///         

        private void Thread_Client_Start()  
        {
            thread_Client = new Thread(Client_connect);  // Thread 객채 생성, Form과는 별도 쓰레드에서 connect 함수가 실행됨.
            thread_Client.IsBackground = true;  // Form이 종료되면 thread1도 종료.
            thread_Client.Start();  // thread1 시작.
        }

        private void Thread_Client_Stop()
        {
            if (thread_Client != null)
            {
                thread_Client.Abort();
                thread_Client = null;
            }

        }

        private void Client_connect()  
        {
            TcpClient tcpClient1 = new TcpClient();  // TcpClient 객체 생성
            IPEndPoint ipEnd = new IPEndPoint(IPAddress.Parse(tb_IP.Text), int.Parse(tb_Port.Text));  // IP주소와 Port번호를 할당
            tcpClient1.Connect(ipEnd);  // 서버에 연결 요청
            writeClient_RichTextbox("서버 연결됨...");

            streamClientReader = new StreamReader(tcpClient1.GetStream());  // 읽기 스트림 연결
            streamClientWriter = new StreamWriter(tcpClient1.GetStream());  // 쓰기 스트림 연결
            streamClientWriter.AutoFlush = true;  // 쓰기 버퍼 자동으로 뭔가 처리..

            while (tcpClient1.Connected)  // 클라이언트가 연결되어 있는 동안
            {
                string receiveData1 = streamClientReader.ReadLine();  // 수신 데이타를 읽어서 receiveData1 변수에 저장
                writeClient_RichTextbox(receiveData1);  // 데이타를 수신창에 쓰기
            }
        }

        private void writeClient_RichTextbox(string data)  // richTextbox1 에 쓰기 함수
        {
            rTB_ClientStatus.Invoke((MethodInvoker)delegate { rTB_ClientStatus.AppendText(data + "\r\n"); }); //  데이타를 수신창에 표시, 반드시 invoke 사용. 충돌피함.
            rTB_ClientStatus.Invoke((MethodInvoker)delegate { rTB_ClientStatus.ScrollToCaret(); });  // 스크롤을 젤 밑으로.
        }

        private void Click_ClientWrite(object sender, EventArgs e)
        {
            string sendData1 = rTB_ClientData.Text;  // testBox3 의 내용을 sendData1 변수에 저장
            streamClientWriter.WriteLine(sendData1);   // 스트림라이터를 통해 데이타를 전송
        }
        #endregion
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
            dGV_SerialList_SelNum(false);
        }

        string EnumToString(eRecipGroup eGroup)
        {
            return eGroup.ToString();
        }

        public void Open()
        {
            switch (mViewPage.nMaintPage)
            {
                case 0:
                    Read_File_EthernetConfig();

                    break;
                case 312:
                    Read_File_EthernetConfig();
                    break;
                case 313:
                    Init_View_Set();

                    break;
                default: break;

            }
        }
        public void Close()
        {
            switch (mViewPage.nMaintPage)
            {
                case 0:
                    {
                    }
                    break;
                case 311:
                    {
                    }
                    break;
                case 312:
                    {
                    }
                    break;
                case 313:
                    {
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
                CData.tEthernet[nArrayCnt].sNo  = sCsvData[nArrayCnt + 1, (int)eEthernet.No];
                CData.tEthernet[nArrayCnt].sName = sCsvData[nArrayCnt + 1, (int)eEthernet.Port_Name];
                CData.tEthernet[nArrayCnt].sIPaddress = sCsvData[nArrayCnt + 1, (int)eEthernet.IPaddress];
                CData.tEthernet[nArrayCnt].sPort = sCsvData[nArrayCnt + 1, (int)eEthernet.Port_no];
                CData.tEthernet[nArrayCnt].sHost = sCsvData[nArrayCnt + 1, (int)eEthernet.Host];
                CData.tEthernet[nArrayCnt].sProtocol = sCsvData[nArrayCnt + 1, (int)eEthernet.Protocol];
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
            dGV_SerialList_SelNum(true);
        }
        private void dGV_SerialList_SelNum(bool bsel = false)
        { 
            if(bsel == false)
            {
                dGV_EthernetList.Rows[0].Selected = true;
            }
            DataGridViewRow row = dGV_EthernetList.SelectedRows[0];   //선택된 Row 값 가져옴.
            nSelRow = row.Index;
            tb_No.Text      = row.Cells[(int)eEthernet.No].Value.ToString();        // row의 컬럼(Cells[0]) = name
            tb_Name.Text    = row.Cells[(int)eEthernet.Port_Name].Value.ToString();
            tb_IP.Text    = row.Cells[(int)eEthernet.IPaddress].Value.ToString();
            tb_Port.Text    = row.Cells[(int)eEthernet.Port_no].Value.ToString();
            cb_Host.Text  = row.Cells[(int)eEthernet.Host].Value.ToString();
            cb_Proc.Text  = row.Cells[(int)eEthernet.Protocol].Value.ToString();      
        }

        //https://soeun-87.tistory.com/31
        //https://yeolco.tistory.com/31?category=757612
        private void Click_PortOpen(object sender, EventArgs e)
        {
            Button mBtn = sender as Button;
            string sName = mBtn.Name.ToString();
            if (sName == "btn_ServerConn")
            {
                Thread_Server_Start(); ;
            }
            else if (sName == "btn_ClientConn")
            {
                Thread_Client_Start(); ;
            }
        }

        private void Click_PortClose(object sender, EventArgs e)
        {
            Button mBtn = sender as Button;
            string sName = mBtn.Name.ToString();
            if (sName == "btn_ServerConn")
            {
                Thread_Server_Start(); ;
            }
            else if (sName == "btn_ClientConn")
            {
                Thread_Client_Start(); ;
            }
        }

        public void PortOpen()
        {
            Console.WriteLine($"PortOpen");
        }


    }
}
