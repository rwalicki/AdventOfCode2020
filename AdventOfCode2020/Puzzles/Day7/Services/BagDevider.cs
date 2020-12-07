using AdventOfCode2020.Puzzles.Day7.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Puzzles.Day7.Services
{
    public class BagDevider
    {
        public List<BagRule> CreateMapListOfBags(List<string> ruleList)
        {
            ruleList.RemoveAll(x => string.IsNullOrEmpty(x));
            var list = new List<BagRule>();
            foreach (var rule in ruleList)
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
                list.Add(new BagRule(name, bagsContainer));
            }
            return list;
        }

        public int GetInnerBagsCount(string bagName, List<BagRule> bagMapRules)
        {
            var newElements = true;
            var dependentListRules = new List<string>();

            var rule = bagMapRules.FirstOrDefault(x => x.Name == bagName);
            rule.BagsMap.ToList().ForEach(x => dependentListRules.Add(x.Key));
            

            while (newElements)
            {
                newElements = false;
                var countBeforeIteration = dependentListRules.Count;
                dependentListRules.ToList().ForEach(x =>
                {
                    bagMapRules.FirstOrDefault(y => y.Name == x).BagsMap.ToList().ForEach(z =>
                    {
                        if (!dependentListRules.Contains(z.Key))
                        {
                            dependentListRules.Add(z.Key);
                        }
                    });
                });
                var countAfterIteration = dependentListRules.Count;
                newElements = countBeforeIteration != countAfterIteration;
            }

            var sortedRules = bagMapRules.Where(x => dependentListRules.Contains(x.Name));

            var result = 0;
            var startPoint = rule.BagsMap;
            startPoint.Values.ToList().ForEach(x => result += x);

            var changes = true;
            while (changes)
            {
                changes = false;
                var countBeforeIteration = result;
                var copy = startPoint.ToList();
                startPoint.Clear();

                foreach (var keyPair in copy)
                {
                    var foundRule = sortedRules.First(x => x.Name == keyPair.Key);
                    foreach (var map in foundRule.BagsMap)
                    {
                        var val = map.Value * keyPair.Value;
                        if (startPoint.ContainsKey(map.Key))
                        {
                            startPoint[map.Key] += val;
                        }
                        else
                        {
                            startPoint[map.Key] = val;
                        }
                    }
                }
                startPoint.Values.ToList().ForEach(x => result += x);
                var countAfterIteration = result;
                changes = countBeforeIteration != countAfterIteration;
            }
            return result;
        }

        private List<string> GetBagNames(Dictionary<string, int> dict)
        {
            return dict.Keys.ToList();
        }

        public Bag GetShineBag(List<Bag> bagList)
        {
            return bagList.First(x => x.Name == "shiny gold");
        }

        public int ShinyGoldPossibleContainerCount(List<Bag> bagList)
        {
            var changesOccured = true;
            var possibleBags = new List<Bag>();
            while (changesOccured)
            {
                changesOccured = false;
                bagList.ForEach(x =>
                {
                    if ((x.List.Any(y => y.Name == "shiny gold") || x.List.Select(z => z.Name).Distinct().Intersect(possibleBags.Select(a => a.Name)).ToList().Count != 0) && !possibleBags.Any(b=>b.Name == x.Name))
                    {
                        possibleBags.Add(x);
                        changesOccured = true;
                    }
                });
            }
            return possibleBags.Count;
        }

        private bool IsBagCanContainShinyGold(Bag bag)
        {
            var result = false;
            if (bag.List.Any(x => x.Name == "shiny gold"))
            {
                return true;
            }
            else
            {
                foreach(var b in bag.List)
                {
                    if (IsBagCanContainShinyGold(b))
                    {
                        return true;
                    }
                }
                return result;
            }
        }

        public List<Bag> BanShinyGoldBag(List<Bag> bagList)
        {
            var bag = bagList.First(x => x.Name == "shiny gold");
            bagList.Remove(bag);
            return bagList;
        }

        public List<Bag> CreateBagList(List<BagRule> bagMapRules)
        {
            var list = new List<Bag>();
            foreach (var bagRule in bagMapRules)
            {
                var bag = CreateBag(bagRule, bagMapRules);
                Console.Write($"\r{(int)((float)(bagMapRules.IndexOf(bagRule)) / (bagMapRules.Count) * 100)}% ");
                list.Add(bag);
            }
            Console.Write("\r");
            return list;
        }

        private Bag CreateBag(BagRule bagRule, List<BagRule> bagMapRules)
        {
            var bag = new Bag();
            bag.Name = bagRule.Name;
            foreach(var map in bagRule.BagsMap)
            {
                var rule = bagMapRules.First(x => x.Name == map.Key);
                var b = CreateBag(rule, bagMapRules);
                for (int i = 0; i < map.Value; i++)
                {
                    bag.List.Add(b);
                }
            }
            return bag;
        }
    }
}