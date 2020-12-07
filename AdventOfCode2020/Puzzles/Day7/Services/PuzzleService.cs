using AdventOfCode2020.Services;
using System;

namespace AdventOfCode2020.Puzzles.Day7.Services
{
    public class PuzzleService : IPuzzleService
    {
        private FileReader _fileReader;
        private BagDevider _bagDevider;

        public PuzzleService()
        {
            _fileReader = new FileReader();
            _bagDevider = new BagDevider();
        }

        public void Start()
        {
            var text = _fileReader.ReadFileToPlainText(Environment.CurrentDirectory + @"\..\..\..\Inputs\input7.txt");
            var list = _fileReader.ReadTextToList(text);

            var bagList = _bagDevider.CreateListOfBags(list);

            //Console.WriteLine($"Part1: {sum1}");
            //Console.WriteLine($"Part2: {sum2}");
            Console.WriteLine($"Press key to continue...");
        }
    }
}