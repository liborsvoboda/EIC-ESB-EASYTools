using System.Linq;

namespace EASYTools.ImageEffectLibrary
{
    public interface IFilterableImage
    {
        IFilterableImage Filter(Filter filter);

        IFilterableImage MeanFilter(int size);

        IFilterableImage LaplacianFilter();

        IFilterableImage ExtendedLaplacianFilter();

        IFilterableImage BilateralFilter(int size, double sigmaD, double sigmaR);
    }

    public class Filter : Image<double>
    {
        public Point Origin { get; set; }

        public Filter(int pixelWidth, int pixelHeight) : base(pixelWidth, pixelHeight)
        {
            Origin = new Point(pixelWidth / 2, pixelHeight / 2);
        }

        public Filter(int pixelWidth, int pixelHeight, Point origin) : base(pixelWidth, pixelHeight)
        {
            Origin = origin;
        }

        public Filter(double[,] pixels) : base(pixels)
        {
            Origin = new Point(PixelWidth / 2, PixelHeight / 2);
        }

        public Filter(double[,] pixels, Point origin) : base(pixels)
        {
            Origin = origin;
        }

        public void Normalize()
        {
            double sum = Pixels.Cast<double>().Sum();
            Pipeline(pixel => pixel / sum);
        }
    }

    public static class Filters
    {
        public static Filter Laplacian { get; } = new Filter(new double[,] {{0, -1, 0}, {-1, 5, -1}, {0, -1, 0}});

        public static Filter ExtendedLaplacian { get; } =
            new Filter(new double[,] {{-1, -1, -1}, {-1, 9, -1}, {-1, -1, -1}});

        public static Filter Mean(int size = 3)
        {
            var filter = new Filter(size, size);
            filter.Pipeline(pixel => 1);
            filter.Normalize();
            return filter;
        }
    }
}