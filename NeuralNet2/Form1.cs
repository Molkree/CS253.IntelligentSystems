using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

using AForge.Video;
using AForge.Video.DirectShow;

namespace NeuralNet2
{
    public partial class Form1 : Form
    {
        private IVideoSource videoSource;
        private FilterInfoCollection videoDevicesList;
        private Camera processor = new Camera();

        public Form1()
        {
            InitializeComponent();

            videoDevicesList = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo videoDevice in videoDevicesList)
            {
                cmbVideoSource.Items.Add(videoDevice.Name);
            }
            if (cmbVideoSource.Items.Count > 0)
            {
                cmbVideoSource.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Камера не найдена!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            processor.ProcessImage((Bitmap)eventArgs.Frame.Clone());

            if (processor.original != null)
                pictureBox1.Image = processor.original;

            if (processor.number != null)
                pictureBox2.Image = processor.number;
        }

        void CloseOpenVideoSource()
        {
            if (videoSource == null)
            {
                videoSource = new VideoCaptureDevice(videoDevicesList[cmbVideoSource.SelectedIndex].MonikerString);
                videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
                videoSource.Start();
                btnStart.Text = "Stop";
            }
            else
            {
                videoSource.SignalToStop();
                if (videoSource != null && videoSource.IsRunning && pictureBox1.Image != null)
                {
                    //pictureBox1.Image.Dispose();
                }
                videoSource = null;
                btnStart.Text = "Start";

            }

        }

        // Чтобы вебка не падала в обморок при неожиданном закрытии окна
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnStart.Text == "Stop")
                videoSource.SignalToStop();
            if (videoSource != null && videoSource.IsRunning && pictureBox1.Image != null)
            {
                //pictureBox1.Image.Dispose();
            }
            videoSource = null;

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            CloseOpenVideoSource();
        }
    }


}
