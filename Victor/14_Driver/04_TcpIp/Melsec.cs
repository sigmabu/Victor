
using System;
using System.Net.Sockets;
using System.Windows.Forms;


namespace Victor
{
    public partial class Melsec
    {
        private TcpClient plcClient;
        private NetworkStream stream;
        public Melsec()
        {
            ConnectToPLC();
        }
        private void ConnectToPLC()
        {
            try
            {
                plcClient = new TcpClient("192.168.0.1", 5002); // PLC IP 주소와 포트
                stream = plcClient.GetStream();
                Console.WriteLine($"PLC 연결 성공!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"PLC 연결 실패: {ex.Message}");
            }
        }
        private void ReadPLCData()
        {
            try
            {
                byte[] command = new byte[]
                {
                    0x50, 0x00, // Subheader
                    0x00, 0xFF, 0xFF, 0x03, 0x00, // Network No, PC No, IO No
                    0x0C, 0x00, // Data Length
                    0x01, 0x04, // Command (Batch Read)
                    0x00, 0x00, // Subcommand
                    0xD0, 0x00, 0x64, 0x00, // Start Address (D100)
                    0x01, 0x00  // Number of Points (1개)
                };

                stream.Write(command, 0, command.Length);
                byte[] response = new byte[256];
                stream.Read(response, 0, response.Length);

                int dataValue = response[11] + (response[12] << 8); // 데이터 값 해석
                Console.WriteLine($"D100 값: { dataValue}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"데이터 읽기 실패:  {ex.Message}");
            }
        }

        private void WritePLCData()
        {
            try
            {
                byte[] command = new byte[]
                {
                    0x50, 0x00, // Subheader
                    0x00, 0xFF, 0xFF, 0x03, 0x00, // Network No, PC No, IO No
                    0x0E, 0x00, // Data Length
                    0x01, 0x14, // Command (Batch Write)
                    0x00, 0x00, // Subcommand
                    0xD0, 0x00, 0x64, 0x00, // Start Address (D100)
                    0x01, 0x00, // Number of Points (1개)
                    0xD2, 0x04 // 데이터 (1234, Little Endian)
                };

                stream.Write(command, 0, command.Length);
                Console.WriteLine($"데이터 쓰기 :  {command}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"데이터 쓰기 실패:  {ex.Message}");
            }
        }

        private string Convert_LittleEndianReverse(int nData)
        {
            //int nData = 1234; // 변환할 숫자
            byte[] littleEndianBytes = BitConverter.GetBytes(nData);

            // 시스템이 Big Endian이면 순서를 뒤집음
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(littleEndianBytes);
            }

            // 결과 출력 (16진수 문자열 변환)
            string hexString = BitConverter.ToString(littleEndianBytes).Replace("-", " ");
            MessageBox.Show($"Little Endian Reverse 변환: {hexString}");
            return hexString;
        }
        private string Convert_LittleEndian(int nData)
        {
            //int nData = 1234; // 변환할 숫자
            byte[] littleEndianBytes = BitConverter.GetBytes(nData);

            // 결과 출력 (16진수 문자열 변환)
            string hexString = BitConverter.ToString(littleEndianBytes).Replace("-", " ");
            MessageBox.Show($"Little Endian Reverse 변환: {hexString}");
            return hexString;
        }

        // Big Endian 변환 (32비트 정수 기준)
        private byte[] IntToBigEndian(int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);  // Big Endian으로 변환
            }
            return bytes;
        }

    }
}
