using AdventOfCode2020.Helpers;
using System;

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
            if(day == Enums.Days.Unknown)
            {
                CloseRequest = true;
            }
        }
    }
}