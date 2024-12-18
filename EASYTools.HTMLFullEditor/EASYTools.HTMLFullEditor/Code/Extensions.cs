﻿using System;
using System.Collections.Generic;

namespace EASYTools.HTMLFullEditor.Code
{
    public static class Extensions
    {
        /// <summary>
        /// IndexOf(predicate) functionality on Enumerable.
        /// </summary>
        public static int IndexOf<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            int i = 0;
            foreach (var item in items)
            {
                if (predicate(item))
                    return i;

                i++;
            }

            return -1;
        }
    }
}
