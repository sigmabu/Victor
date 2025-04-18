using System;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;

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

    public partial class VirtualKeyboard_01 : Form
    {
        private Control targetControl;
        private VirtualKeyboardType keyboardType;
        private TextBox inputBox = new TextBox { Left = 10, Top = 10, Width = 480, Height = 30, Font = new System.Drawing.Font("맑은 고딕", 12) };
        private StringBuilder compositionBuffer = new StringBuilder();
        private Form parentForm;
        private TextBox tbText;
        private VirtualKeyboardType korean;

        private bool isShift = false;


        public VirtualKeyboard_01(Control target, VirtualKeyboardType type, Form owner)
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

        private List<Button> keyboardButtons = new List<Button>();

        private void CreateKeyboard_()
        {
            // 기존 버튼 삭제
            foreach (var btn in keyboardButtons)
                this.Controls.Remove(btn);
            keyboardButtons.Clear();

            string[][] layout;

            if (keyboardType == VirtualKeyboardType.Integer)
            {
                layout = new string[][]
                {
            new string[] { "Esc", "1", "2", "3", "4", "5", "-", "Bs" },
            new string[] { "<-", "6", "7", "8", "9", "0", "Clr", "Del", "Enter" }
                };
            }
            else if (keyboardType == VirtualKeyboardType.Float)
            {
                layout = new string[][]
                {
            new string[] { "Esc", "1", "2", "3", "4", "5", ".", "-", "Bs" },
            new string[] { "<-", "6", "7", "8", "9", "0", "Clr", "Del", "Enter" }
                };
            }
            else return;

            int rows = layout.Length;
            int maxCols = layout.Max(r => r.Length);
            int margin = 5;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < layout[row].Length; col++)
                {
                    Button btn = new Button();
                    btn.Text = layout[row][col];
                    btn.Click += (s, e) => HandleKeyPress(btn.Text);
                    this.Controls.Add(btn);
                    keyboardButtons.Add(btn);
                }
            }

            ResizeKeyboardLayout(); // 초기 사이즈 배치
        }

        private void ResizeKeyboardLayout()
        {
            if (keyboardButtons.Count == 0) return;
            this.Controls.Add(inputBox);
            inputBox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    targetControl.Text = inputBox.Text;
                    this.Close();
                }
            };

            int maxCols = keyboardButtons
                .Select((b, i) => (i / 2 == 0 ? 8 : 9)) // 정수: 8/9, 실수: 9/9
                .Max();

            int rows = (keyboardType == VirtualKeyboardType.Float) ? 2 : 2;
            int margin = 5;

            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height / 3; // 키보드 높이 지정

            int btnWidth = (width - (margin * (maxCols + 1))) / maxCols;
            int btnHeight = (height - (margin * (rows + 1))) / rows;

            for (int i = 0; i < keyboardButtons.Count; i++)
            {
                int row = (i < maxCols) ? 0 : 1;
                int col = i % maxCols;

                var btn = keyboardButtons[i];
                btn.Width = btnWidth;
                btn.Height = btnHeight;
                btn.Left = margin + col * (btnWidth + margin);
                btn.Top = this.ClientSize.Height - height + margin + row * (btnHeight + margin);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ResizeKeyboardLayout(); // 폼 리사이즈 시 버튼도 재배치
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
                    keyRows = new[] { "1 2 3 4 5", "6 7 8 9 0 -" };
                    break;
                case VirtualKeyboardType.Float:
                    keyRows = new[] { "1 2 3 4 5", "6 7 8 9 0 - ." };
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
                    "1 2 3 4 5 6 7 8 9 0 _ =",
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


        private int[] chosungIndexes = new int[19];  // 초성 인덱스
        private int[] jungsungIndexes = new int[21];  // 중성 인덱스
        private int[] jongsungIndexes = new int[28];  // 종성 인덱스

        private string ComposeHangul(string input)
        {
            // 한글 자모 리스트
            string[] chosung = { "ㄱ", "ㄲ", "ㄴ", "ㄷ", "ㄸ", "ㄹ", "ㅁ", "ㅂ", "ㅃ", "ㅅ", "ㅆ", "ㅇ", "ㅈ", "ㅉ", "ㅊ", "ㅋ", "ㅌ", "ㅍ", "ㅎ" };
            string[] jungsung = { "ㅏ", "ㅐ", "ㅑ", "ㅒ", "ㅓ", "ㅔ", "ㅕ", "ㅖ", "ㅗ", "ㅘ", "ㅙ", "ㅚ", "ㅛ", "ㅜ", "ㅝ", "ㅞ", "ㅟ", "ㅠ", "ㅡ", "ㅢ", "ㅣ" };
            string[] jongsung = { "", "ㄱ", "ㄲ", "ㄳ", "ㄴ", "ㄵ", "ㄶ", "ㄷ", "ㄹ", "ㄺ", "ㄻ", "ㄼ", "ㄽ", "ㄾ", "ㄿ", "ㅀ", "ㅁ", "ㅂ", "ㅃ", "ㅄ", "ㅅ", "ㅆ", "ㅇ", "ㅈ", "ㅉ", "ㅊ", "ㅋ", "ㅌ", "ㅍ", "ㅎ" };

            // 한글 완성형 조합
            string result = "";
            int chosungIndex = -1, jungsungIndex = -1, jongsungIndex = -1;

            foreach (char c in input)
            {
                // 초성, 중성, 종성 처리
                if (chosung.Contains(c.ToString()))
                {
                    chosungIndex = Array.IndexOf(chosung, c.ToString());
                }
                else if (jungsung.Contains(c.ToString()))
                {
                    jungsungIndex = Array.IndexOf(jungsung, c.ToString());
                }
                else if (jongsung.Contains(c.ToString()))
                {
                    jongsungIndex = Array.IndexOf(jongsung, c.ToString());
                }

                // 초성, 중성, 종성이 모두 설정되었을 때 완성형 한글 생성
                if (chosungIndex >= 0 && jungsungIndex >= 0)
                {
                    result += (char)(0xAC00 + (chosungIndex * 21 + jungsungIndex) * 28 + jongsungIndex);
                }
            }

            return result;
        }
    }
}