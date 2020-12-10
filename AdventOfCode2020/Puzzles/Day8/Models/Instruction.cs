namespace AdventOfCode2020.Puzzles.Day8.Models
{
    public class Instruction
    {
        public int InstructionValue { get; set; }
        public InstructionType Type { get; set; }

        public Instruction(int instructionValue, InstructionType type)
        {
            InstructionValue = instructionValue;
            Type = type;
        }
    }
}