using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace EASYTools.ImageEffectLibrary
{
    public interface IBitmapSource
    {
        int PixelHeight { get; }

        int PixelWidth { get; }

        BitmapSource ToBitmapSource(double dpiX, double dpiY);
    }

    public interface ITransformableImage
    {
        ITransformableImage Translate(int dx, int dy);

        void MirrorHorizontally();

        void MirrorVertically();

        ITransformableImage RotateD(Point point, double angle);

        ITransformableImage Shear(double dx, double dy);

        ITransformableImage Scale(double kx, double ky, Interpolation interpolation);
    }

    public abstract class Image<T> : IEnumerable<T>
    {
        public int PixelHeight => Pixels.GetLength(1);

        public int PixelWidth => Pixels.GetLength(0);

        public T this[int x, int y]
        {
            get => Pixels[x, y];
            set => Pixels[x, y] = value;
        }

        public T this[Point point]
        {
            get => Pixels[point.X, point.Y];
            set => Pixels[point.X, point.Y] = value;
        }

        public T[,] Pixels { get; set; }

        public delegate T PixelPipelineDelegate(T pixel);

        public delegate T PixelPositionPipelineDelegate(T pixel, Point position);

        public delegate void PixelHandlerDelegate(T pixel);

        public delegate void PixelPositionHandlerDelegate(T pixel, Point position);

        public delegate Point TransformDelegate(Point point);

        public Image(int pixelWidth, int pixelHeight)
        {
            Pixels = new T[pixelWidth, pixelHeight];
        }

        public Image(T[,] pixels)
        {
            Pixels = pixels;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int y = 0; y < PixelHeight; y++)
            {
                for (int x = 0; x < PixelWidth; x++)
                {
                    yield return Pixels[x, y];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Image<T> Pipeline(PixelPipelineDelegate process)
        {
            for (int y = 0; y < PixelHeight; y++)
            {
                for (int x = 0; x < PixelWidth; x++)
                {
                    Pixels[x, y] = process(Pixels[x, y]);
                }
            }

            return this;
        }

        public Image<T> Pipeline(PixelPositionPipelineDelegate process)
        {
            for (int y = 0; y < PixelHeight; y++)
            {
                for (int x = 0; x < PixelWidth; x++)
                {
                    Pixels[x, y] = process(Pixels[x, y], new Point(x, y));
                }
            }

            return this;
        }

        public Image<T> ForEach(PixelHandlerDelegate process)
        {
            for (int y = 0; y < PixelHeight; y++)
            {
                for (int x = 0; x < PixelWidth; x++)
                {
                    process(Pixels[x, y]);
                }
            }

            return this;
        }

        public Image<T> ForEach(PixelPositionHandlerDelegate process)
        {
            for (int y = 0; y < PixelHeight; y++)
            {
                for (int x = 0; x < PixelWidth; x++)
                {
                    process(Pixels[x, y], new Point(x, y));
                }
            }

            return this;
        }

        public Image<T> ParallelForEach(PixelPositionHandlerDelegate process)
        {
            Parallel.For(0, PixelHeight, (y) =>
            {
                for (int x = 0; x < PixelWidth; x++)
                {
                    process(Pixels[x, y], new Point(x, y));
                }
            });
            return this;
        }

        public Image<T> PixelParallelForEach(PixelPositionHandlerDelegate process)
        {
            Parallel.For(0, PixelHeight,
                (y) => { Parallel.For(0, PixelWidth, (x) => { process(Pixels[x, y], new Point(x, y)); }); });
            return this;
        }
    }

    public enum Interpolation
    {
        NearestNeighborInterpolation,
        BilinearInterpolation
    }
}