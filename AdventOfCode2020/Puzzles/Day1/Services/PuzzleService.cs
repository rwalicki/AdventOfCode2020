using AdventOfCode2020.Services;
using System;

namespace AdventOfCode2020.Puzzles.Day1.Services
{
    public class PuzzleService : IPuzzleService
    {
        private FileReader _fileReader;
        private SummaryFinder _summaryFinder;

        public PuzzleService()
        {
            _fileReader = new FileReader();
            _summaryFinder = new SummaryFinder();
        }

        public void Start()
        {
            var text = _fileReader.ReadFileToPlainText(Environment.CurrentDirectory + @"\..\..\..\Inputs\input1.txt");
            var list = _fileReader.ReadTextToList(text);

            var resultPart1 = _summaryFinder.Find2020SumOfTwoNumbers(list);
            var resultPart2 = _summaryFinder.Find2020SumOfThreeNumbers(list);

            Console.WriteLine($"Part1 (numbers): {resultPart1.Item1} {resultPart1.Item2}");
            Console.WriteLine($"Part1 (multiply): {resultPart1.Item1 * resultPart1.Item2}");
            Console.WriteLine(string.Empty);
            Console.WriteLine($"Part2 (numbers): {resultPart2.Item1} {resultPart2.Item2} {resultPart2.Item3}");
            Console.WriteLine($"Part2 (multiply): {resultPart2.Item1 * resultPart2.Item2 * resultPart2.Item3}");
            
            Console.WriteLine($"Press key to continue...");
        }
    }
}