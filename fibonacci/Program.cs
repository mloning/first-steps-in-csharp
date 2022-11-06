class Program
{
    public static void Main(string[] args)
    {
        // parse args
        var n = ParseArgs(args);

        // create empty list
        var fibonacci = new List<int> { 0, 1 };

        // generate numbers
        if (n <= 2)
        {
            fibonacci = fibonacci.Take(n).ToList();
        }
        else
        {
            foreach (int _ in Enumerable.Range(1, n - 2))
            {
                var first = fibonacci[fibonacci.Count - 2];
                var second = fibonacci[fibonacci.Count - 1];
                fibonacci.Add(first + second);
            }
        }

        // print numbers
        fibonacci.ForEach(Console.WriteLine);
    }

    private static int ParseArgs(string[] args)
    {
        var error_msg = "Please pass the length of the Fibonacci series as a positive integer.";
        if (args.Length != 1)
        {
            throw new ApplicationException(error_msg);
        }
        else
        {
            int n;
            bool check = int.TryParse(args[0], out n);
            if (!check || n < 1)
            {
                throw new ApplicationException(error_msg);
            }
            return n;
        }
    }
}