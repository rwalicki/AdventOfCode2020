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

            var bagMapRules = _bagDevider.CreateMapListOfBags(list);
            var bagList = _bagDevider.CreateBagList(bagMapRules);
            var useFullBagList = _bagDevider.BanShinyGoldBag(bagList);
            var result = _bagDevider.ShinyGoldPossibleContainerCount(useFullBagList);
            var result2 = _bagDevider.GetInnerBagsCount("shiny gold", bagMapRules);
            Console.WriteLine($"Part1: {result}");
            Console.WriteLine($"Part2: {result2}");
            Console.WriteLine($"Press key to continue...");
        }
    }
}