using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaLogic
{
    public static class StringExtensions
    {
        public static bool IsPasswordOk(this string text)
        {
            return !String.IsNullOrEmpty(text) && text.Length >= 6;
        }
    }
}
