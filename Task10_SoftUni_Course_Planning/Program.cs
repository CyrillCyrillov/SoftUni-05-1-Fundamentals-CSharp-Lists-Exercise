using System;
using System.Linq;
using System.Collections.Generic;

namespace Task10_SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> courseSchedule = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

            while (true)
            {
                /*
                for (int i = 0; i < courseSchedule.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.{courseSchedule[i]}");
                }
                */

                string[] comand = Console.ReadLine().Split(':', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if(comand[0].ToUpper() == "COURSE START")
                {
                    break;
                }

                if(comand[0].ToUpper() == "ADD")
                {
                    string lesonTitle = comand[1];
                    if((courseSchedule.Contains(lesonTitle)) == false)
                    {
                        courseSchedule.Add(lesonTitle);
                    }
                }

                else if (comand[0].ToUpper() == "INSERT")
                {
                    string lesonTitle = comand[1];
                    int index = int.Parse(comand[2]);
                    if ((courseSchedule.Contains(lesonTitle)) == false)
                    {
                        courseSchedule.Insert(index, lesonTitle);
                    }
                }

                else if (comand[0].ToUpper() == "EXERCISE")
                {
                    string lesonTitle = comand[1];
                    string lesonExercise = lesonTitle + "-Exercise";


                    if ((courseSchedule.Contains(lesonTitle)) == false)
                    {
                        courseSchedule.Add(lesonTitle);
                        courseSchedule.Add(lesonTitle + "-Exercise");
                    }
                    else if((courseSchedule.Contains(lesonExercise) == false))
                    {
                        for (int i = 0; i < courseSchedule.Count; i++)
                        {
                            if(courseSchedule[i] == lesonTitle)
                            {
                                courseSchedule.Insert(i + 1, lesonTitle + "-Exercise");
                            }
                        }
                    }

                }

                else if(comand[0].ToUpper() == "REMOVE")
                {
                    string lesonTitle = comand[1];
                    for (int i = 0; i < courseSchedule.Count; i++)
                    {
                        if (courseSchedule[i] == lesonTitle || courseSchedule[i] == lesonTitle + "-Exercise")
                        {
                            courseSchedule.RemoveAt(i);
                            i--;
                        }
                    }
                }

                else if (comand[0].ToUpper() == "SWAP")
                {
                    string lesonTitleOne = comand[1];
                    string lesonTitleTwo = comand[2];
                    int indexOne = -1;
                    int indexOneExs = -1;
                    int indexTwo = -1;
                    int indexTwoExs = -1;

                    if (courseSchedule.Contains(lesonTitleOne) && courseSchedule.Contains(lesonTitleTwo))
                    {
                        for (int i = 0; i < courseSchedule.Count; i++)
                        {
                            if (courseSchedule[i] == lesonTitleOne || courseSchedule[i] == lesonTitleTwo)
                            {
                                indexOne = i;
                                if (i != courseSchedule.Count - 1 && courseSchedule[i] + "-Exercise" == courseSchedule[i + 1])
                                {
                                    indexOneExs = i + 1;
                                }
                                break;
                            }
                        }

                        for (int i = courseSchedule.Count - 1; i >= 0; i--)
                        {
                             if (courseSchedule[i] == lesonTitleOne || courseSchedule[i] == lesonTitleTwo)
                              {
                                    indexTwo = i;
                                    if (i != courseSchedule.Count - 1 && courseSchedule[i] + "-Exercise" == courseSchedule[i + 1])
                                    {
                                        indexTwoExs = i + 1;
                                    }
                                    break;
                             }
                        }

                        string helpString = courseSchedule[indexOne];
                        courseSchedule[indexOne] = courseSchedule[indexTwo];
                        courseSchedule[indexTwo] = helpString;

                        if(indexOneExs != -1 && indexTwoExs != -1)
                        {
                            courseSchedule.Insert(indexOne + 1, courseSchedule[indexTwoExs]);
                            courseSchedule.RemoveAt(indexTwoExs + 1);
                            courseSchedule.Insert(indexTwo + 2, courseSchedule[indexOneExs + 1]);
                            courseSchedule.RemoveAt(indexOneExs + 1);
                        }

                        else if(indexOneExs != -1)
                        {
                            courseSchedule.Insert(indexTwo + 1, courseSchedule[indexOneExs]);
                            courseSchedule.RemoveAt(indexOneExs);
                        }

                        else if(indexTwoExs != -1)
                        {
                            courseSchedule.Insert(indexOne + 1, courseSchedule[indexTwoExs]);
                            courseSchedule.RemoveAt(indexTwoExs + 1);
                        }
                    }
                }
            }

            for (int i = 0; i < courseSchedule.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{courseSchedule[i]}");
            }
        }
    }
}
