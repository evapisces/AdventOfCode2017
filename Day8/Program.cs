using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day8
{
    public class Program
    {
        public static List<Instruction> Instructions { get; set; }
        public static Dictionary<string, int> Registers { get; set; }
        public static void Main(string[] args)
        {
            Instructions = new List<Instruction>();
            Registers = new Dictionary<string, int>();
            var file = File.ReadAllLines("../../input.txt");

            ProcessFile(file);
            PuzzlePartA();

            Instructions.Clear();
            Registers.Clear();
            ProcessFile(file);
            PuzzlePartB();

            Console.Read();
        }

        private static void ProcessFile(string[] file)
        {
            foreach (var line in file)
            {
                var splits = line.Split(' ');
                var instruction = new Instruction
                {
                    Name = splits[0],
                    IncrDecr = splits[1],
                    Amount = Convert.ToInt32(splits[2]),
                    Condition = new Condition
                    {
                        Left = splits[4],
                        Operand = splits[5],
                        Right = splits[6]
                    }
                };

                Instructions.Add(instruction);

                if (!Registers.ContainsKey(instruction.Name))
                {
                    Registers.Add(instruction.Name, 0);
                }
            }
        }

        private static void PuzzlePartA()
        {
            foreach (var instruction in Instructions)
            {
                var registerValue = 0;
                var condition = instruction.Condition;
                Registers.TryGetValue(condition.Left, out registerValue);

                // if a < 10

                if (condition.Operand.Operator(registerValue, Convert.ToInt32(condition.Right)))
                {
                    switch (instruction.IncrDecr)
                    {
                        case "inc":
                            Registers[instruction.Name] += instruction.Amount;
                            break;
                        case "dec":
                            Registers[instruction.Name] -= instruction.Amount;
                            break;
                    }
                }
            }

            var maxValue = Registers.Values.Max();
            Console.WriteLine("Maximum value in a register = " + maxValue);
        }

        private static void PuzzlePartB()
        {
            var maxValue = 0;
            foreach (var instruction in Instructions)
            {
                var registerValue = 0;
                var condition = instruction.Condition;
                Registers.TryGetValue(condition.Left, out registerValue);

                if (condition.Operand.Operator(registerValue, Convert.ToInt32(condition.Right)))
                {
                    switch (instruction.IncrDecr)
                    {
                        case "inc":
                            Registers[instruction.Name] += instruction.Amount;
                            break;
                        case "dec":
                            Registers[instruction.Name] -= instruction.Amount;
                            break;
                    }
                }
                var max = Registers.Values.Max();

                if (max > maxValue)
                {
                    maxValue = max;
                }
            }

            Console.WriteLine("Largest value in a register ever = " + maxValue);
        }
    }

    public class Instruction
    {
        public string Name { get; set; }
        public string IncrDecr { get; set; }
        public int Amount { get; set; }
        public Condition Condition { get; set; }
    }
    
    public class Condition
    {
        public string Left { get; set; }
        public string Operand { get; set; }
        public string Right { get; set; }
    }

    public class Register
    {
        public char Name { get; set; }
        public int Value { get; set; }
    }

    public static class Extension
    {
        public static Boolean Operator(this string logic, int x, int y)
        {
            switch (logic)
            {
                case ">": return x > y;
                case "<": return x < y;
                case "==": return x == y;
                case ">=": return x >= y;
                case "<=": return x <= y;
                case "!=": return x != y;
                default: throw new Exception("invalid logic");
            }
        }
    }
}
