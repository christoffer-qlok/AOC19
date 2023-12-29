using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
    internal class Workflow
    {
        public List<Rule> Rules { get; set; } = new List<Rule>();

        public Workflow(string s)
        {
            s = s.Trim('{', '}');
            var parts = s.Split(',');

            foreach ( var part in parts )
            {
                Rules.Add(new Rule(part));
            }
        }
    }
}
