using AdventOfCode2020.Puzzles.Day7.Models;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Puzzles.Day7.Services
{
    public class BagDevider
    {
        public List<Bag> CreateListOfBags(List<string> ruleList)
        {
            ruleList.RemoveAll(x => string.IsNullOrEmpty(x));
            var list = new List<Bag>();
            foreach(var rule in ruleList)
            {
                var splittedRule = rule.Split(" bags contain ");
                var name = splittedRule[0];
                var innerBags = splittedRule[1];
                var innerBagArray = innerBags.Split(", ");
                var bagsContainer = new Dictionary<string, int>();
                innerBagArray.ToList().ForEach(x =>
                {
                    var numName = x.Split(" bag")[0];
                    if (numName != "no other")
                    {
                        var innerBagNumberStr = numName.Split(' ')[0];
                        var innerBagNumber = int.Parse(innerBagNumberStr);
                        var innerBagName = numName.Substring(innerBagNumberStr.Length + 1);
                        bagsContainer[innerBagName] = innerBagNumber;
                    }
                });
                list.Add(new Bag(name, bagsContainer));
            }
            return list;
        }
    }
}