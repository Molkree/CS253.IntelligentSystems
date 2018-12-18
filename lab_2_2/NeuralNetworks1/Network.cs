using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace NeuralNetworks1
{
    enum Type { Sine = 0, Rect, Triangle, Circle };

    class Network
    {
        const double min_rand = -0.5;
        const double max_rand = 0.5;



        const int epoches = 10;
        const double learning_rate = 0.1;
        const int samples_cnt = 100;

        const double eps = 0.001;

        const int Img_size = 200;
        const int Input_size = Img_size + Img_size;
        const int Hidden_layer1_size = 800;
        const int Hidden_layer2_size = 800;
        const int Out_layer_size = 4;

        private double[] Weights0 = new double[Input_size * Hidden_layer1_size];
        private double[] Weights1 = new double[Hidden_layer1_size * Hidden_layer2_size];
        private double[] Weights2 = new double[Hidden_layer2_size * Out_layer_size];

        private double[] Input_layer = new double[Input_size];

        private double[] Hidden_layer_1 = new double[Hidden_layer1_size];
        //private double[] H1_input = new double[Hidden_layer1_size];
        
        private double[] Hidden_layer_2 = new double[Hidden_layer2_size];
        //private double[] H2_input = new double[Hidden_layer2_size];

        private double[] Out_layer = new double[Out_layer_size];
        //private double[] Out_layer_input = new double[Out_layer_size];



        private List<bool> correct = new List<bool>();
        private int iter_cnt = 0;

        public Network()
        {
            // initialize weights
            Random rand = new Random();
            for (int i = 0; i < Math.Max(Weights1.Length, Weights2.Length); ++i)
            {
                if (i < Weights1.Length)
                {
                    Weights1[i] = min_rand + rand.NextDouble() * (max_rand - min_rand);
                }
                if (i < Weights2.Length)
                {
                    Weights2[i] = min_rand + rand.NextDouble() * (max_rand - min_rand);
                }
            }
            
            for (int i = 0; i < Weights0.Length; ++i)
            {
                if (rand.Next(100) < 10)
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
        private double Activation(double x)
        {
            return 1 / (1 + Math.Exp(-x)); // sigmoid
            //return x; // identity
            //return (x > 0) ? x : 0; // ReLU
        }

        private double Derivative(double x)
        {
            // sigmoid
            return x * (1 - x);

            // relu
            //if (x <= 0)
            //    return 0;
            //else return 1;
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

        public void Train(bool load = false)
        {
            if (load)
            {
                Load_weights("relu_notrand_weights0.txt", "relu_notrand_weights1.txt", "relu_notrand_weights2.txt");
            }
            else
            {
                Painter p = new Painter();
                while (true)
                {
                    Random rand = new Random();
                    Image img = new Bitmap(200, 200);
                    //int t = i % 4;
                    int t = rand.Next() % 4;
                    img = p.GenerateImage(img, t);
                    //img.Save("img" + iter_cnt.ToString() + ".png");
                    Debug.WriteLine("Label: " + t.ToString());
                    TrainOne(Preprocess(img), (Type)t);
                    Debug.WriteLine("Complete");
                    ++iter_cnt;
                    if (correct.Count > 100)
                    {
                        var t1 = check_last_correct();
                        Debug.WriteLine("Recall: " + t1);
                        if (t1 > 0.4)
                            break;
                    }
                }
                //Save_weights();
            }
        }

        private void Save_weights()
        {
            string lines = "";
            for (int i = 0; i < Weights0.Length; ++i)
                lines += Weights0[i] + " ";

            System.IO.File.WriteAllText(@"weights0.txt", lines);

            lines = "";
            for (int i = 0; i < Weights1.Length; ++i)
                lines += Weights1[i] + " ";

            System.IO.File.WriteAllText(@"weights1.txt", lines);

            lines = "";
            for (int i = 0; i < Weights2.Length; ++i)
                lines += Weights2[i] + " ";

            System.IO.File.WriteAllText(@"weights2.txt", lines);
        }

        private void Load_weights(string w0, string w1, string w2)
        {
            string text = System.IO.File.ReadAllText(w0);
            string[] w = text.Split(' ');
            if (w.Length - 1 != Weights0.Length)
                System.Console.WriteLine("Wrong w0 length!");

            for (int i = 0; i < w.Length - 1; ++i)
                Weights0[i] = double.Parse(w[i]);

            text = System.IO.File.ReadAllText(w1);
            w = text.Split(' ');
            if (w.Length - 1 != Weights1.Length)
                System.Console.WriteLine("Wrong w1 length!");
            for (int i = 0; i < w.Length - 1; ++i)
                Weights1[i] = double.Parse(w[i]);


            text = System.IO.File.ReadAllText(w2);
            w = text.Split(' ');
            if (w.Length - 1 != Weights2.Length)
                System.Console.WriteLine("Wrong w2 length!");
            for (int i = 0; i < w.Length - 1; ++i)
                Weights2[i] = double.Parse(w[i]);
        }

        private double check_last_correct()
        {
            double res = 0;
            for (int i = correct.Count - 100; i < correct.Count; ++i)
            {
                if (correct[i])
                    ++res;
            }
            return res / 100.0;
        }
        
        private void TrainOne(double[] data, Type label)
        {
            var t = Predict(data);
            if (t == label)
                correct.Add(true);
            else
            {
                correct.Add(false);
                Debug.WriteLine("Start backprop");
            }
            if (t != label)
            {
                // error vector for output layer
                double[] err_out = new double[Out_layer_size];

                // diffenerence between output and desired results 
                double d = Out_layer[(int)t] - Out_layer[(int)label];
                if (Math.Abs(d) < 1e-2)
                    d += 0.1;
                for (int i = 0; i < Out_layer_size; ++i)
                {
                    if (i == (int)label)
                        err_out[i] = d;
                    //if (Math.Abs(Out_layer[i] - Out_layer[(int)label]) < 1e-2 || Out_layer[i] > Out_layer[(int)label])
                    else if (Out_layer[i] > Out_layer[(int)label])
                        err_out[i] = Out_layer[(int)label] - Out_layer[i];          
                    else
                        err_out[i] = 0;
                    
                }
                

                // Out layer --> Hidden layer 2

                // vector for hidden layer 2
                double[] err_2 = new double[Hidden_layer2_size];

                for (int i = 0; i < Hidden_layer2_size; ++i)
                {
                    err_2[i] = 0;
                    for (int j = 0; j < Out_layer_size; ++j)
                    {
                        int w_index = i * Out_layer_size + j;
                        err_2[i] += err_out[j] * Weights2[w_index];

                        // OLD VERSION
                        // count Weights2
                        
                        // Wji += alpha (== learning_rate) * aj * Erri [* g'(input_sumi) - for output layer]

                        //double dw = Out_layer[j] * err_out[j] * learning_rate;

                        //double dw = Hidden_layer_2[i] * err_out[j] * learning_rate * Derivative(Out_layer[j]);

                        //Weights2[w_index] += dw;


                        // QUESTION: before or after recount of weights?

                        // count error for hidden layer 2
                        //err_2[i] += err_out[j] * Weights2[i * Out_layer_size + j]; // sum(errj * wij) * g'(inputsumi)
                        
                       
                    }
                    //err_2[i] *= Derivative(Hidden_layer_2[i]);
                }
                double[] err_1 = new double[Hidden_layer1_size];
                // Hidden layer 2 ---> Hidden layer 1
                for (int i = 0; i < Hidden_layer1_size; ++i)
                {
                    err_1[i] = 0;
                    for (int j = 0; j < Hidden_layer2_size; ++j)
                    {
                        int w_index = i * Hidden_layer2_size + j;
                        err_1[i] += err_2[j] * Weights1[w_index];
                    }
                }

                // change weights
                // Input --- (W0) ---> Hidden1
                for (int i = 0; i < Input_size; ++i)
                {
                    for (int j = 0; j < Hidden_layer1_size; ++j)
                    {
                        int w_index = i * Hidden_layer1_size + j;
                        if (Weights0[w_index] != 0)
                        {
                            double next_output = Hidden_layer_1[j];
                            double dw = learning_rate * err_1[j] * Input_layer[i] * (next_output * (1 - next_output));
                            Weights0[w_index] += dw;
                        }
                    }
                }

                // Hidden1 --- (W1) --- Hidden2
                for (int i = 0; i  < Hidden_layer1_size; ++i)
                {
                    for (int j = 0; j < Hidden_layer2_size; ++j)
                    {
                        int w_index = i * Hidden_layer2_size + j;
                        double next_out = Hidden_layer_2[j];
                        double dw = learning_rate * err_2[j] * Hidden_layer_1[i] * (next_out * (1 - next_out));
                        Weights1[w_index] += dw;
                    }
                }

                // Hidden2 --- (W2) --- Out
                for (int i = 0; i < Hidden_layer2_size; ++i)
                {
                    for (int j = 0; j < Out_layer_size; ++j)
                    {
                        int w_index = i * Out_layer_size + j;
                        double next_out = Out_layer[j];
                        double dw = learning_rate * err_out[j] * Hidden_layer_2[i] * (next_out * (1 - next_out));
                        Weights2[w_index] += dw;
                    }
                }

                Debug.WriteLine("Before predict " + Out_layer[0].ToString() + " " + Out_layer[1].ToString()
                                + " " + Out_layer[2].ToString() + " " + Out_layer[3].ToString());
                t = Predict(data);
                Debug.WriteLine("After predict " + Out_layer[0].ToString() + " " + Out_layer[1].ToString()
                                + " " + Out_layer[2].ToString() + " " + Out_layer[3].ToString());
                //if (t == label)
                //    correct.Add(true);
                //else correct.Add(false);
            }

        }

        public Type Predict(double[] data)
        {
           
            data.CopyTo(Input_layer, 0);

            double max = double.MinValue;

            // Input layer --- (Weights0) ---> Hidden layer 1

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
            for (int i = 0; i < Hidden_layer1_size; ++i)
            { 
                if (max > 1)
                {
                    Hidden_layer_1[i] /= max;
            
                }
                
                Hidden_layer_1[i] = Activation(Hidden_layer_1[i]);

            }

            // Hidden layer 1 --- (Weights 1) ---> Hidden layer 2 
            max = double.MinValue;
            for (int j = 0; j < Hidden_layer2_size; ++j)                
            {
                Hidden_layer_2[j] = 0;

                // sum of inputs*weights
                for (int i = 0; i < Hidden_layer1_size; ++i)
                {
                    Hidden_layer_2[j] += Activation(Hidden_layer_1[i]) * Weights1[i * Hidden_layer2_size + j];
                }

                if (Hidden_layer_2[j] > max)
                    max = Hidden_layer_2[j];
                
            }

            // normalize Hidden layer 2
            for (int i = 0; i < Hidden_layer2_size; ++i)
            {
                if (max > 1)
                {
                    Hidden_layer_2[i] /= max;
                  
                }
               
                Hidden_layer_2[i] = Activation(Hidden_layer_2[i]);

            }

            // Hidden layer 2 --- (Weights 2) ---> Out layer
            max = double.MinValue;
            for (int j = 0; j < Out_layer_size; ++j)
            {
                Out_layer[j] = 0;

                for (int i = 0; i < Hidden_layer2_size; ++i)
                {
                    Out_layer[j] += Activation(Hidden_layer_2[i]) * Weights2[i * Out_layer_size + j];
                }

                if (Out_layer[j] > max)
                    max = Out_layer[j];
                

            }

            // normalize Out layer
            for (int i = 0; i < Out_layer_size; ++i)
            {
                if (max > 1)
                    Out_layer[i] /= max;

                //Out_layer[i] = Activation(Out_layer[i]);
            }

            // find max value in Out_layer
            double maxv = double.MinValue;
            int ind = -1;
            for (int i = 0; i < Out_layer_size; ++i)
            {
                if (Out_layer[i] > maxv)
                {
                    maxv = Out_layer[i];
                    ind = i;
                }
            }

            return (Type)ind;
        }
    }
}
