using System;
using System.Windows.Forms;
using Victor;

namespace Victor
{
    public partial class vw00Recipe : UserControl
    {
        /// <summary>
        /// 화면에 정보 업데이트 타이머
        /// </summary>
        private readonly Timer _timer; 

        private int m_iPage = 0;

        private vw01RecipeList m_vwList = new vw01RecipeList();
        private vw02RecipeItem m_vwItem = new vw02RecipeItem("Recipe Item Loader");
        //private vwSetPos_Recipe m_vw03Set = new vwSetPos_Recipe(EProc.STAG1, EGuiPosType.Recipe);

        public vw00Recipe()
        {
            InitializeComponent();

            //vwRecipeList.GoParm += Apply;

            //m_vw02Prm.OnMoveBack += returnToList;
            //m_vw02Prm.OnGoToPosition += goToPosition;
            //m_vw03Set.OnMoveBack += returnToParameter;


            // 220317 syc : 1000U Auto 상황 버튼 비활성화
            // 화면 갱신 타이머
            _timer = new Timer();
            _timer.Interval = 50;
            _timer.Tick += _timer_Tick;
            // syc end
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
            _HideMenu();

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
            m_vwList.Dispose();
            m_vwItem.Dispose();
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
            switch (m_iPage)
            {
                case 1:
                    m_vwList.Open();
                    pnl_Base.Controls.Add(m_vwList);
                    break;
                case 2:
                   // m_vwItem.Open();
                    pnl_Base.Controls.Add(m_vwItem);
                    break;
                case 3:
                    //m_vw03Set.Open();
                    //pnl_Base.Controls.Add(m_vw03Set);
                    break;
            }
        }

        private void _VwClr()
        {
            switch (m_iPage)
            {
                case 1:
                    m_vwList.Close();
                    break;
                case 2:
                    m_vwItem.Close();
                    break;
                case 3:
                    //m_vw03Set.Close();
                    break;
            }

            pnl_Base.Controls.Clear();
        }

        private void _HideMenu()
        {
            // 2020.08.24 JSKim St
            //ELv RetLv = CData.Lev;
            //btn_Save.Enabled = (int)RetLv >= CData.Opt.iLvDvSave;
            //if (CData.bDevOnlyView == true)
            {
                //btn_Save.Enabled = false;
            }
            //else
            {
              //  ELv RetLv = CData.Lev;
                //btn_Save.Enabled = (int)RetLv >= CData.SPara.iLvDvSave;
            }
            // 2020.08.24 JSKim Ed
        }

        /// <summary>
        /// Manual view에 조작 로그 저장 함수
        /// </summary>
        /// <param name="sMsg"></param>
        //private void _SetLog(string sMsg)
        //{
        //    string view = "Device view".PadRight(30);
        //    string level = CData.Lev.ToString().PadRight(10);

        //    CLog.Register(ELog.OPL, string.Format("[{0}]  [Lv:{1}]  {2}", view, level, sMsg));
        //}

        private void rdbMn_CheckedChanged(object sender, EventArgs e)
        {

            //CData.bLastClick = true; //190509  :
            RadioButton mRdb = sender as RadioButton;
            int iNext = int.Parse(mRdb.Tag.ToString());


            if (m_iPage != iNext)
            {
                _VwClr();

                m_iPage = iNext;

                _VwAdd();
            }
        }

        //private void btn_Save_Click(object sender, EventArgs e)
        //{
        //    _SetLog("Click");
        //    //CData.bLastClick = true;

        //    if (CData.LotInfo.bLotOpen && CData.Lev < ELv.Engineer)
        //    {
        //        CMsg.ShowMsg(EMsg.Error, CGvar.GetMsg("CancelLotAndSave", "First Lot Cancel and after Save"));
        //        return;
        //    }

        //    //  VMS23 Device Row(99), Column(100) 개수 제한 체크
        //    // VGSI 에서는 사용 안함.
        //    //string strCheckDevResult = m_vw02Prm.CheckDeviceRowColCount();
        //    //if (0 < strCheckDevResult.Length)
        //    //{
        //    //    CMsg.ShowMsg(eMsg.Error, strCheckDevResult);
        //    //    return;
        //    //}
        //    bool bCheckRcp = true;
        //    string errMsg = "";

        //    string sPath = "";
        //    string[] Temp;
        //    string[] Temp1;
        //    Temp = CData.Device_Current.Split('\\');
        //    Temp1 = Temp[5].Split('.');

        //    bCheckRcp = m_vw02Prm.Get();

        //    if (bCheckRcp == false)
        //    {// Value Validate check Error                
        //        return;
        //    }

        //    m_vw03Set.Get();

        //    if (CData.Dev.eDual == EDual.Single)
        //    {
        //        // Single Mode

        //        bCheckRcp = CDev.It.CheckRecipe(0, out errMsg);
        //        if (!bCheckRcp)
        //        {
        //            CMsg.ShowMsg(EMsg.Error, errMsg, "Error : " + CGvar.GetMsg("ChkRecipe", "Check Recipe"));
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        // Dual Mode

        //        bCheckRcp = CDev.It.CheckRecipe(0, out errMsg);
        //        if (!bCheckRcp)
        //        {
        //            CMsg.ShowMsg(EMsg.Error, errMsg, "Error : Stage_Define #1" + CGvar.GetMsg("ChkRecipe", "Check Recipe"));
        //            return;
        //        }

        //        bCheckRcp = CDev.It.CheckRecipe(1, out errMsg);
        //        if (!bCheckRcp)
        //        {
        //            CMsg.ShowMsg(EMsg.Error, errMsg, "Error : Stage_Define #2" + CGvar.GetMsg("ChkRecipe", "Check Recipe"));
        //            return;
        //        }
        //    }

        //    Utils.Delay(100);

        //    //20200424 jhc : 회전형 드라이 동작 타임아웃 시간 체크
        //    if (!Check_DryTime())
        //    {
        //        CMsg.ShowMsg(EMsg.Error, "Dry Rotation Time Over!!!\nCheck Dry Rotate Velocity or Dry Rotate Count.");
        //        return;
        //    }

        //    if (CData.Device_Group == "") CData.Device_Group = Temp[4];

        //    sPath += CGvar.PATH_DEVICE + string.Format("{0}\\{1}.dev", CData.Device_Group, CData.Dev.sName);
        //    CDev.It.Save(sPath);

        //    m_vw02Prm.Set();
        //    m_vw03Set.Set();

        //    CMsg.ShowMsg(EMsg.Notice, "Device " + CGvar.GetMsg("File Save Finish!!", "file save complete : = " + sPath));
        //    if (CLicense.isSGEM)
        //    {
        //        CVar.cSecsGem.Set_PPIDParameterChanged(sPath);
        //    }
        //}

       
        //private bool Check_DryTime()
        //{
        //    //int rpm = CData.Dev.iDryRPM;
        //    //int cnt = CData.Dev.iDryCnt;
        //    //if (rpm == 0) rpm = 10; //최소값 10 rpm
        //    //if (cnt == 0) cnt = 1;  //최소값 1회전
        //    //double rotationTime = 1000 * (60.0 / (double)rpm) * (double)cnt;
        //    //if (rotationTime > GV.DRYROTATION_TMOUT)
        //    //{
        //    //    return false;
        //    //}
        //    return true;
        //}

        private void _timer_Tick(object sender, EventArgs e)
        {
            // 220317 syc : 1000U Auto 상황 버튼 비활성화 
            //if (CLicense.SwType == ESwType.SG1000U)
            {
                //btn_Save.Enabled = CVar.bCheckRunManual;
            }
            // syc end	
        }

        private void InitializeComponent()
        {
            this.pnl_Base = new System.Windows.Forms.Panel();
            this.label46 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnl_Base
            // 
            this.pnl_Base.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.pnl_Base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Base.Location = new System.Drawing.Point(0, 30);
            this.pnl_Base.Name = "pnl_Base";
            this.pnl_Base.Size = new System.Drawing.Size(1280, 774);
            this.pnl_Base.TabIndex = 452;
            // 
            // label46
            // 
            this.label46.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label46.Dock = System.Windows.Forms.DockStyle.Top;
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label46.ForeColor = System.Drawing.SystemColors.Control;
            this.label46.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label46.Location = new System.Drawing.Point(0, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(1280, 30);
            this.label46.TabIndex = 451;
            this.label46.Text = "RECIPE";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // vw00Recipe
            // 
            this.Controls.Add(this.pnl_Base);
            this.Controls.Add(this.label46);
            this.Name = "vw00Recipe";
            this.Size = new System.Drawing.Size(1280, 804);
            this.ResumeLayout(false);

        }

        //private System.Windows.Forms.Panel pnl_Base;
        //private System.Windows.Forms.Label label46;

    }
}
