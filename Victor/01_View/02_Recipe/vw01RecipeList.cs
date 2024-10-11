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
using Microsoft.VisualBasic.FileIO;
using Victor;
using static System.Windows.Forms.AxHost;

namespace Victor
{
    public partial class vw01RecipeList : UserControl
    {
        public delegate void ListEvt(bool bVal);
        public event ListEvt GoParm;
        private string m_sGrp;
        private string m_sDev;

        private vw02RecipeItem m_vw02Item = new vw02RecipeItem("Recipe : " + eRecipGroup.Common.ToString());

        public vw01RecipeList()
        {
            InitializeComponent();            
            this.lbxM_Dev.DrawItem += lbxM_Dev_DrawItem;
        }

        public void Open()
        {
            GVar.m_iPage = 21;
            vwAdd();
            hideMenu();

            _GrpListUp();
            
            // 초기 ListBox Data 설정
            lbxM_Grp.SelectedItem = (string.IsNullOrEmpty(CRecipe.It.Group) == false) ? CRecipe.It.Group : "Empty";
            lbxM_Dev.SelectedItem = (string.IsNullOrEmpty(CRecipe.It.Name) == false) ? CRecipe.It.Name.Replace(".dev", "") : "Empty";
        }

        private void hideMenu()
        {

        }


        public void Close()
        {
            vwClear();
            //pnl_Menu.Controls.Clear();
        }

        private void SetRecipeTitle(string sPath)
        {
            CRecipe.It.FullPath = sPath;
            CRecipe.It.Group = m_sGrp;
            CRecipe.It.Name = m_sDev + ".dev";

            CLast.Save_LastConfig();
        }
        private void GetRecipeTitle()
        {
            //CRecipe.It.FullPath = sPath;
            m_sGrp = CRecipe.It.Group;
            m_sDev = CRecipe.It.Name;
            
        }
        private void vwAdd()
        {
            switch (GVar.m_iPage)
            {
                case 21:
                    pnl_Menu.Controls.Clear();
                    GetRecipeTitle();
                    pnl_Menu.Controls.Add(pnlM_Grp);
                    pnl_Menu.Controls.Add(pnlM_List);
                    pnl_Menu.Controls.Add(pnl_Btn);

                    break;
                case 22:
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
            //switch (nPage)
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

            pnl_Menu.Controls.Clear();
        }



        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnClick_New(object sender, EventArgs e)
        {
            Button mBtn = sender as Button;
            BeginInvoke(new Action(() => mBtn.Enabled = false));
            string sInput;

            string sPath = GVar.PATH_DEVICE;

            try
            {
                using (Form_Textinput mForm = new Form_Textinput("New Group Name"))
                {
                    if (mForm.ShowDialog() == DialogResult.Cancel) { return; }

                    sInput = sPath + mForm.Val;
                    if (Directory.Exists(sPath + mForm.Val))
                    {
                        sInput = string.Format("{0} {1} Group name exist !!!", sPath, mForm.Val);
                        Form_Msg mMsg = new Form_Msg("ExistGroupName", sInput, eMsg.Error);
                        mMsg.ShowDialog();
                        return;
                    }
                    sPath = sPath + mForm.Val;
                    Directory.CreateDirectory(sPath);
                    _GrpListUp();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                BeginInvoke(new Action(() => mBtn.Enabled = true));
            }
        }

        private void btnClick_SaveAs(object sender, EventArgs e)
        {
            Button mBtn = sender as Button;
            BeginInvoke(new Action(() => mBtn.Enabled = false));

            string sSrc = "";
            string sDst = "";

            try
            {
                // 그룹 선택 여부 확인
                if (lbxM_Grp.SelectedIndex < 0 || m_sGrp == "")
                {
                    Form_Msg mMsg = new Form_Msg("SelectGroupName", "Not selected group", eMsg.Error);
                    mMsg.ShowDialog();

                    return;
                }

                using (Form_Textinput mForm = new Form_Textinput("Save As Group Name"))
                {
                    if (mForm.ShowDialog() == DialogResult.OK)
                    {
                        sSrc = GVar.PATH_DEVICE + lbxM_Grp.SelectedItem.ToString();
                        sDst = GVar.PATH_DEVICE + mForm.Val;

                        if (Directory.Exists(GVar.PATH_DEVICE + mForm.Val))
                        {
                            Form_Msg mMsg = new Form_Msg("ExistGroupName", "Group name exist !!!", eMsg.Error);
                            mMsg.ShowDialog();

                            return;
                        }

                        FileSystem.CopyDirectory(sSrc, sDst, UIOption.AllDialogs);
                        CCheckFile.SaveAs("DEVICE", sSrc, sDst);
                        _GrpListUp();
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                BeginInvoke(new Action(() => mBtn.Enabled = true));
            }
        }

        private void btnClick_Delete(object sender, EventArgs e)
        {
            Button mBtn = sender as Button;
            BeginInvoke(new Action(() => mBtn.Enabled = false));

            string sPath = GVar.PATH_DEVICE;
            string sText;
            Form_Msg mMsg;

            try
            {
                if (lbxM_Grp.SelectedIndex < 0 || m_sGrp == "")
                {
                    mMsg = new Form_Msg("SelectGroupName", "Not selected group", eMsg.Error);
                    mMsg.ShowDialog();

                    return;
                }
                sPath += m_sGrp;
                if (Directory.Exists(sPath))
                {
                    sText = string.Format("{0} selected group Delete!!", sPath);
                    mMsg = new Form_Msg("SelectGroupName", sText, eMsg.Warning);
                    if (mMsg.ShowDialog() == DialogResult.OK)
                    {
                        FileSystem.DeleteDirectory(sPath, DeleteDirectoryOption.DeleteAllContents);
                    }
                }
                _GrpListUp();
                btnM_DApp.Enabled = false;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
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

            if (!Directory.Exists(GVar.PATH_DEVICE))
            { Directory.CreateDirectory(GVar.PATH_DEVICE); }

            lbxM_Grp.Items.Clear();
            DirectoryInfo mFile = new DirectoryInfo(GVar.PATH_DEVICE);
            aVal = mFile.GetDirectories();
            iCnt = aVal.Length;
            for (int i = 0; i < iCnt; i++)
            {
                lbxM_Grp.Items.Add(aVal[i].Name);
            }

            lbxM_Grp.SelectedItem = null;
            lbxM_Grp.ClearSelected();
            lbxM_Dev.ClearSelected();
            lbxM_Dev.Items.Clear();
            //m_sGrp = "";
            //m_sDev = "";
            _RcpListUp();
        }

        private void lbxM_Grp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxM_Grp.SelectedIndex >= 0)
            {
                m_sGrp = lbxM_Grp.SelectedItem.ToString();

                _RcpListUp();
            }
        }

        private void btnClick_NewFile(object sender, EventArgs e)
        {
            Button mBtn = sender as Button;
            BeginInvoke(new Action(() => mBtn.Enabled = false));
            Form_Msg mMsg;
            string sInput;
            string sPath = GVar.PATH_DEVICE;

            try
            {
                if (lbxM_Grp.SelectedIndex < 0 || m_sGrp == "")
                {
                    mMsg = new Form_Msg("SelectGroupName", "Not selected group", eMsg.Error);
                    mMsg.ShowDialog();

                    return;
                }

                sPath += m_sGrp + "\\";

                using (Form_Textinput mForm = new Form_Textinput("New Device Name"))
                {
                    if (mForm.ShowDialog() == DialogResult.Cancel) { return; }

                    sInput = sPath + mForm.Val;
                    if (File.Exists(sPath + mForm.Val + ".dev"))
                    {
                        mMsg = new Form_Msg("ExistGroupName", "Group name exist !!!", eMsg.Error);
                        mMsg.ShowDialog();

                        return;
                    }

                    if (Directory.Exists(sPath + mForm.Val))
                    {
                        sInput = string.Format("{0} {1} File name exist !!!", sPath, mForm.Val);
                        mMsg = new Form_Msg("ExistGroupName", sInput, eMsg.Error);
                        mMsg.ShowDialog();
                        return;
                    }
                    sPath += mForm.Val + ".dev";
                    mRecipe rcp;
                    rcp.sDeviceName = mForm.Val;
                    CRecipe.It.CreateRecipe(sPath);

                    _RcpListUp();

                    mMsg = new Form_Msg("CreateDeviceFile", "Device file create success", eMsg.Notice);
                    mMsg.ShowDialog();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                BeginInvoke(new Action(() => mBtn.Enabled = true));
            }
        }

        private void btnClick_SaveAsFile(object sender, EventArgs e)
        {
            Button mBtn = sender as Button;
            BeginInvoke(new Action(() => mBtn.Enabled = false));
            Form_Msg mMsg;
            string sPath = GVar.PATH_DEVICE;

            string sSrc = "";
            string sDst = "";

            try
            {
                if (lbxM_Grp.SelectedIndex < 0 || m_sGrp == "")
                {
                    mMsg = new Form_Msg("SelectGroupName", "Not selected group", eMsg.Error);
                    mMsg.ShowDialog();

                    return;
                }

                if (lbxM_Dev.SelectedIndex < 0 || m_sDev == "")
                {
                    mMsg = new Form_Msg("SelectDeviceName", "Not selected device", eMsg.Error);
                    mMsg.ShowDialog();

                    return;
                }
                sSrc = GVar.PATH_DEVICE + m_sGrp + "\\" + m_sDev + ".dev";

                using (Form_Textinput mForm = new Form_Textinput(m_sDev + ".dev file SaveAs Device."))
                {
                    if (mForm.ShowDialog() == DialogResult.Cancel) { return; }


                    sDst = GVar.PATH_DEVICE + m_sGrp + "\\" + mForm.Val + ".dev";

                    // 원본과 동일한 이름인지 판단
                    if (sSrc == sDst)
                    {
                        mMsg = new Form_Msg("SameDeviceName", "Device name same !!!", eMsg.Error);
                        mMsg.ShowDialog();

                        return;
                    }

                    // 동일한 이름 존재하는지 판단
                    if (File.Exists(sDst))
                    {
                        mMsg = new Form_Msg("ExistDeviceName", "Device name exist !!!", eMsg.Error);
                        mMsg.ShowDialog();

                        return;
                    }

                    FileSystem.CopyFile(sSrc, sDst, UIOption.AllDialogs);

                    _RcpListUp();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                BeginInvoke(new Action(() => mBtn.Enabled = true));
            }
        }

        private void btnClick_DeleteFile(object sender, EventArgs e)
        {
            Button mBtn = sender as Button;
            BeginInvoke(new Action(() => mBtn.Enabled = false));

            string sPath = GVar.PATH_DEVICE;
            string sText;
            Form_Msg mMsg;

            try
            {
                if (lbxM_Grp.SelectedIndex < 0 || m_sGrp == "")
                {
                    mMsg = new Form_Msg("SelectFileName", "Not selected file", eMsg.Error);
                    mMsg.ShowDialog();

                    return;
                }
                sPath += m_sGrp + "\\";
                if (lbxM_Dev.SelectedIndex < 0 || m_sDev == "")
                {
                    mMsg = new Form_Msg("SelectDeviceName", "Not selected device", eMsg.Error);
                    mMsg.ShowDialog();

                    return;
                }
                sPath += m_sDev + ".dev";

                mMsg = new Form_Msg("Warning", "Delete File " + m_sDev + ".dev. Do you want delete?", eMsg.Warning);

                if (mMsg.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                FileSystem.DeleteFile(sPath);

                _RcpListUp();
                btnM_DApp.Enabled = false;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                BeginInvoke(new Action(() => mBtn.Enabled = true));
            }
        }

        private void _RcpListUp()
        {
            string sPath = GVar.PATH_DEVICE + m_sGrp + "\\";

            if (Directory.Exists(sPath) == true)
            {
                lbxM_Dev.Items.Clear();
                DirectoryInfo mFile = new DirectoryInfo(sPath);
                foreach (FileSystemInfo mInfo in mFile.GetFileSystemInfos("*.dev"))
                {
                    lbxM_Dev.Items.Add(mInfo.Name.Replace(".dev", ""));
                }
            }

            lbxM_Dev.ClearSelected();
            //lbxM_Dev.SelectedItem = m_sDev;
            //m_sDev = "";
            //btnM_DApp.Enabled = false;
        }

        private void lbxM_Dev_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxM_Dev.SelectedIndex >= 0)
            {
                m_sDev = lbxM_Dev.SelectedItem.ToString();
            }
            btnM_DApp.Enabled = true;
            //_RcpListUp();
        }

        private void btnM_DApp_Click(object sender, EventArgs e)
        {
            Button mBtn = sender as Button;
            int iTag = int.Parse(mBtn.Tag.ToString());

            BeginInvoke(new Action(() => mBtn.Enabled = false));

            GVar.m_iPage = iTag;

            string sPath = GVar.PATH_DEVICE + m_sGrp + "\\";
            string sRecipe = m_sGrp + "\\";

            string sHead = "";
            string sMsg = "";
            int nRet = 0;
            Form_Msg mMsg;

            try
            {
                if (lbxM_Dev.SelectedIndex < 0 || m_sDev == "")
                {
                    mMsg = new Form_Msg("SelectDeviceName", "Not selected device", eMsg.Error);
                    mMsg.ShowDialog();

                    return;
                }
                sPath = sPath + m_sDev + ".dev";

                CData.RecipeCur = sPath;
                CRecipe.It.Load(sPath);

                CRecipe.It.m_sGrp = this.m_sGrp;
                CData.RecipeGr = CRecipe.It.m_sGrp;
                SetRecipeTitle(sPath);

                Call_ViewRecipeItem();
            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally { BeginInvoke(new Action(() => mBtn.Enabled = true)); }
            //GoParm(true);
        }
        private void Call_ViewRecipeItem()
        {
            pnl_Menu.Controls.Clear();    // Panel 에서 이전 뷰 삭제

            switch (GVar.m_iPage)    // 신규 뷰 Open 및 표시
            {
                case 21:
                    vwAdd();
                    break;
                case 22:
                    label_RecipeList.Visible = false;
                    pnl_Menu.Controls.Add(m_vw02Item);
                    GVar.nRcpPage = 1;
                    m_vw02Item.Open();
                    break;
                case 3:
                    //pnl_Base.Controls.Add(m_vwMaint);
                    //m_vwMaint.Open();
                    break;
            }
        }
        
        private void lbxM_Dev_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) { return; }

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State ^ DrawItemState.Selected, e.ForeColor, Color.DarkCyan);
            }

            ListBox mLbx = sender as ListBox;
            int iX = e.Bounds.X + (e.Font.Height / 2);
            int iY = e.Bounds.Y + (e.Font.Height / 2);

            e.DrawBackground();
            e.Graphics.DrawString(mLbx.Items[e.Index].ToString(), e.Font, Brushes.White, iX, iY, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }
    }
}
