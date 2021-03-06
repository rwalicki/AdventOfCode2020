﻿namespace AdventOfCode2020.Services
{
    public class PuzzlePicker
    {
        public bool CloseRequest { get; private set; }

        private IDayObtainer _dayObtainerService;

        public PuzzlePicker()
        {
            _dayObtainerService = new DayObtainer();
        }

        public void Start(string inputText)
        {
            var day = _dayObtainerService.TransformToDaysEnum(inputText);
            switch (day)
            {
                case Enums.Days.Day1:
                    var puzzleServiceDay1 = new Puzzles.Day1.Services.PuzzleService();
                    puzzleServiceDay1.Start();
                    break;
                case Enums.Days.Day2:
                    var puzzleServiceDay2 = new Puzzles.Day2.Services.PuzzleService();
                    puzzleServiceDay2.Start();
                    break;
                case Enums.Days.Day6:
                    var puzzleServiceDay6 = new Puzzles.Day6.Services.PuzzleService();
                    puzzleServiceDay6.Start();
                    break;
                case Enums.Days.Day7:
                    var puzzleServiceDay7 = new Puzzles.Day7.Services.PuzzleService();
                    puzzleServiceDay7.Start();
                    break;
                case Enums.Days.Day8:
                    var puzzleServiceDay8 = new Puzzles.Day8.Services.PuzzleService();
                    puzzleServiceDay8.Start();
                    break;
                case Enums.Days.Day9:
                    var puzzleServiceDay9 = new Puzzles.Day9.Services.PuzzleService();
                    puzzleServiceDay9.Start();
                    break;
                case Enums.Days.Unknown:
                    CloseRequest = true;
                    break;
            }
        }
    }
}