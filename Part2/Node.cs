using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
    internal class Node
    {
        public static List<Node> Accepted = new List<Node>();
        public static Sys Sys { get; set; }
        public Node Parent { get; set; }
        public Range X { get; set; }
        public Range M { get; set; }
        public Range A { get; set; }
        public Range S { get; set; }
        public string Workflow { get; set; }
        public List<Node> Children { get; set; } = new List<Node>();


        public Node(string workflow)
        {
            Workflow = workflow;
            X = new Range();
            M = new Range();
            A = new Range();
            S = new Range();
        }

        public Node(string workflow, Range x, Range m, Range a, Range s, Node parent)
        {
            Workflow = workflow;
            X = x;
            M = m;
            A = a;
            S = s;
            Parent = parent;
        }

        public void PrintPath()
        {
            var q = new Stack<Node>();
            var cur = this;
            while (cur != null)
            {
                q.Push(cur);
                cur = cur.Parent;
            }

            while(q.Count > 0)
            {
                Console.WriteLine($"{q.Pop().Workflow}");
            }
        }

        public void ExpandNode()
        {
            if (Workflow == "R")
                return;

            if (Workflow == "A")
            {
                Accepted.Add(this);
                return;
            }

            Range x = X;
            Range m = M;
            Range a = A;
            Range s = S;
            foreach (var rule in Sys.Workflows[Workflow].Rules)
            {
                if (rule.NoTest)
                {
                    Children.Add(new Node(rule.SendTo, x, m, a, s, this));
                    continue;
                }
                Range newRange;
                if (rule.Comparer == "<")
                {
                    switch (rule.Label)
                    {
                        case "x":
                            newRange = new Range(x.Min, Math.Min(x.Max, rule.Num - 1));
                            if (newRange.Positive)
                            {
                                Children.Add(new Node(rule.SendTo, newRange, m, a, s, this));
                            }
                            newRange = new Range(Math.Max(x.Min, rule.Num), x.Max);
                            if (!newRange.Positive)
                                return;
                            x = newRange;
                            break;
                        case "m":
                            newRange = new Range(m.Min, Math.Min(m.Max, rule.Num - 1));
                            if (newRange.Positive)
                            {
                                Children.Add(new Node(rule.SendTo, x, newRange, a, s, this));
                            }
                            newRange = new Range(Math.Max(m.Min, rule.Num), m.Max);
                            if (!newRange.Positive)
                                return;
                            m = newRange;
                            break;
                        case "a":
                            newRange = new Range(a.Min, Math.Min(a.Max, rule.Num - 1));
                            if (newRange.Positive)
                            {
                                Children.Add(new Node(rule.SendTo, x, m, newRange, s, this));
                            }
                            newRange = new Range(Math.Max(a.Min, rule.Num), a.Max);
                            if (!newRange.Positive)
                                return;
                            a = newRange;
                            break;
                        case "s":
                            newRange = new Range(s.Min, Math.Min(s.Max, rule.Num - 1));
                            if (newRange.Positive)
                            {
                                Children.Add(new Node(rule.SendTo, x, m, a, newRange, this));
                            }
                            newRange = new Range(Math.Max(s.Min, rule.Num), s.Max);
                            if (!newRange.Positive)
                                return;
                            s = newRange;
                            break;
                    }
                }
                else // >
                {
                    switch (rule.Label)
                    {
                        case "x":
                            newRange = new Range(Math.Max(x.Min, rule.Num + 1), x.Max);
                            if (newRange.Positive)
                            {
                                Children.Add(new Node(rule.SendTo, newRange, m, a, s, this));
                            }
                            newRange = new Range(x.Min, Math.Min(x.Max, rule.Num));
                            if (!newRange.Positive)
                                return;
                            x = newRange;
                            break;
                        case "m":
                            newRange = new Range(Math.Max(m.Min, rule.Num + 1), m.Max);
                            if (newRange.Positive)
                            {
                                Children.Add(new Node(rule.SendTo, x, newRange, a, s, this));
                            }
                            newRange = new Range(m.Min, Math.Min(m.Max, rule.Num));
                            if (!newRange.Positive)
                                return;
                            m = newRange;
                            break;
                        case "a":
                            newRange = new Range(Math.Max(a.Min, rule.Num + 1), a.Max);
                            if (newRange.Positive)
                            {
                                Children.Add(new Node(rule.SendTo, x, m, newRange, s, this));
                            }
                            newRange = new Range(a.Min, Math.Min(a.Max, rule.Num));
                            if (!newRange.Positive)
                                return;
                            a = newRange;
                            break;
                        case "s":
                            newRange = new Range(Math.Max(s.Min, rule.Num + 1), s.Max);
                            if (newRange.Positive)
                            {
                                Children.Add(new Node(rule.SendTo, x, m, a, newRange, this));
                            }
                            newRange = new Range(s.Min, Math.Min(s.Max, rule.Num));
                            if (!newRange.Positive)
                                return;
                            s = newRange;
                            break;

                    }
                }
            }

            foreach (Node node in Children)
            {
                if (node.Workflow != "S")
                    node.ExpandNode();
            }
        }
    }
}
