using AdventOfCode2020.Enums;

namespace AdventOfCode2020.Helpers
{
    public interface IDayObtainer
    {
        Days TransformToDaysEnum(string day);
    }
}