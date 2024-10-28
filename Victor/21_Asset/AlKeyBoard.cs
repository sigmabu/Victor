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
            Num_KeyBoard_Change();
            nCaps = 0;
            Caps_KeyBoard_Change();


            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                Screen.PrimaryScreen.WorkingArea.Height - this.Height);
            
            tbInput.Text = "";
            nCaps = 0;
            Caps_KeyBoard_Change();
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
            nkeyPadType = (int)(eKaypadType);
            Num_KeyBoard_Change();
            nCaps = 0;
            Caps_KeyBoard_Change();

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
            
            NUM.BackColor = (nkeyPadType != (int)eKeyPadType.Normal) ? Gcolor.ColorBase : Color.White;

            Caps.Enabled = ((nkeyPadType == (int)eKeyPadType.Normal) || (nkeyPadType == (int)eKeyPadType.string_Data)) ? true : false;
            Underbar.Enabled = ((nkeyPadType == (int)eKeyPadType.Normal) || (nkeyPadType == (int)eKeyPadType.string_Data)) ? true : false;
            SQ.Enabled = ((nkeyPadType == (int)eKeyPadType.Normal) || (nkeyPadType == (int)eKeyPadType.string_Data)) ? true : false;
            REST.Enabled = (nkeyPadType != (int)eKeyPadType.Int_data) ? true : false;
            
            QUESTION.Enabled = ((nkeyPadType == (int)eKeyPadType.Normal) || (nkeyPadType == (int)eKeyPadType.string_Data)) ? true : false;
            A.Enabled = ((nkeyPadType == (int)eKeyPadType.Normal) || (nkeyPadType == (int)eKeyPadType.string_Data)) ? true : false;
            B.Enabled = ((nkeyPadType == (int)eKeyPadType.Normal) || (nkeyPadType == (int)eKeyPadType.string_Data)) ? true : false;
            C.Enabled = ((nkeyPadType == (int)eKeyPadType.Normal) || (nkeyPadType == (int)eKeyPadType.string_Data)) ? true : false;
            D.Enabled = ((nkeyPadType == (int)eKeyPadType.Normal) || (nkeyPadType == (int)eKeyPadType.string_Data)) ? true : false;
            E.Enabled = ((nkeyPadType == (int)eKeyPadType.Normal) || (nkeyPadType == (int)eKeyPadType.string_Data)) ? true : false;
            F.Enabled = ((nkeyPadType == (int)eKeyPadType.Normal) || (nkeyPadType == (int)eKeyPadType.string_Data)) ? true : false;
            G.Enabled = ((nkeyPadType == (int)eKeyPadType.Normal) || (nkeyPadType == (int)eKeyPadType.string_Data)) ? true : false;
            H.Enabled = ((nkeyPadType == (int)eKeyPadType.Normal) || (nkeyPadType == (int)eKeyPadType.string_Data)) ? true : false;
            I.Enabled = ((nkeyPadType == (int)eKeyPadType.Normal) || (nkeyPadType == (int)eKeyPadType.string_Data)) ? true : false;
            K.Enabled = ((nkeyPadType == (int)eKeyPadType.Normal) || (nkeyPadType == (int)eKeyPadType.string_Data)) ? true : false;
            J.Enabled = ((nkeyPadType == (int)eKeyPadType.Normal) || (nkeyPadType == (int)eKeyPadType.string_Data)) ? true : false;
            L.Enabled = ((nkeyPadType == (int)eKeyPadType.Normal) || (nkeyPadType == (int)eKeyPadType.string_Data)) ? true : false;
            M.Enabled = ((nkeyPadType == (int)eKeyPadType.Normal) || (nkeyPadType == (int)eKeyPadType.string_Data)) ? true : false;
            N.Enabled = ((nkeyPadType == (int)eKeyPadType.Normal) || (nkeyPadType == (int)eKeyPadType.string_Data)) ? true : false;
            O.Enabled = ((nkeyPadType == (int)eKeyPadType.Normal) || (nkeyPadType == (int)eKeyPadType.string_Data)) ? true : false;
            P.Enabled = ((nkeyPadType == (int)eKeyPadType.Normal) || (nkeyPadType == (int)eKeyPadType.string_Data)) ? true : false;
            Q.Enabled = ((nkeyPadType == (int)eKeyPadType.Normal) || (nkeyPadType == (int)eKeyPadType.string_Data)) ? true : false;
            R.Enabled = ((nkeyPadType == (int)eKeyPadType.Normal) || (nkeyPadType == (int)eKeyPadType.string_Data)) ? true : false;
            S.Enabled = ((nkeyPadType == (int)eKeyPadType.Normal) || (nkeyPadType == (int)eKeyPadType.string_Data)) ? true : false;
            T.Enabled = ((nkeyPadType == (int)eKeyPadType.Normal) || (nkeyPadType == (int)eKeyPadType.string_Data)) ? true : false;
            U.Enabled = ((nkeyPadType == (int)eKeyPadType.Normal) || (nkeyPadType == (int)eKeyPadType.string_Data)) ? true : false;
            V.Enabled = ((nkeyPadType == (int)eKeyPadType.Normal) || (nkeyPadType == (int)eKeyPadType.string_Data)) ? true : false;
            W.Enabled = ((nkeyPadType == (int)eKeyPadType.Normal) || (nkeyPadType == (int)eKeyPadType.string_Data)) ? true : false;
            X.Enabled = ((nkeyPadType == (int)eKeyPadType.Normal) || (nkeyPadType == (int)eKeyPadType.string_Data)) ? true : false;
            Y.Enabled = ((nkeyPadType == (int)eKeyPadType.Normal) || (nkeyPadType == (int)eKeyPadType.string_Data)) ? true : false;
            Z.Enabled = ((nkeyPadType == (int)eKeyPadType.Normal) || (nkeyPadType == (int)eKeyPadType.string_Data)) ? true : false;
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
                    nNum ^= 1;
                    if (nNum == 1) nkeyPadType = (int)eKeyPadType.Double_data;
                    else nkeyPadType = (int)eKeyPadType.Normal;
                    Num_KeyBoard_Change();
                    break;
                case "Caps":
                    nCaps ^= 1;
                    Caps_KeyBoard_Change();
                    break;
                case "Enter":
                    InKey = tbInput.Text;
                    FormClose();
                    break;
                case "SPACE":
                    sHitStr += " ";
                    tbInput.Text = sHitStr;
                    break;
                case "Bs":
                    if (tbInput.Text.Length > 0)
                    {
                        sHitStr = sHitStr.Remove(sHitStr.Length - 1, 1);
                        tbInput.Text = sHitStr;
                    }
                    break;
                case "Del":
                    if (tbInput.Text.Length > 0)
                    {
                        sHitStr = "";
                        tbInput.Text = sHitStr;
                    }
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
