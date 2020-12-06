using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Assignments
{
    class DayFive : DayAssignment
    {
        bool[,] seats = new bool[179, 8];
        public override int Day { get; } = 5;
        public override void Init()
        {

        }

        public override string A()
        {
            int seatId = 0;

            foreach (var line in ReadLines())
            {
                int rowMin = 0;
                int rowMax = 127;
                int columnMin = 0;
                int columnMax = 7;

                for (int i = 0; i < 10; i++)
                {
                    if (line[i] == 'F')
                    {
                        rowMax = rowMin + (int)Math.Floor((rowMax - (float)rowMin) / 2f);
                    }
                    else if (line[i] == 'B')
                    {
                        rowMin += (int)Math.Ceiling((rowMax - (float)rowMin) / 2f);
                    }
                    else if (line[i] == 'R')
                    {
                        columnMin += (int)Math.Ceiling((columnMax - (float)columnMin) / 2f);
                    }
                    else if (line[i] == 'L')
                    {
                        columnMax = columnMin + (int)Math.Floor((columnMax - (float)columnMin) / 2f);
                    }
                    else
                    {
                        Console.WriteLine($"Unkown char: '{line[i]}'");
                    }
                }

                int ID = rowMax * 8 + columnMax;

                if (ID > seatId)
                    seatId = ID;
            }

            return $"highest seat ID : {seatId}";
        }

        public override string B()
        {
            foreach (var line in ReadLines())
            {
                int rowMin = 0;
                int rowMax = 127;
                int columnMin = 0;
                int columnMax = 7;

                for (int i = 0; i < 10; i++)
                {
                    if (line[i] == 'F')
                    {
                        rowMax = rowMin + (int)Math.Floor((rowMax - (float)rowMin) / 2f);
                    }
                    else if (line[i] == 'B')
                    {
                        rowMin += (int)Math.Ceiling((rowMax - (float)rowMin) / 2f);
                    }
                    else if (line[i] == 'R')
                    {
                        columnMin += (int)Math.Ceiling((columnMax - (float)columnMin) / 2f);
                    }
                    else if (line[i] == 'L')
                    {
                        columnMax = columnMin + (int)Math.Floor((columnMax - (float)columnMin) / 2f);
                    }
                    else
                    {
                        Console.WriteLine($"Unkown char: '{line[i]}'");
                    }
                }

                int a = seats.GetLength(0);
                if (seats.GetLength(0) < rowMax || rowMax > seats.GetLength(0))
                    continue;

                seats[rowMax, columnMax] = true;
            }

            int answer = 0;
            for (int r = 1; r < seats.GetLength(0) - 1; r++)
            {
                for (int c = 0; c < seats.GetLength(1); c++)
                {

                    if (!seats[r, c])
                    {
                        if (seats[r + 1, c] && seats[r - 1, c])
                        {
                            answer = (r ) * 8 + (c);
                            Console.Write('?');
                            continue;
                        }

                    }


                    Console.Write(seats[r, c] ? '#' : '.');
                }
                Console.WriteLine();
            }
            return $"Our seatID is {answer}";
        }
    }
}
