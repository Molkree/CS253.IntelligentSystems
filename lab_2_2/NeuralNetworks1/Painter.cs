using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNetworks1
{
    class Painter
    {
        Pen pen = Pens.Black;

        // отклонение от цетра по x и y
        int dx = 10;
        int dy = 10;


        int min_size = 10;


        //  Координаты текущей точки на канве
        int x, y;

        public Painter()
        {
            //  Определяем текущую точку
            x = 0; y = 0;
        }

        /// <summary>
        /// Возвращает текущую точку в виде строки
        /// </summary>
        /// <returns>Координаты текущей точки</returns>
        public string curentPos()
        {
            return x.ToString() + ";" + y.ToString();
        }

        /// <summary>
        /// Перемещение текущей точки в точку с координатами x, y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MoveTo(int x, int y)
        {
            this.x = x; this.y = y;
        }

        /// <summary>
        /// Рисование линии на Image img темно-синим цветом из текущей точки 
        /// в точку с координатами x, y
        /// </summary>
        /// <param name="img"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Image LineTo(Image img, int x, int y)
        {
            //  Если нет изображения, то ничего не делать
            if (img == null) return null;

            try
            {
                //  Создаем новый объект Graphics
                Graphics g = Graphics.FromImage(img);
                //  Линия
                g.DrawLine(pen, this.x, this.y, x, y);
                //  Меняем координаты текущей точки
                this.x = x; this.y = y;
                //  Возвращаем измененное изображение
                return img;
            }
            catch
            {
                MessageBox.Show("Непредвиденная ошибка");
            };
            return null;
        }

        public Image GenerateImage(Image img)
        {
            if (img == null) return null;

            Graphics g = Graphics.FromImage(img);

            Random rand = new Random();

            int h = img.Height;
            int w = img.Width;

            // центр фигуры
            int cx = w / 2 + rand.Next(-dx, dx);
            int cy = h / 2 + rand.Next(-dy, dy);

            int max_size_x = w - cx;
            int max_size_y = h - cy;


            int type = rand.Next(0, 4);

            switch (type)
            {
                case 0: // синусоида
                    {
                        // длина
                        int size1 = rand.Next(min_size, max_size_x) / 2;
                        // высота
                        int size2 = rand.Next(min_size, max_size_y) / 2;


                        double scale_x = rand.NextDouble() * 7;

                        List<Point> pts = new List<Point>();

                        for (int xi = cx - size1; xi < cx + size1; ++xi)
                            pts.Add(new Point(xi, cy + (int)(Math.Sin(xi * scale_x) * size2)));

                        g.DrawLines(pen, pts.ToArray());

                        break;
                    }
                case 1: // прямоугольник
                    {
                        // ширина
                        int size1 = rand.Next(min_size, max_size_x);
                        // высота
                        int size2 = rand.Next(min_size, max_size_y);
                        // левый верхний угол
                        int x0 = cx - size1 / 2;
                        int y0 = cy - size2 / 2;

                        g.DrawRectangle(pen, x0, y0, size1, size2);
                        break;
                    }
                case 2: // треугольник
                    {
                        // длина горизонтальной линии
                        int size1 = rand.Next(min_size, max_size_x);
                        // высота
                        int size2 = rand.Next(min_size, max_size_y);

                        int x0 = cx - size1 / 2;
                        int y0 = cy - size2 / 2;

                        // x-координата третьей точки
                        int x2 = rand.Next(x0, x0 + size1);

                        Point p0 = new Point(x0, y0);
                        Point p1 = new Point(x0 + size1, y0);
                        Point p2 = new Point(x2, y0 + size2);


                        g.DrawLine(pen, p0, p1);
                        g.DrawLine(pen, p0, p2);
                        g.DrawLine(pen, p1, p2);

                        break;
                    }
                case 3: // окружность
                    {
                        int rad = rand.Next(min_size, Math.Min(max_size_x, max_size_y));
                        int x0 = cx - rad;
                        int y0 = cy - rad;

                        g.DrawEllipse(pen, x0, y0, rad * 2, rad * 2);

                        break;
                    }
            }

            return img;
        }
    }
}
