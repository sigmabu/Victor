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
using Renci.SshNet.Common;
using System.Linq;


namespace Victor
{
    public partial class vwSPC : UserControl
    {
        private string sSpcDataPath = GVar.PATH_EQUIP_SpcList;
        private string sFolderPath;
        private string sFileName;
        private static int nEnable_Edit;

        private static string[,] sCsvData;
        static int nSelRow;
        static int nTotalList_Cnt;

        public vwSPC()
        {
            InitializeComponent();

            int FindDot = sSpcDataPath.LastIndexOf(".");
            int Lastsp = sSpcDataPath.LastIndexOf("\\");

            sFileName = sSpcDataPath.Substring(Lastsp + 1, FindDot - Lastsp - 1);
            sFolderPath = sSpcDataPath.Replace(sFileName + ".csv", "");

            nTotalList_Cnt = 0;

            Read_SpcList();
            Init_View_Set();

            Init_Grid_Set();
            //Init_Timer();
        }

        private bool _Release()
        {
            return true;
        }
        private int Read_SpcList()
        {
            int nCnt = 0;
            if (!Directory.Exists(sFolderPath))
            {
                Directory.CreateDirectory(sFolderPath);
            }

            if (!File.Exists(sSpcDataPath))
            {
                //_Save();
                return 0;
            }

            using (StreamReader reader = new StreamReader(sSpcDataPath))
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
                        CData.tSpcList[nCnt].sNo = arrVal[0];
                        CData.tSpcList[nCnt].sName = arrVal[1];
                        CData.tSpcList[nCnt].sDescrip = arrVal[2];
                        CData.tSpcList[nCnt].sXdata = arrVal[3];
                        CData.tSpcList[nCnt].sYdata = arrVal[4];
                        CData.tSpcList[nCnt].sZdata = arrVal[5];
                    }
                    nCnt++;
                }
            }
            nTotalList_Cnt = nCnt;
            // 불러오기 이후 다시 저장하여 추가된 Error 항목 저장
            //_Save();
            return 0;
        }



        private void Init_Grid_Set()
        {
            dGV_DataList.DoubleBuffered(true);

            var dt = new DataTable();

            //dt.Columns.Add(tErrlist[0].number.ToString());
            //dt.Columns.Add(tErrlist[0].name.ToString());
            dt.Columns.Add("No");
            dt.Columns.Add("Name");
            dt.Columns.Add("X Data");
            dt.Columns.Add("Y Data");
            dt.Columns.Add("Z Data");
            for (int i = 1; i < (nTotalList_Cnt-1); i++)
            {
                dt.Rows.Add(CData.tSpcList[i].sNo.ToString(),
                            CData.tSpcList[i].sName.ToString(),
                            CData.tSpcList[i].sXdata.ToString(),
                            CData.tSpcList[i].sYdata.ToString(),
                            CData.tSpcList[i].sZdata.ToString()
                            );
            }
            dGV_DataList.DataSource = dt;

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
 
            //CData.tSpcList[nSelRow].sDescrip =
            //sXlsData[nSelRow][(int)eSpcArray.Description] = rTB_SpcData.Text;
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
                //WriteExcelData(sSpcDataPath, sXlsData);
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
