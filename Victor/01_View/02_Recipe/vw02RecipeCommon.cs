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
    public partial class vw02RecipeCommon : UserControl
    {

        public vw02RecipeCommon()
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
            Load_CommonData();
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

        private void Load_CommonData()
        {
            checkBox1.Text = GVar.RecipeKeyName[1][0]; checkBox1.Checked = (CData.tRecipe.C_Data.bCValue == false) ? false : true;
            label2.Text = GVar.RecipeKeyName[1][1]; textBox2.Text = string.Format("{0}", CData.tRecipe.C_Data.nCValue);
            label3.Text = GVar.RecipeKeyName[1][2]; textBox3.Text = string.Format("{0}", CData.tRecipe.C_Data.dCValue);
            label4.Text = GVar.RecipeKeyName[1][3]; textBox4.Text = string.Format("{0}", CData.tRecipe.C_Data.sCValue);
        }

        public void Get_CommonData()
        {
            CData.tRecipe.C_Data.bCValue = (checkBox1.Checked == false) ? false : true;
            CData.tRecipe.C_Data.nCValue = int.Parse(textBox2.Text);
            CData.tRecipe.C_Data.dCValue = int.Parse(textBox3.Text);
            CData.tRecipe.C_Data.sCValue = textBox4.Text;
        }
    }
}
