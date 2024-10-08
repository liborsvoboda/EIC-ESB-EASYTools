﻿using System.Collections.Generic;
using System.Linq;

namespace EASYTools.HTMLFullEditor.Html
{
    public class FontSize
    {
        public int Key { get; private set; }
        public double Size { get; private set; }
        public string Text { get; private set; }

        public static readonly FontSize XXSmall = new FontSize { Key = 1, Size = 8.5, Text = "8" };
        public static readonly FontSize XSmall = new FontSize { Key = 2, Size = 10.5, Text = "10" };
        public static readonly FontSize Small = new FontSize { Key = 3, Size = 12, Text = "12" };
        public static readonly FontSize Middle = new FontSize { Key = 4, Size = 14, Text = "14" };
        public static readonly FontSize Large = new FontSize { Key = 5, Size = 18, Text = "18" };
        public static readonly FontSize XLarge = new FontSize { Key = 6, Size = 24, Text = "24" };
        public static readonly FontSize XXLarge = new FontSize { Key = 7, Size = 36, Text = "36" };

        public static readonly FontSize[] AllFontSizes = new[]
        {
            XXSmall,
            XSmall,
            Small,
            Middle,
            Large,
            XLarge,
            XXLarge
        };

        public static readonly Dictionary<int, FontSize> SizeByKey = AllFontSizes.ToDictionary(s => s.Key);
    }
}
