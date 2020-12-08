using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Assignments
{
    class Day6 : DayAssignment
    {
        private Dictionary<char, int> answers = new Dictionary<char, int>();
        private int totalSum;
        public override int Day { get; } = 6;
        public override void Init()
        {
            throw new NotImplementedException();
        }


        public override string A()
        {
            foreach (var line in ReadLines())
            {
                if (line == "")
                {
                    totalSum += answers.Count;
                    answers.Clear();
                    continue;
                }

                foreach (var answer in line)
                {
                    if (!answers.ContainsKey(answer))
                        answers.Add(answer, 1);
                }
            }

            totalSum += answers.Count();

            return "sum of answers:" + totalSum;
        }



        public override string B()
        {
            answers.Clear();
            totalSum = 0;
            int userCount = 0;
            foreach (var line in ReadLines())
            {
                if (line == "")
                {
                    foreach (var an in answers)
                    {
                        if (an.Value == userCount)
                            totalSum++;
                    }
                    answers.Clear();
                    userCount = 0;
                    continue;
                }

                userCount++;
                foreach (var answer in line)
                {
                    if (!answers.ContainsKey(answer))
                        answers.Add(answer, 1);
                    else
                        answers[answer]++;
                }
            }

            foreach (var an in answers)
            {
                if (an.Value == userCount)
                    totalSum++;
            }

            return "sum of answers:" + totalSum;
        }
    }
}
