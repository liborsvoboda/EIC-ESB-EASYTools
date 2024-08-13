using System;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace EASYTools.ImageEffectLibrary
{
    public class GrayscaleImage : Image<byte>, IBitmapSource
    {
        public GrayscaleImage(byte[,] pixels) : base(pixels) { }

        public GrayscaleImage(int pixelWidth, int pixelHeight) : base(pixelWidth, pixelHeight) { }

        public GrayscaleImage(byte[] grayscalePixels, int pixelWidth, int pixelHeight) : base(pixelWidth, pixelHeight)
        {
            for (int x = 0; x < pixelWidth; x++)
            {
                for (int y = 0; y < pixelHeight; y++)
                {
                    Pixels[x, y] = grayscalePixels[y * pixelWidth + x];
                }
            }
        }

        private byte GetMaxLuminance()
        {
            byte max = 0;
            foreach (var pixel in this)
            {
                if (pixel > max) max = pixel;

            }
            return max;
        }

        private byte GetMinLuminance()
        {
            byte min = 255;
            foreach (var pixel in this)
            {
                if (pixel < min) min = pixel;

            }
            return min;
        }

        public void EnhanceVisibility()
        {
            double logMax = Math.Log10(GetMaxLuminance() / 255.0 + 1);
            Pipeline((pixel) => Convert.ToByte(255 * Math.Log10(pixel / 255.0 + 1) / logMax));
        }

        public void LightnessLinearStretch()
        {
            byte min = GetMinLuminance();
            double k = 255.0 / (GetMaxLuminance() - min);
            Pipeline((pixel) => Convert.ToByte(k * (pixel - min)));
        }

        private long[] GetHistogram()
        {
            var res = new long[256];
            foreach (var pixel in this)
            {
                res[pixel]++;
            }
            return res;
        }

        private long[] GetHistogramCdf()
        {
            var histogram = GetHistogram();
            var res = new long[256];
            long sum = 0;
            for (int i = 0; i < 256; i++)
            {
                res[i] = histogram[i] + sum;
                sum += histogram[i];
            }
            return res;
        }

        public void HistogramEqualization()
        {
            var cdf = GetHistogramCdf();
            var minCdf = cdf.Min();
            double denominator = PixelWidth * PixelHeight - minCdf;
            Pipeline((pixel) => Convert.ToByte(Math.Round((cdf[pixel] - minCdf) / denominator * 255)));
        }

        public byte[] ToPixelsData()
        {
            byte[] data = new byte[PixelHeight * PixelWidth];
            for (int x = 0; x < PixelWidth; x++)
            {
                for (int y = 0; y < PixelHeight; y++)
                {
                    data[y * PixelWidth + x] = Pixels[x, y];
                }
            }
            return data;
        }

        public BitmapSource ToBitmapSource(double dpiX, double dpiY)
        {
            return BitmapSource.Create(PixelWidth, PixelHeight, dpiX, dpiY, PixelFormats.Gray8, BitmapPalettes.Gray256, ToPixelsData(), PixelWidth);
        }
    }
}