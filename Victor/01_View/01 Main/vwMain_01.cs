﻿using MySqlX.XDevAPI.Relational;
using System;
using System.Windows.Forms;

//using Victor.Logging;
//using Victor._21_Asset;
//using OpenCvSharp;


namespace Victor
{
    public partial class vwMain_01 : UserControl
    {
        private int m_iPage = 0; 


        public vwMain_01()
        {
            InitializeComponent();

            tbText.Click += (s, e) =>
            {
                Form parentForm = this.FindForm();
                if (parentForm != null)
                    Virtualkeyboard.ShowKeyboard(VirtualKeyboardType.English, tbText, parentForm,
                                                    value =>
                                                    {
                                                        tbText.Text = value; // ✅ Enter 시 값 수신
                                                    });
            };
            tbtext1.Click += (s, e) =>
            {
                Form parentForm = this.FindForm();
                if (parentForm != null)
                    Virtualkeyboard.ShowKeyboard(VirtualKeyboardType.Korean, tbtext1, parentForm,
                                                    value =>
                                                    {
                                                        tbtext1.Text = value; // ✅ Enter 시 값 수신
                                                    });
            };
            tbInt.Click += (s, e) =>
            {
                Form parentForm = this.FindForm();
                if (parentForm != null)
                    Virtualkeyboard.ShowKeyboard(VirtualKeyboardType.Integer, tbInt, parentForm,
                                                    value =>
                                                    {
                                                        tbInt.Text = value; // ✅ Enter 시 값 수신
                                                    });
            };
            tbFloat.Click += (s, e) =>
            {
                Form parentForm = this.FindForm();
                if (parentForm != null)
                    Virtualkeyboard.ShowKeyboard(VirtualKeyboardType.Float, tbFloat, parentForm,
                                                    value =>
                                                    {
                                                        tbFloat.Text = value; // ✅ Enter 시 값 수신
                                                    });
            };
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
            return;
            //var ak = new AlKeyBoard(this.ParentForm, tbText.Text);

            //if(ak != null ) tbText.Text = ak.InKey;
            //var ak = new NumKeyBoard(this.ParentForm, tbText.Text);

            //if(ak != null ) tbText.Text = ak.InKey;
        }

        //OpenCvSharp.VideoCapture video;
        //Mat mImage = new Mat();

        static int nCount = 0;
        //private static NLog_Manage Log_W = new NLog_Manage(@"D:\MyLogs\"); //생성후 사용

        private void roundConerButton1_Click(object sender, EventArgs e)
        {
            CShared_mem.SetMsg(1, 0, 0, $"TEST 입력 자료 입니다. {nCount}");

            //NLog_Manage.Info($"TEST 입력 자료 입니다 {nCount}");
            //NLog_Manage Log_W = new NLog_Manage();
            //Log_W.Info($"TEST 입력 자료 입니다 {nCount}");
            //NLog_Manage.Info($"TEST 입력 자료 입니다 {nCount}");
            //LoggerHelper.Instance.Info($"Info 로그 버튼이 클릭되었습니다.");
            LoggerService.LogInfo($"Info 로그 버튼이 클릭되었습니다.");

            nCount++;
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
