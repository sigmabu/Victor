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
    public partial class vw02RecipeULoader : UserControl
    {

        public vw02RecipeULoader()
        {
            InitializeComponent();
        }

        string EnumToString(eRecipGroup eGroup)
        {
            return eGroup.ToString();
        }
       
        private void Init_PageView()
        {
            //switch (m_iPage)
            //{
            //    case 0:
            //        break;
            //    case 11:
            //        break;
            //    case 21:
            //        break;
            //    default:
            //        break;
            //}
        }
        public void Open()
        {
            Load_UnloaderData();
        }
        public void Close()
        {
            //pnl_Base.Controls.Clear();
        }

        private void _VwAdd()
        {
        }

        private void _VwClr()
        {
        }

        private void Load_UnloaderData()
        {
            checkBox1.Text = GVar.RecipeKeyName[3][0]; checkBox1.Checked = (CData.Recipe.Ul_Data.bULValue == false) ? false : true;
            label2.Text = GVar.RecipeKeyName[3][1]; textBox2.Text = string.Format("{0}", CData.Recipe.Ul_Data.nULValue);
            label3.Text = GVar.RecipeKeyName[3][2]; textBox3.Text = string.Format("{0}", CData.Recipe.Ul_Data.dULValue);
            label4.Text = GVar.RecipeKeyName[3][3]; textBox4.Text = string.Format("{0}", CData.Recipe.Ul_Data.sULValue);
        }

        public void Get_UnloaderData()
        {
            CData.Recipe.Ul_Data.bULValue = (checkBox1.Checked == false) ? false : true;
            CData.Recipe.Ul_Data.nULValue = int.Parse(textBox2.Text);
            CData.Recipe.Ul_Data.dULValue = int.Parse(textBox3.Text);
            CData.Recipe.Ul_Data.sULValue = textBox4.Text;
        }

    }
}
