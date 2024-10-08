﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Victor
{
    public partial class FrmMain_ : Form
    {
        private int m_iPage;
        private bool isClickedLevelButton = false;

        private vwMain m_vwMain;
        private vwRecipe m_vwRecipe;
        private vwMaint m_vwMaint;

        public FrmMain_()
        {
            InitializeComponent();
            Init_Screen();
            timer1.Start();
        }

        private void Init_Screen()
        {
            m_iPage = 0;

            m_vwMain = new vwMain();
            m_vwRecipe = new vwRecipe();
            m_vwMaint = new vwMaint();

            rdb_Main.Checked = true;
        }

        private void Click_Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rdb_Menu_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton mBtn = sender as RadioButton;
            int iTag = int.Parse(mBtn.Tag.ToString());

            if (iTag == m_iPage && !isClickedLevelButton)
            {
                return;
            }
            else
            {

                switch (m_iPage)    // 이전 뷰 Close
                {
                    case 11:
                        m_vwMain.Close();
                        break;
                    case 21:
                        m_vwRecipe.Close();
                        break;
                    case 31:
                        m_vwMaint.Close();
                        break;

                    case 99:
                        //m_vwLogIn.Close();
                        break;
                }

                pnl_Base.Controls.Clear();    // Panel 에서 이전 뷰 삭제

                // Log In 화면 Button 을 Click 하였을 때는 기존 뷰 삭제만 진행.
                if (isClickedLevelButton)
                {
                    return;
                }

                m_iPage = iTag;    // 인덱스 변경

                switch (m_iPage)    // 신규 뷰 Open 및 표시
                {
                    case 11:
                        pnl_Base.Controls.Add(m_vwMain);
                        m_vwMain.Open();
                        break;
                    case 21:
                        pnl_Base.Controls.Add(m_vwRecipe);
                        m_vwRecipe.Open();
                        break;
                    case 31:
                        pnl_Base.Controls.Add(m_vwMaint);
                        m_vwMaint.Open();
                        break;
                }
            }
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
        }
    }
}
