using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2020.Assignments
{
    class Day7 : DayAssignment
    {
        Dictionary<string, Dictionary<string, int>> backtypes = new Dictionary<string, Dictionary<string, int>>();

        public override int Day { get; } = 7;
        public override void Init()
        {
            Regex kpSplit = new Regex("s contain ");
            Regex rSplit = new Regex(", |\\.");

            var dic = new Dictionary<string, int>();
            foreach (var bagInfo in ReadLines())
            {
                var split = kpSplit.Split(bagInfo);

                dic = new Dictionary<string, int>();
                var t = rSplit.Split(split[1]);
                foreach (var value in t)
                {
                    if (value == "no other bags")
                        break;
                    if (value == "" || value == " ")
                        continue;
                    string v = value.Replace("bags", "bag");

                    dic.Add(v.Substring(2, v.Length - 2), int.Parse(value[0].ToString()));
                }

                backtypes.Add(split[0], dic);
            }
            return;
        }


        public override string A()
        {

            int totalAmount = 0;
            Stack<string> bagsToSearch = new Stack<string>();
            List<string> searched = new List<string>();
            bagsToSearch.Push("shiny gold bag");
            do
            {
                string ce = bagsToSearch.Pop();
                foreach (var a in backtypes)
                {
                    if (a.Value.ContainsKey(ce) && !searched.Contains(a.Key))
                    {
                        bagsToSearch.Push(a.Key);
                        searched.Add(a.Key);
                        totalAmount++;
                    }
                }


            } while (bagsToSearch.Count != 0);

            return $"TotalAmount: {totalAmount}";
        }

        public int CountBags(string name)
        {
            int amount = 1;
            foreach (var backpack in backtypes[name])
                amount += backpack.Value * CountBags(backpack.Key);

            return amount;
        }

        public override string B()
        {
            int totalAmount = -1;
            totalAmount += CountBags("shiny gold bag");

            return $"TotalAmount: {totalAmount}";
        }
    }
}
