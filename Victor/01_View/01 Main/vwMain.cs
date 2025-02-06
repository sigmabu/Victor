using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
//using OpenCvSharp;


namespace Victor
{
    public partial class vwMain : UserControl
    {
        private int m_iPage = 0; 

        public vwMain()
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
                    //m_vw02Prm.Open();
                    //pnl_Base.Controls.Add(m_vw02Prm);
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

            //pnl_Base.Controls.Clear();
        }

        private void hideMenu()
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
             
        }

        private void tbTest_Click(object sender, EventArgs e)
        {
            //var ak = new AlKeyBoard(this.ParentForm, tbText.Text);

            //if(ak != null ) tbText.Text = ak.InKey;
            var ak = new NumKeyBoard(this.ParentForm, tbText.Text);

            if(ak != null ) tbText.Text = ak.InKey;
        }

        //OpenCvSharp.VideoCapture video;
        //Mat mImage = new Mat();

        private void roundConerButton1_Click(object sender, EventArgs e)
        {
            Http_Client mHttp = new Http_Client();

            //mHttp.Get_Url();
            mHttp.PostRequest_Url();
            return;
            mHttp.RequestPost();
            if (mHttp.nPost_Flag == -1)
            {
                Console.WriteLine("--요청 실패!");
                Console.WriteLine($"응답: mHttp.nPost_Flag = {mHttp.nPost_Flag}");
            }

            if (mHttp.nPost_Flag == 1)
            {
                Console.WriteLine("--요청 성공!");
                Console.WriteLine($"응답: mHttp.nPost_Flag = {mHttp.nPost_Flag}");
            }
        }

        private void roundBorderPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void vwMain_Load(object sender, EventArgs e)
        {
            try
            {
                //video = new VideoCapture(0);
                //video.FrameWidth = 300;
                //video.FrameHeight = 240;
                timer1.Enabled = true;
            }
            catch
            {
                timer1.Enabled = false;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //video.Read(mImage);
            //pictureBox1.Image = 0;
               // OpenCvSharp.e

        }
    }
}
