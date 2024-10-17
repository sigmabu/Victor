using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Runtime.InteropServices;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ExplorerBar;


namespace Victor
{
    public partial class vwIOList : UserControl
    {
        private string sIOListPath;
        private string sFolderPath;
        private string sFileName;

        private static string[,] sCsvData;
        static int nSelRow;


        public vwIOList()
        {
            InitializeComponent();
            Init_View_Set();
        }

        private bool _Release()
        {            

            return true;
        }

        private void Init_View_Set()
        {
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

        string EnumToString(eRecipGroup eGroup)
        {
            return eGroup.ToString();
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
                    }
                    break;
                default: break;
            }
        }

        private void Save_UiData()
        {

            bool create = CCsv.SaveCSVFile(this.sIOListPath, sCsvData, overwrite: true);
        }

        public int Read_File_IOList()
        {
            dGV_InputList.DataSource = Display_File_IOListConfig(sIOListPath, eIO_Kind.In);
            dGV_OutputList.DataSource = Display_File_IOListConfig(sIOListPath, eIO_Kind.Out);

            int nLineCnt = 0;
            int nAdd_InCnt = 0;
            int nAdd_OutCnt = 0;
            int nAdd_SumCnt = 0;
            
            sCsvData = CCsv.OpenCSVFile(this.sIOListPath, out nLineCnt);


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

            dGV_InputList.Rows[0].Selected = true;
            dGV_OutputList.Rows[0].Selected = true;
            return 0;
        }
        public int Write_File_SerialConfig()
        {
            bool create = CCsv.SaveCSVFile(this.sIOListPath, sCsvData, overwrite: true);
            return 0;
        }


        
        private void Click_Open(object sender, EventArgs e)
        {
            Read_File_IOList();
            //Display_File_SerialConfig();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dGV_InputList.DataSource = Display_File_IOListConfig(sIOListPath, eIO_Kind.In);
            dGV_OutputList.DataSource = Display_File_IOListConfig(sIOListPath, eIO_Kind.Out);
        }

        public DataTable Display_File_IOListConfig(string filePath, eIO_Kind eIo_kind = eIO_Kind.In)
        {
            string sData;
            var dt = new DataTable();
            string[] keywords = { "IN/OUT", "In", "Out", "Description" };
            int nWordCnt;
            int nHeadCnt = 0;
            int nComaCnt;
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
                if (line.Contains("EOF") ||
                    (line.Contains(",") == false) ||
                    string.IsNullOrEmpty(line))
                {
                    Console.WriteLine($"문자가 없는 라인 또는 EOF 라인 {line}");
                }
                else if (line.Contains(eIo_kind.ToString()) == false)
                {
                    Console.WriteLine($"해당 InOut List 아니면 Skip : line => {eIo_kind.ToString()}");
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



    }
}
