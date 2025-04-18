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
    public partial class IntkeyboardForm : Form
    {
        private Control targetControl;
        private Form parentForm;
        public class FormLocation
        {
            public int x { get; set; }
            public int y { get; set; }
        }

        //private TextBox tbInput;
        private List<Button> buttons = new();
        public IntkeyboardForm(Control target,Form owner)
        {
            InitializeComponent();
            targetControl = target;
            parentForm = owner;
            this.StartPosition = FormStartPosition.Manual;


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

            // 초기 값 설정
            if (targetControl is TextBox || targetControl is Label)
            {
                tbInput.Text = targetControl.Text;
            }

            CreateKeyboard();
        }
        private void CreateKeyboard()
        {
            
        }

        private void CreateKeyboard__()
        {
            string[][] keys =
            {
            new[] { "Esc", "1", "2", "3", "4", "5", "-", "Bs" },
            new[] { "<-", "6", "7", "8", "9", "0", "Clr", "Del", "Enter" }
        };

            foreach (var row in keys)
            {
                foreach (var key in row)
                {
                    var btn = new Button { Text = key, Font = new Font("Segoe UI", 12F, FontStyle.Bold) };
                    btn.Click += (s, e) => OnKeyClick(key);
                    Controls.Add(btn);
                    buttons.Add(btn);
                }
            }

            //ResizeLayout();
        }

        private void ResizeLayout()
        {
            int rows = 2, cols = 9, margin = 5;
            int w = (ClientSize.Width - margin * (cols + 1)) / cols;
            int h = (ClientSize.Height - margin * (rows + 1)) / rows;

            for (int i = 0; i < buttons.Count; i++)
            {
                int r = i / cols, c = i % cols;
                buttons[i].SetBounds(margin + c * (w + margin), margin + r * (h + margin), w, h);
            }
        }

        private void OnKeyClick(string key)
        {
            switch (key)
            {
                case "Esc": tbInput.Clear(); break;
                case "Bs":
                    if (tbInput.Text.Length > 0)
                        tbInput.Text = tbInput.Text.Substring(0, tbInput.Text.Length - 1);
                    break;
                case "Del": tbInput.Clear(); break;
                case "Clr": tbInput.Clear(); break;
                case "<-": /* 커서 이동 생략 */ break;
                case "Enter": this.Close(); break;
                default: tbInput.Text += key; break;
            }
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
                case "Enter": RaiseEnter(); break;// this.Close(); break;
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
        public  Action<string> OnEnterPressed; // 콜백 설정

        protected  void RaiseEnter()
        {
            OnEnterPressed?.Invoke(tbInput.Text);
            this.Close(); // 입력 후 키보드 닫기
        }
    }
}
