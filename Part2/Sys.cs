using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
    internal class Sys
    {
        public Dictionary<string, Workflow> Workflows { get; set; }

        public Sys()
        {
            Workflows = new Dictionary<string, Workflow>();
        }

        public void ParseWorkflow(string s)
        {
            int labelEnd = s.IndexOf('{');
            string label = s.Substring(0, labelEnd);
            string workflow = s.Substring(labelEnd);
            Workflows[label] = new Workflow(workflow);
        }
    }
}
