namespace Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var total = 0;
            var input = File.ReadAllLines("input.txt");
            foreach (var line in input)
            {
                if (IsSafe(line))
                {
                    total++;
                }
            }

            Console.WriteLine(total);
            total = 0;

            foreach (var line in input)
            {
                if (IsSafeEnough(line))
                {
                    total++;
                }
            }
            Console.WriteLine(total);
        }

        static bool IsSafe(string report)
        {
            bool hasIncreased = false;
            bool hasDecreased = false;

            int[] splitReport = report.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            for (int i = 0; i < splitReport.Length - 1; i++)
            {
                int difference = splitReport[i + 1] - splitReport[i];

                if (Math.Abs(difference) > 3 || Math.Abs(difference) == 0) return false;
                if (difference > 0) hasIncreased = true;
                if (difference < 0) hasDecreased = true;

                if (hasIncreased && hasDecreased) return false;
            }
            return true;
        }

        static bool IsSafe(List<int> report)
        {
            bool hasIncreased = false;
            bool hasDecreased = false;


            for (int i = 0; i < report.Count - 1; i++)
            {
                int difference = report[i + 1] - report[i];

                if (Math.Abs(difference) > 3 || Math.Abs(difference) == 0) return false;
                if (difference > 0) hasIncreased = true;
                if (difference < 0) hasDecreased = true;

                if (hasIncreased && hasDecreased) return false;
            }
            return true;
        }

        static bool IsSafeEnough(string report)
        {
            uint dangerLevel = 0;
            bool hasIncreased = false;
            bool hasDecreased = false;

            List<int> splitReport = report.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            if (IsSafe(splitReport)) return true;

            for (int i = 0; i < splitReport.Count; i++)
            {
                List<int> tempReport = new();
                tempReport = tempReport.Concat(splitReport).ToList();
                tempReport.RemoveAt(i);
                if (IsSafe(tempReport)) return true;
            }

            return false;
        }
    }
}
