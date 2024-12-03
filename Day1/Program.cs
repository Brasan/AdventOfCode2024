using System.ComponentModel;

namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
            Console.ReadLine();
        }

        private static int PartTwo()
        {
            int total = 0;
            Dictionary<int, int> occurances = new();
            List<int> listLeft = new();
            List<int> listRight = new();

            var input = File.ReadAllLines("input.txt");
            foreach (var line in input)
            {
                var splitLine = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                listLeft.Add(splitLine[0]);
                listRight.Add(splitLine[1]);
            }

            foreach (var item in listRight)
            {
                if (occurances.ContainsKey(item))
                {
                    occurances[item]++;
                }
                else
                {
                    occurances.Add(item, 1);
                }
            }

            foreach (var item in listLeft)
            {
                if (!occurances.ContainsKey(item)) continue;

                total += occurances[item] * item;
            }

            return total;
        }

        static int PartOne()
        {
            int total = 0;
            List<int> listLeft = new();
            List<int> listRight = new();

            var input = File.ReadAllLines("input.txt");
            foreach (var line in input)
            {
                var splitLine = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                listLeft.Add(splitLine[0]);
                listRight.Add(splitLine[1]);
            }

            listLeft.Sort();
            listRight.Sort();

            for (int i = 0; i < listLeft.Count; i++)
            {
                total += Math.Abs(listLeft[i] - listRight[i]);
            }

            return total;
        }
    }
}
