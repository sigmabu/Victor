using System;
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
    public partial class vwMaint : UserControl
    {
        // private vwSerial m_vwSerial = new vwSerial("Recipe : " + eRecipGroup.Common.ToString());
        private vwSerial m_vwSerial = new vwSerial();
        public vwMaint()
        {
            InitializeComponent();
        }

        public void Open()
        {

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
            switch (GVar.m_iPage)
            {
                case 11:

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
            switch (GVar.m_iPage)
            {
            //    case 11:
            //        m_vw01Lst.Close();
            //        break;
            //    case 21:
            //        m_vw02Prm.Close();
            //        break;
                case 32:
                m_vwSerial.Close();
                    pnl_Menu.Controls.Remove(m_vwSerial);
                    break;
            }

            //panel1.Controls.Clear();
            //panel2.Controls.Clear();
            //panel3.Controls.Clear();
        }

        private void Click_Button(object sender, EventArgs e)
        {
            Button mBtn = sender as Button;
            GVar.m_iPage = int.Parse(mBtn.Tag.ToString());
            Call_ViewRecipeItem();

        }
            private void Call_ViewRecipeItem()
            {
                pnl_Menu.Controls.Clear();    // Panel 에서 이전 뷰 삭제

                switch (GVar.m_iPage)    // 신규 뷰 Open 및 표시
                {
                    case 31:
                        vwAdd();
                        break;
                    case 32:
                        panel1.Visible = false;
                        panel2.Visible = false;
                        panel3.Visible = false;
                        pnl_Menu.Controls.Add(m_vwSerial);
                        GVar.m_iPage = 32;
                        mViewPage.nMaintPage = 32;
                        m_vwSerial.Open();
                        break;
                    case 33:
                        //pnl_Base.Controls.Add(m_vwMaint);
                        //m_vwMaint.Open();
                        break;
                }
            }
        }
}
