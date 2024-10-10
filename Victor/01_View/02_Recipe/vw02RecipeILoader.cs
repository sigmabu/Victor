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

        private int m_iPage = 1;
        public vw02RecipeLoader()
        {
            InitializeComponent();
            m_iPage = 0;
        }

        string EnumToString(eRecipGroup eGroup)
        {
            return eGroup.ToString();
        }
       
        private void Init_PageView()
        {
            switch (m_iPage)
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
        public void Open()
        {
            m_iPage = 1;
            _VwAdd();
        }
        public void Close()
        {
            //pnl_Base.Controls.Clear();
        }

        private void _VwAdd()
        {
            switch (m_iPage)
            {
                case 1:

                    //pnl_Base.Controls.Add(Pnl_Item);
                    Load_InformationData();

                    break;
            //    case 2:
            //        {
            //            m_vw2Step.Open();
            //            pnl_Base.Controls.Add(m_vw2Step);

            //        }
            //        break;

            }
        }

        private void _VwClr()
        {
            //switch (nPage)
            //{
            //    case 1:
            //        {
            //            m_vw1Wafer.Close();
            //        }
            //        break;
            //    case 2:
            //        {
            //            m_vw2Step.Close();
            //        }
            //        break;
                
            //}

            //pnl_Base.Controls.Clear();
        }

        private void Load_InformationData()
        {
            checkBox1.Text = GVar.RecipeKeyName[0][1]; checkBox1.Checked = (CData.Recipe.bSaveValue == false) ? false : true;
            label2.Text = GVar.RecipeKeyName[0][2]; textBox2.Text = string.Format("{0}", CData.Recipe.nSaveValue);
            label3.Text = GVar.RecipeKeyName[0][3]; textBox3.Text = string.Format("{0}", CData.Recipe.dSaveValue);
            //label4.Text = GVar.RecipeKeyName[0][4]; textBox4.Text = string.Format("{0}", CData.Recipe.nSaveValue);
        }

        private void Get_InformationData()
        {
            CData.Recipe.bSaveValue = (checkBox1.Checked == false) ? false : true;
            CData.Recipe.nSaveValue = int.Parse(textBox2.Text);
            CData.Recipe.dSaveValue = int.Parse(textBox3.Text);
            //label4.Text = GVar.RecipeKeyName[0][4]; textBox4.Text = string.Format("{0}", CData.Recipe.nSaveValue);
        }


        private void Load_CommonData()
        {
            checkBox1.Text = GVar.RecipeKeyName[1][0]; checkBox1.Checked = (CData.Recipe.C_Data.bCValue == false) ? false : true;
            label2.Text = GVar.RecipeKeyName[1][1]; textBox2.Text = string.Format("{0}", CData.Recipe.C_Data.nCValue);
            label3.Text = GVar.RecipeKeyName[1][2]; textBox3.Text = string.Format("{0}", CData.Recipe.C_Data.dCValue);
            label4.Text = GVar.RecipeKeyName[1][3]; textBox4.Text = string.Format("{0}", CData.Recipe.C_Data.sCValue);
        }

        private void Get_CommonData()
        {
            CData.Recipe.C_Data.bCValue = (checkBox1.Checked == false) ? false : true;
            CData.Recipe.C_Data.nCValue = int.Parse(textBox2.Text);
            CData.Recipe.C_Data.dCValue = int.Parse(textBox3.Text);
            CData.Recipe.C_Data.sCValue = textBox4.Text;
        }

        private void Load_LoaderData()
        {
            checkBox1.Text = GVar.RecipeKeyName[1][0]; checkBox1.Checked = (CData.Recipe.L_Data.bLValue == false) ? false : true;
            label2.Text = GVar.RecipeKeyName[1][1]; textBox2.Text = string.Format("{0}", CData.Recipe.L_Data.nLValue);
            label3.Text = GVar.RecipeKeyName[1][2]; textBox3.Text = string.Format("{0}", CData.Recipe.L_Data.dLValue);
            label4.Text = GVar.RecipeKeyName[1][3]; textBox4.Text = string.Format("{0}", CData.Recipe.L_Data.sLValue);
        }

        private void Get_LoaderData()
        {
            CData.Recipe.L_Data.bLValue = (checkBox1.Checked == false) ? false : true;
            CData.Recipe.L_Data.nLValue = int.Parse(textBox2.Text);
            CData.Recipe.L_Data.dLValue = int.Parse(textBox3.Text);
            CData.Recipe.L_Data.sLValue = textBox4.Text;
        }

        private void Load_UnloaderData()
        {
            checkBox1.Text = GVar.RecipeKeyName[1][0]; checkBox1.Checked = (CData.Recipe.Ul_Data.bULValue == false) ? false : true;
            label2.Text = GVar.RecipeKeyName[1][1]; textBox2.Text = string.Format("{0}", CData.Recipe.Ul_Data.nULValue);
            label3.Text = GVar.RecipeKeyName[1][2]; textBox3.Text = string.Format("{0}", CData.Recipe.Ul_Data.dULValue);
            label4.Text = GVar.RecipeKeyName[1][3]; textBox4.Text = string.Format("{0}", CData.Recipe.Ul_Data.sULValue);
        }

        private void Get_UnloaderData()
        {
            CData.Recipe.Ul_Data.bULValue = (checkBox1.Checked == false) ? false : true;
            CData.Recipe.Ul_Data.nULValue = int.Parse(textBox2.Text);
            CData.Recipe.Ul_Data.dULValue = int.Parse(textBox3.Text);
            CData.Recipe.Ul_Data.sULValue = textBox4.Text;
        }

        private void Click_Save(object sender, EventArgs e)
        {
            Get_InformationData();
            Get_CommonData();
            CRecipe.It.Save(CRecipe.It.FullPath);
            CRecipe.It.Load(CRecipe.It.FullPath);
        }
    }
}
