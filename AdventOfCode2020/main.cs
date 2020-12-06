//#define DEVELOP

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2020.Assignments;



namespace AdventOfCode2020
{
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

                int targetDay = 0;
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

                try
                {
                    assignments[targetDay].Init();
                }
                catch (NotImplementedException)
                {
                }

                Console.WriteLine($"Day: {targetDay} \n\n");

                Console.WriteLine("Assignment A: ");
                try
                {
                    Console.WriteLine(assignments[targetDay].A());
                }
                catch (NotImplementedException)
                {
                    Console.WriteLine("Not Implemented");
                }

                Console.WriteLine("");
                Console.WriteLine("=========================");
                Console.WriteLine("");
                Console.WriteLine("Assignment B: ");
                try
                {
                    Console.WriteLine(assignments[targetDay].B());
                }
                catch (NotImplementedException _)
                {
                    Console.WriteLine("Not Implemented");
                }

                Console.WriteLine(""); Console.WriteLine("");
                Console.WriteLine("Press any key to return");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
