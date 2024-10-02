using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Victor
{
    public partial class Form_Textinput : Form
    {
        private Color boardColor = Color.LimeGreen;
        public string Val { get; private set; }
        public Form_Textinput(string sTitle , string sData = "")
        {
            InitializeComponent();

            label_Title.Text = sTitle;
            textBox_Input.Text = sData;
        }
        private void Form_Textinput_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, boardColor, ButtonBorderStyle.Solid);
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            Val = textBox_Input.Text;
            if (Val == string.Empty || Val == null)
            {
                tipName.Show("Value Empty", textBox_Input, 5000);
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
