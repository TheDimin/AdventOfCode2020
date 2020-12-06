using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Assignments
{
    class DayTwo : DayAssignment
    {
        public override int Day { get; } = 2;

        public override void Init()
        {
        }

        public override string A()
        {
            int validCounter = 0;
            foreach (var line in ReadLines("DayTwo.txt"))
            {
                string[] splitLine = line.Split(' ');

                int occurrenceCount = splitLine[2].Count(c => c == splitLine[1][0]);

                string[] countSplit = splitLine[0].Split('-');

                if (occurrenceCount >= int.Parse(countSplit[0]) && occurrenceCount <= int.Parse(countSplit[1]))
                {
                    validCounter++;
                }
            }

            return $"  {validCounter} Valid passwords";
        }

        public override string B()
        {
            int validCounter = 0;
            foreach (var line in ReadLines("DayTwo.txt"))
            {
                string[] splitLine = line.Split(' ');

                string[] countSplit = splitLine[0].Split('-');

                if (splitLine[2][int.Parse(countSplit[0]) - 1] == splitLine[1][0] ^ splitLine[2][int.Parse(countSplit[1]) - 1] == splitLine[1][0])
                {
                    validCounter++;
                    continue;
                }

                Console.WriteLine($" chars A: {splitLine[2][int.Parse(countSplit[0]) - 1]} B: {splitLine[2][int.Parse(countSplit[1]) - 1]} TargetChar: {splitLine[1][0]} , Answers A: {splitLine[2][int.Parse(countSplit[0]) - 1] == splitLine[1][1]} B: {splitLine[2][int.Parse(countSplit[1]) - 1] == splitLine[1][1]}");

            }

            return $"  {validCounter} Valid passwords";
        }
    }
}
