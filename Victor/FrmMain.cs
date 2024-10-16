﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Victor
{
    public delegate void MoveToMenuEventHandler();

    public partial class FrmMain : Form
    {
        private bool isClickedLevelButton = false;

        private vwMain          m_vwMain;
        private vw00Recipe      m_vwRecipe;
        private vw01RecipeList m_vwRecipeList;
        private vw02RecipeItem m_vwRecipeItem = new vw02RecipeItem("tRecipe : " + eRecipGroup.Common.ToString());
        private vwMaint         m_vwMaint;
        //private vwSerial        m_vwSerial;

        public FrmMain()
        {
            InitializeComponent();
            Init_Screen();
            timer1.Start();

            Init_App();
        }

        private void Init_Screen()
        {
            GVar.m_iPage = 0;

            m_vwMain = new vwMain();
            m_vwRecipe  = new vw00Recipe();
            m_vwRecipeList = new vw01RecipeList();
            
            m_vwMaint   = new vwMaint();
            rdb_Main.Checked = true;
            
            Call_PnlBase_Change(mViewPage.nViewMain_111);
        }

        private void Click_Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Click_MenuRadioButton(object sender, EventArgs e)
        {
            RadioButton mBtn = sender as RadioButton;
            int iTag = int.Parse(mBtn.Tag.ToString());

            if (iTag == GVar.m_iPage && !isClickedLevelButton)
            {
                return;
            }
            Call_PnlBase_Change(iTag);
        }

        public void Call_PnlBase_Change(int nTag)
        { 
            switch (GVar.m_iPage)    // 이전 뷰 Close
            {
                case 111:
                    m_vwMain.Close();
                    break;
                case 211:
                    m_vwRecipeList.Close();
                    break;
                case 212:
                    m_vwRecipeItem.Close();
                    break;
                case 311:
                    m_vwMaint.Close();
                    break;
                case 312:
                    //m_vwSerial.Close();
                    m_vwMaint.Close();
                    break;
                case 313:
                    m_vwMaint.Close();
                    break;
                case 314:
                case 315:
                    m_vwMaint.Close();
                    break;
                case 999:
                    //m_vwLogIn.Close();
                    break;
            }

            pnl_Base.Controls.Clear();    // Panel 에서 이전 뷰 삭제

            // Log In 화면 Button 을 Click 하였을 때는 기존 뷰 삭제만 진행.
            if (isClickedLevelButton)
            {
                return;
            }

            GVar.m_iPage = nTag;    // 인덱스 변경            

            switch (GVar.m_iPage)    // 신규 뷰 Open 및 표시
            {
                case 111:
                    pnl_Base.Controls.Add(m_vwMain);
                    m_vwMain.Open();
                    mViewPage.mCurrViewPage = mViewPage.nViewMain_111;
                    break;
                case 211:
                    pnl_Base.Controls.Add(m_vwRecipeList);
                    m_vwRecipeList.Open();
                    mViewPage.mCurrViewPage = mViewPage.nViewRecipeList_211;
                    break;
                case 212:
                    pnl_Base.Controls.Add(m_vwRecipeItem);
                    mViewPage.nRcpPage = 1;
                    m_vwRecipeItem.Open();
                    mViewPage.mCurrViewPage = mViewPage.nViewRecipeItem_212;
                    break;
                case 311:
                    pnl_Base.Controls.Add(m_vwMaint);
                    m_vwMaint.Open();
                    mViewPage.mCurrViewPage = mViewPage.nViewMaint_311;
                    break;
                case 312:
                    //pnl_Base.Controls.Add(m_vwSerial);
                    //m_vwSerial.Open();
                    //mViewPage.mCurrViewPage = mViewPage.nViewMaintSerial_312;
                    break;
            }
        }

        private void Display_Recipe()
        {
            lbl_RecipeGroup.Text = CRecipe.It.Group;
            lblRecipeName.Text = CRecipe.It.Name;

        }


        #region Mouse move GUI
        private System.Drawing.Point mouseDownLocation;

        private void MouseDown_CI(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.mouseDownLocation = e.Location;
            }
        }

        private void MouseMove_CI(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Left = e.X + this.Left - this.mouseDownLocation.X;
                this.Top = e.Y + this.Top - this.mouseDownLocation.Y;
            }
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;

            lbl_Time.Text = datetime.ToString();

            Display_Recipe();
        }

        private void Init_App()
        {
            CLast.Load_LastConfig();
        }

        private void Click_TitleRecipe(object sender, EventArgs e)
        {            
            Call_PnlBase_Change(mViewPage.nViewRecipeItem_212);
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
