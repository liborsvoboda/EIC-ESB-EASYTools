using System;

namespace EASYTools.ImageEffectLibrary
{
    public enum BinaryPixel
    {
        White,
        Black
    }

    public struct RgbPixel
    {
        public byte A { get; set; }

        public byte R { get; set; }

        public byte G { get; set; }

        public byte B { get; set; }

        public RgbPixel(byte r, byte g, byte b, byte a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public static RgbPixel operator +(RgbPixel p1, RgbPixel p2) =>
            new RgbPixel((byte) (p1.R + p2.R), (byte) (p1.G + p2.G), (byte) (p1.B + p2.B), (byte) (p1.A + p2.A));

        public static RgbPixel operator *(double k, RgbPixel p2) =>
            new RgbPixel((byte) (k * p2.R), (byte) (k * p2.G), (byte) (k * p2.B), (byte) (k * p2.A));

        public HslPixel ToHsl()
        {
            float r = R / 255f, g = G / 255f, b = B / 255f;
            float min = Math.Min(r, Math.Min(g, b));
            float max = Math.Max(r, Math.Max(g, b));
            float l = (max + min) / 2;

            float s = 0;
            if (l == 0 || max == min) s = 0;
            else if (l <= 0.5) s = (max - min) / (2 * l);
            else s = (max - min) / (2 - 2 * l);

            float h = 0;
            if (max != min)
            {
                if (max == r) h = 60 * (g - b) / (max - min) + (g >= b ? 0 : 360);
                else if (max == g) h = 60 * (b - r) / (max - min) + 120;
                else h = 60 * (r - g) / (max - min) + 240;
            }

            return new HslPixel(h, s, l, A);
        }
    }

    public static class RgbColors
    {
        public static RgbPixel Transparent { get; } = new RgbPixel(0, 0, 0, 0);
    }

    public struct HslPixel
    {
        public byte A { get; set; }

        public float H { get; set; }

        public float S { get; set; }

        public float L { get; set; }

        public HslPixel(float h, float s, float l, byte a)
        {
            H = h;
            S = s;
            L = l;
            A = a;
        }

        public RgbPixel ToRgb()
        {
            float a = S * Math.Min(L, 1 - L);
            HslPixel hsl = this;

            float F(float n)
            {
                float k = (n + hsl.H / 30) % 12;
                return hsl.L - a * Math.Max(Math.Min(Math.Min(k - 3, 9 - k), 1), -1);
            }

            return new RgbPixel((byte) Math.Round(F(0) * 255), (byte) Math.Round(F(8) * 255),
                (byte) Math.Round(F(4) * 255), A);
        }
    }
}