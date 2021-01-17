using System;
using System.Linq;
using System.Collections.Generic;

namespace Task09_Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pockemons = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int sumOfPockemons = 0;
            int removedValue = 0;
            
            while(pockemons.Count != 0)
            {
                int nextIndex = int.Parse(Console.ReadLine());

                if(nextIndex < 0)
                {
                    sumOfPockemons += pockemons[0];
                    removedValue = pockemons[0];
                    pockemons[0] = pockemons[pockemons.Count - 1];

                    pockemons = IncreasingAndDecreasing(pockemons, removedValue);
                }

                else if (nextIndex >= pockemons.Count)
                {
                    sumOfPockemons += pockemons[pockemons.Count - 1];
                    removedValue = pockemons[pockemons.Count - 1];
                    pockemons[pockemons.Count - 1] = pockemons[0];

                    pockemons = IncreasingAndDecreasing(pockemons, removedValue);
                }

                else
                {
                    sumOfPockemons += pockemons[nextIndex];
                    removedValue = pockemons[nextIndex];
                    pockemons.RemoveAt(nextIndex);

                    pockemons = IncreasingAndDecreasing(pockemons, removedValue);
                }
            }
            
            Console.WriteLine(sumOfPockemons);
        }

        public static List<int> IncreasingAndDecreasing(List<int> pockemons, int removedValue)
        {
            List<int> newPockemons = pockemons;
            
                for (int i = 0; i < newPockemons.Count; i++)
            {
                if (newPockemons[i] <= removedValue)
                {
                    newPockemons[i] += removedValue;
                }
                else
                {
                    newPockemons[i] -= removedValue;
                }
            }

            return newPockemons;
        }
    }
}
