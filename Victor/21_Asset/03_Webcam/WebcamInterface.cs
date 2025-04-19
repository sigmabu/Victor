using System.Collections.Generic;
using System.Windows.Forms;

namespace Victor
{
    public class WebcamInterface
    {
        private List<WebcamDevice> devices = new List<WebcamDevice>();

        public void InitializeDevices(List<PictureBox> boxes)
        {
            for (int i = 0; i < boxes.Count; i++)
            {
                var device = new WebcamDevice(i, boxes[i]);
                devices.Add(device);
            }
        }

        public void StartAll()
        {
            foreach (var device in devices)
            {
                device.Start();
            }
        }

        public void StopAll()
        {
            foreach (var device in devices)
            {
                device.Stop();
            }
        }
    }
}

