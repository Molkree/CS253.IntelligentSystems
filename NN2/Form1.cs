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
//using System.Speech.Synthesis;
//using System.Speech.Recognition;
using Microsoft.Speech.Synthesis;
using Microsoft.Speech.Recognition;


namespace NN2
{
    public partial class Form1 : Form
    {
        static SpeechSynthesizer synth;
        static SpeechRecognitionEngine sre;
        static bool question_correct = false;
        static bool question_train = false;
        static bool question_number = false;
        
        static FilterInfoCollection videoDevicesList;
        static VideoCaptureDevice cVideoCaptureDevice;
        private Bitmap image;
        private Graphics g;
        private Network net;
        private List<double[]> list_dataset;
        private List<double[]> list_labels;

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

            System.Globalization.CultureInfo ci;
            ci = new System.Globalization.CultureInfo("ru-ru");
            sre = new SpeechRecognitionEngine(ci);

            synth.SetOutputToDefaultAudioDevice();
            sre.SetInputToDefaultAudioDevice();
            sre.SpeechRecognized += Sre_SpeechRecognized;

            Choices PredictCommands = new Choices();
            PredictCommands.Add("Что это");
            PredictCommands.Add("Неправильно");
            PredictCommands.Add("Нет");
            PredictCommands.Add("Да");
            PredictCommands.Add("Запомни");
            PredictCommands.Add("Не надо");
            PredictCommands.Add("Правильно");
            PredictCommands.Add("Тренируйся");
            PredictCommands.Add("Смотри");

            PredictCommands.Add("Выход");

            PredictCommands.Add("Глупая");
            PredictCommands.Add("Молодец");
            PredictCommands.Add("Замечательно");
            PredictCommands.Add("Такс");


            PredictCommands.Add("Ноль");
            PredictCommands.Add("Один");
            PredictCommands.Add("Два");
            PredictCommands.Add("Три");
            PredictCommands.Add("Четыре");
            PredictCommands.Add("Пять");
            PredictCommands.Add("Шесть");
            PredictCommands.Add("Семь");
            PredictCommands.Add("Восемь");
            PredictCommands.Add("Девять");


            
            GrammarBuilder gb_Predict = new GrammarBuilder();
            gb_Predict.Append(PredictCommands);

            Grammar g_Predict = new Grammar(gb_Predict);
            sre.LoadGrammarAsync(g_Predict);

            sre.RecognizeAsync(RecognizeMode.Multiple);

        }

        private void Sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string txt = e.Result.Text;

            if (txt.IndexOf("Выход") >= 0)
            {
                synth.Speak("До свиданья");
                this.Close();
            }
            if (txt.IndexOf("Что это") >= 0)
            {
                button_predict_Click(this, new EventArgs());
            }
            if (txt.IndexOf("Тренируйся") >= 0)
            {
                if (list_dataset != null)
                {
                    label_predict.Text = "Начинаю тренировку";
                    synth.Speak("Начинаю тренировку");
                    net.Train(list_dataset.ToArray(), list_labels.ToArray());
                    label_predict.Text = "Готово";
                    synth.Speak("Тренировка завершена");
                }
            }
            if (txt.IndexOf("Смотри") >= 0)
            {
                button_catch_Click(this, new EventArgs());
            }

            // неправильно распознала
            if (question_correct && (txt.IndexOf("Неправильно") >= 0 || txt.IndexOf("Нет") >= 0))
            {
                label_predict.Text = "Какая жалость. Мне запомнить этот образец?";
                synth.Speak("Какая жалость. Мне запомнить этот образец?");
                question_correct = false;
                question_train = true;
            }
            // правильно распознала
            if (question_correct && (txt.IndexOf("Правильно") >= 0 || txt.IndexOf("Да") >= 0))
            {
                label_predict.Text = "Ура, я что-то понимаю в этой жизни!";
                synth.Speak("Ура, я что-то понимаю в этой жизни!");
                question_correct = false;
            }

            // надо запомнить
            if (question_train && txt.IndexOf("Запомни") >= 0)
            {
                label_predict.Text = "Что это за цифра?";
                synth.Speak("Что это за цифра?");
                question_number = true;
                question_train = false;
            }

            //не надо запоминать
            if (question_train && txt.IndexOf("Не надо") >= 0)
            {
                label_predict.Text = "Как скажете.";
                synth.Speak("Как скажете");
                question_train = false;
            }

            if (question_number)
            {
                int correct_class = -1;
                if (txt.IndexOf("Ноль") >= 0)
                {
                    correct_class = 0;
                }
                if (txt.IndexOf("Один") >= 0)
                {
                    correct_class = 1;
                }
                if (txt.IndexOf("Два") >= 0)
                {
                    correct_class = 2;
                }
                if (txt.IndexOf("Три") >= 0)
                {
                    correct_class = 3;
                }
                if (txt.IndexOf("Четыре") >= 0)
                {
                    correct_class = 4;
                }
                if (txt.IndexOf("Пять") >= 0)
                {
                    correct_class = 5;
                }
                if (txt.IndexOf("Шесть") >= 0)
                {
                    correct_class = 6;
                }
                if (txt.IndexOf("Семь") >= 0)
                {
                    correct_class = 7;
                }
                if (txt.IndexOf("Восемь") >= 0)
                {
                    correct_class = 8;
                }
                if (txt.IndexOf("Девять") >= 0)
                {
                    correct_class = 9;
                }

                if (correct_class != -1)
                {
                    question_number = false;
                    synth.Speak("Хорошо, я запомню, что это цифра " + correct_class.ToString());
                    label_predict.Text = "Тренировка";
                    synth.Speak("Начинаю учить");
                    cVideoCaptureDevice.SignalToStop();
                    net.Train_more(pictureBox3.Image as Bitmap, correct_class);
                    label_predict.Text = "Готово";
                    synth.Speak("Я снова с вами");
                    cVideoCaptureDevice.Start();
                }
                else
                {
                    synth.Speak("Я не услышала. Повторите, пожалуйста.");
                }
            }


            // фичи
            if (txt.IndexOf("Глупая") >= 0)
            {
                synth.Speak("Не надо так говорить, а то возьму и обижусь. Так о себе говорить могу только я");
            }
            if (txt.IndexOf("Молодец") >= 0 || txt.IndexOf("Замечательно") >= 0)
            {
                synth.Speak("Ой, спасибо. Засмущали");
            }
            if (txt.IndexOf("Такс") >= 0)
            {
                synth.Rate = 2;
                synth.Speak("Да-да?");
                synth.Rate = 1;
                synth.Speak("Я слушаю");

            }


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
            synth.Speak("Я угадала?");
            question_correct = true;
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
                    synth.Speak("Готова к работе");
                    synth.Speak("Но предупреждаю сразу, я не очень умная.");
                }
                catch
                {
                    MessageBox.Show("Невозможно загрузить.");
                    synth.Speak("Хьюстон, у нас проблема. Не удалось загрузить сеть.");
                }
        }

        private void button_train_Click(object sender, EventArgs e)
        {
            cVideoCaptureDevice.SignalToStop();
            Make_training_dataset();
            synth.Speak("Начинаю тренировку");
            label_predict.Text = "Тренировка...";
            net.Train(list_dataset.ToArray(), list_labels.ToArray());
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
        public void Make_training_dataset(string path = "")
        {
            list_dataset = new List<double[]>();
            list_labels = new List<double[]>();

            FolderBrowserDialog openDlg = new FolderBrowserDialog();
            openDlg.SelectedPath = Environment.CurrentDirectory;
            //OpenFileDialog openDlg = new OpenFileDialog();

            //openDlg.InitialDirectory = Environment.CurrentDirectory;
            //openDlg.RestoreDirectory = true;
            openDlg.Description = "Выберите папку с изображениями...";
            //path = "../../images";
            if (path == "")
            {
                if (openDlg.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(openDlg.SelectedPath))
                {
                    path = openDlg.SelectedPath;
                }
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
        }
    }
    
}
