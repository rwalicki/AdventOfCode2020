using AdventOfCode2020.Services;
using System;

namespace AdventOfCode2020.Puzzles.Day8.Services
{
    public class PuzzleService : IPuzzleService
    {
        private FileReader _fileReader;
        private InstructionSorter _service;

        public PuzzleService()
        {
            _fileReader = new FileReader();
            _service = new InstructionSorter();
        }

        public void Start()
        {
            var text = _fileReader.ReadFileToPlainText(Environment.CurrentDirectory + @"\..\..\..\Inputs\input8.txt");
            var list = _fileReader.ReadTextToList(text);
            var instructionList = _service.GetInstructionList(list);
            var result1 = _service.RunProgram(instructionList);
            var result2 = _service.RunProgramToTerminate(instructionList);
            Console.WriteLine($"Part1: {result1}");
            Console.WriteLine($"Part2: {result2}");
            Console.WriteLine($"Press key to continue...");
        }
    }
}