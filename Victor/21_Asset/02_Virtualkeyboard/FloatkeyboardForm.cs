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
    public partial class FloatkeyboardForm : Form
    {
        //private TextBox targetTextBox;
        private List<Button> buttons = new();
        public FloatkeyboardForm(TextBox target)
        {
            InitializeComponent();
            this.targetTextBox = target;
            this.Resize += (s, e) => ResizeLayout();
            CreateKeyboard();
        }

        private void CreateKeyboard()
        {
            string[][] keys =
            {
            new[] { "Esc", "1", "2", "3", "4", "5", ".", "-", "Bs" },
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

            ResizeLayout();
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
                case "Esc": targetTextBox.Clear(); break;
                //case "Bs": if (targetTextBox.Text.Length > 0) targetTextBox.Text = targetTextBox.Text[..^1]; break;
                case "Bs":
                    if (targetTextBox.Text.Length > 0)
                        targetTextBox.Text = targetTextBox.Text.Substring(0, targetTextBox.Text.Length - 1);
                    break;

                case "Del": targetTextBox.Clear(); break;
                case "Clr": targetTextBox.Clear(); break;
                case "<-": /* 생략 */ break;
                case "Enter": this.Close(); break;
                case ".": if (!targetTextBox.Text.Contains(".")) targetTextBox.Text += "."; break;
                default: targetTextBox.Text += key; break;
            }
        }
    }
}