namespace AOC19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            var system = new Sys();

            int i = 0;
            while (!string.IsNullOrWhiteSpace(lines[i]))
            {
                system.ParseWorkflow(lines[i]);
                i++;
            }

            var items = new List<Item>();
            for (i++; i < lines.Length; i++)
            {
                items.Add(Item.ParseItem(lines[i]));
            }

            int sum = 0;
            foreach (var item in items)
            {
                if (system.CheckItem(item))
                {
                    sum += item.Sum();
                }
            }
            Console.WriteLine(sum);
        }
    }
}
