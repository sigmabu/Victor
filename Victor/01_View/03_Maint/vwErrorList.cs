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
using Microsoft.Office.Interop.Excel;
using System.Linq;
using System.Text;


namespace Victor
{
    public partial class vwErrorList : UserControl
    {
        public EErr Current { get; private set; } = EErr.NONE;

        private string sErrorListPath = GVar.PATH_EQUIP_ErrorList;
        private string sFolderPath;
        private string sFileName;
        private static int nEnable_Edit;

        private static int nSelRow;


        public vwErrorList()
        {
            InitializeComponent();

            int FindDot = sErrorListPath.LastIndexOf(".");
            int Lastsp = sErrorListPath.LastIndexOf("\\");

            sFileName = sErrorListPath.Substring(Lastsp + 1, FindDot - Lastsp - 1);
            sFolderPath = sErrorListPath.Replace(sFileName + ".csv", "");

            Init_ErrorList();
            Init_View_Set();

            Init_Grid_Set();
            //Init_Timer();
        }

        private bool _Release()
        {
            return true;
        }
        private void Init_ErrorList()
        {
            // 리스트 초기화

            EErr[] errs = (EErr[])Enum.GetValues(typeof(EErr));             // 정의된 Error code 수량만큼 List 생성하여 추가
            int cnt = errs.Length;
            for (int i = 0; i < cnt; i++)
            {
                TErr err = new TErr();
                err.number = (int)errs[i];
                err.name = errs[i].ToString();
                err.action = string.Empty;

                // 다국어 지원용
                err.Name_En = string.Empty;
                err.Name_Kr = string.Empty;
                err.Name_Ch = string.Empty;
                err.Action_En = string.Empty;
                err.Action_Kr = string.Empty;
                err.Action_Ch = string.Empty;

                CData.tErrlist.Add(errs[i], err);
            }
        }
        private void _Save()
        {
            StringBuilder builder = new StringBuilder();

            if (!Directory.Exists(sFolderPath))
            {
                Directory.CreateDirectory(sFolderPath);
            }

            builder.AppendLine("#,ErrCode,Name,Action,Image,Name_En,Action_En,Name_Ch,Action_Ch,Name_Kr,Action_Kr");

            // int cnt = tErrlist.Count;
            for (int i = 0; i < CData.tErrlist.Count; i++)
            {
                EErr err = CData.tErrlist.Keys.ToArray()[i];

                builder.Append($"{i},");
                builder.Append(CData.tErrlist[err].number + ",");
                builder.Append(CData.tErrlist[err].name + ",");
                builder.Append(CData.tErrlist[err].action + ",");
                builder.Append(CData.tErrlist[err].image + ",");

                builder.Append(CData.tErrlist[err].Name_En + ",");
                builder.Append(CData.tErrlist[err].Action_En + ",");
                builder.Append(CData.tErrlist[err].Name_Ch + ",");
                builder.Append(CData.tErrlist[err].Action_Ch + ",");
                builder.Append(CData.tErrlist[err].Name_Kr + ",");
                builder.Append(CData.tErrlist[err].Action_Kr);

                builder.AppendLine();
            }
            using (StreamWriter writer = new StreamWriter(sErrorListPath))
            {
                writer.Write(builder.ToString());
            }
        }

        private int Init_Load_ErrorFile_csv()
        {
            if (!Directory.Exists(sFolderPath))
            {
                Directory.CreateDirectory(sFolderPath);
            }

            if (!File.Exists(sErrorListPath))
            {
                _Save();
                return 0;
            }

            using (StreamReader reader = new StreamReader(sErrorListPath))
            {
                string all = reader.ReadToEnd();
                string[] arrAll = all.Replace("\r", "").Split("\n".ToCharArray());

                foreach (string val in arrAll)
                {
                    string[] arrVal = val.ToString().Split(',');
                    if (arrVal[0].Contains("#"))
                    {
                        // 주석 문구
                        continue;
                    }
                    else if (arrVal.Length > 2)
                    {
                        EErr err;
                        if (Enum.TryParse(arrVal[2], out err))
                        {
                            TErr errData = new TErr();

                            //0,1      ,2   ,3     ,4    ,5      ,6        ,7      ,8        ,9      ,10
                            //#,ErrCode,Name,Action,Image,Name_En,Action_En,Name_Ch,Action_Ch,Name_Kr,Action_Kr

                            errData.number = (int)err;
                            errData.name = arrVal[2];

                            if (arrVal.Length >= 5)
                            {
                                errData.action = arrVal[3];
                                errData.image = arrVal[4];

                                // 다국어 지원 내용이 존재하면 취득한다.
                                if (arrVal.Length >= 7)
                                {
                                    errData.Name_En = arrVal[5];
                                    errData.Action_En = arrVal[6];

                                    if (arrVal.Length >= 9)
                                    {
                                        errData.Name_Ch = arrVal[7];
                                        errData.Action_Ch = arrVal[8];

                                        if (arrVal.Length >= 11)
                                        {
                                            errData.Name_Kr = arrVal[9];
                                            errData.Action_Kr = arrVal[10];
                                        }
                                    }
                                }
                            }
                            CData.tErrlist[err] = errData;
                        }
                    }
                }
            }
            // 불러오기 이후 다시 저장하여 추가된 Error 항목 저장
            _Save();
            return 0;
        }

        // Code에 정의된 Alarm Name을 표시한다.
        public string GetName(EErr error)
        {
            return CData.tErrlist[error].name;
        }


        // 다국어 지원되는 Alarm 이름을 조회한다.
        public string GetName2(EErr error, int nLang = -1)
        {
            // 다국어 지원이 가능하다면 지정한 언어로 회신해준다.
            if (nLang == (int)ELang.English)
            {
                return CData.tErrlist[error].Name_En;
            }
            else if (nLang == (int)ELang.Chinese)
            {
                return CData.tErrlist[error].Name_En + "\n" + CData.tErrlist[error].Name_Ch;
            }
            else if (nLang == (int)ELang.Korean)
            {
                return CData.tErrlist[error].Name_En + "\n" + CData.tErrlist[error].Name_Kr;
            }

            return CData.tErrlist[error].name;
        }


        // Alarm의 원인 및 조치 내용을 조회한다.
        public string GetAction(EErr error, int nLang = -1)
        {
            // 다국어 지원이 가능하다면 지정한 언어로 회신해준다.
            if (nLang == (int)ELang.English)
            {
                return string.IsNullOrEmpty(CData.tErrlist[error].Action_En) ? CData.tErrlist[error].action : CData.tErrlist[error].Action_En;
            }
            else if (nLang == (int)ELang.Chinese)
            {
                return string.IsNullOrEmpty(CData.tErrlist[error].Action_Ch) ? CData.tErrlist[error].action : CData.tErrlist[error].Action_Ch;
            }
            else if (nLang == (int)ELang.Korean)
            {
                return string.IsNullOrEmpty(CData.tErrlist[error].Action_Kr) ? CData.tErrlist[error].action : CData.tErrlist[error].Action_Kr;
            }

            return CData.tErrlist[error].action;
        }


        public string GetImage(EErr error)
        {
            return CData.tErrlist[error].image;
        }

        private void Init_Grid_Set()
        {
            dGV_ErrorList.DoubleBuffered(true);

            var dt = new DataTable();

            //dt.Columns.Add(tErrlist[0].number.ToString());
            //dt.Columns.Add(tErrlist[0].name.ToString());
            dt.Columns.Add("No");
            dt.Columns.Add("Error Name");
            for (int i = 1; i < CData.tErrlist.Count; i++)
            {
                EErr err = CData.tErrlist.Keys.ToArray()[i];
                dt.Rows.Add(CData.tErrlist[err].number.ToString(), CData.tErrlist[err].name.ToString());
            }
            dGV_ErrorList.DataSource = dt;

            dGV_ErrorList.Columns[(int)eErrorListGrid.ErrCode].Width = 100;
            dGV_ErrorList.Columns[(int)eErrorListGrid.Name].Width = 495;

            dGV_ErrorList.RowTemplate.Height = 30;

            dGV_ErrorList.Columns[(int)eSpcGrid.Name].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

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

            Init_Load_ErrorFile_csv();

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
                    //Init_FilePath();

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
        private void dGV_ErrorList_SelNum(bool bsel = false)
        {
            if (bsel == false)
            {
                dGV_ErrorList.Rows[0].Selected = true;
            }
            DataGridViewRow nRow = dGV_ErrorList.SelectedRows[0];   //선택된 Row 값 가져옴.
            if (nRow.Index > (CData.tErrlist.Count - 1)) return;
            EErr nSelRow = CData.tErrlist.Keys.ToArray()[nRow.Index +1];
            rTB_ErrTitle.Text = CData.tErrlist[nSelRow].number + ":" + CData.tErrlist[nSelRow].name;
            rTB_ErrorCause.Text = CData.tErrlist[nSelRow].action;
            try
            {
                string sPath = GVar.PATH_EQUIP_ErrorImageFolder + "E" + CData.tErrlist[nSelRow].number + ".png";
                if (File.Exists(sPath))
                {
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
            //nSelRow = nRow;
            if (nRow > (CData.tErrlist.Count -1)) return;
            EErr nSelRow = CData.tErrlist.Keys.ToArray()[nRow];
            rTB_ErrTitle.Text = CData.tErrlist[nSelRow].number + ":" + CData.tErrlist[nSelRow].name;
            rTB_ErrorCause.Text = CData.tErrlist[nSelRow].action;
            try
            {
                string sPath = GVar.PATH_EQUIP_ErrorImageFolder + "E"+CData.tErrlist[nSelRow].number + ".png";
                if (File.Exists(sPath))
                {
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
                Edit_ErrorCause(nSelRow);
                
                //EErr err = CData.tErrlist.Keys.ToArray()[nSelRow];
                //CData.tErrlist[err].action = rTB_ErrorCause.Text;


                //WriteExcelData(sErrorListPath, sXlsData);
            }
        }

        /// <summary>
        /// 이곳은 더 버ㅏ야 할듯
        /// </summary>
        /// <param name="nENum"></param>
        private void Edit_ErrorCause(int nENum)
        {
            EErr[] errs = (EErr[])Enum.GetValues(typeof(EErr));             // 정의된 Error code 수량만큼 List 생성하여 추가
            int cnt = errs.Length;
            //for (int i = 0; i < cnt; i++)
            {
                TErr err = new TErr();
                err.number = (int)errs[nENum];
                err.name = errs[nENum].ToString();
                err.action = string.Empty;
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
            int nColCnt = dGV_ErrorList.RowCount;
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
                        dGV_ErrorList.CurrentCell = null;
                        var row0 = dGV_ErrorList.Rows[nIndex];
                        row0.Selected = true;
                        dGV_ErrorList.CurrentCell = row0.Cells[0];
                        nNewIndex = row0.Index;
                    }

                    break;
                case Keys.Down:

                    dGV_ErrorList.CurrentCell = null;
                    var row1 = dGV_ErrorList.Rows[nIndex];
                    row1.Selected = true;
                    dGV_ErrorList.CurrentCell = row1.Cells[0];
                    nNewIndex = row1.Index + 2;
                    break;
                default:
                    break;
            }
            dGV_ErrorList_SelNum(nNewIndex);
        }   
    }
}
