using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

using System.Data.OleDb;
using System.Collections.Generic;
using System.Diagnostics;
using DataTable = System.Data.DataTable;
using System.Windows.Forms.DataVisualization.Charting;
using System.Text;


namespace Victor
{
    public partial class vwSPC : UserControl
    {

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        Excel.Application excelApp = null;		// Excel 프로그램을 의미합니다.
        Excel.Workbook wookbook = null;				// 통합문서를 의미합니다.
        Excel._Worksheet workSheet = null;		// 워크시트를 의미합니다.
        uint excelProcessId = 0;

        private string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        private string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";

        private string sSpcDataPath;
        private string sFolderPath;
        private string sFileName;

        private static string[][] sXlsData;
        private static int nXlsRow_length;
        private static int nSelRow;

        private static int nEnable_Edit;

        public vwSPC()
        {
            InitializeComponent();
            
            Init_View_Set();
            Init_Grid_Set();
            Init_Timer();
        }

        private bool _Release()
        {
            return true;
        }

        private void Init_Grid_Set()
        {
            dGV_DataList.DoubleBuffered(true);

            dGV_DataList.Columns[(int)eSpcGrid.DataNo].Width    = 100;
            dGV_DataList.Columns[(int)eSpcGrid.Name].Width      = 495;
            dGV_DataList.RowTemplate.Height = 30;
            dGV_DataList.Columns[(int)eSpcGrid.Name].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dGV_DataList.ReadOnly = true;

        }
        private void Init_Timer()
        {
            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            t.Tick += new EventHandler(TimerEvent);
            t.Interval = 500;
            t.Start();
        }

        private void Init_View_Set()
        {
            nEnable_Edit = 0;
            Btn_Output_Set();

            nSelRow = 0;            

            sSpcDataPath = GVar.PATH_EQUIP_SpcList;
            int FindDot = sSpcDataPath.LastIndexOf(".");
            int Lastsp = sSpcDataPath.LastIndexOf("\\");

            sFileName = sSpcDataPath.Substring(Lastsp + 1, FindDot - Lastsp - 1);
            sFolderPath = sSpcDataPath.Replace(sFileName + ".xls", "");
            
            Read_File_SpcData(true);

            Init_Chart();
        }

        private T IntToEnum<T>(int e)
        {
            return (T)(object)e;
        }

        SeriesChartType IntToEnum(int nSeriesChartType)
        {
            return (SeriesChartType)nSeriesChartType;
        }

        public void Init_Chart()
        {
            SeriesChartType eSeriesChartType = IntToEnum(1);
            int nEnumCnt = System.Enum.GetValues(typeof(SeriesChartType)).Length;

            for (int i = 0; i < nEnumCnt; i++)
            {
                eSeriesChartType = IntToEnum(i);
                cbChartsel.Items.Add(eSeriesChartType);
            }
            float Ydata = 0.0f;

            chart_Spc.ChartAreas[0].AxisX.Minimum = 0;
            chart_Spc.ChartAreas[0].AxisX.Maximum = 100;

            chart_Spc.ChartAreas[0].AxisY.Minimum = 0;
            chart_Spc.ChartAreas[0].AxisY.Maximum = 100;

            for (int x = 0; x < chart_Spc.ChartAreas[0].AxisX.Maximum; x++)
            {
                chart_Spc.Series[0].Points.AddXY(x,Ydata);
                Ydata += 0.1f;
            }
        }
        public int Read_File_SpcData(bool bFlag = false)
        {
            if (bFlag)
            {
                sXlsData = ReadExcelData(dGV_DataList, sSpcDataPath, 1024);                
            }
            nXlsRow_length = sXlsData.GetLength(0);
            GetData_Xls_ErrorList();
            dGV_SpcList_SelNum(false);


            return 1;
        }

        public void Open()
        {
            switch (mViewPage.nMaintPage)
            {
                case 0:
                    //Read_File_SpcData();

                    break;
                case 312:
                    //Read_File_SpcData();
                    break;
                case 314:
                    Init_View_Set();

                    break;
                case 315:
                    //Init_View_Set();

                    break;
                default: break;

            }
        }
        public void Close()
        {
            switch (mViewPage.nMaintPage)
            {
                case 0:
                    {
                    }
                    break;
                case 311:
                    {
                    }
                    break;
                case 312:
                    {
                    }
                    break;
                case 313:
                    {
                    }                        
                    break;
                case 314:
                    {
                        nEnable_Edit = 0;
                    }
                    break;
                case 315:
                    {
                        nEnable_Edit = 0;
                    }
                    break;

                default: break;
            }
        }

        private  string[][] ReadExcelData(DataGridView grid, string path,  int numOfColumn)
        {
            string filePath = path;
            string fileExtension = Path.GetExtension(path);
            string header = "Yes";  //rbHeaderYes.Checked ? "Yes" : "No";
            string connectionString = string.Empty;
            string sheetName = string.Empty;

            List<string[]> result = new List<string[]>();            

            try
            {
                excelApp = new Excel.Application();

                if (excelApp == null)
                {
                    MessageBox.Show("엑셀이 설치되지 않았습니다");
                    return result.ToArray();
                }
                // 확장자로 구분하여 커넥션 스트링을 가져옮
                switch (fileExtension)
                {
                    case ".xls":    //Excel 97-03
                        connectionString = string.Format(Excel03ConString, filePath, header);
                        break;
                    case ".xlsx":  //Excel 07
                        connectionString = string.Format(Excel07ConString, filePath, header);
                        break;
                }
                // 엑셀 프로그램 실행

                
                GetWindowThreadProcessId(new IntPtr(excelApp.Hwnd), out excelProcessId);
                // 엑셀 파일 열기
                wookbook = excelApp.Workbooks.Open(path,false);
                // 첫번째 Worksheet
                workSheet = wookbook.Worksheets.get_Item(1) as Excel.Worksheet;   
                // 현재 Worksheet에서 사용된 Range 전체를 선택
                Excel.Range rng = workSheet.UsedRange;
                // Range 데이타를 배열 (1-based array)로
                object[,] data = (object[,])rng.Value;

                for (int r = 1; r <= data.GetLength(0); r++)
                {
                    int length = Math.Min(data.GetLength(1), numOfColumn);
                    string[] arr = new string[length];

                    for (int c = 1; c <= length; c++)
                    {
                        if (data[r, c] == null)
                        {
                            continue;
                        }
                        else if (data[r, c] is string)
                        {
                            arr[c - 1] = data[r, c] as string;
                        }
                        else
                        {
                            arr[c - 1] = data[r, c].ToString();
                        }
                    }

                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (string.IsNullOrWhiteSpace(arr[i]) == false)
                        {
                            result.Add(arr);
                            break;
                        }
                    }
                }

                // 첫 번째 시트의 이름을 가져옮
                using (OleDbConnection con = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.Connection = con;
                        con.Open();
                        DataTable dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                        sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                        con.Close();
                    }
                }
                Console.WriteLine("sheetName = " + sheetName);


                // 첫 번째 시트의 데이타를 읽어서 datagridview 에 보이게 함.
                using (OleDbConnection con = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        using (OleDbDataAdapter oda = new OleDbDataAdapter())
                        {
                            DataTable dt = new DataTable();
                            cmd.CommandText = "SELECT * From [" + sheetName + "]";
                            cmd.Connection = con;
                            con.Open();
                            oda.SelectCommand = cmd;
                            oda.Fill(dt);
                            con.Close();
                            grid.DataSource = dt;
                        }
                    }
                }
                
                wookbook.Close(false);
                excelApp.Quit();
                CLog.Write(ELog.OPL, string.Format($"Error File {path}, Excel File Close"));
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                // Clean up
                ReleaseExcelObject(workSheet);
                ReleaseExcelObject(wookbook);
                ReleaseExcelObject(excelApp);

                if (excelApp != null && excelProcessId > 0)
                {
                    Process.GetProcessById((int)excelProcessId).Kill();
                }
                CLog.Write(ELog.OPL, string.Format($"Error File {path}, Excel File Release"));
            }

            return result.ToArray();
        }
        private  bool WriteExcelData(string path, string[][] targetData)
        {
            try
            {
                // Execute Excel application
                excelApp = new Excel.Application();

                if (excelApp == null)
                {
                    MessageBox.Show("엑셀이 설치되지 않았습니다");
                    return false;
                }
                GetWindowThreadProcessId(new IntPtr(excelApp.Hwnd), out excelProcessId);

                // 엑셀파일 열기 or 새로 만들기
                bool isFileExist = File.Exists(path);
                wookbook = isFileExist ? excelApp.Workbooks.Open(path, ReadOnly: false, Editable: true) : excelApp.Workbooks.Add(Missing.Value);

                workSheet = wookbook.Worksheets.get_Item(1) as Excel.Worksheet;
                // Worksheet 이름 설정하기
                // ws.Name = targetWorksheetName ;

                int row = targetData.GetLength(0);
                int column = targetData[0].Length;

                object[,] data = new object[row, column];

                for (int r = 0; r < row; r++)
                {
                    for (int c = 0; c < column; c++)
                    {
                        data[r, c] = targetData[r][c];
                    }
                }

                // row, column 번호로 Cell 접근
                // Excel.Range rng = ws.Range[ws.Cells[1, 1], ws.Cells[row, column]];

                Excel.Range rng = workSheet.get_Range("A1", Missing.Value);
                rng = rng.get_Resize(row, column);

                // 저장하는 여러 방법 중 두가지
                // rng.Value = data;
                rng.set_Value(Missing.Value, data);

                if (isFileExist)
                {
                    wookbook.Save(); // 덮어쓰기
                }
                else
                {
                    wookbook.SaveCopyAs(path); // 새 파일 만들기
                }

                wookbook.Close(false);
                excelApp.Quit();
            }
            catch (Exception e)
            {
                if (wookbook != null)
                {
                    wookbook.Close(SaveChanges: false);
                }
                if (excelApp != null)
                {
                    excelApp.Quit();
                }

                return false;
            }
            finally
            {
                ReleaseExcelObject(workSheet);
                ReleaseExcelObject(wookbook);
                ReleaseExcelObject(excelApp);

                if (excelApp != null && excelProcessId > 0)
                {
                    Process.GetProcessById((int)excelProcessId).Kill();
                }
            }

            return true;
        }

        private static void ReleaseExcelObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception)
            {
                obj = null;
                throw;
            }
            finally
            {
                GC.Collect();
            }
        }


        private int GetData_Xls_ErrorList()
        {
            int nAdd_SumCnt = 0;

            foreach (var arrVal in sXlsData)
            {
                //0,1      ,2   ,3     ,4    ,5      ,6
                //#,No,Name,Description,xData,yData,zData

                Array.Clear(CData.tSpcList, nAdd_SumCnt, 1);
                CData.tSpcList[nAdd_SumCnt].sNo         = String.IsNullOrEmpty(arrVal[(int)eSpcArray.No]) ? ""      : arrVal[(int)eSpcArray.No].ToString();
                CData.tSpcList[nAdd_SumCnt].sName       = String.IsNullOrEmpty(arrVal[(int)eSpcArray.Name]) ? ""    : arrVal[(int)eSpcArray.Name].ToString();
                CData.tSpcList[nAdd_SumCnt].sDescrip    = String.IsNullOrEmpty(arrVal[(int)eSpcArray.Description]) ? "" : arrVal[(int)eSpcArray.Description].ToString();
                CData.tSpcList[nAdd_SumCnt].sXdata      = String.IsNullOrEmpty(arrVal[(int)eSpcArray.xData]) ? ""   : arrVal[(int)eSpcArray.xData].ToString();
                CData.tSpcList[nAdd_SumCnt].sYdata      = String.IsNullOrEmpty(arrVal[(int)eSpcArray.yData]) ? ""   : arrVal[(int)eSpcArray.yData].ToString();
                CData.tSpcList[nAdd_SumCnt].sZdata      = String.IsNullOrEmpty(arrVal[(int)eSpcArray.zData]) ? ""   : arrVal[(int)eSpcArray.zData].ToString();
                nAdd_SumCnt++;
            }
            return 1;
        }

        private void dGV_SpcList_SelNum(bool bsel = false)
        {
            StringBuilder sb = new StringBuilder();
            sb.Clear();

            if (bsel == false)
            {
                dGV_DataList.Rows[0].Selected = true;
            }
            DataGridViewRow row = dGV_DataList.SelectedRows[0];   //선택된 Row 값 가져옴.
            nSelRow = row.Index + 1;
            rTB_SpcName.Text = CData.tSpcList[nSelRow].sNo + ":" + CData.tSpcList[nSelRow].sName;
            sb.Append(CData.tSpcList[nSelRow].sDescrip);
            sb.AppendLine();
            sb.Append("XData = " + CData.tSpcList[nSelRow].sXdata);
            sb.AppendLine();
            sb.Append("YData = " + CData.tSpcList[nSelRow].sYdata);
            sb.AppendLine();
            sb.Append("ZData = " + CData.tSpcList[nSelRow].sZdata);
            sb.AppendLine();

            rTB_SpcData.Text = sb.ToString();

            try
            {
                
            }
            catch (Exception ex)
            {
            }
        }

        private void dGV_SpcList_SelNum(int nRow)
        {
            StringBuilder sb = new StringBuilder();
            sb.Clear();

            nSelRow = nRow;
            rTB_SpcName.Text = CData.tSpcList[nSelRow].sNo + ":" + CData.tSpcList[nSelRow].sName;

            sb.Append(CData.tSpcList[nSelRow].sDescrip);
            sb.AppendLine();
            sb.Append("XData = " + CData.tSpcList[nSelRow].sXdata);
            sb.AppendLine();
            sb.Append("YData = " + CData.tSpcList[nSelRow].sYdata);
            sb.AppendLine();
            sb.Append("ZData = " + CData.tSpcList[nSelRow].sZdata);
            sb.AppendLine();

            rTB_SpcData.Text = sb.ToString();
            try
            {
            }
            catch (Exception ex)
            {
            }
        }

        private void Edit_SpcList_SelNum(bool bsel = false)
        {
            if (bsel == false)
            {
                dGV_DataList.Rows[0].Selected = true;
            }
            DataGridViewRow row = dGV_DataList.SelectedRows[0];   //선택된 Row 값 가져옴.
            nSelRow = row.Index + 1;
 
            CData.tSpcList[nSelRow].sDescrip =
            sXlsData[nSelRow][(int)eSpcArray.Description] = rTB_SpcData.Text;
        }

        private void TimerEvent(Object myObject, EventArgs myEventArgs)
        {

        }

        private void Click_Output(object sender, EventArgs e)
        {
            nEnable_Edit ^= 1;
            Btn_Output_Set();
            if (nEnable_Edit == 1)
            {
                Edit_SpcList_SelNum();
                WriteExcelData(sSpcDataPath, sXlsData);
            }
        }

        private void Btn_Output_Set()
        {
            btn_Save.BackColor = (nEnable_Edit == 1) ? Color.SteelBlue  : Gcolor.ColorBase;
            btn_Save.ForeColor = (nEnable_Edit == 1) ? Color.Red        : Color.Gray;
        }
        
        private void dGV_SpcList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewColumn item in dGV_DataList.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dGV_SpcList_SelNum(true);
        }


        private new void KeyDown(object sender, KeyEventArgs e)
        {
            DataGridViewRow row = dGV_DataList.SelectedRows[0];
            int nColCnt = dGV_DataList.RowCount;
            int nIndex = row.Index;
            int nNewIndex = 0;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (nIndex == 0)
                    {
                        nNewIndex = 1;
                    }
                    else
                    {
                        dGV_DataList.CurrentCell = null;
                        var row0 = dGV_DataList.Rows[nIndex];
                        row0.Selected = true;
                        dGV_DataList.CurrentCell = row0.Cells[0];
                        nNewIndex = row0.Index;
                    }

                    break;
                case Keys.Down:

                    dGV_DataList.CurrentCell = null;
                    var row1 = dGV_DataList.Rows[nIndex];
                    row1.Selected = true;
                    dGV_DataList.CurrentCell = row1.Cells[0];
                    nNewIndex = row1.Index + 2;
                    break;
                default:
                    break;
            }
            dGV_SpcList_SelNum(nNewIndex);
        }

        private void cbChartsel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //https://blog.naver.com/kimmingul/221877447894

            string str;
            grp_Chart.Text = cbChartsel.Text;
            str = cbChartsel.SelectedItem.ToString();
            var nSel = (int)cbChartsel.SelectedItem;

            chart_Spc.Series.Clear();
            switch (nSel)
            {
                case 0:
                    PointChart();
                    break;
                case 1:
                    FastPointChart();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
                case 10:
                    break;
            }
        }
        private void PointChart()
        {
            Series Chart1 = chart_Spc.Series.Add("Series5");
            Chart1.ChartType = SeriesChartType.Point;  // 점

            // 범례1 데이터
            //for (double i = 0; i < nXlsRow_length * Math.PI; i += 0.1)
            //{
            //    Chart1.Points.AddXY(i, CData.tSpcList[nAdd_SumCnt].sXdata);
            //}
        }

        private void FastPointChart()
        {
            Series Chart1 = chart_Spc.Series.Add("Series1");
            Chart1.ChartType = SeriesChartType.FastPoint;  // 점
        }
    }
}
