using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks1
{
    enum Type { Sine = 0, Rect, Triangle, Circle };

    class Network
    {
        const int epoches = 100;
        const double eps = 0.001;
        const double learning_rate = 0.01;
        

        const int Img_size = 200;
        const int Input_size = Img_size + Img_size;
        const int Hidden_layer1_size = 100;
        const int Hidden_layer2_size = 100;
        const int Out_layer_size = 4;


        private double[] Weights1 = new double[Input_size * Hidden_layer1_size];
        private double[] Weights2 = new double[Hidden_layer2_size * Hidden_layer2_size];

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

        public void Train(int[] data, Type label)
        {

        }

        public Type Predict(int[] data)
        {
            // Пока все нейроны входного слоя связаны со всеми нейронами 1-го скрытого
            for (int i = 0; i < Hidden_layer1_size; ++i)
            {
                Hidden_layer_1[i] = 0;

                for (int j = 0; j < data.Length; ++j)
                {
                    Hidden_layer_1[i] += data[j];
                }
            }

            // Hidden layer 1 --- (Weights 1) ---> Hidden layer 2 
            for (int j = 0; j < Hidden_layer2_size; ++j)                
            {
                Hidden_layer_2[j] = 0;

                // sum of inputs*weights
                for (int i = 0; i < Hidden_layer1_size; ++i)
                {
                    Hidden_layer_2[j] += Hidden_layer_1[i] * Weights1[i * Hidden_layer2_size + j];
                }
                // activation function
                Hidden_layer_2[j] = Sigmoid(Hidden_layer_2[j]);
            }

            // Hidden layer 2 --- (Weights 2) ---> Out layer
            for (int j = 0; j < Out_layer_size; ++j)
            {
                Out_layer[j] = 0;

                for (int i = 0; i < Hidden_layer2_size; ++i)
                {
                    Out_layer[j] += Hidden_layer_2[i] * Weights2[i * Out_layer_size + j];
                }

                Out_layer[j] = Sigmoid(Out_layer[j]);
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
