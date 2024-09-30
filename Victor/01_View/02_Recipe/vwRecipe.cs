using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Victor._02_Dialogue;

namespace Victor
{
    public partial class vwRecipe : UserControl
    {
        public delegate void ListEvt(bool bVal);
        public event ListEvt GoParm;
        private string m_sGrp;
        private string m_sDev;


        private int m_iPage = 0;

        public vwRecipe()
        {
            InitializeComponent();
        }

        public void Open()
        {
            m_iPage = 1;
            _GrpListUp();
            //pnl_Menu.BringToFront();

            //vwAdd();
            //hideMenu();
        }

        public void Close()
        {
            vwClear();
        }

        private void vwAdd()
        {
            switch (m_iPage)
            {
                case 11:
                    
                    break;
                case 21:
                    //m_vw02Prm.Open();
                    //pnl_Base.Controls.Add(m_vw02Prm);
                    break;
                case 31:
                    //m_vw03Set.Open();
                    //pnl_Base.Controls.Add(m_vw03Set);
                    break;
            }
        }

        private void vwClear()
        {
            //switch (m_iPage)
            //{
            //    case 11:
            //        m_vw01Lst.Close();
            //        break;
            //    case 21:
            //        m_vw02Prm.Close();
            //        break;
            //    case 31:
            //        m_vw03Set.Close();
            //        break;
            //}

            //pnl_Base.Controls.Clear();
        }

        private void hideMenu()
        {
            
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnClick_New(object sender, EventArgs e)
        {
            Button mBtn = sender as Button;
            BeginInvoke(new Action(() => mBtn.Enabled = false));
            string sInput;

            string sPath = CGvar.PATH_DEVICE;

            try
            {
                using (form_Textinput mForm = new form_Textinput("New Group Name"))
                {
                    if (mForm.ShowDialog() == DialogResult.Cancel) { return; }

                    sInput = sPath + mForm.Val;
                    if (Directory.Exists(sPath + mForm.Val))
                    {
                        sInput = string.Format("{0} {1} Group name exist !!!", sPath , mForm.Val);
                        Form_Msg mMsg = new Form_Msg("ExistGroupName", sInput);
                        mMsg.ShowDialog();
                        return;
                    }
                    sPath = sPath + mForm.Val;
                    Directory.CreateDirectory(sPath);
                    _GrpListUp();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                BeginInvoke(new Action(() => mBtn.Enabled = true));
            }
        }
        private void _GrpListUp()
        {
            int iCnt = 0;
            DirectoryInfo[] aVal;

            if (!Directory.Exists(CGvar.PATH_DEVICE))
            { Directory.CreateDirectory(CGvar.PATH_DEVICE); }

            lbxM_Grp.Items.Clear();
            DirectoryInfo mFile = new DirectoryInfo(CGvar.PATH_DEVICE);
            aVal = mFile.GetDirectories();
            iCnt = aVal.Length;
            for (int i = 0; i < iCnt; i++)
            {
                lbxM_Grp.Items.Add(aVal[i].Name);
            }

            lbxM_Grp.ClearSelected();
            lbxM_Dev.ClearSelected();
            lbxM_Dev.Items.Clear();
            m_sGrp = "";
            m_sDev = "";
        }

    }
}
