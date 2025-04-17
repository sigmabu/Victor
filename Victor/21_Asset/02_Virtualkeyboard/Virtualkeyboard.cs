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
        public static void ShowKeyboard(VirtualKeyboardType type, TextBox targetTextBox)
        {
            Form keyboard = type switch
            {
                VirtualKeyboardType.Integer => new IntkeyboardForm(targetTextBox),
                VirtualKeyboardType.Float => new FloatkeyboardForm(targetTextBox),
                //VirtualKeyboardType.English => new EnglishKeyboardForm(targetTextBox),
                //VirtualKeyboardType.Korean => new KoreanKeyboardForm(targetTextBox),
                _ => null
            };

            if (keyboard != null)
            {
                keyboard.StartPosition = FormStartPosition.CenterParent;
                keyboard.Size = new System.Drawing.Size(800, 300);
                keyboard.ShowDialog();
            }
            else
            {
                MessageBox.Show("지원되지 않는 키보드 타입입니다.");
            }
        }
    }
}
