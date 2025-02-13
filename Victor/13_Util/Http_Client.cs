using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Text;

namespace Victor
{
    public partial class Http_Client
    {
        //private static readonly Http_Client client = new Http_Client();
        //private static readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        private static readonly HttpClient client = new HttpClient();

        private async Task<string> GetRequest(string url)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode(); // 오류 발생 시 예외 처리
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public async void Get_Url(string url = "https://www.google.com/")
        {
            //if(String.IsNullOrEmpty(url))url =  "https://jsonplaceholder.typicode.com/posts/1"; // 예제 API
            string response = await GetRequest(url);
            Console.WriteLine($"Get_Url{url} = {response}");
        }

        private async Task<string> PostRequest(string url, string jsonData)
        {
            try
            {
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode(); // 오류 발생 시 예외 처리
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public async void PostRequest_Url(string url = "https://www.google.com/")
        {
            //url = "https://jsonplaceholder.typicode.com/posts"; // 예제 API
            string jsonData = "{ \"title\": \"foo\", \"body\": \"bar\", \"userId\": 1 }"; // 샘플 데이터
            string response = await PostRequest(url, jsonData);

            Console.WriteLine($"PostRequest_Url{url} = {response}");
        }

        private async Task<string> FetchDataAsync(string url)
        {
            string sRet = "";
            //using (HttpClient client = new HttpClient())
            {
                try
                {
                    //string url = "https://jsonplaceholder.typicode.com/posts/1"; // 예제 URL
                    string response = await client.GetStringAsync(url);
                    JObject json = JObject.Parse(response);
                    string title = json["title"].ToString();
                    sRet = "제목: " + title;
                    Console.WriteLine($"PostRequest_Url {url} = 제목 {response}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"PostRequest_Url {url} = 오류 {ex.Message}");
                }
            }
            return sRet;
        }
        public async void FetchDataAsync_Url(string url = "https://www.google.com/")
        {
            string jsonData = "{ \"title\": \"foo\", \"body\": \"bar\", \"userId\": 1 }"; // 샘플 데이터
            //string response = 
                await FetchDataAsync(url);
        }

    }
}
