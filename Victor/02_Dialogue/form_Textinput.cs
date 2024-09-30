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
    public partial class form_Textinput : Form
    {
        public string Val { get; private set; }
        public form_Textinput(string sTitle)
        {
            InitializeComponent();
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
