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
    public partial class BasekeyboardForm : Form
    {
        //public BasekeyboardForm()
        //{
        //    InitializeComponent();
        //}
        protected TextBox inputBox = new TextBox();
        public Action<string> OnEnterPressed;

        public BasekeyboardForm()
        {
            inputBox.Dock = DockStyle.Top;
            Controls.Add(inputBox);
        }

        protected void HandleKeyPress(string key)
        {
            if (key == "Enter")
            {
                OnEnterPressed?.Invoke(inputBox.Text);
                this.Close();
            }
            else
            {
                inputBox.Text += key;
            }
        }
    }
}
