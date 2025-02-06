using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Victor
{
    public partial class Http_Client
    {
        //private static readonly Http_Client client = new Http_Client();
        private static readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

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


        public static async Task<bool> RequestPostAsync(string url, string postData, StringBuilder responseValue)
        {
            try
            {
                using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
                {
                    // HTTP 헤더 설정
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko");

                    // 요청 데이터 설정 (application/x-www-form-urlencoded)
                    HttpContent content = new StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded");

                    // HTTP POST 요청 보내기
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    // HTTP 상태 코드 확인
                    if (response.IsSuccessStatusCode)
                    {
                        // 응답 데이터 읽기
                        string responseString = await response.Content.ReadAsStringAsync();
                        responseValue.Clear();
                        responseValue.Append(responseString);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");
                return false;
            }

            return false;
        }

        public int nPost_Flag = 0;
        public async Task RequestPost()
        {
            string url = "http://example.com/api";  // 요청할 URL 입력
            string postData = "key1=value1&key2=value2"; // 전송할 데이터
            StringBuilder response = new StringBuilder();
            nPost_Flag = 0;

            bool success = await RequestPostAsync(url, postData, response);
            if (success)
            {
                Console.WriteLine("요청 성공!");
                Console.WriteLine($"응답: {response}");
                nPost_Flag = 1;
            }
            else
            {
                Console.WriteLine("요청 실패!");
                nPost_Flag = -1;
            }
        }

    }
}
