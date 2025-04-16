using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Victor
{
    // VirtualKeyboardType.cs
    public enum VirtualKeyboardType
    {
        Integer,
        Float,
        Korean,
        English
    }

    public partial class VirtualKeyboard : Form
    {
        private Control targetControl;
        private VirtualKeyboardType keyboardType;
        private TextBox inputBox = new TextBox { Left = 10, Top = 10, Width = 480, Height = 30, Font = new System.Drawing.Font("맑은 고딕", 12) };
        private StringBuilder compositionBuffer = new StringBuilder();
        private Form parentForm;
        private TextBox tbText;
        private VirtualKeyboardType korean;

        private bool isShift = false;


        public VirtualKeyboard(Control target, VirtualKeyboardType type, Form owner)
        {
            InitializeComponent();
            targetControl = target;
            keyboardType = type;
            parentForm = owner;
            this.StartPosition = FormStartPosition.Manual;

            var mainBounds = parentForm.Bounds;
            this.Width = mainBounds.Width;
            this.Height = mainBounds.Height / 3;
            this.Left = mainBounds.Left;
            this.Top = mainBounds.Top + mainBounds.Height * 2 / 3; // 메인 뷰 하단 1/3 위치

            inputBox.Width = this.Width - 20;


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
                inputBox.Text = targetControl.Text;
            }

            CreateKeyboard();
        }

        private void CreateKeyboard()
        {
            this.Controls.Add(inputBox);
            inputBox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    targetControl.Text = inputBox.Text;
                    this.Close();
                }
            };

            FlowLayoutPanel panel = new FlowLayoutPanel
            {
                Left = 10,
                Top = 50,
                Width = this.ClientSize.Width - 20,
                Height = this.ClientSize.Height - 60,
                AutoScroll = true,
                WrapContents = true,
                BackColor = Color.White
            };


            string[] keyRows;

            switch (keyboardType)
            {
                case VirtualKeyboardType.Integer:
                    keyRows = new[] { "1 2 3 4 5", "6 7 8 9 0" };
                    break;
                case VirtualKeyboardType.Float:
                    keyRows = new[] { "1 2 3 4 5", "6 7 8 9 0 ." };
                    break;
                case VirtualKeyboardType.Korean:
                    keyRows = new[] {
                    "ㅂ ㅈ ㄷ ㄱ ㅅ ㅛ ㅕ ㅑ ㅐ ㅔ",
                    "ㅁ ㄴ ㅇ ㄹ ㅎ ㅗ ㅓ ㅏ ㅣ",
                    "ㅋ ㅌ ㅊ ㅍ ㅠ ㅜ ㅡ"
                };
                    break;
                case VirtualKeyboardType.English:
                    keyRows = new[] {
                    "1 2 3 4 5 6 7 8 9 0 - =",
                    "q w e r t y u i o p",
                    "a s d f g h j k l",
                    "z x c v b n m"
                };
                    break;
                default:
                    keyRows = new string[0];
                    break;
            }

            foreach (var row in keyRows)
            {
                foreach (var key in row.Split(' '))
                {
                    var btn = new Button
                    {
                        Text = isShift ? key.ToUpper() : key,
                        Tag = key,
                        AutoSize = true,
                        Font = new System.Drawing.Font("맑은 고딕", 12)
                    };
                    btn.Click += (s, e) => HandleKeyPress((string)btn.Tag);
                    panel.Controls.Add(btn);
                }
            }

            if (keyboardType == VirtualKeyboardType.English)
            {
                //var shiftBtn = new Button { Text = "Shift", AutoSize = true };
                var shiftBtn = new Button { Text = "Shift", Width = 100, Height = 50, ForeColor = Color.DarkRed };
                shiftBtn.Click += (s, e) =>
                {
                    isShift = !isShift;
                    this.Controls.Clear();
                    CreateKeyboard();
                };
                panel.Controls.Add(shiftBtn);
            }

            var btnSpace = new Button { Text = "SPACE", AutoSize = true, ForeColor = Color.DarkRed };
            btnSpace.Click += (s, e) => inputBox.Text += " ";
            panel.Controls.Add(btnSpace);

            var btnBack = new Button { Text = "BACK", AutoSize = true };
            btnBack.Click += (s, e) =>
            {
                if (inputBox.Text.Length > 0)
                    inputBox.Text = inputBox.Text.Substring(0, inputBox.Text.Length - 1);
            };
            panel.Controls.Add(btnBack);

            var btnEnter = new Button { Text = "ENTER", AutoSize = true , ForeColor = Color.DarkRed };
            btnEnter.Click += (s, e) =>
            {
                targetControl.Text = inputBox.Text;
                this.Close();
            };
            panel.Controls.Add(btnEnter);

            var btnEsc = new Button { Text = "ESC", AutoSize = true , ForeColor = Color.DarkRed };
            btnEsc.Click += (s, e) =>
            {
                this.Close();
            };
            panel.Controls.Add(btnEsc);

            this.Controls.Add(panel);
        }

        private void HandleKeyPress(string key)
        {
            if (keyboardType == VirtualKeyboardType.Korean)
            {
                compositionBuffer.Append(key);
                inputBox.Text = ComposeHangul(compositionBuffer.ToString());
            }
            else if (keyboardType == VirtualKeyboardType.English)
            {
                inputBox.Text += isShift ? key.ToUpper() : key.ToLower();
            }
            else if (keyboardType == VirtualKeyboardType.Float && key == ".")
            {
                if (!inputBox.Text.Contains("."))
                    inputBox.Text += ".";
            }
            else
            {
                inputBox.Text += key;
            }
        }

        private string ComposeHangul(string input)
        {
            return input; // 향후 한글 조합 로직 구현 가능
        }
    }
}