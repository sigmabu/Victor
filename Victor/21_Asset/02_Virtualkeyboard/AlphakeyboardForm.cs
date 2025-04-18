using DocumentFormat.OpenXml.VariantTypes;
using System;
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
    public partial class AlphakeyboardForm : Form
    {
        //public AlphakeyboardForm()
        //{
        //    InitializeComponent();
        //}
        private Control targetControl;
        private Form parentForm;
        private readonly Action<string> _onEnter;


        public AlphakeyboardForm(Control target, Form owner, Action<string> onEnter)
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

            // 초기 값 설정
            if (targetControl is TextBox || targetControl is Label)
            {
                tbInput.Text = targetControl.Text;
            }

            CreateKeyboard(true);
            _onEnter = onEnter;
        }
        private void CreateKeyboard(bool bCaps)
        {
            Caps.BackColor = (bCaps == false) ? Color.White : Color.Blue;
            A.Text = (bCaps == false) ? "A".ToLower() : "A".ToUpper();
            B.Text = (bCaps == false) ? "B".ToLower() : "B".ToUpper();
            C.Text = (bCaps == false) ? "C".ToLower() : "C".ToUpper();
            D.Text = (bCaps == false) ? "D".ToLower() : "D".ToUpper();
            E.Text = (bCaps == false) ? "E".ToLower() : "E".ToUpper();
            F.Text = (bCaps == false) ? "F".ToLower() : "F".ToUpper();
            G.Text = (bCaps == false) ? "G".ToLower() : "G".ToUpper();
            H.Text = (bCaps == false) ? "H".ToLower() : "H".ToUpper();
            I.Text = (bCaps == false) ? "I".ToLower() : "I".ToUpper();
            K.Text = (bCaps == false) ? "J".ToLower() : "J".ToUpper();
            L.Text = (bCaps == false) ? "K".ToLower() : "K".ToUpper();
            L.Text = (bCaps == false) ? "L".ToLower() : "L".ToUpper();
            M.Text = (bCaps == false) ? "M".ToLower() : "M".ToUpper();
            N.Text = (bCaps == false) ? "N".ToLower() : "N".ToUpper();
            O.Text = (bCaps == false) ? "O".ToLower() : "O".ToUpper();
            P.Text = (bCaps == false) ? "P".ToLower() : "P".ToUpper();
            Q.Text = (bCaps == false) ? "Q".ToLower() : "Q".ToUpper();
            R.Text = (bCaps == false) ? "R".ToLower() : "R".ToUpper();
            S.Text = (bCaps == false) ? "S".ToLower() : "S".ToUpper();
            T.Text = (bCaps == false) ? "T".ToLower() : "T".ToUpper();
            U.Text = (bCaps == false) ? "U".ToLower() : "U".ToUpper();
            V.Text = (bCaps == false) ? "V".ToLower() : "V".ToUpper();
            W.Text = (bCaps == false) ? "W".ToLower() : "W".ToUpper();
            X.Text = (bCaps == false) ? "X".ToLower() : "X".ToUpper();
            Y.Text = (bCaps == false) ? "Y".ToLower() : "Y".ToUpper();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            string sInData = "";
            string key = (sender as Button).Text;
            sInData = tbInput.Text;
            switch (key)
            {
                case "Caps":
                    
                    if (Caps.BackColor == Color.White)
                    {
                        CreateKeyboard(true);
                    }
                    else
                    {
                        CreateKeyboard(false);
                    }
                        break;
                case "Esc": this.Close(); break;
                case "Bs":
                    if (tbInput.Text.Length > 0)
                        tbInput.Text = tbInput.Text.Substring(0, tbInput.Text.Length - 1);
                    break;
                case "Del": tbInput.Clear(); break;
                case "Clr": tbInput.Clear(); break;
                case "<-": /* 커서 이동 생략 */ break;
                case "Enter":
                    _onEnter?.Invoke(tbInput.Text); // Module로 전달();
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
                case ".":
                    if (sInData.Contains(".") == false)
                    {
                        if (sInData.IndexOf("-") == 0)
                        {
                            tbInput.Text = sInData.Replace("-", "-0.");
                        }
                        else
                        {
                            tbInput.Text = "0." + sInData;
                        }
                    }
                    break;
                default: tbInput.Text += key; break;
            }
        }
    }
}