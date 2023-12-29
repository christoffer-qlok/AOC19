namespace Part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            var system = new Sys();

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    break;
                system.ParseWorkflow(line);
                
            }
            Node.Sys = system;
            var root = new Node("in");

            root.ExpandNode();
            Console.WriteLine($"Done expanding. Accepted groups: {Node.Accepted.Count()}");

            long sum = Node.Accepted.Sum(n => (long)n.X.Length * n.M.Length * n.A.Length * n.S.Length);
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
