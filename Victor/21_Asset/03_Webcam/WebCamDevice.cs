using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Victor
{
    public class WebcamDevice
    {
        private VideoCapture capture;
        private Thread captureThread;
        private bool isRunning = false;
        private PictureBox displayBox;
        private int deviceIndex;

        public WebcamDevice(int index, PictureBox box)
        {
            deviceIndex = index;
            displayBox = box;
        }

        public void Start()
        {
            if (isRunning) return;

            capture = new VideoCapture(deviceIndex);
            isRunning = true;

            captureThread = new Thread(() =>
            {
                using (Mat frame = new Mat())
                {
                    while (isRunning)
                    {
                        if (!capture.Read(frame)) continue;

                        Bitmap image = BitmapConverter.ToBitmap(frame);

                        displayBox.Invoke((MethodInvoker)(() =>
                        {
                            displayBox.Image?.Dispose();
                            displayBox.Image = new Bitmap(image);
                        }));

                        Thread.Sleep(30);
                    }
                }
            });
            captureThread.IsBackground = true;
            captureThread.Start();
        }

        public void Stop()
        {
            isRunning = false;
            capture?.Release();
        }
    }
}

