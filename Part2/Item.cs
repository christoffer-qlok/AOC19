using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
    internal class Item
    {
        public int X { get; set; }
        public int M { get; set; }
        public int A { get; set; }
        public int S { get; set; }

        public int Sum()
        {
            return X + M + A + S;
        }

        public static Item ParseItem(string s)
        {
            s = s.Trim('{', '}');
            var parts = s.Split(',');

            var ret = new Item();

            foreach (var part in parts)
            {
                var assignmentParts = part.Split('=');
                int value = int.Parse(assignmentParts[1]);

                switch (assignmentParts[0])
                {
                    case "x":
                        ret.X = value; break;
                    case "m":
                        ret.M = value; break;
                    case "a":
                        ret.A = value; break;
                    case "s":
                        ret.S = value; break;
                }
            }
            return ret;
        }

        public override string ToString()
        {
            return $"{{x={X},m={M},a={A},s={S}}}";
        }
    }
}
