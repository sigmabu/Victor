﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Victor
{
    public partial class IntkeyboardForm : BasekeyboardForm
    {
        private Control targetControl;
        private Form parentForm;
        private readonly Action<string> _onEnter;


        public IntkeyboardForm(Control target,Form owner, Action<string> onEnter)
        {
            InitializeComponent();

           
            targetControl = target;
            parentForm = owner;
            //this.StartPosition = FormStartPosition.Manual;


            this.FormBorderStyle = FormBorderStyle.None; // 타이틀 바 제거
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(2);

            // 회색 테두리
            this.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(Color.Gray, 2))
                {
                    e.Graphics.DrawRectangle(pen, 1, 1, this.Width - 2, this.Height - 2);
                }
            };

            btnFloat.Visible = false;
            PERIODE.Visible = false;

            // 초기 값 설정
            if (targetControl is TextBox || targetControl is Label)
            {
                tbInput.Text = targetControl.Text;
            }

            CreateKeyboard();
            _onEnter = onEnter;
        }
        private void CreateKeyboard()
        {
            
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            string sInData ="";
            string key = (sender as Button).Text;
            sInData = tbInput.Text;
            switch (key)
            {
                case "Esc": this.Close(); break;
                case "Bs":
                    if (tbInput.Text.Length > 0)
                        tbInput.Text = tbInput.Text.Substring(0, tbInput.Text.Length - 1);
                    break;
                case "Del":tbInput.Clear(); break;
                case "Clr": tbInput.Clear(); break;
                case "<-": /* 커서 이동 생략 */ break;
                case "Enter": _onEnter?.Invoke(tbInput.Text); // Module로 전달();
                              this.Close(); break;
                case "-":
                        if (sInData.IndexOf("-") == 0)
                        {
                            tbInput.Text = sInData.Replace("-", "");
                        }
                        else if (sInData.IndexOf("-") > 0)
                        {
                            tbInput.Text = sInData.Replace("-", "");
                        }
                        else if (sInData.IndexOf("-") == -1)  
                        {
                            tbInput.Text = "-" + sInData;
                        }
                        else if (sInData.Length == 0)
                        {
                            tbInput.Text += key;
                        }
                            break;
                default: tbInput.Text += key; break;
            }
        }        
    }
}
