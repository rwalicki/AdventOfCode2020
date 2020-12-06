using AdventOfCode2020.Services;
using System;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new PuzzlePicker();
            while (!service.CloseRequest)
            {
                Console.Clear();
                Console.WriteLine("*** AdventOfCode 2020 ***");
                Console.WriteLine("");
                Console.Write("Choose day (1-24): ");
                var day = Console.ReadLine();
                service.Start(day);
            }
            Console.WriteLine("*** End ***");
            Console.Read();
        }
    }
}