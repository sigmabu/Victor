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
    public partial class vw02RecipeItem : UserControl
    {
        private string m_sTitle;

        private vw02RecipeCommon    m_vw02Common    = new vw02RecipeCommon();
        private vw02RecipeLoader    m_vw02Loader    = new vw02RecipeLoader();
        private vw02RecipeBank      m_vw02Bank      = new vw02RecipeBank();
        private vw02RecipeULoader   m_vw02Uloader   = new vw02RecipeULoader();
        public vw02RecipeItem(string sTitle)
        {
            InitializeComponent();
            m_sTitle = sTitle;
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
                btn[i].Name = "btn_"+EnumToString((eRecipGroup)i);
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
                mViewPage.nRcpPage = 1;
                _VwAdd();
            }
            else if (button.Text == EnumToString((eRecipGroup)1))
            {
                Console.WriteLine(button.Text + "번 버튼이 눌렸습니다.");
                m_sTitle = "Recipe : " + button.Text;
                label_RecipeItem.Text = m_sTitle;
                label_RecipeItem.Text = m_sTitle;
                _VwClr();
                mViewPage.nRcpPage = 2;
                _VwAdd();
            }
            else if (button.Text == EnumToString((eRecipGroup)2))
            {
                Console.WriteLine(button.Text + "번 버튼이 눌렸습니다.");
                m_sTitle = "Recipe : " + button.Text;
                label_RecipeItem.Text = m_sTitle;
                _VwClr();
                mViewPage.nRcpPage = 3;
                _VwAdd();
            }
            else if (button.Text == EnumToString((eRecipGroup)3))
            {
                Console.WriteLine(button.Text + "번 버튼이 눌렸습니다.");
                m_sTitle = "Recipe : " + button.Text;
                label_RecipeItem.Text = m_sTitle;
                _VwClr();
                mViewPage.nRcpPage = 4;
                _VwAdd();
            }

            else //if(button.Text == EnumToString((eRecipGroup)0))
            {
                Console.WriteLine(button.Text + "번 버튼이 눌렸습니다.");
                m_sTitle = "Recipe : " + button.Text;
                label_RecipeItem.Text = m_sTitle;
                _VwClr();
                mViewPage.nRcpPage = 0;
                _VwAdd();

                Load_InformationData();
            }
            //MessageBox.Show(button.Text + "번 버튼이 눌렸습니다.");
        }

        private void Init_PageView()
        {
            switch (mViewPage.nRcpPage)
            {
                case 0:
                    break;
                case 111:
                    break;
                case 211:
                    break;
                default:
                    break;
            }
        }
        public void Open()
        {
            _VwAdd();
        }
        public void Close()
        {
            _VwClr();
        }

        private void _VwAdd()
        {
            switch (mViewPage.nRcpPage)
            {
                case 0:
                    Load_InformationData();                    

                    break;
                case 1:
                    Pnl_Item.Controls.Remove(m_vw02Loader);
                    m_vw02Loader.Close();
                    Pnl_Item.Controls.Remove(m_vw02Bank);
                    m_vw02Bank.Close();
                    Pnl_Item.Controls.Remove(m_vw02Uloader);
                    m_vw02Uloader.Close();
                    //Load_CfgData();
                    Pnl_Item.Controls.Add(m_vw02Common);
                    m_vw02Common.Open();                   

                    break;
                case 2:
                    Pnl_Item.Controls.Add(m_vw02Loader);
                    m_vw02Loader.Open();

                    break;
                case 3:
                    Pnl_Item.Controls.Add(m_vw02Bank);
                    m_vw02Bank.Open();
                    break;
                case 4:
                    Pnl_Item.Controls.Add(m_vw02Uloader);
                    m_vw02Uloader.Open();
                    break;

            }
        }

        private void _VwClr()
        {
            switch (mViewPage.nRcpPage)
            {
                case 0:
                    {
                    }
                    break;
                case 1:
                    {
                        Pnl_Item.Controls.Remove(m_vw02Common);
                        m_vw02Common.Close();
                        Pnl_Item.Controls.Remove(m_vw02Loader);
                        m_vw02Loader.Close();
                        Pnl_Item.Controls.Remove(m_vw02Bank);
                        m_vw02Bank.Close();
                        Pnl_Item.Controls.Remove(m_vw02Uloader);
                        m_vw02Uloader.Close();                        
                    }
                    break;
                case 2:
                    {
                        m_vw02Loader.Close();
                        Pnl_Item.Controls.Remove(m_vw02Loader);
                    }
                    break;
                case 3:
                    {
                        m_vw02Bank.Close();
                        Pnl_Item.Controls.Remove(m_vw02Bank);
                    }
                    break;
                case 4:
                    {
                        m_vw02Uloader.Close();
                        Pnl_Item.Controls.Remove(m_vw02Uloader);
                    }
                    break;
            }
        }

        private void Load_InformationData()
        {
            //checkBox1.Text = GVar.RecipeKeyName[0][1]; checkBox1.Checked = (CData.Recipe.bSaveValue == false) ? false : true;
            //label2.Text = GVar.RecipeKeyName[0][2]; textBox2.Text = string.Format("{0}", CData.Recipe.nSaveValue);
            //label3.Text = GVar.RecipeKeyName[0][3]; textBox3.Text = string.Format("{0}", CData.Recipe.dSaveValue);
            //label4.Text = GVar.RecipeKeyName[0][4]; textBox4.Text = string.Format("{0}", CData.Recipe.nSaveValue);
        }

        private void Get_InformationData()
        {
            //CData.Recipe.bSaveValue = (checkBox1.Checked == false) ? false : true;
            //CData.Recipe.nSaveValue = int.Parse(textBox2.Text);
            //CData.Recipe.dSaveValue = int.Parse(textBox3.Text);
            //label4.Text = GVar.RecipeKeyName[0][4]; textBox4.Text = string.Format("{0}", CData.Recipe.nSaveValue);
        }

        private void Click_Save(object sender, EventArgs e)
        {
            Get_InformationData();
            if (mViewPage.nRcpPage == 1) m_vw02Common.Get_CommonData();
            if(mViewPage.nRcpPage == 2)m_vw02Loader.Get_LoaderData();
            else if(mViewPage.nRcpPage == 3) m_vw02Bank.Get_BankData();
            else if (mViewPage.nRcpPage == 4) m_vw02Uloader.Get_UnloaderData();

            CRecipe.It.Save(CRecipe.It.FullPath);
            CRecipe.It.Load(CRecipe.It.FullPath);
        }
    }
}
