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


namespace Victor
{
    public partial class vwErrorList : UserControl
    {

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        Excel.Application excelApp = null;		// Excel 프로그램을 의미합니다.
        Excel.Workbook wookbook = null;				// 통합문서를 의미합니다.
        Excel._Worksheet workSheet = null;		// 워크시트를 의미합니다.
        uint excelProcessId = 0;

        private string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        private string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";

        private string sErrorListPath;
        private string sFolderPath;
        private string sFileName;

        private static string[][] sXlsData;
        private static int nSelRow;

        private static int nEnable_Edit;

        public vwErrorList()
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
            dGV_ErrorList.DoubleBuffered(true);

            dGV_ErrorList.Columns[(int)eErrorListGrid.ErrCode].Width    = 100;
            dGV_ErrorList.Columns[(int)eErrorListGrid.Name].Width       = 495;

            dGV_ErrorList.RowTemplate.Height = 30;

            dGV_ErrorList.Columns[(int)eErrorListGrid.Name].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dGV_ErrorList.ReadOnly = true;

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

            sErrorListPath = GVar.PATH_EQUIP_ErrorList;
            int FindDot = sErrorListPath.LastIndexOf(".");
            int Lastsp = sErrorListPath.LastIndexOf("\\");

            sFileName = sErrorListPath.Substring(Lastsp + 1, FindDot - Lastsp - 1);
            sFolderPath = sErrorListPath.Replace(sFileName + ".xls", "");
            
            Read_File_ErroList(true);
        }

        public int Read_File_ErroList(bool bFlag = false)
        {
            if (bFlag)
            {
                sXlsData = ReadExcelData(dGV_ErrorList, sErrorListPath, 1024);
            }
            GetData_Xls_ErrorList();
            dGV_ErrorList_SelNum(false);
            return 1;
        }

        public void Open()
        {
            switch (mViewPage.nMaintPage)
            {
                case 0:
                    //Read_File_ErroList();

                    break;
                case 312:
                    //Read_File_ErroList();
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
                //0,1      ,2   ,3     ,4    ,5      ,6        ,7      ,8        ,9      ,10
                //#,ErrorCode,Name,Action,Image,Name_En,Action_En,Name_Ch,Action_Ch,Name_Kr,Action_Kr

                Array.Clear(CData.tErrorList, nAdd_SumCnt, 1);
                CData.tErrorList[nAdd_SumCnt].sCode         = String.IsNullOrEmpty(arrVal[(int)eErrorArray.Code]) ? "" : arrVal[(int)eErrorArray.Code].ToString();
                CData.tErrorList[nAdd_SumCnt].sName         = String.IsNullOrEmpty(arrVal[(int)eErrorArray.Name]) ? "" : arrVal[(int)eErrorArray.Name].ToString();
                CData.tErrorList[nAdd_SumCnt].sAction       = String.IsNullOrEmpty(arrVal[(int)eErrorArray.Action]) ? "" : arrVal[(int)eErrorArray.Action].ToString();
                CData.tErrorList[nAdd_SumCnt].sImage        = String.IsNullOrEmpty(arrVal[(int)eErrorArray.Image]) ? "" : arrVal[(int)eErrorArray.Image].ToString();
                CData.tErrorList[nAdd_SumCnt].sName_En      = String.IsNullOrEmpty(arrVal[(int)eErrorArray.Name_En]) ? "" : arrVal[(int)eErrorArray.Name_En].ToString();
                CData.tErrorList[nAdd_SumCnt].sAction_En    = String.IsNullOrEmpty(arrVal[(int)eErrorArray.Action_En]) ? "" : arrVal[(int)eErrorArray.Action_En].ToString();
                CData.tErrorList[nAdd_SumCnt].sName_Ch      = String.IsNullOrEmpty(arrVal[(int)eErrorArray.Name_Ch]) ? "" : arrVal[(int)eErrorArray.Name_Ch].ToString();
                CData.tErrorList[nAdd_SumCnt].sAction_Ch    = String.IsNullOrEmpty(arrVal[(int)eErrorArray.Action_Ch]) ? "" : arrVal[(int)eErrorArray.Action_Ch].ToString();
                CData.tErrorList[nAdd_SumCnt].sName_Ch      = String.IsNullOrEmpty(arrVal[(int)eErrorArray.Name_Kr]) ? "" : arrVal[(int)eErrorArray.Name_Kr].ToString();
                CData.tErrorList[nAdd_SumCnt].sAction_Ch    = String.IsNullOrEmpty(arrVal[(int)eErrorArray.Action_Kr]) ? "" : arrVal[(int)eErrorArray.Action_Kr].ToString();
                nAdd_SumCnt++;
            }
            return 1;
        }

        private void dGV_ErrorList_SelNum(bool bsel = false)
        {
            if (bsel == false)
            {
                dGV_ErrorList.Rows[0].Selected = true;
            }
            DataGridViewRow row = dGV_ErrorList.SelectedRows[0];   //선택된 Row 값 가져옴.
            nSelRow = row.Index + 1;
            rTB_ErrTitle.Text = CData.tErrorList[nSelRow].sCode + ":" + CData.tErrorList[nSelRow].sName;
            rTB_ErrorCause.Text = CData.tErrorList[nSelRow].sAction;
            try
            {
                if (String.IsNullOrEmpty(CData.tErrorList[nSelRow].sImage) == false)
                {
                    //PictureBox 컨트롤에 디렉토리 경로의 이미지를 Load 합니다.
                    string sPath = GVar.PATH_EQUIP_ErrorImageFolder + CData.tErrorList[nSelRow].sImage + ".png";
                    pb_Image.Load(sPath);
                    //Load한 이미지 크기를 PictureBox 컨트롤 크기와 동일하게 맞추어 줍니다.
                    pb_Image.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    pb_Image.Image = null;

                }
            }
            catch (Exception ex)
            {
            }
        }

        private void dGV_ErrorList_SelNum(int nRow)
        {
            nSelRow = nRow;
            rTB_ErrTitle.Text = CData.tErrorList[nSelRow].sCode + ":" + CData.tErrorList[nSelRow].sName;
            rTB_ErrorCause.Text = CData.tErrorList[nSelRow].sAction;
            try
            {
                if (String.IsNullOrEmpty(CData.tErrorList[nSelRow].sImage) == false)
                {
                    //PictureBox 컨트롤에 디렉토리 경로의 이미지를 Load 합니다.
                    string sPath = GVar.PATH_EQUIP_ErrorImageFolder + CData.tErrorList[nSelRow].sImage + ".png";
                    pb_Image.Load(sPath);
                    //Load한 이미지 크기를 PictureBox 컨트롤 크기와 동일하게 맞추어 줍니다.
                    pb_Image.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    pb_Image.Image = null;

                }
            }
            catch (Exception ex)
            {
            }
        }

        private void Edit_ErrorList_SelNum(bool bsel = false)
        {
            if (bsel == false)
            {
                dGV_ErrorList.Rows[0].Selected = true;
            }
            DataGridViewRow row = dGV_ErrorList.SelectedRows[0];   //선택된 Row 값 가져옴.
            nSelRow = row.Index + 1;
 
            CData.tErrorList[nSelRow].sAction =
            sXlsData[nSelRow][(int)eErrorArray.Action] = rTB_ErrorCause.Text;
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
                Edit_ErrorList_SelNum();
                WriteExcelData(sErrorListPath, sXlsData);
            }
        }

        private void Btn_Output_Set()
        {
            btn_Save.BackColor = (nEnable_Edit == 1) ? Color.SteelBlue : Gcolor.ColorBase;
            btn_Save.ForeColor = (nEnable_Edit == 1) ? Color.Red : Color.Gray;
        }
        
        private void dGV_ErrorList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewColumn item in dGV_ErrorList.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dGV_ErrorList_SelNum(true);
        }

        private new void KeyDown(object sender, KeyEventArgs e)
        {
            DataGridViewRow row = dGV_ErrorList.SelectedRows[0];
            int nIndex = row.Index;

            if (e.KeyCode.Equals(Keys.Up))
            {
                dGV_ErrorList.CurrentCell = null;
                var row0 = dGV_ErrorList.Rows[nIndex];
                row0.Selected = true;
                dGV_ErrorList.CurrentCell = row0.Cells[0];
            }
            if(e.KeyCode.Equals(Keys.Down))
            {
                dGV_ErrorList.CurrentCell = null;
                var row1 = dGV_ErrorList.Rows[nIndex];
                row1.Selected = true;
                dGV_ErrorList.CurrentCell = row1.Cells[0];
            }
            row = dGV_ErrorList.SelectedRows[0];
            int nNewIndex = row.Index;

            dGV_ErrorList_SelNum(nNewIndex);
        }
    }
}
