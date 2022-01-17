using System;
using System.Collections.Generic;
using System.Text;

namespace AncestralNames
{
    public class FunctionUtils
    {
        public static int value(string r)
        {
            if (r == "I")
                return 1;

            if (r == "III")
                return 3;

            if (r == "IV")
                return 4;

            if (r == "V")
                return 5;

            if (r == "VI")
                return 6;

            if (r == "VII")
                return 7;

            if (r == "VIII")
                return 8;

            if (r == "IX")
                return 9;

            if (r == "X")
                return 10;
            
            if (r == "XX")
                return 20;

            if (r == "XXX")
                return 30;

            if (r == "XL")
                return 40;
            
            if (r == "L")
                return 50;
            
            return -1;
        }

        public static int romanToDecimal(string str)
        {
            var index = str.IndexOf(" ");
            str = str.Remove(0, index).Trim();

            int res = 0;

            for (int i = 0; i < str.Length; i++)
            {

                int s1 = value(str[i].ToString());

                if (i + 1 < str.Length)
                {

                    int s2 = value(str[i + 1].ToString());

                    if (s1 >= s2)
                    {
                        res = res + s1;
                    }
                    else
                    {
                        res = res + s2 - s1;
                        i++;
                    }
                }
                else
                {
                    res = res + s1;
                }
            }
            return res;
        }

        public static void sortRoman(String[] arr, int n)
        {
            List<Pair> vp = new List<Pair>();

            for (int i = 0; i < n; i++)
            {
                vp.Add(new Pair(romanToDecimal(arr[i]),
                                               arr[i]));
            }

            Comparer gg = new Comparer();
            vp.Sort(gg);

            for (int i = 0; i < vp.Count; i++)
                Console.WriteLine(vp[i].y + "\n");
        }
    }
}
