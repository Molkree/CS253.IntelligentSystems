using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks1
{
    enum Type { Sine = 0, Rect, Triangle, Circle };

    class Network
    {
        const int epoches = 100;
        const double learning_rate = 0.7;
        const int samples_cnt = 200;

        const double eps = 0.001;

        const int Img_size = 200;
        const int Input_size = Img_size + Img_size;
        const int Hidden_layer1_size = 100;
        const int Hidden_layer2_size = 50;
        const int Out_layer_size = 4;

        private double[] Weights0 = new double[Input_size * Hidden_layer1_size];
        private double[] Weights1 = new double[Hidden_layer1_size * Hidden_layer2_size];
        private double[] Weights2 = new double[Hidden_layer2_size * Out_layer_size];

        private double[] Hidden_layer_1 = new double[Hidden_layer1_size];
        private double[] Hidden_layer_2 = new double[Hidden_layer2_size];
        private double[] Out_layer = new double[Out_layer_size];


        public Network()
        {
            // initialize weights
            Random rand = new Random();
            for (int i = 0; i < Math.Max(Weights1.Length, Weights2.Length); ++i)
            {
                if (i < Weights1.Length)
                {
                    Weights1[i] = rand.NextDouble();
                }
                if (i < Weights2.Length)
                {
                    Weights2[i] = rand.NextDouble();
                }
            }
            
            for (int i = 0; i < Weights0.Length; ++i)
            {
                if (rand.Next(100) < 40)
                {
                    Weights0[i] = 0;
                }
                else Weights0[i] = 1;
            }

        }

        /// <summary>
        /// Sigmoid in [-1, 1]
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private double Sigmoid(double x)
        {
            return 2 / (1 + Math.Exp(-2 * x)) - 1;
        }

        public double[] Preprocess(Image image)
        {
            Bitmap img = image as Bitmap;

            double[] res = new double[400];
            int sz = 200;

            for (int i = 0; i < 400; ++i)
                res[i] = 0;

            // sum in rows and cols
            for (int i = 0; i < img.Height; ++i)
            {
                for (int j = 0; j < img.Width; ++j)
                {
                    Color c = img.GetPixel(j, i);
                    if (c.R == 0 && c.G == 0 && c.B == 0)
                    {
                        // row
                        ++res[i];
                        // col
                        ++res[sz + j];

                    }
                }
            }

            for (int i = 0; i < res.Length; ++i)
                res[i] /= 200.0;

            return res;
        }

        public void Train()
        {
            Painter p = new Painter();
            for (int i = 0; i < samples_cnt; ++i)
            {
                Image img = new Bitmap(200, 200);
                int t = i % 4;
                img = p.GenerateImage(img, t);
                TrainOne(Preprocess(img), (Type)t);
            }
        }

        private void TrainOne(double[] data, Type label)
        {
            var t = Predict(data);
            if (t != label)
            {
                for (int e = 0; e < epoches; ++e)
                {
                    // count dest vector
                    double[] dest = new double[Out_layer_size];

                    // error vector for output layer
                    double[] err_out = new double[Out_layer_size];

                    // diffenerence between output and desired results 
                    double d = Out_layer[(int)t] - Out_layer[(int)label];

                    for (int i = 0; i < Out_layer_size; ++i)
                    {
                        if (Out_layer[i] > Out_layer[(int)label])
                        {
                            dest[i] = Out_layer[i] - d;
                            err_out[i] = -d;
                        }
                        else
                        {
                            dest[i] = Out_layer[i];
                            err_out[i] = 0;
                        }
                    }
                    dest[(int)label] += d;
                    err_out[(int)label] = d;


                    // Out layer --> Hidden layer 2

                    // vector for hidden layer 2
                    double[] err_2 = new double[Hidden_layer2_size];

                    for (int i = 0; i < Hidden_layer2_size; ++i)
                    {
                        err_2[i] = 0;
                        for (int j = 0; j < Out_layer_size; ++j)
                        {
                            err_2[i] += err_out[j] * Weights2[j];

                            int w_index = i * Out_layer_size + j;
                            double dw = Out_layer[j] * Weights2[w_index] * err_out[j] * learning_rate;
                            Weights2[w_index] += dw;
                        }
                    }

                    // Hidden layer 2 ---> Hidden layer 1
                    for (int i = 0; i < Hidden_layer1_size; ++i)
                    {
                        for (int j = 0; j < Hidden_layer2_size; ++j)
                        {
                            int w_index = i * Hidden_layer2_size + j;
                            double dw = Hidden_layer_2[j] * Weights1[w_index] * err_2[j] * learning_rate;
                            Weights1[w_index] += dw;
                        }
                    }
                    t = Predict(data);
                }
            }

        }

        public Type Predict(double[] data)
        {
            // Input layer --- (Weights0) ---> Hidden layer 1

            double max = double.MinValue;

            for (int i = 0; i < Hidden_layer1_size; ++i)
            {
                Hidden_layer_1[i] = 0;

                for (int j = 0; j < data.Length; ++j)
                {
                    Hidden_layer_1[i] += data[j] * Weights0[j * Hidden_layer1_size + i];
                }
                if (Hidden_layer_1[i] > max)
                    max = Hidden_layer_1[i];
            }
            // normalize Hidden layer 1
            if (max > 1)
            {
                for (int i = 0; i < Hidden_layer1_size; ++i)
                {
                    Hidden_layer_1[i] /= max;
                    Hidden_layer_1[i] = Sigmoid(Hidden_layer_1[i]);

                }
            }

            // Hidden layer 1 --- (Weights 1) ---> Hidden layer 2 
            max = double.MinValue;
            for (int j = 0; j < Hidden_layer2_size; ++j)                
            {
                Hidden_layer_2[j] = 0;

                // sum of inputs*weights
                for (int i = 0; i < Hidden_layer1_size; ++i)
                {
                    Hidden_layer_2[j] += Hidden_layer_1[i] * Weights1[i * Hidden_layer2_size + j];
                }

                if (Hidden_layer_2[j] > max)
                    max = Hidden_layer_2[j];
              
            }

            // normalize Hidden layer 2
            if (max > 1)
            {
                for (int i = 0; i < Hidden_layer2_size; ++i)
                {
                    Hidden_layer_2[i] /= max;
                    Hidden_layer_2[i] = Sigmoid(Hidden_layer_2[i]);

                }
            }

            // Hidden layer 2 --- (Weights 2) ---> Out layer
            max = double.MinValue;
            for (int j = 0; j < Out_layer_size; ++j)
            {
                Out_layer[j] = 0;

                for (int i = 0; i < Hidden_layer2_size; ++i)
                {
                    Out_layer[j] += Hidden_layer_2[i] * Weights2[i * Out_layer_size + j];
                }

                if (Out_layer[j] > max)
                    max = Out_layer[j];

            }

            // normalize Out layer
            if (max > 1)
            {
                for (int i = 0; i < Out_layer_size; ++i)
                {
                    Out_layer[i] /= max;
                    Out_layer[i] = Sigmoid(Out_layer[i]);

                }
            }

            // find max value in Out_layer
            double maxv = double.MinValue;
            int ind = -1;
            for (int i = 0; i < Out_layer_size; ++i)
                if (Out_layer[i] > maxv)
                {
                    maxv = Out_layer[i];
                    ind = i;
                }
            

            return (Type)ind;
        }
    }
}
