using System.Collections.Generic;

namespace AdventOfCode2020.Puzzles.Day7.Models
{
    public class BagRule
    {
        public string Name { get; set; }
        public Dictionary<string, int> BagsMap { get; set; }

        public BagRule(string name, Dictionary<string, int> bagsMap)
        {
            Name = name;
            BagsMap = bagsMap;
        }
    }
}