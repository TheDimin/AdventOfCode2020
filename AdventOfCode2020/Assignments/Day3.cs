using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Assignments
{
    class Day3 : DayAssignment
    {
        private char[,] map;

        private int width, height = 0;

        public override int Day { get; } = 3;
        public override void Init()
        {
            var fileReader = ReadLines().ToArray();

            int height = fileReader.Length;
            int width = fileReader.First().Length;

            map = new char[height, width];


            int h = 0;
            int w = 0;
            foreach (var line in fileReader)
            {
                foreach (var c in line)
                {
                    map[h, w++] = c;
                }

                w = 0;
                h++;
            }
        }

        private int GetEncounters(int y, int x)
        {
            int treeCounter = 0;

            for (height = 0, width = 0; height < map.GetLength(0); height += x, width += y)
            {
                if (width >= map.GetLength(1))
                {
                    width = width - map.GetLength(1);
                }

                if (map[height, width] == '#')
                    treeCounter++;
            }

            return treeCounter;
        }

        public override string A()
        {
            return $"Encounterd {GetEncounters(3, 1)} Trees";
        }

        public override string B()
        {
            int total = GetEncounters(1, 1);

            total *= GetEncounters(3, 1);

            total *= GetEncounters(5, 1);
            total *= GetEncounters(7, 1);
            total *= GetEncounters(1, 2);

            return $"Sum of encounters : " + total;
        }
    }
}
