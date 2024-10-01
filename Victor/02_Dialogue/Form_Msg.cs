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

        public Form_Msg(string sTitle, string sData, eMsg emagtype, BtnCancle_Type nCancle = 0)
        {
            InitializeComponent();
            label_Title.Text = sTitle;
            label_Data.Text = sData;

            if (emagtype == eMsg.Warning)
            {
                label_Title.BackColor = Color.Yellow;
                label_Title.ForeColor = Color.DarkRed;
            }
            else if (emagtype == eMsg.Error)
            {
                label_Title.BackColor = Color.DarkRed;
                label_Title.ForeColor = Color.White;
            }
            else /*if (emagtype == eMsg.Notice) */
            {
                label_Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
                label_Title.ForeColor = Color.White;
            }

            if (nCancle == BtnCancle_Type.None)
            {
                btn_Cancel.Visible = false;
            }
        }
        

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
