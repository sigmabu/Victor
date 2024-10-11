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
    public partial class vwMaintBase : UserControl
    {
        private string m_sTitle;

        private vwSerial    m_vwSerial = new vwSerial();
        
        public vwMaintBase(string sTitle)
        {
            InitializeComponent();
            m_sTitle = sTitle;
            label_MaintBase.Text = m_sTitle;
        }


        public void vw_Open()
        {
            switch (mViewPage.nMaintPage)
            {
                case 0:
                    Load_CfgData();                    

                    break;
                case 32:
                    //Pnl_Item.Controls.Remove(m_vw02Loader);
                    //m_vw02Loader.Close();
                    //Pnl_Item.Controls.Remove(m_vw02Bank);
                    //m_vw02Bank.Close();
                    //Pnl_Item.Controls.Remove(m_vw02Uloader);
                    //m_vw02Uloader.Close();

                    Pnl_Item.Controls.Add(m_vwSerial);
                    m_vwSerial.Open();                   

                    break;
                case 33:
                    //Pnl_Item.Controls.Add(m_vw02Loader);
                    //m_vw02Loader.Open();

                    break;
                default: break;

            }
        }
        public void vw_Clear()
        {
            switch (mViewPage.nMaintPage)
            {
                case 0:
                    {
                    }
                    break;
                case 32:
                    {
                        Pnl_Item.Controls.Remove(m_vwSerial);
                        m_vwSerial.Close();                      
                    }
                    break;
                case 33:
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
