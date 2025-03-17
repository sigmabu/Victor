using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Interop;

namespace Victor
{
    public class CSys04_Common : SingleTone<CSys04_Common>
    {
        delegate void pDelegateFun();
        static pDelegateFun NextFun = null;
        DateTime Now = DateTime.Now;



        private CSys04_Common()
        {
        }

        ~CSys04_Common()
        {

        }


        double dCnt = 0.0;
        public List<double> __dDZaxis_Step_NextCycleUp_Pos = new List<double>();
        public void Main_Process()
        {
            DTrace_Message();


        }
        private int old_key;
        string sData0;
        private void Display_mode()
        {
            return;
        }

        private void DTrace_Message()
        {
        }
    }
}
