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
    public partial class vw02RecipeItem : Form
    {
        private int nPage = 0;
        public vw02RecipeItem(string sTitle)
        {
            InitializeComponent();
            nPage = 0;
            lbl_Title.Text = sTitle;
        }

        private void Init_PageView()
        {
            switch (nPage)
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
            nPage = 1;
            _VwAdd();
        }
        public void Close_PageView()
        {
        }

        private void _VwAdd()
        {
            //switch (nPage)
            //{
            //    case 1:
            //        m_vw1Wafer.Open();
            //        pnl_Base.Controls.Add(m_vw1Wafer);
            //        break;
            //    case 2:
            //        {
            //            m_vw2Step.Open();
            //            pnl_Base.Controls.Add(m_vw2Step);

            //        }
            //        break;

            //}
        }

        private void _VwClr()
        {
            //switch (nPage)
            //{
            //    case 1:
            //        {
            //            m_vw1Wafer.Close();
            //        }
            //        break;
            //    case 2:
            //        {
            //            m_vw2Step.Close();
            //        }
            //        break;
                
            //}

            pnl_Base.Controls.Clear();
        }

    }
}
