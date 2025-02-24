using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Victor
{
    public class JsonHelper
    {
        private string _folderPath;

        public JsonHelper(string folderPath)
        {
            _folderPath = folderPath;
            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }
        }

        // JSON 파일 읽기
        /// <summary>
        /// private void Read_Json()
        /// {
        ///            JsonHelper jsonHelper = new JsonHelper(@"C:\MyJsonFolder");
        ///        List<Dictionary<string, object>> data = jsonHelper.ReadJson("sample.json");
        ///
        ///            foreach (var item in data)
        ///            {
        ///                Console.WriteLine(string.Join(" | ", item.Select(kv => $"{kv.Key}: {kv.Value}")));
        ///            }
        ///}
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> ReadJson(string fileName)
        {
            string filePath = Path.Combine(_folderPath, fileName);
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(jsonData) ?? new List<Dictionary<string, object>>();
            }
            else
            {
                MessageBox.Show($"파일이 존재하지 않습니다: {filePath}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Dictionary<string, object>>();
            }
        }

        // JSON 파일 쓰기
        /// <summary>
        ///         private void Write_Json()
        ///{
        ///    JsonHelper jsonHelper = new JsonHelper(@"C:\MyJsonFolder");
        ///     List<Dictionary<string, object>> data = new List<Dictionary<string, object>>
        ///    {
        ///        new Dictionary<string, object> { { "이름", "김철수" }, { "나이", 30 }, { "직업", "개발자" } },
        ///        new Dictionary<string, object> { { "이름", "이영희" }, { "나이", 25 }, { "직업", "디자이너" } }
        ///    };
        ///
        ///     jsonHelper.WriteJson("sample.json", data);
        ///}

        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="data"></param>
        public void WriteJson(string fileName, List<Dictionary<string, object>> data)
        {
            string filePath = Path.Combine(_folderPath, fileName);
            string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
            //MessageBox.Show($"파일 저장 완료: {filePath}", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 특정 항목 업데이트 및 JSON 파일 저장
        /// <summary>
        ///         private void Update_Json()
        ///{
        ///    JsonHelper jsonHelper = new JsonHelper(@"C:\MyJsonFolder");
        ///     Dictionary<string, object> newData = new Dictionary<string, object>
        ///    {
        ///        { "나이", 31 },
        ///        { "직업", $"소프트웨어 엔지니어 = {nCount}" }
        ///    };
        ///
        ///     jsonHelper.UpdateJson("sample.json", "이름", "김철수", newData);
        ///    nCount++;
        ///}
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="key"></param>
        /// <param name="searchValue"></param>
        /// <param name="newData"></param>
        public void UpdateJson(string fileName, string key, object searchValue, Dictionary<string, object> newData)
        {
            List<Dictionary<string, object>> jsonData = ReadJson(fileName);
            foreach (var item in jsonData)
            {
                if (item.ContainsKey(key) && item[key].Equals(searchValue))
                {
                    foreach (var pair in newData)
                    {
                        item[pair.Key] = pair.Value;
                    }
                }
            }
            WriteJson(fileName, jsonData);
        }
    }
}
