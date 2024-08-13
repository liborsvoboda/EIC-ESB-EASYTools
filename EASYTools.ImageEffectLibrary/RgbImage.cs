using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace EASYTools.ImageEffectLibrary
{
    public class RgbImage : Image<RgbPixel?>, ITransformableImage, IBitmapSource, IFilterableImage
    {
        public RgbImage(RgbPixel?[,] pixels) : base(pixels)
        {
        }

        public RgbImage(int pixelWidth, int pixelHeight) : base(pixelWidth, pixelHeight)
        {
        }

        public RgbImage(byte[] bgraPixels, int pixelWidth, int pixelHeight) : base(pixelWidth, pixelHeight)
        {
            for (int x = 0; x < pixelWidth; x++)
            {
                for (int y = 0; y < pixelHeight; y++)
                {
                    int offset = y * PixelWidth * 4 + x * 4;

                    // offset + 0: B
                    // offset + 1: G
                    // offset + 2: R
                    // offset + 3: A
                    Pixels[x, y] = new RgbPixel(bgraPixels[offset + 2], bgraPixels[offset + 1], bgraPixels[offset + 0],
                        bgraPixels[offset + 3]);
                }
            }
        }

        private float GetMaxLuminance()
        {
            float max = 0;
            foreach (var pixel in this)
            {
                Debug.Assert(pixel != null, nameof(pixel) + " != null");
                float l = pixel.Value.ToHsl().L;
                if (l > max) max = l;
            }

            return max;
        }

        private float GetMinLuminance()
        {
            float min = 1;
            foreach (var pixel in this)
            {
                Debug.Assert(pixel != null, nameof(pixel) + " != null");
                float l = pixel.Value.ToHsl().L;
                if (l < min) min = l;
            }

            return min;
        }

        public void EnhanceVisibility()
        {
            double logMax = Math.Log10(GetMaxLuminance() + 1);
            Pipeline((pixel) =>
            {
                Debug.Assert(pixel != null, nameof(pixel) + " != null");
                var hsl = pixel.Value.ToHsl();
                hsl.L = Convert.ToSingle(Math.Log10(hsl.L + 1) / logMax);
                return hsl.ToRgb();
            });
        }

        public void LightnessLinearStretch()
        {
            float min = GetMinLuminance();
            float k = GetMaxLuminance() - min;
            Pipeline((pixel) =>
            {
                Debug.Assert(pixel != null, nameof(pixel) + " != null");
                var hsl = pixel.Value.ToHsl();
                hsl.L = (hsl.L - min) / k;
                return hsl.ToRgb();
            });
        }

        private long[] GetHistogramOfSaturation(int levels)
        {
            var res = new long[levels];
            foreach (var pixel in this)
            {
                Debug.Assert(pixel != null, nameof(pixel) + " != null");
                int level = (int) Math.Round(pixel.Value.ToHsl().S * (levels - 1));
                res[level]++;
            }

            return res;
        }

        private long[] GetHistogramCdfOfSaturation(int levels)
        {
            var histogram = GetHistogramOfSaturation(levels);
            var res = new long[levels];
            long sum = 0;
            for (int i = 0; i < levels; i++)
            {
                res[i] = histogram[i] + sum;
                sum += histogram[i];
            }

            return res;
        }

        public void SaturationHistogramEqualization(int levels)
        {
            var cdf = GetHistogramCdfOfSaturation(levels);
            var minCdf = cdf.Min();
            double denominator = PixelWidth * PixelHeight - minCdf;
            Pipeline((pixel) =>
            {
                Debug.Assert(pixel != null, nameof(pixel) + " != null");
                var hsl = pixel.Value.ToHsl();
                int level = (int) Math.Round(hsl.S * (levels - 1));
                hsl.S = Convert.ToSingle((cdf[level] - minCdf) / denominator);
                return hsl.ToRgb();
            });
        }

        private long[] GetHistogramOfLightness(int levels)
        {
            var res = new long[levels];
            foreach (var pixel in this)
            {
                Debug.Assert(pixel != null, nameof(pixel) + " != null");
                int level = (int) Math.Round(pixel.Value.ToHsl().L * (levels - 1));
                res[level]++;
            }

            return res;
        }

        private long[] GetHistogramCdfOfLightness(int levels)
        {
            var histogram = GetHistogramOfLightness(levels);
            var res = new long[levels];
            long sum = 0;
            for (int i = 0; i < levels; i++)
            {
                res[i] = histogram[i] + sum;
                sum += histogram[i];
            }

            return res;
        }

        public void LightnessHistogramEqualization(int levels)
        {
            var cdf = GetHistogramCdfOfLightness(levels);
            var minCdf = cdf.Min();
            double denominator = PixelWidth * PixelHeight - minCdf;
            Pipeline((pixel) =>
            {
                Debug.Assert(pixel != null, nameof(pixel) + " != null");
                var hsl = pixel.Value.ToHsl();
                int level = (int) Math.Round(hsl.L * (levels - 1));
                hsl.L = Convert.ToSingle((cdf[level] - minCdf) / denominator);
                return hsl.ToRgb();
            });
        }

        public RgbImage Transform(int newWidth, int newHeight, TransformDelegate transform)
        {
            var res = new RgbImage(newWidth, newHeight);
            for (int y = 0; y < PixelHeight; y++)
            {
                for (int x = 0; x < PixelWidth; x++)
                {
                    var newPos = transform(new Point(x, y));
                    if (newPos.X < 0 || newPos.X >= newWidth) continue;
                    if (newPos.Y < 0 || newPos.Y >= newHeight) continue;
                    res[newPos] = this[x, y];
                }
            }

            return res;
        }

        public ITransformableImage Translate(int dx, int dy)
        {
            return Transform(PixelWidth + dx, PixelHeight + dy, (point) => point + new Point(dx, dy));
        }

        public void MirrorHorizontally()
        {
            for (int x = 0; x < PixelWidth / 2; x++)
            {
                for (int y = 0; y < PixelHeight; y++)
                {
                    var temp = this[x, y];
                    this[x, y] = this[PixelWidth - 1 - x, y];
                    this[PixelWidth - 1 - x, y] = temp;
                }
            }
        }

        public void MirrorVertically()
        {
            for (int x = 0; x < PixelWidth; x++)
            {
                for (int y = 0; y < PixelHeight / 2; y++)
                {
                    var temp = this[x, y];
                    this[x, y] = this[x, PixelHeight - 1 - y];
                    this[x, PixelHeight - 1 - y] = temp;
                }
            }
        }

        public ITransformableImage RotateD(Point origin, double angle)
        {
            var vertices = new Point[]
            {
                Point.Zeros.RotateD(origin, angle),
                new Point(PixelWidth - 1, 0).RotateD(origin, angle),
                new Point(PixelWidth - 1, PixelHeight - 1).RotateD(origin, angle),
                new Point(0, PixelHeight - 1).RotateD(origin, angle)
            };

            var xs = vertices.Select((point) => point.X).ToArray();
            var ys = vertices.Select((point) => point.Y).ToArray();

            int left = xs.Min(), right = xs.Max(), top = ys.Min(), bottom = ys.Max();

            var newOrigin = new Point(left, top);
            var res = Transform(
                right - left + 1,
                bottom - top + 1,
                (point) => point.RotateD(origin, angle) - newOrigin
            );

            for (int i = 0; i < vertices.Length; i++) vertices[i] -= newOrigin;

            var borders = new Line[]
            {
                new Line(vertices[3], vertices[0]),
                new Line(vertices[0], vertices[1]),
                new Line(vertices[1], vertices[2]),
                new Line(vertices[2], vertices[3])
            };

            for (var y = 0; y < res.PixelHeight; y++)
            {
                var inters = new List<int>();
                foreach (var border in borders)
                {
                    var inter = Line.Intersection(border, new Line(y, Line.Axis.Y));
                    if (inter == null) continue;
                    var x = inter.Value.X;
                    if (x < 0 || x >= res.PixelWidth) continue;
                    inters.Add(x);
                }

                res.RowInterpolation(y, inters.Min(), inters.Max());
            }

            res.FillNullPixels();
            return res;
        }

        private void RowInterpolation(int y, int start, int end)
        {
            for (int x = start; x <= end; x++)
            {
                if (Pixels[x, y] != null) continue;
                Pixels[x, y] = FindNearestInRow(x, y, start, end);
            }
        }

        private RgbPixel FindNearestInRow(int x, int y, int start, int end)
        {
            for (int cursor = 1;; cursor++)
            {
                if (x - cursor >= start && Pixels[x - cursor, y] != null) return Pixels[x - cursor, y].Value;
                if (x + cursor <= end && Pixels[x + cursor, y] != null) return Pixels[x + cursor, y].Value;
            }
        }

        private void FillNullPixels() => Pipeline((pixel) => pixel ?? RgbColors.Transparent);

        public ITransformableImage Shear(double dx, double dy)
        {
            var res = Transform(
                (int) Math.Ceiling(PixelWidth + dx * PixelHeight),
                (int) Math.Ceiling(PixelHeight + dy * PixelWidth),
                (point) => new Point(
                    (int) Math.Round(point.X + dx * point.Y),
                    (int) Math.Round(point.Y + dy * point.X)
                )
            );

            for (int x = 0; x < res.PixelWidth; x++)
            {
                for (int y = 0; y < res.PixelHeight; y++)
                {
                    if (res[x, y] != null) continue;
                    int x0 = (int) Math.Round((x - y * dx) / (1 - dx * dy));
                    if (x0 < 0 || x0 >= PixelWidth) continue;
                    int y0 = (int) Math.Round((y - x * dy) / (1 - dx * dy));
                    if (y0 < 0 || y0 >= PixelHeight) continue;
                    res[x, y] = this[x0, y0];
                }
            }

            res.FillNullPixels();
            return res;
        }

        public ITransformableImage Scale(double kx, double ky, Interpolation interpolation)
        {
            RgbImage res;
            switch (interpolation)
            {
                case Interpolation.NearestNeighborInterpolation:
                    res = Transform(
                        (int) Math.Ceiling(kx * PixelWidth),
                        (int) Math.Ceiling(ky * PixelHeight),
                        (point) => new Point(
                            (int) Math.Round(kx * point.X),
                            (int) Math.Round(ky * point.Y)
                        )
                    );
                    res.NearestNeighborInterpolation(this, kx, ky);
                    break;
                case Interpolation.BilinearInterpolation:
                    res = ScaleWithBilinearInterpolation(kx, ky);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(interpolation), interpolation, null);
            }

            res.FillNullPixels();
            return res;
        }

        private void NearestNeighborInterpolation(RgbImage origin, double kx, double ky)
        {
            for (int x = 0; x < PixelWidth; x++)
            {
                for (int y = 0; y < PixelHeight; y++)
                {
                    if (this[x, y] != null) continue;
                    int x0 = (int) Math.Round(x / kx);
                    if (x0 < 0 || x0 >= origin.PixelWidth) continue;
                    int y0 = (int) Math.Round(y / ky);
                    if (y0 < 0 || y0 >= origin.PixelHeight) continue;
                    this[x, y] = origin[x0, y0];
                }
            }
        }

        private RgbImage ScaleWithBilinearInterpolation(double kx, double ky)
        {
            var res = new RgbImage((PixelWidth * kx).Round(), (PixelHeight * ky).Round());
            for (int x = 0; x < PixelWidth - 1; x++)
            {
                for (int y = 0; y < PixelHeight - 1; y++)
                {
                    int nx1 = (kx * x).Round(), ny1 = (ky * y).Round();
                    int nx2 = (kx * (x + 1)).Round(), ny2 = (ky * (y + 1)).Round();
                    RgbPixel p11 = this[x, y].Value,
                        p12 = this[x, y + 1].Value,
                        p21 = this[x + 1, y].Value,
                        p22 = this[x + 1, y + 1].Value;
                    for (int nx = nx1; nx <= nx2; nx++)
                    {
                        for (int ny = ny1; ny <= ny2; ny++)
                        {
                            double k = (nx2 - nx1) * (ny2 - ny1);
                            double m1 = nx2 - nx, m2 = nx - nx1;
                            double n1 = ny2 - ny, n2 = ny - ny1;
                            res[nx, ny] = m2 * n2 / k * p11 + m1 * n2 / k * p21 + m2 * n1 / k * p12 + m1 * n1 / k * p22;
                        }
                    }
                }
            }

            return res;
        }

        public byte[] ToBrgaPixelsData()
        {
            byte[] data = new byte[PixelHeight * PixelWidth * 4];
            for (int x = 0; x < PixelWidth; x++)
            {
                for (int y = 0; y < PixelHeight; y++)
                {
                    Debug.Assert(Pixels[x, y] != null);
                    var pixel = Pixels[x, y].Value;
                    int offset = y * PixelWidth * 4 + x * 4;
                    data[offset] = pixel.B;
                    data[offset + 1] = pixel.G;
                    data[offset + 2] = pixel.R;
                    data[offset + 3] = pixel.A;
                }
            }

            return data;
        }

        public BitmapSource ToBitmapSource(double dpiX, double dpiY)
        {
            return BitmapSource.Create(PixelWidth, PixelHeight, dpiX, dpiY, PixelFormats.Bgra32, null,
                ToBrgaPixelsData(), PixelWidth * 4);
        }

        public RgbImage Map(PixelPipelineDelegate process)
        {
            var res = new RgbImage(PixelWidth, PixelHeight);
            ForEach((pixel, position) => res[position] = process(pixel));
            return res;
        }

        public RgbImage Map(PixelPositionPipelineDelegate process)
        {
            var res = new RgbImage(PixelWidth, PixelHeight);
            ForEach((pixel, position) => res[position] = process(pixel, position));
            return res;
        }

        public RgbImage ParallelMap(PixelPositionPipelineDelegate process)
        {
            var res = new RgbImage(PixelWidth, PixelHeight);
            ParallelForEach((pixel, position) => res[position] = process(pixel, position));
            return res;
        }
        
        public RgbImage PixelParallelMap(PixelPositionPipelineDelegate process)
        {
            var res = new RgbImage(PixelWidth, PixelHeight);
            PixelParallelForEach((pixel, position) => res[position] = process(pixel, position));
            return res;
        }

        public HslImage ToHslImage()
        {
            var res = new HslImage(PixelWidth, PixelHeight);
            ForEach((pixel, position) => res[position] = pixel.Value.ToHsl());
            return res;
        }

        public IFilterableImage Filter(Filter filter) => ((HslImage) ToHslImage().Filter(filter)).ToRgbImage();

        public IFilterableImage MeanFilter(int size) => Filter(Filters.Mean(size));

        public IFilterableImage LaplacianFilter() => Filter(Filters.Laplacian);

        public IFilterableImage ExtendedLaplacianFilter() => Filter(Filters.ExtendedLaplacian);

        public IFilterableImage BilateralFilter(int size, double sigmaD, double sigmaR) =>
            BilateralFilterRgb(size, sigmaD, sigmaR);

        public IFilterableImage BilateralFilterL(int size, double sigmaD, double sigmaR) =>
            ((HslImage) ToHslImage().BilateralFilter(size, sigmaD, sigmaR)).ToRgbImage();

        public IFilterableImage BilateralFilterRgb(int size, double sigmaD, double sigmaR)
        {
            var origin = new Point(size / 2, size / 2);
            return ParallelMap((pixel, position) =>
            {
                double weightR = 0, weightG = 0, weightB = 0, sumR = 0, sumG = 0, sumB = 0;
                for (int x = 0; x < size; x++)
                {
                    for (int y = 0; y < size; y++)
                    {
                        var neighborPos = position - origin + new Point(x, y);
                        neighborPos.X = neighborPos.X.LimitTo(0, PixelWidth - 1);
                        neighborPos.Y = neighborPos.Y.LimitTo(0, PixelHeight - 1);

                        RgbPixel neighborPixel = this[neighborPos].Value;
                        double distFactor = -position.GetSquaredDistance(neighborPos) / (2 * sigmaD);
                        double rw = Math.Exp(distFactor - (pixel.Value.R - neighborPixel.R).Squared() / (2 * sigmaR));
                        double gw = Math.Exp(distFactor - (pixel.Value.G - neighborPixel.G).Squared() / (2 * sigmaR));
                        double bw = Math.Exp(distFactor - (pixel.Value.B - neighborPixel.B).Squared() / (2 * sigmaR));

                        weightR += rw;
                        weightG += gw;
                        weightB += bw;
                        sumR += rw * neighborPixel.R;
                        sumG += gw * neighborPixel.G;
                        sumB += bw * neighborPixel.B;
                    }
                }

                return new RgbPixel(
                    (byte) Math.Round(sumR / weightR).LimitTo(0, 255),
                    (byte) Math.Round(sumG / weightG).LimitTo(0, 255),
                    (byte) Math.Round(sumB / weightB).LimitTo(0, 255),
                    pixel.Value.A
                );
            });
        }
    }
}