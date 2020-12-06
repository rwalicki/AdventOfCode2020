using AdventOfCode2020.Helpers;

namespace AdventOfCode2020.Services
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
                case Enums.Days.Day6:
                    var puzzleService = new Puzzles.Day6.Services.PuzzleService();
                    puzzleService.Start();
                    break;
                case Enums.Days.Unknown:
                    CloseRequest = true;
                    break;
            }
        }
    }
}