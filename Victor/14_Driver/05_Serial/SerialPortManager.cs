using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Text;
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
}