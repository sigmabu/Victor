using System;
using System.Diagnostics;
using System.Windows.Forms;

public class CTime
{
    private DateTime _target;

    private long SetTime;

    private long PreTime;

    private long CurTime;

    private Stopwatch stopwatch = new Stopwatch();

    private Stopwatch stopwatch01 = new Stopwatch();

    private int _setDelay = 0;

    public void Start(int msec)
    {
        _setDelay = msec;
        _target = DateTime.Now.Add(new TimeSpan(0, 0, 0, 0, _setDelay));
    }

    public bool End()
    {
        if (_target >= DateTime.Now)
        {
            return false;
        }

        return true;
    }

    public int GetSetTime()
    {
        return _setDelay;
    }

    public string TickTime_Stop()
    {
        stopwatch01.Stop();
        return stopwatch01.Elapsed.ToString("hh\\:mm\\:ss\\.f");
    }

    public string TickTime_Restart()
    {
        stopwatch01.Start();
        return stopwatch01.Elapsed.ToString("hh\\:mm\\:ss\\.f");
    }

    public string TickTime_Get()
    {
        return stopwatch01.Elapsed.ToString("hh\\:mm\\:ss\\.f");
    }

    public string TickTime_Start()
    {
        stopwatch01 = Stopwatch.StartNew();
        return stopwatch01.Elapsed.ToString("hh\\:mm\\:ss\\.f");
    }

    public long GetTickTime_ms()
    {
        return stopwatch.ElapsedTicks * 1000 / Stopwatch.Frequency;
    }

    public bool OnDelay(bool SeqInput, long _SetTime)
    {
        SetTime = _SetTime;
        return OnDelay(SeqInput);
    }

    private bool OnDelay(bool SeqInput)
    {
        bool result = false;
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
                PreTime = CurTime;
                result = true;
            }
            else
            {
                result = false;
            }
        }
        else
        {
            stopwatch = Stopwatch.StartNew();
            PreTime = GetTickTime_ms();
        }

        return result;
    }

    public DateTime Wait(int msec)
    {
        DateTime now = DateTime.Now;
        TimeSpan value = new TimeSpan(0, 0, 0, 0, msec);
        DateTime dateTime = now.Add(value);
        while (dateTime >= now)
        {
            Application.DoEvents();
            now = DateTime.Now;
        }

        return DateTime.Now;
    }
}