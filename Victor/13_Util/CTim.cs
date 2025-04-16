using System;
using System.Diagnostics;
using System.Threading;

namespace Victor
{
    #region Timer 정의
    
    //private CTimers[] timers = new CTimers[10];

    //public MainForm()
    //{
    //    InitializeComponent();
    //    for (int i = 0; i < timers.Length; i++)
    //        timers[i] = new StopWatchHelper();
    //}
    //btnStart.Click += (s, e) => timers[index].Start(100);
    //btnStop.Click += (s, e) => timers[index].Stop();
    //btnElapsed.Click += (s, e) => lblTime.Text = timers[index].ElapsedMilliseconds() + " ms";
    //btnNow.Click += (s, e) => lblNow.Text = timers[index].GetCurrentFullTimestamp();
    //btnEnd.Click += (s, e) => lblEnd.Text = timers[index].End().ToString();

    #endregion
    public class CTimers
    {
        private Stopwatch stopwatch;
        private long targetDelayMs = -1;

        public CTimers()
        {
            stopwatch = new Stopwatch();
        }

        public void Start(long delayMilliseconds = -1)
        {
            targetDelayMs = delayMilliseconds;
            stopwatch.Restart();
        }

        public void Stop()
        {
            stopwatch.Stop();
            targetDelayMs = -1;
        }

        public bool End()
        {
            if (targetDelayMs < 0)
                return false;

            return stopwatch.ElapsedMilliseconds >= targetDelayMs;
        }


        public long ElapsedMilliseconds()
        {
            return stopwatch.ElapsedMilliseconds;
        }

        public string ElapsedTimestamp()
        {
            TimeSpan elapsed = stopwatch.Elapsed;
            DateTime baseTime = new DateTime(1, 1, 1).Add(elapsed);
            return baseTime.ToString("HH:mm:ss.fff");
        }

        public void Delay(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }

        public string GetCurrentFullTimestamp()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }

        public string GetCurrentShortTimestamp()
        {
            return DateTime.Now.ToString("HH:mm:ss.fff");
        }

    }
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
