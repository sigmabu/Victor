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
        public event MoveToMenuEventHandler OnMoveBack;
        public event MoveToMenuEventHandler OnGoToPosition;

        private int m_iPage = 1;
        public vw02RecipeItem(string sTitle)
        {
            InitializeComponent();
            m_iPage = 0;
            label_RecipeItem.Text = sTitle;
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
        public void Open()
        {
            m_iPage = 1;
            _VwAdd();
        }
        public void Close()
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

        private void rdb_SubMenu_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton mRdb = sender as RadioButton;
            int iNext = int.Parse(mRdb.Tag.ToString());


            if (m_iPage != iNext)
            {
                _VwClr();

                m_iPage = iNext;

                _VwAdd();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.OnMoveBack?.Invoke();
        }

        private void btnPosition_Click(object sender, EventArgs e)
        {
            this.OnGoToPosition?.Invoke();
        }

    }
}
