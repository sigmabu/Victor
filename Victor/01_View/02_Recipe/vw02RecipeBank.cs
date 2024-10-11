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
using Microsoft.VisualBasic.FileIO;
using Victor;
using static System.Windows.Forms.Button;


namespace Victor
{
    public partial class vw02RecipeBank : UserControl
    {

        public vw02RecipeBank()
        {
            InitializeComponent();
        }

        string EnumToString(eRecipGroup eGroup)
        {
            return eGroup.ToString();
        }
       
        private void Init_PageView()
        {
        }
        public void Open()
        {
            Load_BankData();
        }
        public void Close()
        {

        }

        private void _VwAdd()
        {
        }

        private void _VwClr()
        {
        }

        private void Load_BankData()
        {
            checkBox1.Text = GVar.RecipeKeyName[2][0]; checkBox1.Checked = (CData.Recipe.Ul_Data.bULValue == false) ? false : true;
            label2.Text = GVar.RecipeKeyName[2][1]; textBox2.Text = string.Format("{0}", CData.Recipe.Ul_Data.nULValue);
            label3.Text = GVar.RecipeKeyName[2][2]; textBox3.Text = string.Format("{0}", CData.Recipe.Ul_Data.dULValue);
            label4.Text = GVar.RecipeKeyName[2][3]; textBox4.Text = string.Format("{0}", CData.Recipe.Ul_Data.sULValue);
        }

        public void Get_BankData()
        {
            CData.Recipe.Ul_Data.bULValue = (checkBox1.Checked == false) ? false : true;
            CData.Recipe.Ul_Data.nULValue = int.Parse(textBox2.Text);
            CData.Recipe.Ul_Data.dULValue = int.Parse(textBox3.Text);
            CData.Recipe.Ul_Data.sULValue = textBox4.Text;
        }

    }
}
