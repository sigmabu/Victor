using OfficeOpenXml;
using OfficeOpenXml.Table;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

///
/// Nuget ClosedXml 설치
namespace Victor
{
    public class ExcelHelper
    {
        private string _folderPath;

        public ExcelHelper(string folderPath)
        {
            _folderPath = folderPath;
            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        }

        // 특정 셀 데이터 읽기
        public string ReadCell(string fileName, string sheetName, int row, int col)
        {
            string filePath = Path.Combine(_folderPath, fileName);
            if (!File.Exists(filePath)) return null;

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var sheet = package.Workbook.Worksheets[sheetName];
                return sheet?.Cells[row, col].Text;
            }
        }

        // 특정 셀 데이터 쓰기
        public void WriteCell(string fileName, string sheetName, int row, int col, string value)
        {
            string filePath = Path.Combine(_folderPath, fileName);
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var sheet = package.Workbook.Worksheets[sheetName] ?? package.Workbook.Worksheets.Add(sheetName);
                sheet.Cells[row, col].Value = value;
                package.Save();
            }
        }

        // 특정 셀 데이터 업데이트
        public void UpdateCell(string fileName, string sheetName, int row, int col, string newValue)
        {
            WriteCell(fileName, sheetName, row, col, newValue);
        }

        // 전체 데이터 읽기
        public DataTable ReadAllData(string fileName, string sheetName)
        {
            string filePath = Path.Combine(_folderPath, fileName);
            DataTable table = new DataTable();

            if (!File.Exists(filePath)) return table;
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var sheet = package.Workbook.Worksheets[sheetName];
                if (sheet == null) return table;

                foreach (var firstRowCell in sheet.Cells[1, 1, 1, sheet.Dimension.End.Column])
                {
                    table.Columns.Add(firstRowCell.Text);
                }

                for (int row = 2; row <= sheet.Dimension.End.Row; row++)
                {
                    var newRow = table.NewRow();
                    for (int col = 1; col <= sheet.Dimension.End.Column; col++)
                    {
                        newRow[col - 1] = sheet.Cells[row, col].Text;
                    }
                    table.Rows.Add(newRow);
                }
            }
            return table;
        }

        // 전체 데이터 쓰기
        public void WriteAllData(string fileName, string sheetName, DataTable data)
        {
            string filePath = Path.Combine(_folderPath, fileName);
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var sheet = package.Workbook.Worksheets[sheetName] ?? package.Workbook.Worksheets.Add(sheetName);
                sheet.Cells.LoadFromDataTable(data, true, TableStyles.Medium2);
                package.Save();
            }
        }

        // Excel 인쇄
        public void PrintExcel(string fileName)
        {
            string filePath = Path.Combine(_folderPath, fileName);
            if (File.Exists(filePath))
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = filePath,
                    UseShellExecute = true,
                    Verb = "print"
                });
            }
            else
            {
                MessageBox.Show("파일을 찾을 수 없습니다!", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ReadCell()
        {
            ExcelHelper excelHelper = new ExcelHelper(@"C:\MyExcelFolder");
            string value = excelHelper.ReadCell("data.xlsx", "Sheet1", 2, 1);
            MessageBox.Show($"읽은 값: {value}");
        }

        public void WriteCell()
        {
            ExcelHelper excelHelper = new ExcelHelper(@"C:\MyExcelFolder");
            excelHelper.WriteCell("data.xlsx", "Sheet1", 2, 1, "새로운 값");
        }

        public void UpdateCell()
        {
            ExcelHelper excelHelper = new ExcelHelper(@"C:\MyExcelFolder");
            excelHelper.UpdateCell("data.xlsx", "Sheet1", 2, 1, "업데이트된 값");
        }

        public void ReadAll_Exel()
        {
            ExcelHelper excelHelper = new ExcelHelper(@"C:\MyExcelFolder");
            DataTable table = excelHelper.ReadAllData("data.xlsx", "Sheet1");

            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine(string.Join(", ", row.ItemArray));
            }
        }

        public void WriteAll_Excel()
        {
            ExcelHelper excelHelper = new ExcelHelper(@"C:\MyExcelFolder");
            DataTable table = new DataTable();
            table.Columns.Add("이름");
            table.Columns.Add("나이");
            table.Rows.Add("김철수", 30);
            table.Rows.Add("이영희", 25);

            excelHelper.WriteAllData("data.xlsx", "Sheet1", table);
        }

        public void Print_Excel()
        {
            ExcelHelper excelHelper = new ExcelHelper(@"C:\MyExcelFolder");
            excelHelper.PrintExcel("data.xlsx");
        }

    }
}