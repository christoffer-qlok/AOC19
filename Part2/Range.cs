using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
    internal struct Range
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public int Length { get { return Max - Min + 1; } }
        public bool Positive { get { return Length > 0; } }

        public Range()
        {
            Min = 1;
            Max = 4000;
        }

        public Range(int from, int to)
        {
            Min = from;
            Max = to;
        }

        public override string ToString()
        {
            return $"({Min}, {Max})";
        }
    }
}
