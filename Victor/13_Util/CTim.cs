using System;
using System.Diagnostics;

namespace Victor
{
    public class CTim
    {
        private DateTime _target;
        private long SetTime;
        private long PreTime;
        private long CurTime;
        private Stopwatch stopwatch = new Stopwatch();
        private Stopwatch stopwatch01 = new Stopwatch();

        private int _setDelay = 0;

        public CTim()
        {
        }

        /// <summary>
        /// 밀리세컨드로 대기시간 입력 [ms]
        /// </summary>
        /// <param name="msec"></param>
        public void Start(int msec)
        {
            _setDelay = msec;
            _target = DateTime.Now.Add(new TimeSpan(0, 0, 0, 0, _setDelay));
        }

        /// <summary>
        /// 지정된 시간을 넘어가면 true 반환, 아직 넘지 못하면 false
        /// </summary>
        /// <returns></returns>
        public bool End()
        {
            if (_target >= DateTime.Now)
            { return false; }
            else
            { return true; }
        }

        public int GetSetTime()
        {
            return _setDelay;
        }

        public string TickTime_Stop()
        {
            stopwatch01.Stop();
            return stopwatch01.Elapsed.ToString(@"hh\:mm\:ss\.f");
        }
        public string TickTime_Restart()
        {
            stopwatch01.Start();
            return stopwatch01.Elapsed.ToString(@"hh\:mm\:ss\.f");
        }

        public string TickTime_Get()
        {
            //stopwatch01.Start();
            return stopwatch01.Elapsed.ToString(@"hh\:mm\:ss\.f");
        }

        public string TickTime_Start()
        {
            stopwatch01 = Stopwatch.StartNew();//    .Start();
            return stopwatch01.Elapsed.ToString(@"hh\:mm\:ss\.f");
        }

        public long GetTickTime_ms()
        {
            return stopwatch.ElapsedTicks * 1000L / Stopwatch.Frequency;
        }

        public bool OnDelay(bool SeqInput, long _SetTime)
        {
            SetTime = _SetTime;
            return OnDelay(SeqInput);
        }

        private bool OnDelay(bool SeqInput)
        {
            bool Result = false;
            if (SeqInput)
            {
                CurTime = GetTickTime_ms();
                if (CurTime == 0)
                {
                    stopwatch = Stopwatch.StartNew();
                    PreTime = GetTickTime_ms();
                }
                if (CurTime - PreTime >= SetTime)
                {
                    //stopwatch = Stopwatch.StartNew();
                    PreTime = CurTime;
                    Result = true;
                }
                else
                {
                    Result = false;
                }
            }
            else
            {
                stopwatch = Stopwatch.StartNew();
                PreTime = GetTickTime_ms();

            }
            return Result;
        }

        public DateTime Wait(int msec)
        {
            DateTime now = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, msec);
            DateTime target = now.Add(duration);

            while (target >= now)
            {
                System.Windows.Forms.Application.DoEvents();
                now = DateTime.Now;
            }

            return DateTime.Now;
        }

    }
}
