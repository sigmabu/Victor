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
    public partial class vwSerial : UserControl
    {
        
        public vwSerial()
        {
            InitializeComponent();            
        }

        string EnumToString(eRecipGroup eGroup)
        {
            return eGroup.ToString();
        }

        public void Open()
        {
            switch (mViewPage.nRcpPage)
            {
                case 0:
                    Load_CfgData();                    

                    break;
                case 1:
                    //Pnl_Item.Controls.Remove(m_vw02Loader);
                    //m_vw02Loader.Close();
                    //Pnl_Item.Controls.Remove(m_vw02Bank);
                    //m_vw02Bank.Close();
                    //Pnl_Item.Controls.Remove(m_vw02Uloader);
                    //m_vw02Uloader.Close();

                    //Pnl_Item.Controls.Add(m_vw02Common);
                    //m_vw02Common.Open();                   

                    break;
                case 2:
                    //Pnl_Item.Controls.Add(m_vw02Loader);
                    //m_vw02Loader.Open();

                    break;
                default: break;

            }
        }
        public void Close()
        {
            switch (mViewPage.nRcpPage)
            {
                case 0:
                    {
                    }
                    break;
                case 1:
                    {
                        //Pnl_Item.Controls.Remove(m_vw02Common);
                        //m_vw02Common.Close();                      
                    }
                    break;
                case 2:
                    {
                        //m_vw02Loader.Close();
                        //Pnl_Item.Controls.Remove(m_vw02Loader);
                    }
                    break;
                default: break;
            }
        }

        private void Load_CfgData()
        {
        }

        private void Get_UiData()
        {
        }

        private void Save_UiData()
        {
        }

        private void Click_Save(object sender, EventArgs e)
        {
            Get_UiData();
            Save_UiData();
        }
    }
}
