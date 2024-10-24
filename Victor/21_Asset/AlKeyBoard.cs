using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.Button;

namespace Victor
{ 
    public partial class AlKeyBoard : Form
    {
        private int caretPosition;
        private string sHitStr = "";

        public string InKey { get; private set; }
        public MessageBoxButtons Result { get; private set; }
        public AlKeyBoard()
        {
            InitializeComponent();
            Result = MessageBoxButtons.AbortRetryIgnore;
            this.ShowDialog();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                Screen.PrimaryScreen.WorkingArea.Height - this.Height);
            caretPosition = 0;
            tbInput.Text = "";
        }

        private void Esc_Click(object sender, EventArgs e)
        {
            FormClose();
        }

        private void FormClose()
        {
            Result = MessageBoxButtons.OK;
            this.Close();            
        }



        private void Click_Keypad(object sender, EventArgs e)
        {
            Button btn = sender as  Button;

            switch (btn.Name.ToString())
            {
                case "Enter":
                    InKey = tbInput.Text;
                    FormClose();
                    break;
                case "A":
                case "B":
                case "C":
                case "D":
                case "E":
                case "F":
                case "G":
                case "H":
                case "I":
                case "J":
                case "K":
                case "L":
                case "M":
                case "N":
                case "O":
                case "P":
                case "Q":
                case "R":
                case "S":
                case "T":
                case "U":
                case "V":
                case "W":
                case "X":
                case "Y":
                case " ":
                    sHitStr += btn.Text.ToString();
                    tbInput.Text = sHitStr;
                    break;
                default: break;
            }
        }        

        private void FormLoad(object sender, EventArgs e)
        {
            tbInput.Focus();
            tbInput.ScrollToCaret();
        }

        private void FormShown(object sender, EventArgs e)
        {
            setFocusOnTextBox();
        }

        private void setFocusOnTextBox()
        {
            tbInput.Select(caretPosition, 0);
            tbInput.Focus();
            tbInput.ScrollToCaret();
        }

        private void AlKeyBoard_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
