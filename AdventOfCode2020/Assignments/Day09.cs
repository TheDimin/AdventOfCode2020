using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Assignments
{
    class Day09 : DayAssignment
    {
        public override int Day { get; } = 9;
        private const int preamble = 5;
        private List<long> numbers;
        private long invalidProperty = 0;
        private int invalidIndex = 0;
        public override void Init()
        {
            string[] data = ReadLines().ToArray();
            numbers = new List<long>(data.Length);
            for (int i = 0; i < data.Length; i++)
            {
                numbers.Add(long.Parse(data[i]));
            }

        }

        public override string A()
        {
            for (int CurrentNum = preamble; CurrentNum < numbers.Count; CurrentNum++)
            {
                bool found = false;
                for (int NumA = CurrentNum - preamble; NumA < CurrentNum; NumA++)
                {
                    for (int NumB = NumA; NumB < CurrentNum; NumB++)
                    {
                        if (numbers[NumA] + numbers[NumB] == numbers[CurrentNum])
                        {
                            invalidIndex = CurrentNum;
                            found = true;
                            break;

                        }
                    }
                    if (found)
                        break;
                }

                if (!found)
                {
                    invalidProperty = numbers[CurrentNum];
                    return $"Found the odd number: {invalidProperty}";
                }
            }

            return "Failed to find odd one";
        }

        public override string B()
        {
            for (int NumA = 0; NumA < invalidIndex - preamble; NumA++)
            {
                for (int NumB = NumA; NumB < invalidIndex; NumB++)
                {
                    List<long> t = numbers.GetRange(NumA, NumB);
                    if (t.Sum() == invalidProperty)
                    {
                        t.Sort();
                        return $"Encryption weakness: {t[0] + t.Last()}";
                    }
                }
            }
            return "Failed to find odd one";
        }
    }
}
