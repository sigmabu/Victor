﻿using System;
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
    public partial class vw02RecipeItem : UserControl
    {
        private string m_sTitle;

        private int nPage = 1;
        private vw02RecipeLoader m_vw02Loader = new vw02RecipeLoader();
        public vw02RecipeItem(string sTitle)
        {
            InitializeComponent();
            m_sTitle = sTitle;
            nPage = 0;
            label_RecipeItem.Text = m_sTitle;
            CreateRecipeGroupButton();
        }

        string EnumToString(eRecipGroup eGroup)
        {
            return eGroup.ToString();
        }
        private void CreateRecipeGroupButton()
        {
            int nRcpGroup = Convert.ToInt32(eRecipGroup.End);

            int nBtnMargin = 0;
            int nBtn_w = 133;
            int nBtn_h = 72;
            int nBtn_s = 80;
            int nBtn_Px = 5;// 1138;// 1095;
            int nBtn_Py = 35;

            Button[] btn = new Button[nRcpGroup];
            for (int i = 0; i < nRcpGroup; i++)
            {
                btn[i] = new Button();
                btn[i].FlatStyle = FlatStyle.Flat;
                btn[i].FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
                btn[i].FlatAppearance.BorderSize = 1;
                btn[i].FlatAppearance.CheckedBackColor = Color.SteelBlue;
                btn[i].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
                btn[i].Margin = new Padding(nBtnMargin);
                btn[i].Padding = new Padding(0,0,7,0);
                btn[i].Text = EnumToString((eRecipGroup)i);
                btn[i].Size = new Size( nBtn_w, nBtn_h);
                btn[i].Location = new Point(nBtn_Px , nBtn_Py + (nBtn_s * i));
                btn[i].Click += Click_SectionMenu;

                Pnl_Button.Controls.Add(btn[i]);
            }
        }
        private void Click_SectionMenu(object sender, EventArgs e)
        {
            Button button = sender as Button;
            
            if (button.Text == EnumToString((eRecipGroup)0))
            {
                Console.WriteLine(button.Text + "번 버튼이 눌렸습니다.");
                m_sTitle = "Recipe : " + button.Text;
                label_RecipeItem.Text = m_sTitle;

                _VwClr();
                nPage = 1;
                _VwAdd();
                Load_CommonData();
            }
            else if (button.Text == EnumToString((eRecipGroup)1))
            {
                Console.WriteLine(button.Text + "번 버튼이 눌렸습니다.");
                m_sTitle = "Recipe : " + button.Text;
                label_RecipeItem.Text = m_sTitle;
                label_RecipeItem.Text = m_sTitle;
                _VwClr();
                nPage = 2;
                _VwAdd();

                Load_LoaderData();
            }
            else if (button.Text == EnumToString((eRecipGroup)2))
            {
                Console.WriteLine(button.Text + "번 버튼이 눌렸습니다.");
                m_sTitle = "Recipe : " + button.Text;
                label_RecipeItem.Text = m_sTitle;
                Load_UnloaderData();
            }
            else //if(button.Text == EnumToString((eRecipGroup)0))
            {
                Console.WriteLine(button.Text + "번 버튼이 눌렸습니다.");
                m_sTitle = "Recipe : " + button.Text;
                label_RecipeItem.Text = m_sTitle;
                _VwClr();
                nPage = 1;
                _VwAdd();

                Load_InformationData();
            }
            MessageBox.Show(button.Text + "번 버튼이 눌렸습니다.");
        }

        private void Init_PageView()
        {
            switch (nPage)
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
            nPage = 1;
            _VwAdd();
        }
        public void Close()
        {
            //pnl_Base.Controls.Clear();
        }

        private void _VwAdd()
        {
            switch (nPage)
            {
                case 1:

                    //pnl_Base.Controls.Add(Pnl_Item);
                    //Pnl_Item.Controls.Clear();
                    //Pnl_Item.Controls.Add(m_vw02Loader);
                    //Load_InformationData();

                    break;
                case 2:
                    //Pnl_Item.Controls.Clear();
                    Pnl_Item.Controls.Add(m_vw02Loader);
                    Load_InformationData();
                    break;
            }
        }

        private void _VwClr()
        {
            switch (nPage)
            {
                case 1:
                    {
                        //m_vw1Wafer.Close();
                    }
                    break;
                case 2:
                    {
                        m_vw02Loader.Close();
                        Pnl_Item.Controls.Remove(m_vw02Loader);
                    }
                    break;                
            }

            //Pnl_Item.Controls.Clear();
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
