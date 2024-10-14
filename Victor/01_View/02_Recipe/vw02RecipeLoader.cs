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
    public partial class vw02RecipeLoader : UserControl
    {

        public vw02RecipeLoader()
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
            Load_LoaderData();
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

        private void Load_LoaderData()
        {
            checkBox1.Text = GVar.RecipeKeyName[1][0]; checkBox1.Checked = (CData.tRecipe.L_Data.bLValue == false) ? false : true;
            label2.Text = GVar.RecipeKeyName[1][1]; textBox2.Text = string.Format("{0}", CData.tRecipe.L_Data.nLValue);
            label3.Text = GVar.RecipeKeyName[1][2]; textBox3.Text = string.Format("{0}", CData.tRecipe.L_Data.dLValue);
            label4.Text = GVar.RecipeKeyName[1][3]; textBox4.Text = string.Format("{0}", CData.tRecipe.L_Data.sLValue);
        }

        public void Get_LoaderData()
        {
            CData.tRecipe.L_Data.bLValue = (checkBox1.Checked == false) ? false : true;
            CData.tRecipe.L_Data.nLValue = int.Parse(textBox2.Text);
            CData.tRecipe.L_Data.dLValue = int.Parse(textBox3.Text);
            CData.tRecipe.L_Data.sLValue = textBox4.Text;
        }
    }
}
