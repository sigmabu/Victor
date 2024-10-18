using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Reflection;

namespace Victor
{
    public partial class vwErrorList : UserControl
    {        
        private string sErrorListPath;
        private string sFolderPath;
        private string sFileName;

        private static string[,] sCsvData;
        private static int nSelRow;
        private static int nErrorList_Cnt;

        private static int nEnable_Output;

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

            dGV_ErrorList.Columns[(int)eErrorListGrid.No].Width         = 70;
            dGV_ErrorList.Columns[(int)eErrorListGrid.ErrCode].Width   = 100;
            dGV_ErrorList.Columns[(int)eErrorListGrid.Name].Width      = 425;
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
            nEnable_Output = 0;
            Btn_Output_Set();

            nSelRow = 0;
            dGV_ErrorList.ReadOnly = true;

            sErrorListPath = GVar.PATH_EQUIP_ErrorList;
            int FindDot = sErrorListPath.LastIndexOf(".");
            int Lastsp = sErrorListPath.LastIndexOf("\\");

            sFileName = sErrorListPath.Substring(Lastsp + 1, FindDot - Lastsp - 1);
            sFolderPath = sErrorListPath.Replace(sFileName + ".csv", "");
            Read_File_Errorist();
            dGV_ErrorList_SelNum(false);
        }
               

        public void Open()
        {
            switch (mViewPage.nMaintPage)
            {
                case 0:
                    Read_File_Errorist();

                    break;
                case 312:
                    Read_File_Errorist();
                    break;
                case 314:
                    Init_View_Set();

                    break;
                case 315:
                    Init_View_Set();

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
                        nEnable_Output = 0;
                    }
                    break;
                case 315:
                    {
                        nEnable_Output = 0;
                    }
                    break;

                default: break;
            }
        }

        private void Save_UiData()
        {

            bool create = CCsv.SaveCSVFile(this.sErrorListPath, sCsvData, overwrite: true);
        }

        public int Read_File_Errorist()
        {
            dGV_ErrorList.DataSource = Display_File_ErrorList(sErrorListPath, out nErrorList_Cnt);

            int nLineCnt = 0;
            int nAdd_SumCnt = 0;
            //return 1;
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
                        eErr err;
                        if (Enum.TryParse(arrVal[2], out err))
                        {
                            //0,1      ,2   ,3     ,4    ,5      ,6        ,7      ,8        ,9      ,10
                            //#,ErrorCode,Name,Action,Image,Name_En,Action_En,Name_Ch,Action_Ch,Name_Kr,Action_Kr

                            Array.Clear(CData.tErrorList, nAdd_SumCnt, 1);
                            CData.tErrorList[nAdd_SumCnt].sNo = arrVal[0];
                            CData.tErrorList[nAdd_SumCnt].sCode = arrVal[1];
                            CData.tErrorList[nAdd_SumCnt].sName = arrVal[2];
                            CData.tErrorList[nAdd_SumCnt].sAction   = (arrVal.Length > 3) ? arrVal[3]  : "";
                            CData.tErrorList[nAdd_SumCnt].sImage    = (arrVal.Length > 4) ? arrVal[4]  : "";
                            CData.tErrorList[nAdd_SumCnt].sName_En  = (arrVal.Length > 5) ? arrVal[5]  : "";
                            CData.tErrorList[nAdd_SumCnt].sAction_En = (arrVal.Length > 6) ? arrVal[6] : "";
                            CData.tErrorList[nAdd_SumCnt].sName_Ch  = (arrVal.Length > 7) ? arrVal[7]  : "";
                            CData.tErrorList[nAdd_SumCnt].sAction_Ch = (arrVal.Length > 8) ? arrVal[8] : "";
                            CData.tErrorList[nAdd_SumCnt].sName_Ch  = (arrVal.Length > 9) ? arrVal[9]  : "";
                            CData.tErrorList[nAdd_SumCnt].sAction_Ch = (arrVal.Length > 10) ? arrVal[10] : "";
                            nAdd_SumCnt++;
                            /*
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

                            _list[err] = errData;
                            */
                        }
                    }
                }
            }
            return 1;
            /*
            sCsvData = CCsv.Open_ErrorCSVFile(this.sErrorListPath, nErrorList_Cnt);


            foreach (string str in sCsvData)
            {
                if((nAdd_SumCnt + 1) >= nLineCnt)
                {
                    return -1;
                }
                else if (string.IsNullOrEmpty(sCsvData[nAdd_SumCnt + 1, (int)eIOArray.Label]))
                {
                    return -1;
                }
                else if (sCsvData[nAdd_SumCnt + 1, (int)eIOArray.Label].ToString() == GVar.EOF)
                {
                    return -1;
                }

                CData.tErrorList[nAdd_SumCnt].sNo       = sCsvData[nAdd_SumCnt + 1, (int)eErrorArray.No];
                CData.tErrorList[nAdd_SumCnt].sCode     = sCsvData[nAdd_SumCnt + 1, (int)eErrorArray.Code];
                CData.tErrorList[nAdd_SumCnt].sName     = sCsvData[nAdd_SumCnt + 1, (int)eErrorArray.Name];
                CData.tErrorList[nAdd_SumCnt].sAction   = sCsvData[nAdd_SumCnt + 1, (int)eErrorArray.Action];
                CData.tErrorList[nAdd_SumCnt].sName_En  = sCsvData[nAdd_SumCnt + 1, (int)eErrorArray.Name_En];
                CData.tErrorList[nAdd_SumCnt].sAction_En = sCsvData[nAdd_SumCnt + 1, (int)eErrorArray.Action_En];
                CData.tErrorList[nAdd_SumCnt].sName_Ch = sCsvData[nAdd_SumCnt + 1, (int)eErrorArray.Name_Ch];
                CData.tErrorList[nAdd_SumCnt].sAction_Ch = sCsvData[nAdd_SumCnt + 1, (int)eErrorArray.Action_Ch];
                CData.tErrorList[nAdd_SumCnt].sName_Ch = sCsvData[nAdd_SumCnt + 1, (int)eErrorArray.Name_Ch];
                CData.tErrorList[nAdd_SumCnt].sAction_Ch = sCsvData[nAdd_SumCnt + 1, (int)eErrorArray.Action_Ch];
                CData.tErrorList[nAdd_SumCnt].sName_Kr = sCsvData[nAdd_SumCnt + 1, (int)eErrorArray.Name_Kr];
                CData.tErrorList[nAdd_SumCnt].sAction_Kr = sCsvData[nAdd_SumCnt + 1, (int)eErrorArray.Action_Kr];
                nAdd_SumCnt++;
            }

            dGV_ErrorList.Rows[0].Selected = false;
            return 0;
            */
        }
        public int Write_File_ErrorConfig()
        {
            bool create = CCsv.SaveCSVFile(this.sErrorListPath, sCsvData, overwrite: true);
            return 0;
        }

        
        private void Click_Open(object sender, EventArgs e)
        {
            Read_File_Errorist();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dGV_ErrorList.DataSource = Display_File_ErrorList(sErrorListPath, out nErrorList_Cnt);
        }

        public DataTable Display_File_ErrorList(string filePath, out int nList_Cnt )
        {
            string sData;
            var dt = new DataTable();
            string[] keywords = { "Action", "Image", "Name_En", "Action_En", "Name_Ch" , "Action_Ch", "Name_Kr", "Action_Kr" };
            int nWordCnt;
            int nHeadCnt = 0;
            nList_Cnt = 0;

            bool bAdd_Flag;
            int[] nSkip_Col = new int[(int)eErrorArray.End];
            Array.Clear(nSkip_Col, 0, (int)eErrorArray.End);

            StringBuilder sb = new StringBuilder();
            sb.Clear();
            string[] sRowwords00;

            int nHeadWord_Cnt = 0;
            int nSkip_Cnt = 0;

            int nAddWord_Cnt = 0;

            // 첫번째 행을 읽어 컬럼명으로 세팅
            foreach (var headerLine in File.ReadLines(filePath,Encoding.Default).Take(1))
            {
                foreach (var headerItem in headerLine.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {                
                    sData = headerItem;
                    bAdd_Flag = true;
                    for (nWordCnt = 0; nWordCnt < keywords.Length; nWordCnt++)
                    {
                        if (sData.ToUpper().Contains(keywords[nWordCnt].ToUpper()) == true)
                        {
                            sData = sData.ToUpper().Replace(keywords[nWordCnt], "");
                            bAdd_Flag = false;
                            nSkip_Col[nHeadCnt] = 1;
                        }
                    }
                    if(bAdd_Flag == true)
                    {
                        dt.Columns.Add(sData.Trim());
                        nHeadWord_Cnt++;
                    }
                    nHeadCnt++;
                }
            }
            // 나머지 행을 읽어 데이터로 세팅
            foreach (var line in File.ReadLines(filePath, Encoding.Default).Skip(1))
            {
                int nth = line.IndexOf("E".ToUpper());
                if (line.Contains(GVar.EOF) ||
                    (line.Contains(",") == false) ||
                    string.IsNullOrEmpty(line))
                {
                    Console.WriteLine($"문자가 없는 라인 또는 EOF 라인 {line}");
                }
                else if (line.IndexOf("E".ToUpper()) != 0)
                {
                    Console.WriteLine($"첫째 문자가 E 아니면  Skip : {line}");
                }
                else
                {
                    nAddWord_Cnt = 0;
                    sRowwords00 = line.ToString().Split(',');
                    for (nSkip_Cnt = 0; nSkip_Cnt < sRowwords00.Length; nSkip_Cnt++)
                    {                        
                        if (nSkip_Col[nSkip_Cnt] == 0)
                        {
                            sb.Append(sRowwords00[nSkip_Cnt]);
                            if ((nSkip_Cnt + 1) >= sRowwords00.Length) sb.Append("\n");
                            if ((nAddWord_Cnt + 1) < nHeadWord_Cnt) sb.Append(",");
                            else break;
                            nAddWord_Cnt++;
                        }
                    }
                    dt.Rows.Add(sb.ToString().Split(','));
                    nList_Cnt++;
                    //dt.Rows.Add(line.Split(','));
                    sb.Clear();
                }
            }
            return dt;
        }
        private void dGV_ErrorList_SelNum(bool bsel = false)
        {
            if (bsel == false)
            {
                dGV_ErrorList.Rows[0].Selected = true;
            }
            DataGridViewRow row = dGV_ErrorList.SelectedRows[0];   //선택된 Row 값 가져옴.
            nSelRow = row.Index;
            //tb_No.Text      = row.Cells[(int)eEthernet.No].Value.ToString();        // row의 컬럼(Cells[0]) = name
            rTB_ErrTitle.Text    = row.Cells[(int)eErrorArray.No].Value.ToString() + ":" + row.Cells[(int)eErrorArray.Name].Value.ToString();
            rTB_ErrorCause.Text = CData.tErrorList[nSelRow].sAction.ToString();
            //tb_IP.Text    = row.Cells[(int)eEthernet.IPaddress].Value.ToString();
            //tb_Port.Text    = row.Cells[(int)eEthernet.Port_no].Value.ToString();
            //cb_Host.Text  = row.Cells[(int)eEthernet.Host].Value.ToString();
            //cb_Proc.Text  = row.Cells[(int)eEthernet.Protocol].Value.ToString();      
        }

        private void TimerEvent(Object myObject, EventArgs myEventArgs)
        {

        }

        private void Click_Output(object sender, EventArgs e)
        {
            nEnable_Output ^= 1;
            Btn_Output_Set();
        }

        private void Btn_Output_Set()
        {
            btn_Save.BackColor = (nEnable_Output == 1) ? Color.SteelBlue : Gcolor.ColorBase;
            btn_Save.ForeColor = (nEnable_Output == 1) ? Color.Red : Color.Gray;
        }
        
        private void dGV_ErrorList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewColumn item in dGV_ErrorList.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dGV_ErrorList_SelNum(true);
        }
    }
}
