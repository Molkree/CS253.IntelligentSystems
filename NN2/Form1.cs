using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Accord.Video.DirectShow;
using Accord.Video;
using Accord.Imaging.Filters;

namespace NN2
{
    public partial class Form1 : Form
    {
        FilterInfoCollection videoDevicesList;
        VideoCaptureDevice cVideoCaptureDevice;
        Bitmap image;
        Graphics g;
        Network net;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            try
            {
                videoDevicesList = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                foreach (FilterInfo cFilterInfo in videoDevicesList)
                {
                    comboBox1.Items.Add(cFilterInfo.Name);
                }
                comboBox1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.ToString());
            }
            net = new Network(28 * 28, 500);
            

        }

        private void getFrame(object sender, NewFrameEventArgs eventArgs)
        {

            Bitmap BsourceImage = (Bitmap)eventArgs.Frame.Clone();
            ResizeBilinear scale_filter = new ResizeBilinear(pictureBox1.Width, pictureBox1.Height);
            BsourceImage = scale_filter.Apply(BsourceImage);
            pictureBox1.Image = BsourceImage;

            g = Graphics.FromImage(pictureBox1.Image);
            g.DrawRectangle(Pens.Red, new Rectangle(50, 50, 200, 200));

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cVideoCaptureDevice != null)
                cVideoCaptureDevice.SignalToStop();
        }

        private void button_catch_Click(object sender, EventArgs e)
        {
            Bitmap input_image = pictureBox1.Image as Bitmap;
            Grayscale gray_filter = new Grayscale(0.2125, 0.7154, 0.0721);
            BradleyLocalThresholding threshold_filter = new BradleyLocalThresholding();
            threshold_filter.PixelBrightnessDifferenceLimit = 0.1f;
            ResizeBicubic scale_filter = new ResizeBicubic(pictureBox2.Width, pictureBox2.Height);
            ResizeBicubic scale_small_filter = new ResizeBicubic(28, 28);
            Crop crop_filter = new Crop(new Rectangle(51, 51, 199, 199));
          
            image = gray_filter.Apply(input_image);
            image = crop_filter.Apply(image);
            image = threshold_filter.Apply(image);

            image = scale_small_filter.Apply(image);

            pictureBox3.Image = image;
            pictureBox3.Refresh();



            Bitmap bigger_bmp = scale_filter.Apply(image);
            
            pictureBox2.Image = bigger_bmp;
            pictureBox2.Refresh();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cVideoCaptureDevice = new VideoCaptureDevice(videoDevicesList[comboBox1.SelectedIndex].MonikerString);
            cVideoCaptureDevice.NewFrame += new NewFrameEventHandler(getFrame);
            cVideoCaptureDevice.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                button_catch_Click(sender, e);
        }

        private void button_predict_Click(object sender, EventArgs e)
        {
            int number = net.Predict(image);
            label_predict.Text = "It is " + number.ToString() + "!";
        }
        

        private void button_load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();

            openDlg.InitialDirectory = Environment.CurrentDirectory;
            openDlg.RestoreDirectory = true;
            openDlg.Title = "Загрузить данные сети";

          

            if (openDlg.ShowDialog() == DialogResult.OK)
                try
                {
                   net.Load_net(openDlg.FileName);
                }
                catch
                {
                    MessageBox.Show("Невозможно загрузить.");
                }
        }

        private void button_train_Click(object sender, EventArgs e)
        {
            label_predict.Text = "training...";
            net.Train();
            label_predict.Text = "Ready!";
        }
    }
    
}
