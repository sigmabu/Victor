using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Victor
{    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool bNew;

            Application.AddMessageFilter(new AltF4Filter()); 

            Mutex mutex = new Mutex(true, "Victor", out bNew);
            if (bNew)
            {
                // 소유권이 부여
                // 즉 해당 프로그램이 실행되고 있지 않은 경우

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                Application.Run(new FrmMain());

                // 뮤텍스 릴리즈
                mutex.ReleaseMutex();
            }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //MiniDump.CreateMiniDump();
        }
    }

    public class AltF4Filter : IMessageFilter
    {
        public bool PreFilterMessage(ref Message m)
        {
            const int WM_SYSKEYDOWN = 0x0104;
            if (m.Msg == WM_SYSKEYDOWN)
            {
                bool alt = ((int)m.LParam & 0x20000000) != 0;
                if (alt && (m.WParam == new IntPtr((int)Keys.F4)))
                {
                    return true; //무시하기                
                }
            }
            return false;
        }
    }
}