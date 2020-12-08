using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Assignments
{
    class Day1 : DayAssignment
    {
        private int[] numbers;


        public override int Day { get; } = 1;

        public override void Init()
        {
            numbers = ParseFileToIntArray();
        }

        public override string A()
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i; j < numbers.Length; j++)
                {
                    var n3 = numbers[i] + numbers[j];
                    if (n3 == 2020)
                        return (numbers[i] * numbers[j]).ToString();
                }
            }
            return "NO ANSWER FOUND";
        }

        public override string B()
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i; j < numbers.Length; j++)
                {
                    for (int k = j; k < numbers.Length; k++)
                    {
                        var n3 = numbers[i] + numbers[j] + numbers[k];
                        if (n3 == 2020)
                            return (numbers[i] * numbers[j] * numbers[k]).ToString();
                    }
                }
            }

            return "NO ANSWER FOUND";
        }
    }
}
