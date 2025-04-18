using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Victor
{
    #region 
    //btn.Click += (s, e) => VirtualKeyboardModule.ShowKeyboard(VirtualKeyboardType.Korean, inputBox);

    #endregion
    public static class Virtualkeyboard
    {
        private static Action<string> _onValueConfirmed;
        public static void ShowKeyboard(VirtualKeyboardType type,
                                    TextBox targetTextBox, Form owner,
                                    Action<string> onValueConfirmed)
        {
            Form keyboard = null;
            _onValueConfirmed = onValueConfirmed;

            switch (type)
            {
                case VirtualKeyboardType.Integer:
                    keyboard = new IntkeyboardForm(targetTextBox, owner,OnKeyboardEnter);
                    break;
                //case VirtualKeyboardType.Float:
                //    keyboard = new FloatkeyboardForm(targetTextBox);
                //    break;
                //case VirtualKeyboardType.English:
                //    keyboard = new EnglishKeyboardForm(targetTextBox);
                //    break;
                //case VirtualKeyboardType.Korean:
                //    keyboard = new KoreanKeyboardForm(targetTextBox);
                //    break;
                default:
                    MessageBox.Show("지원되지 않는 키보드 타입입니다.");
                    return;
            }

            if (keyboard != null)
            {
                // Enter 키 눌렀을 때 targetControl.Text에 값 전달

                // 📍 메인 폼 위치 기준으로 설정
                int x = owner.Left;
                int y = owner.Top + (int)(owner.Height * 2.0 / 3.0);
                int w = owner.Bounds.Width;
                int h = owner.Bounds.Height / 3;

                keyboard.StartPosition = FormStartPosition.Manual;
                keyboard.Location = new System.Drawing.Point(x, y);
                keyboard.Size = new System.Drawing.Size(w, h);
                keyboard.ShowDialog(owner);
            }
            else
            {
                MessageBox.Show("지원되지 않는 키보드 타입입니다.");
            }
        }


        // 키보드에서 Enter 눌렀을 때 호출
        private static void OnKeyboardEnter(string value)
        {
            _onValueConfirmed?.Invoke(value);  // MainForm으로 전달
        }
    }
}
