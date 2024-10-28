using System;
using System.Drawing;
using System.Windows.Forms;

namespace Victor
{
    /// <summary>
    /// 사용법
    ///  var ak = new NumKeyBoard(this.ParentForm, tbText.Text);
    ///             if(ak != null ) tbText.Text = ak.InKey;
    /// </summary>
    public partial class NumKeyBoard : Form
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

        private bool bDot_Exist;
        private int nCharCnt { get; set; }
        private int nkeyPadType { get; set; }
        private int nNum { get; set; }
        private int nFloat { get; set; }
        public string InKey { get; private set; }
        public MessageBoxButtons Result { get; private set; }
        public NumKeyBoard(string str, eKeyPadType eKaypadType = eKeyPadType.Double_data)
        {
            InitializeComponent();
            Result = MessageBoxButtons.AbortRetryIgnore;

            Result = MessageBoxButtons.AbortRetryIgnore;
            InKey = str;
            bDot_Exist = InKey.Contains(".");
            nCharCnt = InKey.Length;
            tbInput.Text = str;
            sHitStr = tbInput.Text;
            nkeyPadType = (int)eKaypadType;
            Num_KeyBoard_Change();
            nFloat = 0;
            Float_KeyBoard_Change();


            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                Screen.PrimaryScreen.WorkingArea.Height - this.Height);
            
            tbInput.Text = "";
            Float_KeyBoard_Change();
            this.ShowDialog();
        }

        public NumKeyBoard(Form mainFrame, string str, eKeyPadType eKaypadType = eKeyPadType.Double_data)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(mainFrame.Location.X + (mainFrame.Width - this.Width) / 2, mainFrame.Location.Y + mainFrame.Height - this.Height);

            Result = MessageBoxButtons.AbortRetryIgnore;
            InKey = str;
            bDot_Exist = InKey.Contains(".") ;
            nCharCnt = InKey.Length;
            tbInput.Text = str;
            sHitStr = tbInput.Text;
            nkeyPadType = (int)(eKaypadType);
            Num_KeyBoard_Change();
            nFloat = 0;
            Float_KeyBoard_Change();

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

            Float.BackColor = (nkeyPadType != (int)eKeyPadType.Double_data) ? Gcolor.ColorBase : Color.White;
            PERIODE.Enabled = ((nkeyPadType == (int)eKeyPadType.Double_data)) ? true : false;
        }
        private void Float_KeyBoard_Change()
        {
            Float.BackColor = (nFloat == 1) ? Gcolor.ColorBase: Color.White;
        }

        private void Click_Keypad(object sender, EventArgs e)
        {
            Button btn = sender as  Button;

            nCharCnt = sHitStr.Length;
            bDot_Exist = sHitStr.Contains(".");
            if ((btn.Name.ToString() == "Minus") && (nCharCnt > 0))
            {
                return;
            }
            if ((btn.Name.ToString() == "PERIODE"))
            { 
                if (nCharCnt < 1)
                {
                    sHitStr = "0";
                }
                if(bDot_Exist == true)
                {
                    return;
                }
            }

            switch (btn.Name.ToString())
            {
                case "Float":
                    nFloat ^= 1;
                    if (nFloat == 1) nkeyPadType = (int)eKeyPadType.Double_data;
                    else nkeyPadType = (int)eKeyPadType.Int_data;
                    Num_KeyBoard_Change();
                    break;
                case "Enter":
                    InKey = tbInput.Text;
                    FormClose();
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
                case "Minus":                    
                        //if (nCharCnt < 1)
                        //{

                        //}
                        //else break;
                case "PERIODE":
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

        private void NumKeyBoard_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
