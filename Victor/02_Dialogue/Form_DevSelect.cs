using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Victor
{
    public partial class Form_DevSelect : Form
    {
        public string dVal { get; private set; }
        public string gVal { get; private set; }

        public Form_DevSelect(object oList, string sGroupId, string sDeviceId)
        {
            InitializeComponent();


            foreach(var item in oList as ListBox.ObjectCollection)
            {
                dataGridView1.Rows.Add(item);

            }
            lb_gVal.Text = sGroupId;
            lb_dVal.Text = sDeviceId;
            txt_Value.Text = sDeviceId;
            txt_Value.Select();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            gVal = (string)dataGridView1.SelectedCells[0].Value.ToString();
            dVal = txt_Value.Text;
            if (dVal == string.Empty || dVal == null)
            {
                tipName.Show("Value Empty", txt_Value, 5000);
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btn_Can_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
