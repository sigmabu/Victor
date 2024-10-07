using System;
using System.Reflection.Emit;
using System.Windows.Forms;
//using Util;
using Victor;

namespace Victor
{
    public partial class vw00Recipe : UserControl
    {

        private int m_iPage = 0;

        private vw01RecipeList m_vw01List = new vw01RecipeList();
        private vw02RecipeItem m_vw02Item = new vw02RecipeItem("Recipe Loader");

        public vw00Recipe()
        {
            InitializeComponent();

            m_vw01List.GoParm += Apply;

            m_vw02Item.OnMoveBack += returnToList;
            m_vw02Item.OnGoToPosition += goToPosition;
            //m_vw03Set.OnMoveBack += returnToParameter;


        }

        public void Open()
        {
            m_iPage = 11;

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

        private void returnToList()
        {
            _VwClr();

            m_iPage = 11;

            _vwAdd();
        }
        private void returnToParameter()
        {
            _VwClr();

            m_iPage = 21;

            _vwAdd();
        }
        private void goToPosition()
        {
            _VwClr();

            m_iPage = 31;

            _vwAdd();
        }

        public void Apply(bool bVal)
        {

            if (bVal)
            {
                //rdbMn_Parm.Checked = true;

                _VwClr();

                m_iPage = 21;

                _vwAdd();

                //m_vw02Prm.Set();
                //m_vw03Set.Set();
            }
            else
            {
                //rdbMn_List.Checked = true;
            }
        }

        public void LinkSelectpage()
        {
            m_iPage = 0;
            Apply(true);
        }

        private void _vwAdd()
        {
            switch (m_iPage)
            {
                case 11:
                    m_vw01List.Open();
                    pnl_Base.Controls.Add(m_vw01List);
                    break;
                case 21:
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
            switch (m_iPage)
            {
                case 11:
                    m_vw01List.Close();
                    break;
                case 21:
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

            //_SetLog(string.Format("N, {0} -> {1}", m_iPage, iNext));
            //if (m_iPage != iNext)
            //{
            //    _VwClr();

            //    m_iPage = iNext;

            //    _vwAdd();
            //}
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
           
        }

        //20200424  : 회전형 드라이 동작 타임아웃 시간 체크
        private bool Check_DryTime()
        {
 
            return true;
        }
    }
}
