using AdventOfCode2020.Enums;
using System;

namespace AdventOfCode2020.Services
{
    public class DayObtainer : IDayObtainer
    {
        public Days TransformToDaysEnum(string day)
        {
            if (int.TryParse(day, out var dayValue))
            {
                if (Enum.TryParse<Days>("Day" + dayValue, out var dayEnum))
                {
                    return dayEnum;
                }
            }
            return Days.Unknown;
        } 
    }
}