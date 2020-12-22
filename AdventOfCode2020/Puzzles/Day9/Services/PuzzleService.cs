using AdventOfCode2020.Services;
using System;

namespace AdventOfCode2020.Puzzles.Day9.Services
{
    public class PuzzleService : IPuzzleService
    {
        private FileReader _fileReader;
        private PreambleService _service;

        public PuzzleService()
        {
            _fileReader = new FileReader();
            _service = new PreambleService(25);
        }

        public void Start()
        {
            var text = _fileReader.ReadFileToPlainText(Environment.CurrentDirectory + @"\..\..\..\Inputs\input9.txt");
            var list = _fileReader.ReadTextToList(text);

            var result1 = _service.FindInvalidElement(list);
            var result2 = _service.FindContiguousSetResult(list, result1);
            Console.WriteLine($"Part1: {result1}");
            Console.WriteLine($"Part1: {result2}");
            Console.WriteLine($"Press key to continue...");
        }
    }
}