using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Game game = new Game();
            game.SetWords();

            Console.WriteLine("Ready?");
            Console.ReadLine();
            Console.WriteLine("Go!");
            Console.WriteLine();

            game.Input();

            Console.WriteLine();
            Console.WriteLine("Finish!");

            Console.ReadLine();
        }
    }

    class Game
    {
        Stopwatch stopwatch = new Stopwatch();
        List<string> words = new List<string>();
        int i = 0;

        public void SetWords()
        {
            using (var sr = new StreamReader(@"..\..\TextFile1.txt"))
            {
                while (!sr.EndOfStream)
                {
                    words.Add(sr.ReadLine());
                }
            }
            words = words.OrderBy(i => Guid.NewGuid()).ToList();
        }

        public void Input()
        {
            stopwatch.Start();
            while (true)
            {
                if (i >= words.Count)
                    break;

                Console.WriteLine($"{words[i]}");

                var input = Console.ReadLine();
                if (words[i] == input)
                {
                    i++;
                    Console.Clear();
                    Console.WriteLine("OK!");
                    Console.WriteLine();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Retry...");
                    Console.WriteLine();
                }
            }
        }

        public void TimeSpanTest()
        {
            stopwatch.Start();
            int count = 0;
            while (count <= 10000)
            {
                Console.WriteLine(stopwatch.Elapsed.ToString(@"mm\:ss\:ff"));
                count++;
            }
        }
    }
}
