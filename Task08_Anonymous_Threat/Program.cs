using System;
using System.Linq;
using System.Collections.Generic;

namespace Task08_Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inPutStrings = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            while(true)
            {
                string[] comand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if(comand[0] == "3:1")
                {
                    break;
                }

                if(comand[0] == "merge")
                {
                    int startIndex = int.Parse(comand[1]);
                    int endIndex = int.Parse(comand[2]);

                    if(startIndex <= inPutStrings.Count -1)
                    {
                        string newElement = string.Empty;
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            if (i >= 0 && i < inPutStrings.Count)
                            {
                                newElement = newElement + inPutStrings[i];
                            }
                        }
                        for (int i = endIndex; i >= startIndex; i--)
                        {
                            if (i >= 0 && i < inPutStrings.Count)
                            {
                                inPutStrings.RemoveAt(i);
                            }
                        }

                        if (startIndex < 0)
                        {
                            startIndex = 0;
                        }

                        inPutStrings.Insert(startIndex, newElement);
                    }
                    
                }

                if(comand[0] == "divide")
                {
                    int index = int.Parse(comand[1]);
                    int partition = int.Parse(comand[2]);

                    if(partition != 0)
                    {
                        int elementsInPartition = inPutStrings[index].Length / partition;
                        int additiolElementInLastPartition = inPutStrings[index].Length % partition;

                        int helpIndexToDevide = 0;
                        int helpIndexToFindElement = index;
                        string helpStringToInsert = string.Empty;
                        int helpIndexToInsert = index;

                        
                        for (int i = 1; i <= partition; i++)
                        {
                            if(i == partition)
                            {
                                helpStringToInsert = string.Empty;
                                for (int x = 0; x < elementsInPartition + additiolElementInLastPartition; x++)
                                {
                                    helpStringToInsert += inPutStrings[helpIndexToFindElement][x + helpIndexToDevide];
                                }
                            }
                            else
                            {
                                for (int x = 0; x < elementsInPartition; x++)
                                {
                                    helpStringToInsert += inPutStrings[helpIndexToFindElement][x + helpIndexToDevide];
                                }
                            }

                            helpIndexToDevide += elementsInPartition;
                            inPutStrings.Insert(helpIndexToInsert, helpStringToInsert);
                            helpIndexToFindElement += 1;
                            helpIndexToInsert += 1;
                            helpStringToInsert = string.Empty;
                        }

                        inPutStrings.RemoveAt(index + partition);
                    }
                    


                }



            }
            
            Console.WriteLine(string.Join(' ', inPutStrings));
        }
    }
}
