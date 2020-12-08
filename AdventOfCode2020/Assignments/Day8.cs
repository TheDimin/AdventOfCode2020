using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2020.Assignments
{
    class Day8 : DayAssignment
    {

        class Instruction
        {
            public int line = 0;
            public string command = "NONE";
            public int amount = 0;
            public int ExecutionCounter = 0;
            public bool HasBeenExecuted = false;

            public override string ToString()
            {
                return $"{command} : {amount}";
            }

            public int Execute(int globalCounter, ref List<Instruction> program, out bool FoundLoop)
            {
                FoundLoop = false;
                switch (command)
                {
                    case "acc":
                        {
                            if (HasBeenExecuted)
                            {
                                FoundLoop = true;
                                return globalCounter;
                            }
                            globalCounter += amount;
                            goto default;
                        }
                    case "jmp":
                        JMP:
                        {
                            if (HasBeenExecuted)
                            {
                                FoundLoop = true;
                                return globalCounter;
                            }

                            HasBeenExecuted = true;
                            if (line + amount >= program.Count)
                            {
                                return globalCounter;
                            }

                            int a = program[line + amount].Execute(globalCounter, ref program, out FoundLoop);
                            if (FoundLoop)
                            {
                                goto default;//Recursion detected ignore those values
                            }
                            return a;
                        }
                    case "nop":
                        {
                            if (HasBeenExecuted)
                            {
                                FoundLoop = true;
                                return globalCounter;
                            }

                            goto default;
                        }
                    default:
                        {
                            HasBeenExecuted = true;
                            if (line + 1 < program.Count)
                            {
                                return program[line + 1].Execute(globalCounter, ref program, out FoundLoop);
                            }
                            else
                            {
                                return globalCounter;
                            }
                        }
                }
            }
        }

        private List<Instruction> program = new List<Instruction>();


        public override int Day { get; } = 8;
        public override void Init()
        {
            var lines = ReadLines().ToArray();
            program = new List<Instruction>(lines.Count());
            int lineIndex = 0;
            foreach (var line in lines)
            {

                var sline = line.Split(' ');
                program.Add(new Instruction() { command = sline[0], amount = int.Parse(sline[1]), line = lineIndex });
                lineIndex++;
            }
        }


        void Clear()
        {
            foreach (var instruction in program)
            {
                instruction.ExecutionCounter = 0;
            }
        }

        public override string A()
        {
            int globalCounter = 0;
            int currentLine = 0;
            Instruction currentInstruction = program[0];

            while (currentInstruction != null && currentInstruction.ExecutionCounter != 1)
            {
                currentInstruction.ExecutionCounter++;
                switch (currentInstruction.command)
                {
                    case "acc":
                        {
                            globalCounter += currentInstruction.amount;
                            goto default;
                        }
                    case "jmp":
                        {
                            currentLine += currentInstruction.amount;
                            currentInstruction = program[currentLine];
                            break;
                        }
                    default:
                        {
                            currentLine++;
                            if (currentLine >= program.Count)
                                currentInstruction = null;
                            else
                                currentInstruction = program[currentLine];
                            break;
                        }
                }
            }

            return $" Global value: {globalCounter}";
        }



        public override string B()
        {
            int globalCounter = 0;
            Instruction currentInstruction = program[0];
            Clear();

            globalCounter = currentInstruction.Execute(globalCounter, ref program, out _);


            return $" Global value: {globalCounter} :: {currentInstruction.ExecutionCounter} ";
        }
    }
}
