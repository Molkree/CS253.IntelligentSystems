﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNetworks1
{
    public partial class Form1 : Form
    {
        Painter p;
        Network net;

        public Form1()
        {
            InitializeComponent();
            p = new Painter();
            net = new Network();
            comboBox_label.SelectedIndex = 4;
        }

        private void button_draw_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            Graphics g = Graphics.FromImage(pictureBox1.Image);

            //g.FillRectangle(new SolidBrush(Color.White), 0, 0, pictureBox1.Width, pictureBox1.Height);
            g.Clear(Color.White);
            p.MoveTo(0, 0);
        }

        private void button_gen_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            p.GenerateImage(pictureBox1.Image);
        }

        private void button_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();

            openDlg.InitialDirectory = Environment.CurrentDirectory;
            //openDlg.Filter = "Изображение в формате PNG (*.png)|*.png";
            //  saveFileDialog1.FilterIndex = filterIndex;
            openDlg.RestoreDirectory = true;
            openDlg.Title = "Открыть изображение как...";
            if (openDlg.ShowDialog() == DialogResult.OK)
                try
                {
                    pictureBox1.Image = new Bitmap(openDlg.FileName);
                }
                catch
                {
                    MessageBox.Show("Не могу открыть изображение.");
                }
            p.MoveTo(0, 0);
            return;
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            //  Если нет изображения, то и сохранять нечего, выходим
            if (pictureBox1.Image == null)
                return;

            //  Явно определяем диалог для сохранения изображения
            SaveFileDialog saveDlg = new SaveFileDialog();

            //  Открываем файлы из папки приложения
            saveDlg.InitialDirectory = Environment.CurrentDirectory;

            //  В качестве фильтра используем строку, определенную в файле 
            //  ресурсов. Использовать ее можно так:
            //saveDlg.Filter = Graphic1.Properties.Resources.DlgFilterString;

            //  По умолчанию работаем с bmp, поэтому устанавливаем соответствующее
            //  значение активного фильтра
            saveDlg.FilterIndex = 2;

            //  После закрытия диалога восстанавливаем исходную текущую директорию
            saveDlg.RestoreDirectory = true;

            //  Определяем заголовок диалога
            saveDlg.Title = "Сохранить изображение как...";

            //  Показываем диалог, и если сохранение подтверждено, сохраняем файл
            if (saveDlg.ShowDialog() == DialogResult.OK)
                pictureBox1.Image.Save(saveDlg.FileName);

            return;
        }

        private void button_train_Click(object sender, EventArgs e)
        {
            /*if (pictureBox1.Image is null)
            {
                MessageBox.Show("Нет изображения", "Выберите / сгенерируйте / нарисуйте изображение для сети.", MessageBoxButtons.OK);
            }
            else if (comboBox_label.SelectedIndex == 4)
            {
                MessageBox.Show("Не выбран ответ", "Сети для тренировки нужен правильный ответ.\nВы ведь хороший учитель, правда?", MessageBoxButtons.OK);
            }
            else
            {
                net.Train(Preprocess(pictureBox1.Image), (Type)comboBox_label.SelectedIndex);
            }*/
            label_ready.Text = "...";
            net.Train();
            label_ready.Text = "ready!";
        }

        private void button_predict_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image is null)
            {
                MessageBox.Show("Выберите / сгенерируйте / нарисуйте изображение для сети.", "Нет изображения", MessageBoxButtons.OK);
            }
            else
            {
                Type t = net.Predict(net.Preprocess(pictureBox1.Image));
                comboBox_label.SelectedIndex = (int)t;
            }
        }

        

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //  При нажатии клавиши просто переходим в эту точку, чтобы 
            //  дальше рисовать кривую из этой точки
            p.MoveTo(e.X, e.Y);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                p.MoveTo(e.X, e.Y);
            if (e.Button == MouseButtons.Left)
                pictureBox1.Image = p.LineTo(pictureBox1.Image, e.X, e.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label_ready.Text = "...";
            net.Train(true);
            label_ready.Text = "ready!";
        }
    }
}
