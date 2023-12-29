using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
    internal class Rule
    {
        public string Label { get; set; }
        public string SendTo { get; set; }
        public string Comparer { get; set; }
        public int Num { get; set; }
        public bool NoTest { get; set; }

        public Rule(string s)
        {
            if (!s.Contains(':')) // no test just send
            {
                NoTest = true;
                SendTo = s;
                return;
            }

            string cmpWith = s.Substring(0, 1);
            Comparer = s.Substring(1, 1);
            int colonIndex = s.IndexOf(':');
            Num = int.Parse(s.Substring(2, colonIndex - 2));
            SendTo = s.Substring(colonIndex + 1);
            Label = cmpWith;
        }
    }
}
