﻿using System;
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
            dGV_InputList.ReadOnly = true;

            sIOListPath = GVar.PATH_EQUIP_IOList;
            int FindDot = sIOListPath.LastIndexOf(".");
            int Lastsp = sIOListPath.LastIndexOf("\\");

            sFileName = sIOListPath.Substring(Lastsp + 1, FindDot - Lastsp - 1);
            sFolderPath = sIOListPath.Replace(sFileName + ".csv", "");
            Read_File_IOList();
            dGV_SerialList_SelNum(false);
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
            dGV_InputList.DataSource = Display_File_SerialConfig(sIOListPath);

            int nLineCnt = 0;
            sCsvData = CCsv.OpenCSVFile(this.sIOListPath, out nLineCnt);
            int nAddCnt = 0;

            foreach (string str in sCsvData)
            {
                if(nAddCnt+1>=nLineCnt)
                {
                    return -1;
                }
                if (string.IsNullOrEmpty(sCsvData[nAddCnt + 1, (int)eIOArray.Label]))
                {
                    return -1;
                }
                CData.tInList[nAddCnt].sLabel  = sCsvData[nAddCnt + 1, (int)eIOArray.Label];
                CData.tInList[nAddCnt].sInOut  = sCsvData[nAddCnt + 1, (int)eIOArray.InOut];
                CData.tInList[nAddCnt].sName   = sCsvData[nAddCnt + 1, (int)eIOArray.Name];
                CData.tInList[nAddCnt].sCoil   = sCsvData[nAddCnt + 1, (int)eIOArray.Coil];
                CData.tInList[nAddCnt].sPart   = sCsvData[nAddCnt + 1, (int)eIOArray.Part];
                CData.tInList[nAddCnt].sDesc   = sCsvData[nAddCnt + 1, (int)eIOArray.Desc];
                nAddCnt++;
            }

            dGV_InputList.Rows[0].Selected = true;
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
            dGV_InputList.DataSource = Display_File_SerialConfig(sIOListPath);
        }

        public DataTable Display_File_SerialConfig(string filePath)
        {
            var dt = new DataTable();

            // 첫번째 행을 읽어 컬럼명으로 세팅
            foreach (var headerLine in File.ReadLines(filePath).Take(1))
            {
                foreach (var headerItem in headerLine.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    dt.Columns.Add(headerItem.Trim());
                }
            }
            // 나머지 행을 읽어 데이터로 세팅
            foreach (var line in File.ReadLines(filePath).Skip(1))
            {
                if (line.Contains("EOF") || 
                    (line.Contains(",") == false) ||
                    string.IsNullOrEmpty(line))
                {
                    Console.WriteLine(line);
                }
                else
                {
                    dt.Rows.Add(line.Split(','));
                }
            }
            return dt;
        }

        private void dGV_SerialList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dGV_SerialList_SelNum(true);
        }
        private void dGV_SerialList_SelNum(bool bsel = false)
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