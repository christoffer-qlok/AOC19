using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC19
{
    internal class Workflow
    {
        private List<Rule> rules = new List<Rule>();

        public Workflow(string s)
        {
            s = s.Trim('{', '}');
            var parts = s.Split(',');

            foreach ( var part in parts )
            {
                rules.Add(new Rule(part));
            }
        }

        public string SendTo(Item item)
        {
            foreach ( var rule in rules )
            {
                if(rule.Check(item))
                {
                    return rule.SendTo();
                }
            }
            throw new Exception("No matching rule");
        }
    }
}
