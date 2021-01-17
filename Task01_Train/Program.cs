using System;
using System.Linq;
using System.Collections.Generic;

namespace Task01_Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> train = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int capacity = int.Parse(Console.ReadLine());

            while(true)
            {
                string[] comand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if(comand[0] == "end")
                {
                    break;
                }
                
                else
                {
                    if(comand[0] == "Add")
                    {
                        train.Add(int.Parse(comand[1]));
                    }

                    else
                    {
                        int additionalPassengers = int.Parse(comand[0]);
                        for (int i = 0; i < train.Count; i++)
                        {
                            if(train[i] + additionalPassengers <= capacity)
                            {
                                train[i] += additionalPassengers;
                                i = train.Count;
                            }
                        }
                    }
                }
            }
            
            Console.WriteLine(string.Join(' ', train));
        }
    }
}
