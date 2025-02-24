using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;


namespace Victor
{
    public class EthernetHelper
    {
        private TcpListener _tcpServer;
        private TcpClient _tcpClient;
        private UdpClient _udpClient;
        private int _port;
        private string _address;
        private bool _isConnected;
        private Thread _listenThread;

        // 생성자 - 기본 초기화
        public EthernetHelper()
        {
            _isConnected = false;
        }

        // CSV 파일에서 포트 설정을 읽어오는 기능
        public bool LoadSettings(string csvFilePath)
        {
            try
            {
                using (var reader = new StreamReader(csvFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] values = line.Split(',');
                        if (values.Length >= 2)
                        {
                            _address = values[0];
                            _port = int.Parse(values[1]);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"설정 로드 실패: {ex.Message}");
                return false;
            }
        }

        // 포트 열기 - TCP 또는 UDP
        public bool OpenPort(string mode)
        {
            try
            {
                if (mode.ToUpper() == "TCP")
                {
                    _tcpServer = new TcpListener(IPAddress.Parse(_address), _port);
                    _tcpServer.Start();
                    _listenThread = new Thread(ListenForClients);
                    _listenThread.Start();
                    _isConnected = true;
                    Console.WriteLine("TCP 포트 열기 성공");
                }
                else if (mode.ToUpper() == "UDP")
                {
                    _udpClient = new UdpClient(_port);
                    _isConnected = true;
                    Console.WriteLine("UDP 포트 열기 성공");
                }
                else
                {
                    throw new InvalidOperationException("지원되지 않는 모드입니다.");
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"포트 열기 실패: {ex.Message}");
                return false;
            }
        }

        // 포트 닫기
        public void ClosePort(string mode)
        {
            try
            {
                if (mode.ToUpper() == "TCP")
                {
                    _tcpServer.Stop();
                    _tcpClient.Close();
                    _isConnected = false;
                    Console.WriteLine("TCP 포트 닫기 성공");
                }
                else if (mode.ToUpper() == "UDP")
                {
                    _udpClient.Close();
                    _isConnected = false;
                    Console.WriteLine("UDP 포트 닫기 성공");
                }
                else
                {
                    throw new InvalidOperationException("지원되지 않는 모드입니다.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"포트 닫기 실패: {ex.Message}");
            }
        }

        // 서버에서 클라이언트 연결을 기다리는 메서드
        private void ListenForClients()
        {
            try
            {
                while (_isConnected)
                {
                    var client = _tcpServer.AcceptTcpClient();
                    _tcpClient = client;
                    Console.WriteLine("클라이언트 연결됨");
                    // 클라이언트로부터 데이터를 받는 처리
                    Thread readThread = new Thread(ReadFromClient);
                    readThread.Start(client);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"서버 대기 실패: {ex.Message}");
            }
        }

        // 클라이언트로부터 데이터 읽기
        private void ReadFromClient(object obj)
        {
            var client = (TcpClient)obj;
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];

            try
            {
                while (_isConnected)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        Console.WriteLine($"수신된 데이터: {data}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"데이터 수신 실패: {ex.Message}");
            }
        }

        // 데이터를 TCP로 송신하는 메서드 (동기적으로)
        public bool SendDataTcp(string data)
        {
            try
            {
                if (_tcpClient == null || !_isConnected) return false;
                NetworkStream stream = _tcpClient.GetStream();
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
                Console.WriteLine("데이터 송신 성공");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"TCP 데이터 송신 실패: {ex.Message}");
                return false;
            }
        }

        // 데이터를 UDP로 송신하는 메서드 (동기적으로)
        public bool SendDataUdp(string data)
        {
            try
            {
                if (_udpClient == null || !_isConnected) return false;
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                _udpClient.Send(buffer, buffer.Length, _address, _port);
                Console.WriteLine("데이터 송신 성공 (UDP)");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UDP 데이터 송신 실패: {ex.Message}");
                return false;
            }
        }

        // 파일 읽기 (TCP 또는 UDP로 전송)
        public bool SendFile(string filePath)
        {
            try
            {
                byte[] fileBytes = File.ReadAllBytes(filePath);
                if (_tcpClient != null && _isConnected)
                {
                    NetworkStream stream = _tcpClient.GetStream();
                    stream.Write(fileBytes, 0, fileBytes.Length);
                    stream.Flush();
                    Console.WriteLine("파일 송신 성공");
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"파일 송신 실패: {ex.Message}");
                return false;
            }
        }

        // 포트 연결 상태 확인
        public bool IsPortConnected()
        {
            return _isConnected;
        }
    }

    /*
    public partial class EthernetInterface
    {
        private EthernetComm _ethernetComm;

        public EthernetInterface()
        {
            InitializeComponent();
            _ethernetComm = new EthernetComm();
        }

        // 포트 설정을 읽고 열기
        private void btnOpenPort_Click(object sender, EventArgs e)
        {
            if (_ethernetComm.LoadSettings("settings.csv"))
            {
                _ethernetComm.OpenPort("TCP");
            }
        }

        // 포트 닫기
        private void btnClosePort_Click(object sender, EventArgs e)
        {
            _ethernetComm.ClosePort("TCP");
        }

        // 데이터 전송
        private void btnSendData_Click(object sender, EventArgs e)
        {
            _ethernetComm.SendDataTcp(txtSendData.Text);
        }

        // 파일 송신
        private void btnSendFile_Click(object sender, EventArgs e)
        {
            _ethernetComm.SendFile("testfile.txt");
        }

        // 포트 연결 상태 확인
        private void btnCheckConnection_Click(object sender, EventArgs e)
        {
            if (_ethernetComm.IsPortConnected())
            {
                MessageBox.Show("포트가 연결되었습니다.");
            }
            else
            {
                MessageBox.Show("포트가 연결되지 않았습니다.");
            }
        }
    }*/
}