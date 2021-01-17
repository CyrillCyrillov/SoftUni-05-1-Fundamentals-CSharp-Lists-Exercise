using System;
using System.Linq;
using System.Collections.Generic;

namespace Task02_Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            while(true)
            {
                string[] comand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if(comand[0] == "end")
                {
                    break;
                }

                else if(comand[0] == "Delete")
                {
                    numbers.RemoveAll(x => x == int.Parse(comand[1]));
                }
                else if(comand[0] == "Insert")
                {
                    numbers.Insert(int.Parse(comand[2]), int.Parse(comand[1]));
                }
            }
            
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
