using System;

namespace AncestralNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Philippe I", "Philip II" };
            //string[] names = { "Louis VIII", "Louis IX" };
            int n = names.Length;

            FunctionUtils.sortRoman(names, n);
        }
    }
}
