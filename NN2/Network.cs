using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Accord.Imaging;
using Accord.Neuro;
using Accord.Neuro.Learning;
using Accord.Math;
using System.Diagnostics;
using Accord.Imaging.Filters;

namespace NN2
{
    class Network
    {
        const double Eps = 1e-2;
        const int Epochs = 100;

        private UnmanagedImage data;
        //BackPropagationLearning backprop;
        //ActivationLayer input_layer;
        //ActivationLayer hidden_layer;
        //ActivationLayer output_layer;
        private int input_size;
        private int hidden_size;
        private int output_size;
        ActivationNetwork net;

        public Network(int input_sz, int hidden_sz, int output_sz = 10)
        {
            input_size = input_sz;
            hidden_size = hidden_sz;
            output_size = output_sz;
            net = new ActivationNetwork(new SigmoidFunction(), input_size, hidden_size, output_size);
        }

        public int Predict(Bitmap img)
        {
            double[] res = net.Compute(Preprocess(img));
            return res.ArgMax();
        }

        public double[] Preprocess(Bitmap input_image)
        {
            Grayscale gray_filter = new Grayscale(0.2125, 0.7154, 0.0721);
            ResizeBilinear scale_filter = new ResizeBilinear(28, 28);
            BradleyLocalThresholding threshold_filter = new BradleyLocalThresholding();

            Bitmap bmp = gray_filter.Apply(input_image);
            bmp = scale_filter.Apply(bmp);
            bmp = threshold_filter.Apply(bmp);

            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData =
                bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                bmp.PixelFormat);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            double[] res = new double[bytes];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, res, 0, bytes);


            return res;
        }

        public void Load_net(String path)
        {
            net = Accord.Neuro.Network.Load(path) as ActivationNetwork;
        }

        public void Train()
        {
            Accord.DataSets.MNIST mnist = new Accord.DataSets.MNIST();
            var training = mnist.Training;
            
            BackPropagationLearning backprop = new BackPropagationLearning(net);
            double error = double.MaxValue;
            int epoch = 0;
            while (epoch < Epochs)
            {
                // for some reason it's size is not 28*28, it is 780...
                var samples = training.Item1.ToDense();

                // because we need double[][]
                int len = training.Item2.Length;
                double[][] labels = new double[len][];
                for (int j = 0; j < len; ++j)
                {
                    labels[j] = new double[] { training.Item2[j] };
                }

                // var label = training.Item2;
                error = backprop.RunEpoch(samples, labels);
                Debug.WriteLine("error = ", error);

                ++epoch;
            }
            net.Save("net");
        }
    }
}
