using System;
using System.Linq;
using System.Collections.Generic;

namespace Task07_Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputString = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();

            List<string> outputString = new List<string>();
            //List<string> outputString = {start};

            for (int i = inputString.Count - 1; i >= 0; i--)
            {
                List<string> curentString = inputString[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
                
                for (int j = 0; j < curentString.Count; j++)
                {
                    outputString.Add(curentString[j]);
                }
            }
            
            
            Console.WriteLine(string.Join(' ', outputString));
        }
    }
}
