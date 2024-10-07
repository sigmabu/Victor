using System;
using System.Windows.Forms;
//using Util;
using Victor;

namespace Victor
{
    public partial class vw00Recipe : UserControl
    {
        /// <summary>
        /// 화면에 정보 업데이트 타이머
        /// </summary>
        private readonly Timer _timer; // 220317 syc : 1000U Auto 상황 버튼 비활성화

        private int m_iPage = 0;

        //private vwDev_01Lst m_vw01Lst = new vwDev_01Lst();
        //private vwDev_02Prm m_vw02Prm = new vwDev_02Prm();
        //private vwSetPos_Recipe m_vw03Set = new vwSetPos_Recipe(EProc.STAG1, EGuiPosType.Recipe);

        public vw00Recipe()
        {
            InitializeComponent();

            //m_vw01Lst.GoParm += Apply;

            //m_vw02Prm.OnMoveBack += returnToList;
            //m_vw02Prm.OnGoToPosition += goToPosition;
            //m_vw03Set.OnMoveBack += returnToParameter;


            // 220317 syc : 1000U Auto 상황 버튼 비활성화
            // 화면 갱신 타이머
            _timer = new Timer();
            _timer.Interval = 50;
//            _timer.Tick += _timer_Tick;

        }

        public void Open()
        {
            //if(!CLicense.isDF)
            //{
            //    CData.Dev.bDynamicSkip = true;
            //}

            //rdbMn_Parm.Visible = false;
            //rdbMn_Set.Visible = false;

            //if (CData.bDevOnlyView == false)
            //{
            //    CData.Dev.bBcrKeyInSkip = false;
            //}

            m_iPage = 1;

            _VwAdd();
            //_HideMenu();

            // 타이머 멈춤 상태면 타이머 다시 시작
            if (!_timer.Enabled)
            {
                _timer.Start();
            }
        }

        public void Close()
        {
            _VwClr();

            // 타이머 실행 중이면 타이머 멈춤
            if (_timer.Enabled)
            {
                _timer.Stop();
            }
        }

        /// <summary>
        /// 해당 뷰의 Dispose 함수 실행시 자동으로 실행됨
        /// </summary>
        public void Release()
        {
            //m_vw01Lst.Dispose();
            //m_vw02Prm.Dispose();
            //m_vw03Set.Dispose();
        }

        private void returnToList()
        {
            _VwClr();

            m_iPage = 1;

            _VwAdd();
        }
        private void returnToParameter()
        {
            _VwClr();

            m_iPage = 2;

            _VwAdd();
        }
        private void goToPosition()
        {
            _VwClr();

            m_iPage = 3;

            _VwAdd();
        }

        public void Apply(bool bVal)
        {
            //btn_Save.Visible = bVal;
            //rdbMn_Parm.Visible = bVal;
            //20191204 ghk_level
            //if (bVal && (int)CData.Lev >= CData.SPara.iLvDvPosView)
            //{ rdbMn_Set.Visible = true; }
            //else
            //{ rdbMn_Set.Visible = false; }

            if (bVal)
            {
                //rdbMn_Parm.Checked = true;

                _VwClr();

                m_iPage = 2;

                _VwAdd();

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

        private void _VwAdd()
        {
            //switch (m_iPage)
            //{
            //    case 1:
            //        m_vw01Lst.Open();
            //        pnl_Base.Controls.Add(m_vw01Lst);
            //        break;
            //    case 2:
            //        m_vw02Prm.Open();
            //        pnl_Base.Controls.Add(m_vw02Prm);
            //        break;
            //    case 3:
            //        m_vw03Set.Open();
            //        pnl_Base.Controls.Add(m_vw03Set);
            //        break;
            //}
        }

        private void _VwClr()
        {
        //    switch (m_iPage)
        //    {
        //        case 1:
        //            m_vw01Lst.Close();
        //            break;
        //        case 2:
        //            m_vw02Prm.Close();
        //            break;
        //        case 3:
        //            m_vw03Set.Close();
        //            break;
        //    }

        //    pnl_Base.Controls.Clear();
        }

        private void _HideMenu()
        {
            
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

            //    _VwAdd();
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

        private void _timer_Tick(object sender, EventArgs e)
        {
           
        }
    }
}
