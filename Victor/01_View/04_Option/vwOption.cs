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
    public partial class vwOption : UserControl
    {
        /// <summary>
        /// 현재 화면이 Menu 화면인지 확인하기 위한 Flag.
        /// </summary>
        public bool IsMenuScreen { get; private set; } = false;

        private int m_iPage = 0;

        public vwOption()
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

            //panel1.Controls.Clear();
            //panel2.Controls.Clear();
            //panel3.Controls.Clear();
        }

        private void hideMenu()
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
