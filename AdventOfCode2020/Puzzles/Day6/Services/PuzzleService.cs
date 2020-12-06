using AdventOfCode2020.Services;
using System;

namespace AdventOfCode2020.Puzzles.Day6.Services
{
    public class PuzzleService
    {
        private FileReader _fileReader;
        private GroupDevider _groupDevider;

        public PuzzleService()
        {
            _fileReader = new FileReader();
            _groupDevider = new GroupDevider();
        }

        public void Start()
        {
            var text = _fileReader.ReadFileToPlainText(@"C:\downloads\input.txt");
            var list = _fileReader.ReadTextToList(text);
            var sortedList = _groupDevider.DevideByReturnSymbol(list);
            var sortedByGroupsPart1 = _groupDevider.CreateGroups(sortedList);
            var sortedByGroupsPart2 = _groupDevider.CreateGroupsWithIntersection(sortedList);
            var sum1 = _groupDevider.SumOfCounts(sortedByGroupsPart1);
            var sum2 = _groupDevider.SumOfCounts(sortedByGroupsPart2);
            Console.WriteLine($"Part1: {sum1}");
            Console.WriteLine($"Part2: {sum2}");
            Console.WriteLine($"Press key to continue...");
        }
    }
}