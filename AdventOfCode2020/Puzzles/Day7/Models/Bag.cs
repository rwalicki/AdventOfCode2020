using System.Collections.Generic;

namespace AdventOfCode2020.Puzzles.Day7.Models
{
    public class Bag
    {
        public string Name { get; set; }
        public List<Bag> List { get; set; }

        public Bag()
        {
            List = new List<Bag>();
        }
    }
}