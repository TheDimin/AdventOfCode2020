using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Assignments
{
    class Day10 : DayAssignment
    {
        public override int Day { get; } = 10;
        private List<int> volts = new List<int>();
        public override void Init()
        {
            volts.Clear();
            foreach (var line in ReadLines())
            {
                volts.Add(int.Parse(line));
            }
            volts.Add(0);
            volts.Sort();
            volts.Add(volts.Last());
            volts.Sort();
        }

        public override string A()
        {
            Dictionary<int, int> voltdiff = new Dictionary<int, int>();
            int currentVolt = 0;
            for (int i = 1; i < volts.Count; i++)
            {
                currentVolt = volts[i - 1];
                int dif = volts[i] - currentVolt;
                if (!voltdiff.ContainsKey(dif))
                    voltdiff.Add(dif, 1);
                else
                    voltdiff[dif]++;
            }
            return $"multiplied answer {voltdiff[1] * voltdiff[3]}";
        }

        private long ValidConnections()
        {
            Dictionary<int, long> cahced = new Dictionary<int, long>();
            for (int i = volts.Count - 1; i > -1; i--)
            {
                int volt = volts[i];
                if (!cahced.ContainsKey(volt))
                {
                    long amount = 0;
                    for (int j = 1; j < 4; j++)
                    {
                        if (i + j >= volts.Count)
                        {
                            amount = 1;
                            break;
                        }

                        int otherVolt = volts[i + j];
                        int dif = otherVolt - volt;
                        if (dif >= 1 && dif <= 3)
                            amount += cahced[otherVolt];
                    }
                    cahced.Add(volt, amount);
                }
            }

            return cahced[volts[0]];
        }

        public override string B()
        {
            return $"{ValidConnections()} Connections";
        }
    }
}
