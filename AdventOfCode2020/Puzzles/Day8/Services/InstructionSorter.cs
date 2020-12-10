using AdventOfCode2020.Puzzles.Day8.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Puzzles.Day8.Services
{
    public class InstructionSorter
    {
        private List<int> _executedInstructions;
        private List<int> _indexesChanged;
        private int _accumulator;

        public int Accumulator
        {
            get => _accumulator;
            set => _accumulator = value;
        }

        public InstructionSorter()
        {
            _executedInstructions = new List<int>();
            _indexesChanged = new List<int>();
        }

        public List<Instruction> GetInstructionList(List<string> list)
        {
            list.RemoveAll(x => string.IsNullOrEmpty(x));
            var instructionList = new List<Instruction>();
            list.ForEach(x =>
            {
                var arrayIntruction = x.Split(' ');
                var type = arrayIntruction[0];
                var val = arrayIntruction[1];

                instructionList.Add(new Instruction(int.Parse(val), Enum.Parse<InstructionType>(type)));
            });
            return instructionList;
        }

        public int RunProgram(List<Instruction> instructionList)
        {
            var i = 0;

            while (!IndexHasBeenExecuted(i))
            {
                RememberExecutedIndex(i);
                var instruction = TakeInstruction(i, instructionList);
                i = ExecuteInstruction(i, instruction, instructionList);
            }

            return _accumulator;
        }

        public int RunProgramToTerminate(List<Instruction> instructionList)
        {
            var lastIndex = instructionList.Count - 1;
            var finished = false;
            while (!finished && !_executedInstructions.Contains(lastIndex))
            {
                _accumulator = 0;
                var i = 0;
                _executedInstructions.Clear();
                var changedInstructionList = ChangeInstructionList(instructionList);
                while (!IndexHasBeenExecuted(i))
                {
                    RememberExecutedIndex(i);
                    var instruction = TakeInstruction(i, changedInstructionList);
                    if (instruction == null)
                    {
                        finished = true;
                        break;
                    }
                    i = ExecuteInstruction(i, instruction, changedInstructionList);
                }
            }
            return _accumulator;
        }

        private List<Instruction> ChangeInstructionList(List<Instruction> instructionList)
        {
            var i = FindIndexToChange(instructionList);
            RememberChangedIndex(i);
            return ChangeListAtIndex(i, instructionList);
        }

        private void RememberChangedIndex(int i)
        {
            _indexesChanged.Add(i);
        }

        private List<Instruction> ChangeListAtIndex(int i, List<Instruction> instructionList)
        {
            var newList = new List<Instruction>();
            foreach(var instr in instructionList)
            {
                newList.Add(new Instruction(instr.InstructionValue, instr.Type));
            }
            
            if (newList[i].Type == InstructionType.jmp)
            {
                newList[i].Type = InstructionType.nop;
            }
            else if (newList[i].Type == InstructionType.nop)
            {
                newList[i].Type = InstructionType.jmp;
            }
            return newList;
        }

        private int FindIndexToChange(List<Instruction> instructionList)
        {
            if (_indexesChanged.Count == 0)
            {
                for (int i = 0; i < instructionList.Count; i++)
                {
                    if (instructionList[i].Type == InstructionType.nop || instructionList[i].Type == InstructionType.jmp)
                    {
                        return i;
                    }
                }
            }
            else
            {
                var lastChangedIndex = _indexesChanged.Last();
                for (int i = 0; i < instructionList.Count; i++)
                {
                    if ((i > lastChangedIndex) && (instructionList[i].Type == InstructionType.nop || instructionList[i].Type == InstructionType.jmp))
                    {
                        return i;
                    }
                }
            }
            return 0;
        }

        private bool LastInstructionExecuted(int lastIndex)
        {
            return _executedInstructions.Contains(lastIndex);
        }

        private bool IndexHasBeenExecuted(int i)
        {
            return _executedInstructions.Contains(i);
        }

        private void RememberExecutedIndex(int i)
        {
            _executedInstructions.Add(i);
        }

        private Instruction TakeInstruction(int i, List<Instruction> instructionList)
        {
            if (instructionList.Count <= i)
            {
                return null;
            }
            return instructionList[i];
        }

        private int ExecuteInstruction(int i, Instruction instruction, List<Instruction> instructionList)
        {
            switch (instruction.Type)
            {
                case InstructionType.acc:
                    _accumulator += instruction.InstructionValue;
                    i++;
                    break;
                case InstructionType.jmp:
                    i += instruction.InstructionValue;
                    break;
                case InstructionType.nop:
                    i++;
                    break;
            }
            return i;
        }
    }
}