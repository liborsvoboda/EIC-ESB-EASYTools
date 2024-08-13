using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;


namespace EASYTools.ImageEffectLibrary {

    public partial class ImageHelper : INotifyPropertyChanged
    {
        private bool changed = false;
        private string fileName = null;
        public enum FileType
        {
            Png,
            Jpeg,
            Bmp,
            Gif,
            Tiff,
            Wmp
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ImageHelper() { }

        public BitmapSource EditingImage { get; set; }

        public BitmapImage OriginImage { get; set; }

        public IBitmapSource DipLibImage { get; set; }

        public string FileName { get { return fileName; } private set { fileName = value; } }

        public bool Changed { get { return changed; } private set { changed = value; } }

        public void NewOrigin(string fileName = null) {
            FileName = fileName;
            
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                MemoryStream ms = new MemoryStream();
                BitmapImage bi = new BitmapImage();
                byte[] bytArray = File.ReadAllBytes(fileName);
                ms.Write(bytArray, 0, bytArray.Length); ms.Position = 0;
                bi.BeginInit();
                bi.StreamSource = ms;
                bi.EndInit();
                EditingImage = OriginImage = bi;
                //new BitmapImage(new Uri(fileName)) { CacheOption = BitmapCacheOption.OnDemand 
            } else { EditingImage = OriginImage = null; }
            Changed = false;
            GetRgbImage();
        }

        public ImageHelper(string fileName = null)
        {
            FileName = fileName;

            if (!string.IsNullOrWhiteSpace(fileName))
            {
                MemoryStream ms = new MemoryStream();
                BitmapImage bi = new BitmapImage();
                byte[] bytArray = File.ReadAllBytes(fileName);
                ms.Write(bytArray, 0, bytArray.Length); ms.Position = 0;
                bi.BeginInit();
                bi.StreamSource = ms;
                bi.EndInit();
                EditingImage = OriginImage = bi;
                //new BitmapImage(new Uri(fileName)) { CacheOption = BitmapCacheOption.OnDemand 
            } else { EditingImage = OriginImage = null; }

            Changed = false;
            GetRgbImage();
        }

        private void NotifyPropertyChanged(string name)
        {
            
            Changed = true;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private static FileType? GetFileTypeByExtension(string extension)
        {
            switch (extension.ToLower(new CultureInfo("en-US")))
            {
                case ".png":
                    return FileType.Png;
                case ".jpg":
                case ".jpeg":
                case ".jpe":
                case ".jif":
                case ".jfif":
                case ".jfi":
                    return FileType.Jpeg;
                case ".bmp":
                case ".dib":
                    return FileType.Bmp;
                case ".gif":
                    return FileType.Gif;
                case ".tiff":
                case ".tif":
                    return FileType.Tiff;
                case ".wmp":
                    return FileType.Wmp;
                default:
                    return FileType.Png;
            }
        }

        private static BitmapEncoder GetEncoder(string fileName)
        {
            switch (GetFileTypeByExtension(Path.GetExtension(fileName)))
            {
                case FileType.Png:
                    return new PngBitmapEncoder();
                case FileType.Jpeg:
                    return new JpegBitmapEncoder();
                case FileType.Bmp:
                    return new BmpBitmapEncoder();
                case FileType.Gif:
                    return new GifBitmapEncoder();
                case FileType.Tiff:
                    return new TiffBitmapEncoder();
                case FileType.Wmp:
                    return new WmpBitmapEncoder();
                default:
                    return new PngBitmapEncoder();
            }
        }

        private void SaveImage(string fileName)
        {
            var encoder = GetEncoder(fileName);
            encoder.Frames.Add(BitmapFrame.Create(EditingImage));
            using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                encoder.Save(fileStream);
            }
        }

        public void Save() {
            SaveImage(FileName);
        }

        public void ResetChanges() {
            EditingImage = OriginImage;
            Changed = false;
        }

        public void SaveTo(string fileName)
        {
            SaveImage(fileName);
        }

        public void SaveAs()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG (*.png)|*.png|" +
                                    "JPEG (*.jpg;*.jpeg;*.jpe;*.jif;*.jfif;*.jfi)|*.jpg;*.jpeg;*.jpe;*.jif;*.jfif;*.jfi|" +
                                    "BMP (*.bmp;*.dib)|*.bmp;*.dib|" +
                                    "GIF (*.gif)|*.gif|" +
                                    "TIFF (*.tiff;*.tif)|*.tiff;*.tif|" +
                                    "WMP (*.wmp)|*.wmp|" +
                                    "所有文件 (*.*)|*.*";
            if (saveFileDialog.ShowDialog() != true) return;
            SaveImage(saveFileDialog.FileName);
            FileName = saveFileDialog.FileName;
        }

        private void RefreshImage()
        {
            EditingImage = DipLibImage.ToBitmapSource(EditingImage.DpiX, EditingImage.DpiY);
            NotifyPropertyChanged(nameof(EditingImage));
        }
    }

    public partial class ImageHelper {
        private void GetRgbImage() {
            if (DipLibImage is RgbImage) return;
            EditingImage = new FormatConvertedBitmap(OriginImage, PixelFormats.Bgra32, null, 0);
            byte[] pixels = new byte[EditingImage.PixelWidth * EditingImage.PixelHeight * 4];
            EditingImage.CopyPixels(pixels, EditingImage.PixelWidth * 4, 0);
            DipLibImage = new RgbImage(pixels, EditingImage.PixelWidth, EditingImage.PixelHeight);
        }

        private void GetGrayscaleImage() {
            if (DipLibImage is GrayscaleImage) return;
            EditingImage = new FormatConvertedBitmap(OriginImage, PixelFormats.Gray8, BitmapPalettes.Gray256, 0);
            byte[] pixels = new byte[EditingImage.PixelWidth * EditingImage.PixelHeight];
            EditingImage.CopyPixels(pixels, EditingImage.PixelWidth, 0);
            DipLibImage = new GrayscaleImage(pixels, EditingImage.PixelWidth, EditingImage.PixelHeight);
        }

        public void ConvertToGrayscale() {
            GetGrayscaleImage();
            RefreshImage();
        }

        public void EnhanceVisibility() {
            if (DipLibImage is GrayscaleImage) (DipLibImage as GrayscaleImage).EnhanceVisibility();
            else
            {
                if (!(DipLibImage is RgbImage)) GetRgbImage();
                (DipLibImage as RgbImage).EnhanceVisibility();
            }
            RefreshImage();
        }

        public void LightnessLinearStretch() {
            if (DipLibImage is GrayscaleImage) (DipLibImage as GrayscaleImage).LightnessLinearStretch();
            else
            {
                if (!(DipLibImage is RgbImage)) GetRgbImage();
                (DipLibImage as RgbImage).LightnessLinearStretch();
            }
            RefreshImage();
        }

        public void GrayscaleHistogramEqualization() {
            GetGrayscaleImage();
            (DipLibImage as GrayscaleImage).HistogramEqualization();
            RefreshImage();
        }

        public void SaturationHistogramEqualization() {
            GetRgbImage();
            (DipLibImage as RgbImage).SaturationHistogramEqualization(101);
            RefreshImage();
        }

        public void LightnessHistogramEqualization() {
            GetRgbImage();
            (DipLibImage as RgbImage).LightnessHistogramEqualization(101);
            RefreshImage();
        }

        public void MirrorHorizontally() {
            GetRgbImage();
            (DipLibImage as RgbImage).MirrorHorizontally();
            RefreshImage();
        }

        public void MirrorVertically() {
            GetRgbImage();
            (DipLibImage as RgbImage).MirrorVertically();
            RefreshImage();
        }

        public void LaplacianFilter() {
            GetRgbImage();
            (DipLibImage as RgbImage).LaplacianFilter();
            RefreshImage();
        }



        private void GetBinaryImage() {
            if (DipLibImage is BinaryImage) return;
            if (!(DipLibImage is GrayscaleImage)) GetGrayscaleImage();
            var grayscale = DipLibImage as GrayscaleImage;
            DipLibImage = new BinaryImage(grayscale.ToPixelsData(), grayscale.PixelWidth, grayscale.PixelHeight);
        }

        public void Binarize() {
            GetBinaryImage();
            RefreshImage();
        }

        public void Dilation() {
            GetBinaryImage();
            DipLibImage = (DipLibImage as BinaryImage).Dilation(StructuringElements.Cross(3));
            RefreshImage();
        }

        public void Erosion() {
            GetBinaryImage();
            DipLibImage = (DipLibImage as BinaryImage).Erosion(StructuringElements.Cross(3));
            RefreshImage();
        }

        public void MorphologyOpen() {
            GetBinaryImage();
            DipLibImage = (DipLibImage as BinaryImage).Open(StructuringElements.Cross(3));
            RefreshImage();
        }

        public void MorphologyClose() {
            GetBinaryImage();
            DipLibImage = (DipLibImage as BinaryImage).Close(StructuringElements.Cross(3));
            RefreshImage();
        }
    }
}
