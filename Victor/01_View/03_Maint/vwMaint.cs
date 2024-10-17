using System;
using System.Drawing;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace Victor
{
    public partial class vwMaint : UserControl
    {
        private vwSerial m_vwSerial = new vwSerial();
        private vwEthernet m_vwEthernet = new vwEthernet();
        private vwIOList m_vwIOList = new vwIOList();
        public vwMaint()
        {
            InitializeComponent();
        }

        public void Open()
        {
            GVar.m_iPage = mViewPage.nViewMaint_311;
            vwAdd();
        }

        public void Close()
        {
            vwClear();
        }

        private void vwAdd()
        {
            switch (GVar.m_iPage)
            {
                case 311:

                    panel1.Visible = true;
                    panel2.Visible = true;
                    panel3.Visible = true;

                    break;
                case 312:
                    //m_vw02Prm.Open();
                    //pnl_Base.Controls.Add(m_vw02Prm);
                    break;
                case 313:
                    //m_vw03Set.Open();
                    //pnl_Base.Controls.Add(m_vw03Set);
                    break;
            }
        }

        private void vwClear()
        {
            switch (GVar.m_iPage)
            {
                case 312:
                    m_vwSerial.Close();
                    pnl_Menu.Controls.Remove(m_vwSerial);
                    break;
                case 313:
                    m_vwEthernet.Close();
                    pnl_Menu.Controls.Remove(m_vwEthernet);
                    break;
                case 314:
                    m_vwIOList.Close();
                    pnl_Menu.Controls.Remove(m_vwIOList);
                    break;
                default: break;
            }

            pnl_Menu.Controls.Clear();
        }

        private void Click_OptionButton(object sender, EventArgs e)
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
                case 311:
                    vwAdd();
                    break;
                case 312:
                    panel1.Visible = false;
                    panel2.Visible = false;
                    panel3.Visible = false;

                    pnl_Menu.Controls.Add(m_vwSerial);
                    m_vwSerial.Location = new Point(0, 32);
                    GVar.m_iPage = mViewPage.nViewMaintSerial_312;
                    mViewPage.nMaintPage = mViewPage.nViewMaintSerial_312;
                    m_vwSerial.Open();
                    break;
                case 313:
                    panel1.Visible = false;
                    panel2.Visible = false;
                    panel3.Visible = false;

                    pnl_Menu.Controls.Add(m_vwEthernet);
                    m_vwEthernet.Location = new Point(0, 32);
                    GVar.m_iPage = mViewPage.nViewMaintEthernet_313;
                    mViewPage.nMaintPage = mViewPage.nViewMaintEthernet_313;
                    m_vwEthernet.Open();
                    
                    break;
                case 314:
                    panel1.Visible = false;
                    panel2.Visible = false;
                    panel3.Visible = false;

                    pnl_Menu.Controls.Add(m_vwIOList);
                    m_vwIOList.Location = new Point(0, 32);
                    GVar.m_iPage = mViewPage.nViewMaintIOList_314;
                    mViewPage.nMaintPage = mViewPage.nViewMaintIOList_314;
                    m_vwIOList.Open();

                    break;
            }
        }
    }
}
