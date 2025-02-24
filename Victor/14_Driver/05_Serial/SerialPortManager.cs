using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Victor
{
    public class SerialConfig
    {
        public string PortName { get; set; }
        public int BaudRate { get; set; }
        public Parity Parity { get; set; }
        public int DataBits { get; set; }
        public StopBits StopBits { get; set; }
    }
    public partial class SerialPortManager
    {
        private SerialPort _serialPort;
        private static string[] _availablePorts;
        private static List<SerialConfig> _serialConfigs = new List<SerialConfig>();

        static SerialPortManager()
        {
            _availablePorts = SerialPort.GetPortNames();
            LoadSerialConfig("config.csv");
        }

        private static void LoadSerialConfig(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (var line in lines)
                    {
                        string[] values = line.Split(',');
                        if (values.Length == 5)
                        {
                            _serialConfigs.Add(new SerialConfig
                            {
                                PortName = values[0].Trim(),
                                BaudRate = int.Parse(values[1].Trim()),
                                Parity = (Parity)Enum.Parse(typeof(Parity), values[2].Trim()),
                                DataBits = int.Parse(values[3].Trim()),
                                StopBits = (StopBits)Enum.Parse(typeof(StopBits), values[4].Trim())
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading serial config: " + ex.Message);
            }
        }

        public SerialPortManager(int configIndex = 0)
        {
            if (_serialConfigs.Count > configIndex)
            {
                var config = _serialConfigs[configIndex];
                _serialPort = new SerialPort(config.PortName, config.BaudRate, config.Parity, config.DataBits, config.StopBits);
                _serialPort.DataReceived += SerialPort_DataReceived;
            }
            else
            {
                MessageBox.Show("Invalid serial configuration index.");
            }
        }

        public event Action<byte[]> DataReceived;

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int bytesToRead = _serialPort.BytesToRead;
                byte[] buffer = new byte[bytesToRead];
                _serialPort.Read(buffer, 0, bytesToRead);
                DataReceived?.Invoke(buffer);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading serial data: " + ex.Message);
            }
        }

        public void Open()
        {
            if (!_serialPort.IsOpen)
            {
                _serialPort.Open();
            }
        }

        public void Close()
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
            }
        }

        public void Write(byte[] data)
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Write(data, 0, data.Length);
            }
            else
            {
                MessageBox.Show("Serial port is not open.");
            }
        }

        public static string[] GetAvailablePorts()
        {
            return _availablePorts;
        }
    }
    /*
    public class SerialPort_User
    {
    private SerialPortManager _serialPortManager;

        public SerialPort_User()
        {

            _serialPortManager = new SerialPortManager();
            _serialPortManager.DataReceived += SerialDataReceived;
            LoadAvailablePorts();
        }

        private void SerialDataReceived(byte[] data)
        {
            Invoke(new Action(() => txtReceivedData.Text += Encoding.UTF8.GetString(data) + "\n"));
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            _serialPortManager.Open();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _serialPortManager.Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            byte[] data = Encoding.UTF8.GetBytes(txtSendData.Text);
            _serialPortManager.Write(data);
        }

        private void LoadAvailablePorts()
        {
            string[] ports = SerialPortManager.GetAvailablePorts();
            listBoxPorts.Items.Clear();
            listBoxPorts.Items.AddRange(ports);
        }
    }    */

    public class SerialFileTransfer
    {
        private SerialPort _serialPort;
        private const int BufferSize = 1024; // 전송 버퍼 크기 (1KB)

        public SerialFileTransfer(string portName, int baudRate = 9600, Parity parity = Parity.None, int dataBits = 8, StopBits stopBits = StopBits.One)
        {
            _serialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits)
            {
                ReadTimeout = 500,
                WriteTimeout = 500
            };
        }

        // 파일 전송
        public void SendFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("파일이 존재하지 않습니다.");
                return;
            }

            try
            {
                _serialPort.Open();
                byte[] fileBytes = File.ReadAllBytes(filePath);
                int totalChunks = (int)Math.Ceiling((double)fileBytes.Length / BufferSize);

                for (int i = 0; i < totalChunks; i++)
                {
                    int chunkSize = Math.Min(BufferSize, fileBytes.Length - i * BufferSize);
                    byte[] chunk = new byte[chunkSize];
                    Array.Copy(fileBytes, i * BufferSize, chunk, 0, chunkSize);
                    _serialPort.Write(chunk, 0, chunk.Length);
                    Thread.Sleep(100); // 작은 딜레이 추가 (전송 속도 조정)
                }

                Console.WriteLine("파일 전송 완료.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"파일 전송 중 오류 발생: {ex.Message}");
            }
            finally
            {
                if (_serialPort.IsOpen)
                    _serialPort.Close();
            }
        }

        // 파일 수신
        public void ReceiveFile(string savePath)
        {
            try
            {
                _serialPort.Open();
                using (MemoryStream ms = new MemoryStream())
                {
                    byte[] buffer = new byte[BufferSize];
                    int bytesRead;

                    while ((bytesRead = _serialPort.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, bytesRead);
                    }

                    File.WriteAllBytes(savePath, ms.ToArray());
                    Console.WriteLine("파일 수신 완료.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"파일 수신 중 오류 발생: {ex.Message}");
            }
            finally
            {
                if (_serialPort.IsOpen)
                    _serialPort.Close();
            }
        }
    }
    /*
     * public static void Main()
    {
        // 송신
        string sendPortName = "COM1";  // 송신 시 사용할 COM 포트
        string sendFilePath = @"C:\path\to\send\file.txt";  // 전송할 파일 경로

        SerialFileTransfer sender = new SerialFileTransfer(sendPortName);
        sender.SendFile(sendFilePath);

        // 수신
        string receivePortName = "COM2";  // 수신 시 사용할 COM 포트
        string receiveFilePath = @"C:\path\to\receive\file.txt";  // 수신할 파일 경로

        SerialFileTransfer receiver = new SerialFileTransfer(receivePortName);
        receiver.ReceiveFile(receiveFilePath);
    }
     * */
}