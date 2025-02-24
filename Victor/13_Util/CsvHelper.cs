using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Victor
{
    public class CsvHelper
    {
        private string _folderPath;

        public CsvHelper(string folderPath = @"C:\MyCsvFolder")
        {
            _folderPath = folderPath;
            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }
        }

        // CSV 파일 읽기 (특정 키 값 필터링 가능)

        /// <summary>
        /// private void btnRead_Click(object sender, EventArgs e)
        /// {
        ///     CsvHelper csvHelper = new CsvHelper(@"C:\MyCsvFolder");
        ///     List<string[]> filteredData = csvHelper.ReadCsv("sample.csv", 0, "김철수"); // 첫 번째 컬럼에서 "김철수" 찾기
        ///    foreach (var row in filteredData)
        ///    {
        ///        Console.WriteLine(string.Join(" | ", row));
        ///    }
        /// }
        
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="columnIndex"></param>
        /// <param name="filterValue"></param>
        /// <returns></returns>
        public List<string[]> ReadCsv(string fileName = "sample.csv",int columnIndex = -1, string filterValue = null)
        {
            string filePath = Path.Combine(_folderPath, fileName);
            List<string[]> csvData = new List<string[]>();

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (line != null)
                        {
                            string[] row = line.Split(',');
                            if (columnIndex >= 0 && filterValue != null)
                            {
                                if (columnIndex < row.Length && row[columnIndex] == filterValue)
                                {
                                    csvData.Add(row);
                                }
                            }
                            else
                            {
                                csvData.Add(row);
                            }
                        }
                    }
                }
            }
            else
            {
               // MessageBox.Show($"파일이 존재하지 않습니다: {filePath}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return csvData;
        }

        // 특정 항목 업데이트 및 CSV 파일 저장

        /// <summary>
        ///private void Update_Csv()
        ///{
        ///    CsvHelper csvHelper = new CsvHelper(@"C:\MyCsvFolder");
        ///
        ///    string[] newData = { "김철수", "31", $"소프트웨어 엔지니어 = {nCount}" }; // 업데이트할 데이터
        ///    csvHelper.UpdateCsv(0, "김철수", newData, "sample.csv"); // 첫 번째 컬럼에서 "김철수" 찾고 수정
        ///    nCount++;
        ///}
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="columnIndex"></param>
        /// <param name="searchValue"></param>
        /// <param name="newRow"></param>
        public void UpdateCsv(int columnIndex, string searchValue, string[] newRow, string fileName = "sample.csv" )
        {
            string filePath = Path.Combine(_folderPath, fileName);
            List<string[]> csvData = ReadCsv(fileName);

            for (int i = 0; i < csvData.Count; i++)
            {
                if (columnIndex < csvData[i].Length && csvData[i][columnIndex] == searchValue)
                {
                    csvData[i] = newRow;
                }
            }
            WriteCsv( csvData, fileName);
        }

        // CSV 파일 쓰기

        ///private void Save_Csv()
        ///{
        ///    CsvHelper csvHelper = new CsvHelper(@"C:\MyCsvFolder");
        ///    List<string[]> data = new List<string[]>
        ///    {
        ///        new string[] { "이름", "나이", "직업" },
        ///        new string[] { "김철수", "30", "개발자" },
        ///        new string[] { "이영희", "25", "디자이너" }
        ///    };
        ///
        ///    csvHelper.WriteCsv(data, "sample.csv");
        ///}
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="data"></param>
        public void WriteCsv(List<string[]> data, string fileName = "sample.csv")
        {
            string filePath = Path.Combine(_folderPath, fileName);
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var row in data)
                {
                    writer.WriteLine(string.Join(",", row));
                }
            }
            //MessageBox.Show($"파일 저장 완료: {filePath}", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
