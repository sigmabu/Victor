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
using static System.Net.Mime.MediaTypeNames;

namespace Victor
{
    public partial class vwMain : UserControl
    {
        private int m_iPage = 0; 

        public vwMain()
        {
            InitializeComponent();
        }
        public void Open()
        {
            m_iPage = 1;
            //pnl_Menu.BringToFront();
            //vwAdd();
            //hideMenu();
        }

        public void Close()
        {
            vwClear();
        }

        private void vwAdd()
        {
            switch (m_iPage)
            {
                case 11:
                    //m_vw02Prm.Open();
                    //pnl_Base.Controls.Add(m_vw02Prm);
                    break;
                case 21:
                    //m_vw02Prm.Open();
                    //pnl_Base.Controls.Add(m_vw02Prm);
                    break;
                case 31:
                    //m_vw03Set.Open();
                    //pnl_Base.Controls.Add(m_vw03Set);
                    break;
            }
        }

        private void vwClear()
        {
            //switch (nPage)
            //{
            //    case 11:
            //        m_vw01Lst.Close();
            //        break;
            //    case 21:
            //        m_vw02Prm.Close();
            //        break;
            //    case 31:
            //        m_vw03Set.Close();
            //        break;
            //}

            //pnl_Base.Controls.Clear();
        }

        private void hideMenu()
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
             
        }

        private void tbTest_Click(object sender, EventArgs e)
        {
            //var ak = new AlKeyBoard(this.ParentForm, tbText.Text);

            //if(ak != null ) tbText.Text = ak.InKey;
            var ak = new NumKeyBoard(this.ParentForm, tbText.Text);

            if(ak != null ) tbText.Text = ak.InKey;
        }

        private void roundConerButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
