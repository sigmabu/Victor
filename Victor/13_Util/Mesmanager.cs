using System;
using System.IO;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Newtonsoft.Json;

#region Winform 에서 호출 방식

//private MesManager mes;
//private async void btnTcpJson_Click(object sender, EventArgs e)
//{
//    await comm.RunAsync("tcp", "json");
//}

//private async void btnHttpXml_Click(object sender, EventArgs e)
//{
//    await comm.RunAsync("http", "xml");
//}
#endregion
public class SendData
{
    public string User_ID { get; set; }
    public string Machine_ID { get; set; }
    public string Process_ID { get; set; }
    public string Machine_Status { get; set; }
    public string Material_ID { get; set; }
    public string Proc_Data { get; set; }
    public string Proc_Time { get; set; }
}

public class ResponseData
{
    public string Result { get; set; }
    public string Barcode_ID { get; set; }
    public string User_ID { get; set; }
}

public class MesManager
{
    private readonly string tcpHost;
    private readonly int tcpPort;
    private readonly string httpUrl;

    public MesManager(string tcpHost, int tcpPort, string httpUrl)
    {
        this.tcpHost = tcpHost;
        this.tcpPort = tcpPort;
        this.httpUrl = httpUrl;
    }

    public async Task RunAsync(string mode, string format)
    {
        SendData data = CreateSampleData();
        string rawResponse = "";

        try
        {
            if (mode == "tcp")
                rawResponse = await SendTcpAsync(data, format);
            else
                rawResponse = await SendHttpAsync(data, format);

            string error;
            var parsed = ParseResponse(rawResponse, format, out error);

            if (error != null)
            {
                MessageBox.Show($"❌ 에러 코드: {error}");
            }
            else if (parsed != null)
            {
                MessageBox.Show($"✅ 결과: {parsed.Result}\n📦 바코드: {parsed.Barcode_ID}\n👤 작업자: {parsed.User_ID}");
            }
            else
            {
                MessageBox.Show("⚠️ 응답 파싱 실패");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("💥 통신 중 예외 발생: " + ex.Message);
        }
    }

    private SendData CreateSampleData()
    {
        return new SendData
        {
            User_ID = "USER001",
            Machine_ID = "EQ001",
            Process_ID = "PRC001",
            Machine_Status = "RUN",
            Material_ID = "P123456",
            Proc_Data = "73.5",
            Proc_Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        };
    }

    public async Task<string> SendTcpAsync(SendData data, string format)
    {
        string message = ConvertToFormat(data, format);
        using (TcpClient client = new TcpClient())
        {
            await client.ConnectAsync(tcpHost, tcpPort);
            NetworkStream stream = client.GetStream();

            byte[] bytesToSend = Encoding.UTF8.GetBytes(message + "\n");
            await stream.WriteAsync(bytesToSend, 0, bytesToSend.Length);

            byte[] buffer = new byte[4096];
            int readBytes = await stream.ReadAsync(buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer, 0, readBytes).Trim();
        }
    }

    public async Task<string> SendHttpAsync(SendData data, string format)
    {
        string message = ConvertToFormat(data, format);
        //string contentType = format switch
        //{
        //    "json" => "application/json",
        //    "xml" => "application/xml",
        //    _ => "text/plain"
        //};
        string contentType;

        switch (format)
        {
            case "json":
                contentType = "application/json";
                break;
            case "xml":
                contentType = "application/xml";
                break;
            default:
                contentType = "text/plain";
                break;
        }

        using (var client = new HttpClient())
        {
            var content = new StringContent(message, Encoding.UTF8, contentType);
            var response = await client.PostAsync(httpUrl, content);
            return await response.Content.ReadAsStringAsync();
        }
    }

    public ResponseData ParseResponse(string response, string format, out string errorCode)
    {
        errorCode = null;

        if (response.StartsWith("ERR"))
        {
            errorCode = response.Substring(3);
            return null;
        }

        try
        {
            if (format == "json")
                return JsonConvert.DeserializeObject<ResponseData>(response);

            if (format == "xml")
            {
                var serializer = new XmlSerializer(typeof(ResponseData));
                using (var reader = new StringReader(response))
                    return (ResponseData)serializer.Deserialize(reader);
            }

            // string
            string[] parts = response.Split('|');
            if (parts.Length >= 3)
            {
                return new ResponseData
                {
                    Result = parts[0],
                    Barcode_ID = parts[1],
                    User_ID = parts[2]
                };
            }
        }
        catch
        {
            errorCode = "FORMAT_ERROR";
        }

        return null;
    }

    private string ConvertToFormat(SendData data, string format)
    {
        if (format == "json")
            return JsonConvert.SerializeObject(data);

        if (format == "xml")
        {
            var serializer = new XmlSerializer(typeof(SendData));
            using (var sw = new StringWriter())
            {
                serializer.Serialize(sw, data);
                return sw.ToString();
            }
        }

        // string
        return $"{data.User_ID}|{data.Machine_ID}|{data.Process_ID}|{data.Machine_Status}|{data.Material_ID}|{data.Proc_Data}|{data.Proc_Time}";
    }
}
