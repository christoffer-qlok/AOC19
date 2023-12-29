using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC19
{
    internal class Rule
    {
        private Func<Item, int> _selector;
        private Func<int, int, bool> _comparer;
        private int _compareWith;
        private string _sendTo;

        public Rule(string s)
        {
            if (!s.Contains(':')) // no test just send
            {
                _selector = (it) => 0;
                _comparer = (l, n) => true;
                _sendTo = s;
                return;
            }

            string cmpWith = s.Substring(0, 1);
            string comparer = s.Substring(1, 1);
            int colonIndex = s.IndexOf(':');
            _compareWith = int.Parse(s.Substring(2, colonIndex - 2));
            _sendTo = s.Substring(colonIndex + 1);

            switch (cmpWith)
            {
                case "x":
                    _selector = (it) => it.X;
                    break;
                case "m":
                    _selector = (it) => it.M;
                    break;
                case "a":
                    _selector = (it) => it.A;
                    break;
                case "s":
                    _selector = (it) => it.S;
                    break;
                default:
                    throw new Exception($"Bad compare item: {cmpWith}");
            }

            switch (comparer)
            {
                case "<":
                    _comparer = (n, cmp) => n < cmp;
                    break;
                case ">":
                    _comparer = (n, cmp) => n > cmp;
                    break;
                default:
                    throw new Exception($"Bad comparer: {comparer}");
            }
        }

        public bool Check(Item item)
        {
            int n = _selector(item);
            return _comparer(n, _compareWith);
        }

        public string SendTo()
        {
            return _sendTo;
        }
    }
}
