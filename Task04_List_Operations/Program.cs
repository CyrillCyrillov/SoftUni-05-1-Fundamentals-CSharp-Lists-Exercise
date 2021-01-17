using System;
using System.Linq;
using System.Collections.Generic;

namespace Task04_List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            while(true)
            {
                string[] comand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if(comand[0] == "End")
                {
                    break;
                }

                else if(comand[0] == "Add")
                {
                    numbers.Add(int.Parse(comand[1]));
                }
                else if(comand[0] == "Insert")
                {
                    if (int.Parse(comand[2]) < 0 || int.Parse(comand[2]) > numbers.Count -1)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.Insert(int.Parse(comand[2]), int.Parse(comand[1]));
                    }
                }
                else if(comand[0] == "Remove")
                {
                    if(int.Parse(comand[1]) < 0 || int.Parse(comand[1]) > numbers.Count - 1)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.RemoveAt(int.Parse(comand[1]));
                    }
                }
                else if(comand[1] == "left")
                {
                    for (int i = 1; i <= int.Parse(comand[2]); i++)
                    {
                        numbers.Add(numbers[0]);
                        numbers.RemoveAt(0);
                    }
                }
                else if (comand[1] == "right")
                {
                    for (int i = 1; i <= int.Parse(comand[2]); i++)
                    {
                        numbers.Insert(0, numbers[numbers.Count - 1]);
                        numbers.RemoveAt(numbers.Count - 1);
                    }
                }
            }
            
            
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
