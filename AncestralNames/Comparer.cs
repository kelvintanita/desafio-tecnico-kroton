using System;
using System.Collections.Generic;
using System.Text;

namespace AncestralNames
{
    public class Comparer : IComparer<Pair>
    {
        public int Compare(Pair p1, Pair p2)
        {
            if (p1.x == 0 || p2.x == 0)
            {
                return 0;
            }

            return p1.x.CompareTo(p2.x);
        }
    }
}
