using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Victor._21_Asset._02_Virtualkeyboard
{
    public partial class KoreakeyboardForm : Form
    {

        private Control targetControl;
        private Form parentForm;
        private readonly Action<string> _onEnter;
        //private StringBuilder buffer = new StringBuilder();
        private List<char> buffer = new List<char>();
        public string CommittedText { get; private set; } = "";
        private KoreanInputBuffer inputBuffer = new KoreanInputBuffer();

        public KoreakeyboardForm(Control target, Form owner, Action<string> onEnter)
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
            A.Text = (bCaps == false) ? "ㅁ" : "ㅁ";
            B.Text = (bCaps == false) ? "ㅠ" : "ㅠ";
            C.Text = (bCaps == false) ? "ㅊ" : "ㅊ";
            D.Text = (bCaps == false) ? "ㅇ" : "ㅇ";
            E.Text = (bCaps == false) ? "ㄷ" : "ㄷ";
            F.Text = (bCaps == false) ? "ㄹ" : "ㄹ";
            G.Text = (bCaps == false) ? "ㅎ" : "ㅎ";
            H.Text = (bCaps == false) ? "ㅗ" : "ㅗ";
            I.Text = (bCaps == false) ? "ㅑ" : "ㅑ";
            J.Text = (bCaps == false) ? "ㅓ" : "ㅓ";
            K.Text = (bCaps == false) ? "ㅏ" : "ㅏ";
            L.Text = (bCaps == false) ? "ㅣ" : "ㅣ";
            M.Text = (bCaps == false) ? "ㅡ" : "ㅡ";
            N.Text = (bCaps == false) ? "ㅜ" : "ㅜ";
            O.Text = (bCaps == false) ? "ㅐ" : "ㅒ";
            P.Text = (bCaps == false) ? "ㅔ" : "ㅖ";
            Q.Text = (bCaps == false) ? "ㅂ" : "ㅃ";
            R.Text = (bCaps == false) ? "ㄱ" : "ㄲ";
            S.Text = (bCaps == false) ? "ㄴ" : "ㄴ";
            T.Text = (bCaps == false) ? "ㅅ" : "ㅆ";
            U.Text = (bCaps == false) ? "ㅕ" : "ㅕ";
            V.Text = (bCaps == false) ? "ㅍ" : "ㅍ";
            W.Text = (bCaps == false) ? "ㅈ" : "ㅉ";
            X.Text = (bCaps == false) ? "ㅌ" : "ㅌ";
            Y.Text = (bCaps == false) ? "ㅛ" : "ㅛ";
            Z.Text = (bCaps == false) ? "ㅋ" : "ㅋ";
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
                case "Del": tbInput.Clear(); buffer.Clear(); break;
                case "Clr": tbInput.Clear(); buffer.Clear(); break;
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
                default:
                    inputBuffer.AddKey(key[0]);
                    tbInput.Text = inputBuffer.CommittedText;

                    //tbInput.Text += key;
                    //buffer.Append(key);
                    //tbInput.Text = HangulComposer.Compose(buffer.ToString());

                        break;
            }
        }

        public class KoreanInputBuffer
        {
            private List<char> buffer = new List<char>();
            public string CommittedText { get; private set; } = "";

            public string AddKey(char key)
            {
                buffer.Add(key);

                int count = buffer.Count;
                char composed;

                // Case 1: 초성 + 중성 + 종성
                if (count == 3)
                {
                    if (HangulComposer.TryCompose(buffer.ToArray(), out composed))
                    {
                        CommittedText += composed;
                        buffer.Clear();
                        return CommittedText;
                    }
                    else
                    {
                        // 종성이 될 수 없는 경우 → 첫 글자 확정 후 뒤 다시 시도
                        CommittedText += buffer[0];
                        buffer.RemoveAt(0);
                        return AddKey(key);
                    }
                }

                // Case 2: 초성 + 중성
                if (count == 2)
                {
                    if (HangulComposer.TryCompose(buffer.ToArray(), out composed))
                    {
                        return CommittedText + composed;
                    }
                    else
                    {
                        // 중성이 유효하지 않음 → 초성 확정
                        CommittedText += buffer[0];
                        buffer.RemoveAt(0);
                        return AddKey(key);
                    }
                }

                // Case 3: 초성만 입력됨
                if (count == 1)
                {
                    return CommittedText + buffer[0];
                }

                // fallback
                return CommittedText;
            }

            public void Backspace()
            {
                if (buffer.Count > 0)
                {
                    buffer.RemoveAt(buffer.Count - 1);
                }
                else if (CommittedText.Length > 0)
                {
                    CommittedText = CommittedText.Substring(0, CommittedText.Length - 1);
                }
            }

            public void Clear()
            {
                buffer.Clear();
                CommittedText = "";
            }
        }

    }
    public class KoreanInputBuffer
    {
        private List<char> buffer = new List<char>();
        public string CommittedText { get; private set; } = "";

        public string AddKey(char key)
        {
            buffer.Add(key);

            if (buffer.Count >= 2 && HangulComposer.TryCompose(buffer.ToArray(), out char composed))
            {
                return CommittedText + composed;
            }

            if (buffer.Count == 3) // 종성 포함 후 확정
            {
                if (HangulComposer.TryCompose(buffer.ToArray(), out char composed3))
                {
                    CommittedText += composed3;
                    buffer.Clear();
                    return CommittedText;
                }
                else
                {
                    CommittedText += buffer[0];
                    buffer.RemoveAt(0);
                    return AddKey(key); // 재시도
                }
            }
            // 🔥 조합이 아직 안된 상태라면 buffer 자체를 표시
            if (buffer.Count > 0)
            {
                return CommittedText += new string(buffer.ToArray());//  + new string(buffer.ToArray());
            }

            return CommittedText;
        }

        public void Backspace()
        {
            if (buffer.Count > 0)
            {
                buffer.RemoveAt(buffer.Count - 1);
            }
            else if (CommittedText.Length > 0)
            {
                CommittedText = CommittedText.Substring(0, CommittedText.Length - 1);
            }
        }

        public void Clear()
        {
            buffer.Clear();
            CommittedText = "";
        }
    }


    public static class HangulComposer
    {
        private static readonly string CHO = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ";
        private static readonly string JUNG = "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ";
        private static readonly string JONG = "\0ㄱㄲㄳㄴㄵㄶㄷㄹㄺㄻㄼㄽㄾㄿㅀㅁㅂㅄㅅㅆㅇㅈㅊㅋㅌㅍㅎ";

        private static int IndexOf(string source, char c) => source.IndexOf(c);

        public static char ComposeSyllable(int cho, int jung, int jong)
        {
            return (char)(0xAC00 + cho * 21 * 28 + jung * 28 + jong);
        }

        public static bool TryCompose(char[] buffer, out char result)
        {
            result = '\0';
            if (buffer.Length < 2) return false;

            int cho = IndexOf(CHO, buffer[0]);
            int jung = IndexOf(JUNG, buffer[1]);

            if (cho < 0 || jung < 0) return false;

            int jong = 0;
            if (buffer.Length > 2)
            {
                jong = IndexOf(JONG, buffer[2]);
                if (jong < 0) jong = 0;
            }

            result = ComposeSyllable(cho, jung, jong);
            return true;
        }
    }
      
}