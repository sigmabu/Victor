using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;
using static System.Windows.Forms.Button;

namespace Victor
{ 
    /// <summary>
    /// 사용법
    /// var ak = new AlKeyBoard(this.ParentForm, tbText.Text);
    ///       if(ak != null ) tbText.Text = ak.InKey;
    /// </summary>
    public partial class AlKeyBoard : Form
    {
        private int caretPosition;
        private string sHitStr = "";

        private int nCaps { get; set; }
        public string InKey { get; private set; }
        public MessageBoxButtons Result { get; private set; }
        public AlKeyBoard(string str)
        {
            InitializeComponent();
            Result = MessageBoxButtons.AbortRetryIgnore;

            Result = MessageBoxButtons.AbortRetryIgnore;
            InKey = str;
            tbInput.Text = str;
            nCaps = 0;

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                Screen.PrimaryScreen.WorkingArea.Height - this.Height);
            caretPosition = 0;
            tbInput.Text = "";
            nCaps = 0;
            this.ShowDialog();
        }

        public AlKeyBoard(Form mainFrame, string str )
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(mainFrame.Location.X + (mainFrame.Width - this.Width) / 2, mainFrame.Location.Y + mainFrame.Height - this.Height);

            Result = MessageBoxButtons.AbortRetryIgnore;
            InKey = str;
            tbInput.Text = str;
            nCaps = 0;

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                Screen.PrimaryScreen.WorkingArea.Height - this.Height);
            caretPosition = 0;
            this.ShowDialog();

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

        private void Caps_KeyBoard_Change()
        {
            Caps.BackColor = (nCaps == 0) ? Gcolor.ColorBase: Color.White;
            A.Text = (nCaps == 1) ? "A".ToLower(): "A".ToUpper();
            B.Text = (nCaps == 1) ? "B".ToLower(): "B".ToUpper();
            C.Text = (nCaps == 1) ? "C".ToLower(): "C".ToUpper();
            D.Text = (nCaps == 1) ? "D".ToLower(): "D".ToUpper();
            E.Text = (nCaps == 1) ? "E".ToLower(): "E".ToUpper();
            F.Text = (nCaps == 1) ? "F".ToLower(): "F".ToUpper();
            G.Text = (nCaps == 1) ? "G".ToLower(): "G".ToUpper();
            H.Text = (nCaps == 1) ? "H".ToLower(): "H".ToUpper();
            I.Text = (nCaps == 1) ? "I".ToLower(): "I".ToUpper();
            K.Text = (nCaps == 1) ? "J".ToLower(): "J".ToUpper();
            L.Text = (nCaps == 1) ? "K".ToLower(): "K".ToUpper();
            L.Text = (nCaps == 1) ? "L".ToLower(): "L".ToUpper();
            M.Text = (nCaps == 1) ? "M".ToLower(): "M".ToUpper();
            N.Text = (nCaps == 1) ? "N".ToLower(): "N".ToUpper();
            O.Text = (nCaps == 1) ? "O".ToLower(): "O".ToUpper();
            P.Text = (nCaps == 1) ? "P".ToLower(): "P".ToUpper();
            Q.Text = (nCaps == 1) ? "Q".ToLower(): "Q".ToUpper();
            R.Text = (nCaps == 1) ? "R".ToLower(): "R".ToUpper();
            S.Text = (nCaps == 1) ? "S".ToLower(): "S".ToUpper();
            T.Text = (nCaps == 1) ? "T".ToLower(): "T".ToUpper();
            U.Text = (nCaps == 1) ? "U".ToLower(): "U".ToUpper();
            V.Text = (nCaps == 1) ? "V".ToLower(): "V".ToUpper();
            W.Text = (nCaps == 1) ? "W".ToLower(): "W".ToUpper();
            X.Text = (nCaps == 1) ? "X".ToLower(): "X".ToUpper();
            Y.Text = (nCaps == 1) ? "Y".ToLower(): "Y".ToUpper();

        }

        private void Click_Keypad(object sender, EventArgs e)
        {
            Button btn = sender as  Button;

            switch (btn.Name.ToString())
            {
                case "Caps":
                    if (nCaps == 0)
                    {
                        nCaps = 1;
                    }
                    else
                    {
                        nCaps = 0;
                    }
                    Caps_KeyBoard_Change();
                    break;
                case "Enter":
                    InKey = tbInput.Text;
                    FormClose();
                    break;
                case "no1":
                case "no2":
                case "no3":
                case "no4":
                case "no5":
                case "no6":
                case "no7":
                case "no8":
                case "no9":
                case "no0":
                case "Underbar": 
                case "SQ":
                case "REST":
                case "PERIODE":
                case "QUESTION":
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
                case "SPACE":
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
