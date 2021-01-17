using System;
using System.Linq;
using System.Collections.Generic;

namespace Task03_House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>();

            int numberOfComands = int.Parse(Console.ReadLine());
            string[] comand = new string[4];

            for (int i = 1; i <= numberOfComands; i++)
            {
                comand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if(comand[2] == "going")
                {
                    if(names.Contains(comand[0]))
                    {
                        Console.WriteLine($"{comand[0]} is already in the list!");
                    }
                    else
                    {
                        names.Add(comand[0]);
                    }
                }

                else if(comand[2] == "not")
                {
                    if (names.Contains(comand[0]))
                    {
                        names.Remove(comand[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{comand[0]} is not in the list!");
                    }
                }
            }

            Console.WriteLine(string.Join((char)10, names));
        }
    }
}
