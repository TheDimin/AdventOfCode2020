//#define DEVELOP

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using AdventOfCode2020.Assignments;



namespace AdventOfCode2020
{

    class LogThrow : Exception
    {
        public LogThrow(string message) : base(message)
        {
        }
    }
    static class Application
    {
        private static Dictionary<int, DayAssignment> assignments = new Dictionary<int, DayAssignment>();

        static void Main(string[] args)
        {
            foreach (Type type in Assembly.GetAssembly(typeof(DayAssignment)).GetTypes().Where(classType =>
                classType.IsClass && !classType.IsAbstract && classType.IsSubclassOf(typeof(DayAssignment))))
            {
                var assignment = (DayAssignment)Activator.CreateInstance(type);
                assignments.Add(assignment.Day, assignment);
            }

            while (true)
            {

                int targetDay = 8;
#if !DEVELOP
                if (args.Length == 0)
                {
                    bool invalid;

                    do
                    {
                        Console.Clear();
                        Console.Write("Load day: ");
                        invalid = !int.TryParse(Console.ReadLine(), out targetDay);
                        if (!invalid)
                            invalid = !assignments.ContainsKey(targetDay);
                    } while (invalid);
                }
                else
                {
                    targetDay = int.Parse(args[0]);
                }
#endif
                Console.Clear();
                Stopwatch timer = new Stopwatch();
                TimeSpan InitTime;
                TimeSpan ATime;
                TimeSpan BTime;

                try
                {
                    timer.Start();
                    assignments[targetDay].Init();
                }
                catch (NotImplementedException)
                {
                }

                InitTime = timer.Elapsed;

                Console.WriteLine($"Day: {targetDay} \n\n");
                Console.WriteLine("Assignment A: ");

                try
                {
                    timer.Restart();
                    Console.WriteLine(assignments[targetDay].A());
                }
                catch (NotImplementedException)
                {
                    Console.WriteLine("Not Implemented");
                }

                ATime = timer.Elapsed;

                Console.WriteLine("");
                Console.WriteLine("=========================");
                Console.WriteLine("");
                Console.WriteLine("Assignment B: ");
                try
                {
                    timer.Restart();
                    Console.WriteLine(assignments[targetDay].B());
                }
                catch (NotImplementedException)
                {
                    Console.WriteLine("Not Implemented");
                }
                catch (LogThrow e)
                {
                    Console.Clear();
                    Console.Write(e.Message);

                    Console.WriteLine("Press any key to return");
                    Console.ReadKey();
                    continue;

                }

                BTime = timer.Elapsed;
                timer.Stop();

                Console.WriteLine("\n\n");

                Console.WriteLine($"Init executionTime: {InitTime.TotalMilliseconds} MS");
                Console.WriteLine($"A executionTime: {ATime.TotalMilliseconds} MS");
                Console.WriteLine($"B executionTime: {BTime.TotalMilliseconds} MS");
                Console.WriteLine($"Total executionTime: {(InitTime + ATime + BTime).TotalMilliseconds} MS");
                Console.WriteLine("\n\n");

                Console.WriteLine("Press any key to return");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
