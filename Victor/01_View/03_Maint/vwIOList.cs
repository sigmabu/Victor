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
    public partial class vwIOList : UserControl
    {        
        private string sIOListPath;
        private string sFolderPath;
        private string sFileName;

        private static string[,] sCsvData;
        private static int nSelRow;
        private static int nInList_Cnt;
        private static int nOutList_Cnt;

        private static int nEnable_Output;

        public vwIOList()
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
            dGV_InputList.DoubleBuffered(true);
            dGV_OutputList.DoubleBuffered(true);

            dGV_InputList.Columns[(int)eIOListGrid.Label].Width     = dGV_OutputList.Columns[(int)eIOListGrid.Label].Width  = 70;
            dGV_InputList.Columns[(int)eIOListGrid.Name].Width      = dGV_OutputList.Columns[(int)eIOListGrid.Name].Width   = 380;
            dGV_InputList.Columns[(int)eIOListGrid.Coil].Width      = dGV_OutputList.Columns[(int)eIOListGrid.Coil].Width   = 45;
            dGV_InputList.Columns[(int)eIOListGrid.Part].Width      = dGV_OutputList.Columns[(int)eIOListGrid.Part].Width   = 100;

            dGV_InputList.RowTemplate.Height = dGV_OutputList.RowTemplate.Height =  30;

            dGV_InputList.ReadOnly = dGV_OutputList.ReadOnly = true;
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
            dGV_InputList.ReadOnly = 
            dGV_OutputList.ReadOnly = true;

            sIOListPath = GVar.PATH_EQUIP_IOList;
            int FindDot = sIOListPath.LastIndexOf(".");
            int Lastsp = sIOListPath.LastIndexOf("\\");

            sFileName = sIOListPath.Substring(Lastsp + 1, FindDot - Lastsp - 1);
            sFolderPath = sIOListPath.Replace(sFileName + ".csv", "");
            Read_File_IOList();
            dGV_IOList_SelNum(false);
        }
               

        public void Open()
        {
            switch (mViewPage.nMaintPage)
            {
                case 0:
                    Read_File_IOList();

                    break;
                case 312:
                    Read_File_IOList();
                    break;
                case 314:
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
                default: break;
            }
        }

        private void Save_UiData()
        {

            bool create = CSV.SaveCSVFile(this.sIOListPath, sCsvData, overwrite: true);
        }

        public int Read_File_IOList()
        {
            dGV_InputList.DataSource = Display_File_IOListConfig(sIOListPath, out nInList_Cnt, eIO_Kind.In);
            dGV_OutputList.DataSource = Display_File_IOListConfig(sIOListPath, out nOutList_Cnt, eIO_Kind.Out);

            int nLineCnt = 0;
            int nAdd_InCnt = 0;
            int nAdd_OutCnt = 0;
            int nAdd_SumCnt = 0;
            
            sCsvData = CSV.OpenCSVFile(this.sIOListPath, out nLineCnt);


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
                if (sCsvData[nAdd_SumCnt + 1, (int)eIOArray.InOut].ToString() == eIO_Kind.In.ToString())
                {

                    CData.tInList[nAdd_InCnt].sLabel = sCsvData[nAdd_SumCnt + 1, (int)eIOArray.Label];
                    CData.tInList[nAdd_InCnt].sInOut = sCsvData[nAdd_SumCnt + 1, (int)eIOArray.InOut];
                    CData.tInList[nAdd_InCnt].sName = sCsvData[nAdd_SumCnt + 1, (int)eIOArray.Name];
                    CData.tInList[nAdd_InCnt].sCoil = sCsvData[nAdd_SumCnt + 1, (int)eIOArray.Coil];
                    CData.tInList[nAdd_InCnt].sPart = sCsvData[nAdd_SumCnt + 1, (int)eIOArray.Part];
                    CData.tInList[nAdd_InCnt].sDesc = sCsvData[nAdd_SumCnt + 1, (int)eIOArray.Desc];

                    nAdd_InCnt++;
                }
                else
                {
                    CData.tOutList[nAdd_OutCnt].sLabel = sCsvData[nAdd_SumCnt + 1, (int)eIOArray.Label];
                    CData.tOutList[nAdd_OutCnt].sInOut = sCsvData[nAdd_SumCnt + 1, (int)eIOArray.InOut];
                    CData.tOutList[nAdd_OutCnt].sName = sCsvData[nAdd_SumCnt + 1, (int)eIOArray.Name];
                    CData.tOutList[nAdd_OutCnt].sCoil = sCsvData[nAdd_SumCnt + 1, (int)eIOArray.Coil];
                    CData.tOutList[nAdd_OutCnt].sPart = sCsvData[nAdd_SumCnt + 1, (int)eIOArray.Part];
                    CData.tOutList[nAdd_OutCnt].sDesc = sCsvData[nAdd_SumCnt + 1, (int)eIOArray.Desc];

                    nAdd_OutCnt++;
                }
                nAdd_SumCnt++;
            }

            dGV_InputList.Rows[0].Selected = false;
            dGV_OutputList.Rows[0].Selected = false;
            return 0;
        }
        
        private void Click_Open(object sender, EventArgs e)
        {
            Read_File_IOList();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dGV_InputList.DataSource = Display_File_IOListConfig(sIOListPath, out nInList_Cnt, eIO_Kind.In);
            dGV_OutputList.DataSource = Display_File_IOListConfig(sIOListPath, out nOutList_Cnt, eIO_Kind.Out);
        }

        public DataTable Display_File_IOListConfig(string filePath, out int nList_Cnt , eIO_Kind eIo_kind = eIO_Kind.In)
        {
            string sData;
            var dt = new DataTable();
            string[] keywords = { "IN/OUT", "In", "Out", "Description" };
            int nWordCnt;
            int nHeadCnt = 0;
            nList_Cnt = 0;

            bool bAdd_Flag;
            int[] nSkip_Col = new int[(int)eIOArray.End];
            Array.Clear(nSkip_Col, 0, (int)eIOArray.End);

            StringBuilder sb = new StringBuilder();
            sb.Clear();
            string[] sRowwords00;

            int nSkip_Cnt = 0;

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
                    }
                    nHeadCnt++;
                }
            }
            // 나머지 행을 읽어 데이터로 세팅
            foreach (var line in File.ReadLines(filePath, Encoding.Default).Skip(1))
            {
                if (line.Contains(GVar.EOF) ||
                    (line.Contains(",") == false) ||
                    string.IsNullOrEmpty(line))
                {
                    //Console.WriteLine($"문자가 없는 라인 또는 EOF 라인 {line}");
                }
                else if (line.Contains(eIo_kind.ToString()) == false)
                {
                    //Console.WriteLine($"0.해당 InOut List 아니면 Skip : {line} => {eIo_kind.ToString()}");
                }
                else if ((line.IndexOf("X".ToUpper())  == 0) && (eIo_kind == eIO_Kind.Out))
                {
                    //Console.WriteLine($"1.해당 InOut List 아니면 Skip : {line} => {eIo_kind.ToString()}");
                }
                else if ((line.IndexOf("Y".ToUpper()) == 0) && (eIo_kind == eIO_Kind.In))
                {
                    //Console.WriteLine($"2.해당 InOut List 아니면 Skip : {line} => {eIo_kind.ToString()}");
                }
                else
                {
                    sRowwords00 = line.ToString().Split(',');
                    for (nSkip_Cnt = 0; nSkip_Cnt < sRowwords00.Length; nSkip_Cnt++)
                    {                        
                        if (nSkip_Col[nSkip_Cnt] == 0)
                        {
                            sb.Append(sRowwords00[nSkip_Cnt]);
                            if ((nSkip_Cnt + 1) >= sRowwords00.Length) sb.Append("\n");
                            else if ((nSkip_Cnt+2) < sRowwords00.Length) sb.Append(",");                            
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

        private void dGV_SerialList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dGV_IOList_SelNum(true);
        }
        private void dGV_IOList_SelNum(bool bsel = false)
        { 
            //if(bsel == false)
            //{
            //    dGV_InputtList.Rows[0].Selected = true;
            //}
            //DataGridViewRow row = dGV_InputtList.SelectedRows[0];   //선택된 Row 값 가져옴.
            //nSelRow = row.Index;
            //tb_No.Text      = row.Cells[(int)eEthernet.No].Value.ToString();        // row의 컬럼(Cells[0]) = name
            //tb_Name.Text    = row.Cells[(int)eEthernet.Port_Name].Value.ToString();
            //tb_IP.Text    = row.Cells[(int)eEthernet.IPaddress].Value.ToString();
            //tb_Port.Text    = row.Cells[(int)eEthernet.Port_no].Value.ToString();
            //cb_Host.Text  = row.Cells[(int)eEthernet.Host].Value.ToString();
            //cb_Proc.Text  = row.Cells[(int)eEthernet.Protocol].Value.ToString();      
        }

        private int nToggle = 0;
        private static int[] nDIN = new int[6] { 1, 3, 10, 21, 25, 28 };
        private static int[] nDOUT = new int[6] { 3, 3, 9, 26, 33, 56 };

        private void Timer_InPutList()
        {
            string sIN_Label;
            for (int i = 0; i < nInList_Cnt; i++)
            {
                sIN_Label = dGV_InputList.Rows[i].Cells[0].Value.ToString();
                sIN_Label = sIN_Label.Replace("X", "");
                var result = Utils.HexStr2Int(sIN_Label);
                foreach (var v  in nDIN)
                {
                    if(v == result)
                    {
                        dGV_InputList.Rows[i].DefaultCellStyle.ForeColor = (nToggle == 1)? Gcolor.Color_OnGreen : Color.White ;
                    }
                }
                //foreach (var s in sIN_Label)
                //{
                //    Console.WriteLine($" sIN_Label = {sIN_Label} ,  0x{result:X2} ({result})");
                //}                       
            }

        }

        private void Timer_OutPutList()
        {
            string sOUT_Label;

            for (int i = 0; i < nOutList_Cnt; i++)
            {
                sOUT_Label = dGV_OutputList.Rows[i].Cells[0].Value.ToString();
                sOUT_Label = sOUT_Label.Replace("Y", "");
                var result = Utils.HexStr2Int(sOUT_Label);
                foreach (var v in nDOUT)
                {
                    if (v == result)
                    {
                        dGV_OutputList.Rows[i].DefaultCellStyle.ForeColor = (nToggle == 1) ? Color.Red : Color.White;
                    }
                }                   
            }
        }
        private void TimerEvent(Object myObject, EventArgs myEventArgs)
        {
            nToggle ^= 1;

            Timer_InPutList();
            Timer_OutPutList();

        }

        private void Click_Output(object sender, EventArgs e)
        {
            nEnable_Output ^= 1;
            Btn_Output_Set();
        }

        private void Btn_Output_Set()
        {
            btn_Output.BackColor = (nEnable_Output == 1) ? Color.SteelBlue : Gcolor.ColorBase;
            btn_Output.ForeColor = (nEnable_Output == 1) ? Color.Red : Color.Gray;
        }

        private void dGV_OutputList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewColumn item in dGV_OutputList.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (nEnable_Output == 0) return;
            DataGridViewRow row = dGV_OutputList.SelectedRows[0];   //선택된 Row 값 가져옴.
            int nSelRow = row.Index;
            string sOUT_Label = dGV_OutputList.Rows[nSelRow].Cells[0].Value.ToString();
            sOUT_Label = sOUT_Label.Replace("Y", "");
            var result = Utils.HexStr2Int(sOUT_Label);
            

            //ToDo : 보드 Output
            HW.mIo.WriteOutBit((uint)result, (uint) 1);

            dGV_OutputList.Rows[nSelRow].DefaultCellStyle.ForeColor = (nToggle == 1) ? Color.Red : Color.White;

        }

        private void dGV_InList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewColumn item in dGV_InputList.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
}
