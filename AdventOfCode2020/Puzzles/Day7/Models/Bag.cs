using System.Collections.Generic;

namespace AdventOfCode2020.Puzzles.Day7.Models
{
    public class Bag
    {
        private readonly string _name;
        private readonly Dictionary<string, int> _bagsContainer;

        public Bag(string name, Dictionary<string, int> bagsContainer)
        {
            _name = name;
            _bagsContainer = bagsContainer;
        }
    }
}