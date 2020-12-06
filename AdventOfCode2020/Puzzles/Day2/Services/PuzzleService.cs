using AdventOfCode2020.Services;
using System;

namespace AdventOfCode2020.Puzzles.Day2.Services
{
    public class PuzzleService : IPuzzleService
    {
        private FileReader _fileReader;
        private readonly PasswordValidator _validator;

        public PuzzleService()
        {
            _fileReader = new FileReader();
            _validator = new PasswordValidator();
        }

        public void Start()
        {
            var text = _fileReader.ReadFileToPlainText(Environment.CurrentDirectory + @"\..\..\..\Inputs\input2.txt");
            var list = _fileReader.ReadTextToList(text);

            var result = _validator.GetValidPasswords(list);

            Console.WriteLine($"Part1 (ValidPasswords): {result}");
            //Console.WriteLine($"Part1 (multiply): {resultPart1.Item1 * resultPart1.Item2}");
            //Console.WriteLine(string.Empty);
            //Console.WriteLine($"Part2 (numbers): {resultPart2.Item1} {resultPart2.Item2} {resultPart2.Item3}");
            //Console.WriteLine($"Part2 (multiply): {resultPart2.Item1 * resultPart2.Item2 * resultPart2.Item3}");

            Console.WriteLine($"Press key to continue...");
        }
    }
}
