using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GardenArt.Helpers
{
    public static class StringHelpers
    {
        public static string UpperCaseFirst(this string s)
        {
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        public static string Max24Chars(this string s)
        {

            if (s.Length > 23) { 
                s = s.Substring(0, 24);
                s += "...";
            }
         
            return s;
        }
    }
}