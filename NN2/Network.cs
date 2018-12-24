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
        const int Epochs = 100000;

        //private UnmanagedImage data;
        //BackPropagationLearning backprop;
        //ActivationLayer input_layer;
        //ActivationLayer hidden_layer;
        //ActivationLayer output_layer;
        //double[] data;
        private int input_size;
        private int output_size;
        ActivationNetwork net;
        ParallelResilientBackpropagationLearning backprop;
        NguyenWidrow nguen;

        public Network(int input_sz, int output_sz = 10)
        {
            input_size = input_sz;
            output_size = output_sz;
            net = new ActivationNetwork(new Accord.Neuro.BipolarSigmoidFunction(), 
                input_size, input_size*3, input_size * 2, input_size, 100, output_size);
            backprop = new ParallelResilientBackpropagationLearning(net);
            nguen = new NguyenWidrow(net);
            nguen.Randomize();
        }

        public int Predict(Bitmap img)
        {
            //Filter(img);
            double[] res = net.Compute(Preprocess(img));
            return res.ArgMax();
        }

        public double[] Preprocess(Bitmap bmp)
        {
            int w = bmp.Width;
            int h = bmp.Height;

            System.Drawing.Imaging.BitmapData imdata = bmp.LockBits(
                new Rectangle(0, 0, w, h),
                System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);

            UnmanagedImage unmImg = new UnmanagedImage(imdata);

                       
            double[] res = new double[w*h];
            for (int i = 0; i < w; ++i)
                for (int j = 0; j < h; ++j)
                {
                    float c = unmImg.GetPixel(i, j).GetBrightness();
                    res[i * w + j] = c;
//                    Color c = bmp.GetPixel(i, j);
                    /*if (c.R < 50 && c.G < 50 && c.B < 50)
                        res[i * w + j] = 1;
                    else res[i * w + j] = 0;*/
                }

            bmp.UnlockBits(imdata);

            return res;
            /*Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
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

            return res;*/
        }

        public Bitmap Filter(Bitmap input_image)
        {
            Grayscale gray_filter = new Grayscale(0.2125, 0.7154, 0.0721);
            BradleyLocalThresholding threshold_filter = new BradleyLocalThresholding();
            threshold_filter.PixelBrightnessDifferenceLimit = 0.5f;
            ResizeBicubic scale_small_filter = new ResizeBicubic(28, 28);
            Crop crop_filter = new Crop(new Rectangle(51, 51, 199, 199));
            ResizeBilinear scale_filter = new ResizeBilinear(28, 28);

            Bitmap bmp = gray_filter.Apply(input_image);
            bmp = crop_filter.Apply(bmp);
            bmp = threshold_filter.Apply(bmp);
            bmp = scale_small_filter.Apply(bmp);
     
            return bmp;
        }

        public void Load_net(String path)
        {
            net = Accord.Neuro.Network.Load(path) as ActivationNetwork;
        }

        public void Train(double[][] dataset, double[][] labels)
        {
            if (dataset.Length <= 0)
                return;

            net.Randomize();
            
            double error = 100;
            int epoch = 0;
            int len = dataset.Length;
      
            while (error > 0.001 && epoch < Epochs)
            {
                error = backprop.RunEpoch(dataset, labels) / len;
                Debug.WriteLine("iteration = " + epoch.ToString());
                Debug.WriteLine("error = " + error.ToString());
                ++epoch;
            }
            net.Save("net");
        }
    }
}
