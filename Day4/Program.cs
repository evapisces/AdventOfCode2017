using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
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
            var validPassphrases = 0;
            foreach (var line in file)
            {
                var words = line.Split(' ').ToList();
                var distinctWords = line.Split(' ').Distinct().ToList();

                if (words.Count == distinctWords.Count)
                {
                    validPassphrases++;
                }
            }

            Console.WriteLine($"Number of valid passphrases = {validPassphrases}");
        }

        private static void PuzzlePartTwo(string[] file)
        {
            var validPassphrases = 0;
            foreach (var line in file)
            {
                
                var words = line.Split(' ').ToList();
                var orderedWords = new List<string>();

                foreach (var word in words)
                {
                    var test = String.Concat(word.OrderBy(w => w));
                    orderedWords.Add(test);
                }

                var distinctWords = orderedWords.Distinct().ToList();

                if (words.Count == distinctWords.Count)
                {
                    validPassphrases++;
                }
            }

            Console.WriteLine($"Number of valid passphrases = {validPassphrases}");
        }
    }
}
