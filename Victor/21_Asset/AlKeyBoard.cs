using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;
using static System.Windows.Forms.Button;
using static Victor.AlKeyBoard;

namespace Victor
{ 
    /// <summary>
    /// 사용법
    /// var ak = new AlKeyBoard(this.ParentForm, tbText.Text);
    ///       if(ak != null ) tbText.Text = ak.InKey;
    /// </summary>
    public partial class AlKeyBoard : Form
    {
        public enum eKeyPadType
        {
            Normal,
            string_Data,
            Int_data,
            Double_data,
            end
        }
        private string sHitStr = "";

        private int nCharCnt { get; set; }
        private int nkeyPadType { get; set; }
        private int nNum { get; set; }
        private int nCaps { get; set; }
        public string InKey { get; private set; }
        public MessageBoxButtons Result { get; private set; }
        public AlKeyBoard(string str, eKeyPadType eKaypadType = eKeyPadType.Normal)
        {
            InitializeComponent();
            Result = MessageBoxButtons.AbortRetryIgnore;

            Result = MessageBoxButtons.AbortRetryIgnore;
            InKey = str;
            tbInput.Text = str;
            sHitStr = tbInput.Text;
            nkeyPadType = (int)eKaypadType;
            nCaps = 0;

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                Screen.PrimaryScreen.WorkingArea.Height - this.Height);
            
            tbInput.Text = "";
            nCaps = 0;
            this.ShowDialog();
        }

        public AlKeyBoard(Form mainFrame, string str, eKeyPadType eKaypadType = eKeyPadType.Normal)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(mainFrame.Location.X + (mainFrame.Width - this.Width) / 2, mainFrame.Location.Y + mainFrame.Height - this.Height);

            Result = MessageBoxButtons.AbortRetryIgnore;
            InKey = str;
            tbInput.Text = str;
            sHitStr = tbInput.Text;
            nCaps = 0;

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                Screen.PrimaryScreen.WorkingArea.Height - this.Height);
            
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

        private void Num_KeyBoard_Change()
        {
            NUM.BackColor = (nNum == 0) ? Gcolor.ColorBase : Color.White;

            Caps.Enabled = (nNum == 1) ? true : false;
            Underbar.Enabled = (nNum == 1) ? true : false;
            SQ.Enabled = (nNum == 1) ? true : false;
            REST.Enabled = (nNum == 1) ? true : false;
            
            QUESTION.Enabled = (nNum == 1) ? true : false;
            A.Enabled = (nNum == 1) ? true : false;
            B.Enabled = (nNum == 1) ? true : false;
            C.Enabled = (nNum == 1) ? true : false;
            D.Enabled = (nNum == 1) ? true : false;
            E.Enabled = (nNum == 1) ? true : false;
            F.Enabled = (nNum == 1) ? true : false;
            G.Enabled = (nNum == 1) ? true : false;
            H.Enabled = (nNum == 1) ? true : false;
            I.Enabled = (nNum == 1) ? true : false;
            K.Enabled = (nNum == 1) ? true : false;
            J.Enabled = (nNum == 1) ? true : false;
            L.Enabled = (nNum == 1) ? true : false;
            M.Enabled = (nNum == 1) ? true : false;
            N.Enabled = (nNum == 1) ? true : false;
            O.Enabled = (nNum == 1) ? true : false;
            P.Enabled = (nNum == 1) ? true : false;
            Q.Enabled = (nNum == 1) ? true : false;
            R.Enabled = (nNum == 1) ? true : false;
            S.Enabled = (nNum == 1) ? true : false;
            T.Enabled = (nNum == 1) ? true : false;
            U.Enabled = (nNum == 1) ? true : false;
            V.Enabled = (nNum == 1) ? true : false;
            W.Enabled = (nNum == 1) ? true : false;
            X.Enabled = (nNum == 1) ? true : false;
            Y.Enabled = (nNum == 1) ? true : false;
            Z.Enabled = (nNum == 1) ? true : false;
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
                case "NUM":
                    if (nNum == 0)
                    {
                        nNum = 1;
                    }
                    else
                    {
                        nNum = 0;
                    }
                    Num_KeyBoard_Change();

                    break;
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
                case "Z":
                case "SPACE":
                    sHitStr += btn.Text.ToString();
                    tbInput.Text = sHitStr;
                    break;
                case "Bs":
                    if (tbInput.Text.Length > 0)
                    {
                        sHitStr = sHitStr.Remove(sHitStr.Length - 1, 1);
                        tbInput.Text = sHitStr;
                    }
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
            nCharCnt = tbInput.Text.Length;
            tbInput.Select(nCharCnt, 0);
            tbInput.Focus();
            tbInput.ScrollToCaret();
        }

        private void AlKeyBoard_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
