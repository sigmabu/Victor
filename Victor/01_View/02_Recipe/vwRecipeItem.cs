using System;
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
    public partial class vwRecipeItem : Form
    {
        private int m_iPage = 0;
        public vwRecipeItem(string sTitle)
        {
            InitializeComponent();
            m_iPage = 0;
            lbl_Title.Text = sTitle;
        }

        private void Init_PageView()
        {
            switch (m_iPage)
            {
                case 0:
                    break;
                case 11:
                    break;
                case 21:
                    break;
                default:
                    break;
            }
        }
        public void Open_PageView()
        {
            m_iPage = 0;
        }
        public void Close_PageView()
        {
        }

        public void Open()
        {
            m_iPage = 11;
            //_GrpListUp();
            //pnl_Menu.BringToFront();

            vwAdd();
            hideMenu();
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

                    break;
                case 21:
                    //m_vw02Prm.Open();
                    //pnl_Base.Controls.Add(vwRecipeList);
                    break;
                case 31:
                    //m_vw03Set.Open();
                    //pnl_Base.Controls.Add(m_vw03Set);
                    break;
            }
        }

        private void vwClear()
        {
            //switch (m_iPage)
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

    }
}
