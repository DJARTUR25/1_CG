 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.ComponentModel;

namespace Фильтры_лаба
{
    public abstract class Filters
    {
        public abstract Color calculateNewPixelColor(Bitmap sourceImage, int x, int y);
        public Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }

            return resultImage;
        }

        public int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            if (value > max) return max;
            return value;
        }
    }

    class InvertFilter : Filters
    {
        public override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(255 - sourceColor.R, 255 - sourceColor.G, 255 - sourceColor.B);
            return resultColor;
        }
    }

    class GrayScaleFilter : Filters
    {
        public override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int Intensity = (int)(0.36 * sourceColor.R + 0.53 * sourceColor.G + 0.11 * sourceColor.B);
            int grayValue = Clamp(Intensity, 0, 255);
            return Color.FromArgb(grayValue, grayValue, grayValue);
        }
    }

    class SepiaFilter : Filters
    {
        public override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int Intensity = (int)(0.36 * sourceColor.R + 0.53 * sourceColor.G + 0.11 * sourceColor.B);
            int SepiaValue = Clamp(Intensity, 0, 255);

            float k = (float)(0.5);
            int r = (int)(2 * k * sourceColor.R + SepiaValue);
            int g = (int)(0.5 * k * sourceColor.G + SepiaValue);
            int b = (int)(-1 * k * sourceColor.B + SepiaValue);

            r = Clamp(r, 0, 255);
            g = Clamp(g, 0, 255);
            b = Clamp(b, 0, 255);

            return Color.FromArgb(r, g, b);
        }
    }

    class Brightness : Filters
    {
        public override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int R = (int)sourceColor.R;
            int G = (int)sourceColor.G;
            int B = (int)sourceColor.B;

            int k = 50; // параметр яркости

            R = Clamp((int)(R + k), 0, 255);
            G = Clamp((int)(G + k), 0, 255);
            B = Clamp((int)(B + k), 0, 255);

            Color resultColor = Color.FromArgb(R, G, B);
            return resultColor;
        }
    }

    class MatrixFilter : Filters
    {
        protected float[,] kernel = null;
        protected MatrixFilter() { }

        public MatrixFilter(float[,] kernel)
        {
            this.kernel = kernel;
        }
        public override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;

            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            for (int i = -radiusY; i <= radiusY; i++)
            {
                for (int j = -radiusY; j <= radiusY; j++)
                {
                    int idX = Clamp(x + j, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + i, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultR += neighborColor.R * kernel[j + radiusX, i + radiusY];
                    resultG += neighborColor.G * kernel[j + radiusX, i + radiusY];
                    resultB += neighborColor.B * kernel[j + radiusX, i + radiusY];
                }
            }
            return Color.FromArgb(Clamp((int)resultR, 0, 255), Clamp((int)resultG, 0, 255), Clamp((int)resultB, 0, 255));
        }
    }

    class BlurFilter : MatrixFilter
    {
        public BlurFilter()
        {
            int sizeX = 3;
            int sizeY = 3;
            kernel = new float[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    kernel[i, j] = 1.0f / (float)(sizeX * sizeY);
                }
            }
        }
    }

    class GaussianFilter : MatrixFilter
    {
        public GaussianFilter() { createGaussianKernel(3, 2); }
        public void createGaussianKernel(int radius, float sigma)
        {
            int size = 2 * radius + 1;
            kernel = new float[size, size];
            float norm = 0;
            for (int i = -radius; i <= radius; i++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    kernel[i + radius, j + radius] = (float)(Math.Exp(-(i * i + j * j) / (sigma * sigma)));
                    norm += kernel[i + radius, j + radius];
                }
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    kernel[i, j] /= norm;
                }
            }
        }
    }

    class SobelFilter : MatrixFilter
    {
        protected float[,] kernelX = null;
        protected float[,] kernelY = null;

        public SobelFilter()
        {
            kernelX = new float[,]
            {
                {-1, 0, 1 },
                {-2, 0, 2 },
                {-1, 0, 1 }
            };

            kernelY = new float[,]
            {
                { -1, -2, -1 },
                {  0,  0,  0 },
                {  1,  2,  1 }
            };
        }

        public override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernelX.GetLength(0) / 2;
            int radiusY = kernelX.GetLength(1) / 2;

            float resultRX = 0; float resultRY = 0;
            float resultGX = 0; float resultGY = 0;
            float resultBX = 0; float resultBY = 0;

            for (int l = -radiusY; l <= radiusY; l++)
            {
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);

                    resultRX += neighborColor.R * kernelX[k + radiusX, l + radiusY];
                    resultRX += neighborColor.G * kernelX[k + radiusX, l + radiusY];
                    resultBX += neighborColor.B * kernelX[k + radiusX, l + radiusY];

                    resultRY += neighborColor.R * kernelY[k + radiusX, l + radiusY];
                    resultRY += neighborColor.G * kernelY[k + radiusX, l + radiusY];
                    resultBY += neighborColor.B * kernelY[k + radiusX, l + radiusY];

                }
            }

            int resultR = (int)Math.Sqrt(resultRX * resultRX + resultRY * resultRY);
            int resultG = (int)Math.Sqrt(resultGX * resultGX + resultGY * resultGY);
            int resultB = (int)Math.Sqrt(resultBX * resultBX + resultBY * resultBY);

            return Color.FromArgb(Clamp((int)resultR, 0, 255), Clamp((int)resultG, 0, 255), Clamp((int)resultB, 0, 255));
        }
    }

    class Sharpness : MatrixFilter
    {
        public Sharpness()
        {
            int sizeX = 3;
            int sizeY = 3;

            kernel = new float[sizeX, sizeY];
            kernel[0, 0] = 0;
            kernel[0, 1] = -1;
            kernel[0, 2] = 0;
            kernel[1, 0] = -1;
            kernel[1, 1] = 5;
            kernel[1, 2] = -1;
            kernel[2, 0] = 0;
            kernel[2, 1] = -1;
            kernel[2, 2] = 0;
        }
    }

    class Embossing : MatrixFilter
    {
        public Embossing()
        {
            int sizeX = 3;
            int sizeY = 3;

            kernel = new float[sizeX, sizeY];
            kernel[0, 0] = 0;
            kernel[0, 1] = 1;
            kernel[0, 2] = 0;
            kernel[1, 0] = 1;
            kernel[1, 1] = 0;
            kernel[1, 2] = -1;
            kernel[2, 0] = 0;
            kernel[2, 1] = -1;
            kernel[2, 2] = 0;
        }

        protected Color grayscale(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            double Intensity = (double)(0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B);
            int k = 5;
            Color resultcolor = Color.FromArgb(Clamp((int)(Intensity + 2 * k), -255, 255), Clamp((int)(Intensity + 0.5 * k), -255, 255), Clamp((int)(Intensity - k), -255, 255));
            return resultcolor;
        }
        protected Bitmap processImage(Bitmap sourceImage)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, grayscale(sourceImage, i, j));
                }
            }

            return resultImage;
        }

        public override Color calculateNewPixelColor(Bitmap resultimage, int i, int j)
        {
            Bitmap sourceimage;
            sourceimage = resultimage;
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;
            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            for (int l = -radiusY; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idx = Clamp(i + k, 0, sourceimage.Width - 1);
                    int idy = Clamp(j + l, 0, sourceimage.Height - 1);
                    Color neighborcolor = sourceimage.GetPixel(idx, idy);
                    resultR += neighborcolor.R * kernel[k + radiusX, l + radiusY];
                    resultG += neighborcolor.G * kernel[k + radiusX, l + radiusY];
                    resultB += neighborcolor.B * kernel[k + radiusX, l + radiusY];
                }
            resultR = (resultR + 255) / 2;
            resultG = (resultG + 255) / 2;
            resultB = (resultB + 255) / 2;
            return Color.FromArgb(Clamp((int)resultR, 0, 255), Clamp((int)resultG, 0, 255), Clamp((int)resultB, 0, 255));
        }
    }

    class MedianFilter : MatrixFilter
    {
        private int kernelSize;

        public MedianFilter(int size = 3) : base(CreateKernel(size))
        {
            kernelSize = size;
        }

        private static float[,] CreateKernel(int size)
        {
            float[,] kernel = new float[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    kernel[i, j] = 1;
            return kernel;
        }

        public override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radius = kernelSize / 2;
            List<int> R = new List<int>();
            List<int> G = new List<int>();
            List<int> B = new List<int>();

            for (int i = -radius; i <= radius; i++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    int idX = Clamp(x + i, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + j, 0, sourceImage.Height - 1);
                    Color pixel = sourceImage.GetPixel(idX, idY);
                    R.Add(pixel.R);
                    G.Add(pixel.G);
                    B.Add(pixel.B);
                }
            }

            R.Sort();
            G.Sort();
            B.Sort();
            int medianIndex = R.Count / 2;

            return Color.FromArgb(
                Clamp(R[medianIndex], 0, 255),
                Clamp(G[medianIndex], 0, 255),
                Clamp(B[medianIndex], 0, 255)
            );
        }

        public Bitmap ApplyMedianFilter(Bitmap sourceImage, BackgroundWorker worker)
        {
            return processImage(sourceImage, worker);
        }
    }

    class TransferFilter : Filters
    {
        public override Color calculateNewPixelColor(Bitmap sourceImage, int k, int l)
        {
            int x = 0;
            if (k >= 50)
            {
                x = k - 50;
            }
            int y = l;
            Color sourceColor = sourceImage.GetPixel(x, y);
            Color resultColor = sourceColor;
            return resultColor;
        }
    }

    class TurnFilter : Filters
    {
        private double mu;
        private Color BackColor;

        public TurnFilter(double mu, Color Back)
        {
            this.mu = mu;
            this.BackColor = Back;
        }

        public override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int x0 = (int)(0);
            int y0 = (int)(0);
            int turnX = (int)((x - x0) * Math.Cos(mu) + (y - y0) * Math.Sin(mu) + x0);
            int turnY = (int)(-(x - x0) * Math.Sin(mu) + (y - y0) * Math.Cos(mu) + y0);

            if (turnX >= 0 && turnX < sourceImage.Width && turnY >= 0 && turnY < sourceImage.Height)
                return sourceImage.GetPixel(turnX, turnY);
            else 
                return BackColor;
        }
    }
}