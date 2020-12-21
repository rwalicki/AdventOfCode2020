using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Services
{
    public class ConverterService
    {
        public List<int> ConvertToInt(List<string> list)
        {
            list.RemoveAll(x=>string.IsNullOrEmpty(x));
            return list.Select(x => int.Parse(x)).ToList();
        }

        public List<double> ConvertToDouble(List<string> list)
        {
            list.RemoveAll(x => string.IsNullOrEmpty(x));
            return list.Select(x => double.Parse(x)).ToList();
        }
    }
}