using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Victor._02_Dialogue
{
    public partial class Form_Msg : Form
    {
        public enum BtnCancle_Type
        {
            None = 0,
            btnYES ,
            btnNO,
            btnCANCEL
        }

        public Form_Msg(string sTitle, string sData, BtnCancle_Type nCancle = 0)
        {
            InitializeComponent();
            label_Title.Text = sTitle;
            label_Data.Text = sData;
            if (nCancle == BtnCancle_Type.None)
            {
                btn_Cancel.Visible = false;
            }
        }
        

        private void btn_OK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
