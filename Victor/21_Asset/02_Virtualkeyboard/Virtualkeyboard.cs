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
        public static void ShowKeyboard(VirtualKeyboardType type, TextBox targetTextBox, Form owner)//, Action<string> onEnterCallback)
        {
            Form keyboard = type switch
            {
                VirtualKeyboardType.Integer => new IntkeyboardForm(targetTextBox, owner),
                //VirtualKeyboardType.Float => new FloatkeyboardForm(targetTextBox),
                //VirtualKeyboardType.English => new EnglishKeyboardForm(targetTextBox),
                //VirtualKeyboardType.Korean => new KoreanKeyboardForm(targetTextBox),
                _ => null
            };

            if (keyboard != null)
            {
                // Enter 키 눌렀을 때 targetControl.Text에 값 전달
                keyboard.OnEnterPressed = value =>
                {
                    if (targetControl is TextBox tb)
                        tb.Text = value;
                    else if (targetControl is Label lbl)
                        lbl.Text = value;
                    else
                        MessageBox.Show("지원되지 않는 컨트롤입니다.");
                };

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
    }
}
