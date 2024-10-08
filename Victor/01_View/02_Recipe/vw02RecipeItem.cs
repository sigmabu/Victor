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


namespace Victor
{
    public partial class vw02RecipeItem : UserControl
    {
        public event MoveToMenuEventHandler OnMoveBack;
        public event MoveToMenuEventHandler OnGoToPosition;
        private string m_sTitle;

        private int m_iPage = 1;
        public vw02RecipeItem(string sTitle)
        {
            InitializeComponent();
            m_sTitle = sTitle;
            m_iPage = 0;
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
            int nBtn_w = 172;
            int nBtn_h = 72;
            int nBtn_s = 80;
            int nBtn_Px = 1095;
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
                btn[i].Click += btn_Click;

                Pnl_Item.Controls.Add(btn[i]);
            }
        }
        private void btn_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            MessageBox.Show(button.Text + "번 버튼이 눌렸습니다.");
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

        private void rdb_SubMenu_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton mRdb = sender as RadioButton;
            int iNext = int.Parse(mRdb.Tag.ToString());


            if (m_iPage != iNext)
            {
                _VwClr();

                m_iPage = iNext;

                _VwAdd();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.OnMoveBack?.Invoke();
        }

        private void btnPosition_Click(object sender, EventArgs e)
        {
            this.OnGoToPosition?.Invoke();
        }

    }
}
