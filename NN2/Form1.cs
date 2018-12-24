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
using System.IO;

using System.Speech;
using System.Speech.Synthesis;
using System.Speech.Recognition;

namespace NN2
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer synth;


        FilterInfoCollection videoDevicesList;
        VideoCaptureDevice cVideoCaptureDevice;
        Bitmap image;
        Graphics g;
        Network net;
        double[][] dataset;
        double[][] labels;

        const int classes = 10;

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
            net = new Network(28 * 28, classes);

            synth = new SpeechSynthesizer();
            synth.SetOutputToDefaultAudioDevice();

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
            ResizeBicubic scale_filter = new ResizeBicubic(pictureBox2.Width, pictureBox2.Height);
            
            image = net.Filter(input_image);
            
            pictureBox3.Image = image;
            pictureBox3.Refresh();
            
            Bitmap bigger_image = scale_filter.Apply(image);
            
            pictureBox2.Image = bigger_image;
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
            if (e.KeyData == Keys.C)
                button_catch_Click(sender, e);
        }

        private void button_predict_Click(object sender, EventArgs e)
        {
            if (pictureBox3.Image == null)
                return;
            int number = net.Predict(pictureBox3.Image as Bitmap);
            label_predict.Text = "Я думаю, это " + number.ToString() + ".";
            synth.Speak("Я думаю, это " + number.ToString());
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
                    synth.Speak("Хьюстон, у нас проблема. Не удалось загрузить сеть.");
                }

            synth.Speak("Готова к работе");
            synth.Speak("Но предупреждаю сразу, я не очень умная.");
        }

        private void button_train_Click(object sender, EventArgs e)
        {
            cVideoCaptureDevice.SignalToStop();
            Make_training_dataset();
            synth.Speak("Начинаю тренировку");
            label_predict.Text = "Тренировка...";
            net.Train(dataset, labels);
            label_predict.Text = "Готово!";
            cVideoCaptureDevice.Start();
            synth.Speak("Готова к работе");
            synth.Speak("Но предупреждаю сразу, я не очень умная.");

        }

        private void button_save_Click(object sender, EventArgs e)
        {
            //  Если нет изображения, то и сохранять нечего, выходим
            if (pictureBox3.Image == null)
                return;

            SaveFileDialog saveDlg = new SaveFileDialog();

            //  Открываем файлы из папки приложения
            saveDlg.InitialDirectory = Environment.CurrentDirectory;

            
            //  После закрытия диалога восстанавливаем исходную текущую директорию
            saveDlg.RestoreDirectory = true;

            //  Определяем заголовок диалога
            saveDlg.Title = "Сохранить изображение как...";

            //  Показываем диалог, и если сохранение подтверждено, сохраняем файл
            if (saveDlg.ShowDialog() == DialogResult.OK)
                pictureBox3.Image.Save(saveDlg.FileName);

            return;
        }

        private void button_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();

            openDlg.InitialDirectory = Environment.CurrentDirectory;
            openDlg.RestoreDirectory = true;
            openDlg.Title = "Открыть изображение как...";
            if (openDlg.ShowDialog() == DialogResult.OK)
                try
                {
                    pictureBox3.Image = new Bitmap(openDlg.FileName);
                    //ResizeBicubic scale_filter = new ResizeBicubic(pictureBox2.Width, pictureBox2.Height);
                    //pictureBox2.Image = scale_filter.Apply(pictureBox3.Image as Bitmap);
                }
                catch
                {
                    MessageBox.Show("Не могу открыть изображение.");
                }
            return;
        }

        public void Make_training_dataset()
        {
            List<double[]> list_dataset = new List<double[]>();
            List<double[]> list_labels = new List<double[]>();

            FolderBrowserDialog openDlg = new FolderBrowserDialog();
            openDlg.SelectedPath = Environment.CurrentDirectory;
            //OpenFileDialog openDlg = new OpenFileDialog();

            //openDlg.InitialDirectory = Environment.CurrentDirectory;
            //openDlg.RestoreDirectory = true;
            openDlg.Description = "Выберите папку с изображениями...";
            String path = "";
            if (openDlg.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(openDlg.SelectedPath))                
            {
                path = openDlg.SelectedPath;
            }

            if (path != "")
                foreach (string file in Directory.EnumerateFiles(path, "*.png"))
                {
                    Bitmap img = new Bitmap(file);
                    String name = System.IO.Path.GetFileName(file);
                    list_dataset.Add(net.Preprocess(img));
                    double[] lbl = new double[classes];
                    for (int i = 0; i < classes; ++i)
                        lbl[i] = 0;
                    switch (name[0])
                    {
                        case '0':
                            lbl[0] = 1;
                            break;
                        case '1':
                            lbl[1] = 1;
                            break;
                        case '2':
                            lbl[2] = 1;
                            break;
                        case '3':
                            lbl[3] = 1;
                            break;
                        case '4':
                            lbl[4] = 1;
                            break;
                        case '5':
                            lbl[5] = 1;
                            break;
                        case '6':
                            lbl[6] = 1;
                            break;
                        case '7':
                            lbl[7] = 1;
                            break;
                        case '8':
                            lbl[8] = 1;
                            break;
                        case '9':
                            lbl[9] = 1;
                            break;
                        default:
                            break;
                    }

                    list_labels.Add(lbl);
                }

            dataset = list_dataset.ToArray();
            labels = list_labels.ToArray();
        }
    }
    
}
