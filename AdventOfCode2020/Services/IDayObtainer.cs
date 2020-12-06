using AdventOfCode2020.Enums;

namespace AdventOfCode2020.Services
{
    public interface IDayObtainer
    {
        Days TransformToDaysEnum(string day);
    }
}