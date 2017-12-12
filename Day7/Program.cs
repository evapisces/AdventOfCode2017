using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    public class Program
    {
        public static List<Disk> Tower { get; set; }
        public static void Main(string[] args)
        {
            var file = File.ReadAllLines("../../testinput.txt");

            PuzzlePartA(file);

            Console.Read();
        }

        private static void PuzzlePartA(string[] file)
        {
            Tower = new List<Disk>();

            foreach (var line in file)
            {
                var splits = line.Split(new string[] { " -> " }, StringSplitOptions.None);
                var left = splits[0];
                var name = left.Split(' ')[0];
                var weight = Convert.ToInt32(left.Split(' ')[1].Replace("(", "").Replace(")", ""));

                if (Tower.Any(t => t.Name == name))
                {
                    var disk = Tower.FirstOrDefault(t => t.Name == name);
                    disk.Weight = weight;
                }
                else
                {
                    var disk = new Disk
                    {
                        Name = name,
                        Weight = weight
                    };
                    Tower.Add(disk);
                }

                if (splits.Count() == 2)    // disks underneath
                {
                    var right = splits[1];
                    var newSplits = right.Split(new string[] { ", " }, StringSplitOptions.None);

                    Tower.FirstOrDefault(d => d.Name == name).Below = new List<Disk>();
                    foreach (var newSplit in newSplits)
                    {
                        Tower.FirstOrDefault(d => d.Name == name).Below.Add(new Disk
                        {
                            Name = newSplit
                        });
                    }
                }
                else
                {
                    
                }
            }
        }
    }

    public class Disk
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public List<Disk> Above { get; set; }
        public List<Disk> Below { get; set; }
    }
}
