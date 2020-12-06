using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    abstract class DayAssignment
    {
        public abstract int Day { get; }

        public static IEnumerable<string> ReadLines(string FileName) =>
            File.ReadLines(Directory.GetCurrentDirectory() + @"\Data\" + FileName);

        public IEnumerable<string> ReadLines() => File.ReadLines(Directory.GetCurrentDirectory() + @"\Data\" + GetType().Name + ".txt");

        public int[] ParseFileToIntArray()
        {
            List<int> values = new List<int>();
            int lastInt = 0;
            foreach (var line in File.ReadLines(Directory.GetCurrentDirectory() + @"\Data\" + GetType().Name + ".txt"))
            {
                if (int.TryParse(line, out lastInt))
                {
                    values.Add(lastInt);
                }
            }

            return values.ToArray();
        }


        public abstract void Init();

        public abstract string A();

        public abstract string B();
    }
}
