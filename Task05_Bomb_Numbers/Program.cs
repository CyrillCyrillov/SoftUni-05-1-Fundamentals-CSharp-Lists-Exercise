using System;
using System.Linq;
using System.Collections.Generic;

namespace Task05_Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int[] bomb = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            for (int i = 0; i < numbers.Count; i++)
            {
                if(numbers[i] == bomb[0])
                {
                    for(int j = bomb[1]; j > 0; j--)
                    {
                        if(i + j  <= numbers.Count - 1)
                        {
                            numbers.RemoveAt(i + j);
                        }
                    }

                    int rightIndex = i;

                    for (int x = bomb[1]; x > 0; x--)
                    {
                        if(rightIndex - x >= 0)
                        {
                            numbers.RemoveAt(rightIndex - x);
                            rightIndex -= 1;
                        }
                    }


                    numbers.RemoveAt(rightIndex);

                    i = 0;
                }
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}
