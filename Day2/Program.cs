using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var file = File.ReadAllLines("../../input.txt");
            Console.WriteLine("Part 1:");
            Console.WriteLine("=======");
            PuzzlePartOne(file);

            Console.WriteLine("\n\nPart 2:");
            Console.WriteLine("=======");
            PuzzlePartTwo(file);

            Console.Read();
        }

        private static void PuzzlePartOne(string[] file)
        {
            var sum = 0;

            foreach (var line in file)
            {
                var row = line.Replace('\t', ' ').Split(' ').Select(Int32.Parse).ToList();
                var max = row.Max();
                var min = row.Min();
                var diff = max - min;

                sum += diff;
            }

            Console.WriteLine($"CHECKSUM = {sum}");
        }

        private static void PuzzlePartTwo(string[] file)
        {
            var sum = 0;

            foreach (var line in file)
            {
                var row = line.Replace('\t', ' ').Split(' ').Select(Int32.Parse).ToList();

                for (var i = 0; i < row.Count; i++)
                {
                    var item = row[i];

                    var test = row.FirstOrDefault(r => r % item == 0 && r != row[i]);

                    if (test > 0)
                    {
                        sum += test / item;
                        break;
                    }
                }
            }

            Console.WriteLine($"SUM = {sum}");
        }
    }
}
