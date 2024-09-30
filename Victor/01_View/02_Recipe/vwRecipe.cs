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

            string sPath = CGvar.PATH_DEVICE;

            try
            {
                ////using (frmTxt mForm = new frmTxt("New sGroup sName", this))
                //using (AlphaKeypad mForm = new AlphaKeypad(this.ParentForm))
                //{
                //    if (mForm.ShowDialog() == DialogResult.Cancel) { return; }

                //    if (Directory.Exists(sPath + mForm.Result))
                //    {
                //        CMsg.ShowMsg(EMsg.Error, CGvar.GetMsg("ExistGroupName", "sGroup name exist !!!"));
                //        return;
                //    }
                //    sPath = sPath + mForm.Result; //190130  : Device에 New가 되지 않아 수정
                //    Directory.CreateDirectory(sPath);
                //    _GrpListUp();
                //}
            }
            catch (Exception ex)
            {

            }
            finally
            {
                BeginInvoke(new Action(() => mBtn.Enabled = true));
            }            
        }

    }
}
