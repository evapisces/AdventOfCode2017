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
            Tower = new List<Disk>();
            SetupTower(file);
            PuzzlePartA(file);

            Console.Read();
        }

        private static void SetupTower(string[] file)
        {
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

                if (splits.Length == 2)    // disks underneath
                {
                    var right = splits[1];
                    var newSplits = right.Split(new string[] { ", " }, StringSplitOptions.None);

                    if (Tower.FirstOrDefault(d => d.Name == name).Below == null)
                    {
                        Tower.FirstOrDefault(d => d.Name == name).Below = new List<Disk>();
                    }

                    foreach (var newSplit in newSplits)
                    {
                        if (Tower.Any(d => d.Name == newSplit))
                        {
                            var existingDisk = Tower.Find(d => d.Name == newSplit);
                            Tower.FirstOrDefault(d => d.Name == name).Below.Add(existingDisk);
                        }
                        else
                        {
                            Tower.FirstOrDefault(d => d.Name == name).Below.Add(new Disk
                            {
                                Name = newSplit
                            });
                        }
                    }
                }
            }
        }

        /*private static void PrintItems()
        {
            PrintItems(0);
        }

        private static void PrintItems(int levelOfIndentation)
        {
            foreach (var disk in Tower)
            {
                Console.WriteLine(disk.Name);
                Console.WriteLine(levelOfIndentation);
                PrintItems(levelOfIndentation + 1);
            }
        }*/

        private void IterateTower(List<Disk> tower)
        {
            
        }

        private static void PuzzlePartA(string[] file)
        {
            var test = new List<Disk>();

            //IterateTower()

            foreach (var disk in Tower)
            {
                if (disk.Below?.Count > 0)
                {
                    test.Add(disk);
                }
            }

            while (test.Count > 1)
            {
                foreach (var t in test)
                {
                    if (t.Below?.Count == 0)
                    {
                        test.Remove(t);
                    }
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
