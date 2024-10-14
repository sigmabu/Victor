using System;
using System.Reflection.Emit;
using System.Windows.Forms;
//using Util;
using Victor;

namespace Victor
{
    public partial class vw00Recipe : UserControl
    {

        private vw01RecipeList m_vw01List = new vw01RecipeList();
        private vw02RecipeItem m_vw02Item = new vw02RecipeItem("tRecipe :" + eRecipGroup.Common.ToString());

        public vw00Recipe()
        {
            InitializeComponent();
        }

        public void Open()
        {
            GVar.m_iPage = 111;

            _vwAdd();
            _HideMenu();
        }

        public void Close()
        {
            _VwClr();
        }

        /// <summary>
        /// 해당 뷰의 Dispose 함수 실행시 자동으로 실행됨
        /// </summary>
        public void Release()
        {
            m_vw01List.Dispose();
            m_vw02Item.Dispose();
            //m_vw03Set.Dispose();
        }

        private void _vwAdd()
        {
            switch (GVar.m_iPage)
            {
                case 21:
                    m_vw01List.Open();
                    pnl_Base.Controls.Add(m_vw01List);
                    break;
                case 22:
                    m_vw02Item.Open();
                    pnl_Base.Controls.Add(m_vw02Item);
                    break;
            //    case 3:
            //        m_vw03Set.Open();
            //        pnl_Base.Controls.Add(m_vw03Set);
            //        break;
            }
        }

        private void _VwClr()
        {
            switch (GVar.m_iPage)
            {
                case 21:
                    m_vw01List.Close();
                    break;
                case 22:
                    m_vw02Item.Close();
                    break;
        //        case 3:
        //            m_vw03Set.Close();
        //            break;
            }
            pnl_Base.Controls.Clear();
        }

        private void _HideMenu()
        {
            label_Recipe.Visible = false;
        }

        /// <summary>
        /// Manual view에 조작 로그 저장 함수
        /// </summary>
        /// <param name="sMsg"></param>
        private void _SetLog(string sMsg)
        {
            //string view = "Device view".PadRight(30);
            //string level = CData.Lev.ToString().PadRight(10);

            //CLog.Register(ELog.OPL, string.Format("[{0}]  [Lv:{1}]  {2}", view, level, sMsg));
        }

        private void rdbMn_CheckedChanged(object sender, EventArgs e)
        {
            //_SetLog("Click");
            ////CData.bLastClick = true; //190509  :
            //RadioButton mRdb = sender as RadioButton;
            //int iNext = int.Parse(mRdb.Tag.ToString());

            //_SetLog(string.Format("N, {0} -> {1}", nPage, iNext));
            //if (nPage != iNext)
            //{
            //    _VwClr();

            //    nPage = iNext;

            //    _vwAdd();
            //}
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
           
        }
    }
}
