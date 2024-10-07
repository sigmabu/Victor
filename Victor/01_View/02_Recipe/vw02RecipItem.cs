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
    public partial class vw02RecipItem : Form
    {
        private int nPage = 0;
        public vw02RecipItem(string sTitle)
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
            nPage = 0;
        }
        public void Close_PageView()
        {
        }
    }
}
