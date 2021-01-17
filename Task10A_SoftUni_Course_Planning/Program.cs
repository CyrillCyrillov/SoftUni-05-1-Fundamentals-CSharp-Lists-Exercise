using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Course_Planning
{
	class Program
	{
		static void Main(string[] args)
		{
			List<string> input = Console.ReadLine().Split(", ").ToList(); // read the input 

			string command = string.Empty;

			string action = string.Empty; // add, remove, insert , swap , exercise 
			string element = string.Empty; // Covers only Add / Remove / Exercise



			string lesson = string.Empty; // covers only insert 
			int index = 0; // covers only insert 
			string element1 = string.Empty;// Covers only insert and swap

			string firstLesson = string.Empty; // covers only swap !
			string secondLesson = string.Empty; // covers only swap ! 


			while (true)
			{
				command = Console.ReadLine();// read commands 

				if (command == "course start")
				{
					break;
				}

				List<string> incomingDetails = command.Split(":").ToList(); // get a list of the input commands   separated by : 

				for (int i = 0; i < incomingDetails.Count; i++)
				{
					action = incomingDetails[0]; // what we need to do 
					element = incomingDetails[1]; // which course to look for. Covers only Add / Remove / Excercise that have 2 elements only 


					if (action == "Insert")
					{
						index = int.Parse(incomingDetails[2]);
						lesson = element;  // this is the lesson to insert 
										   //index = elementInsert; // this is the index where to insert the lesson 


						break;
					}

					else if (action == "Swap")
					{
						string elementInsert = incomingDetails[2]; // to cover swap  

						firstLesson = incomingDetails[1];
						secondLesson = incomingDetails[2];


						break;
					}
				}

				for (int k = 0; k < input.Count; k++)
				{
					if (action == "Add") // 
					{
						if (!input.Contains(element)) //if it does not exist
						{
							input.Add(element);
						}


					}

					else if (action == "Remove") //  if it exists.

					//Each time you Remove a lesson, you should do the same with the Exercises, if there are any, which follow the lessons. 
					{

						string excercise = element + '-' + "Exercise";

						if (input.Contains(element))
						{
							input.Remove(element);

						}

						if (input.Contains(excercise))
						{
							input.Remove(excercise);
						}


					}


					else if (action == "Exercise")
					{
						string excercise = element + '-' + "Exercise";



						if (!input.Contains(element))
						{

							if (!input.Contains(excercise)) // If the lesson doesn`t exist, add the lesson in the end of the course schedule, followed by the Exercise. 
							{
								input.Add(element);
								input.Add(excercise);
								break;
							}


							break;
						}

						else if (input.Contains(element) && !input.Contains(excercise)) // if the lesson exists and there is no exercise already, add the excercise to the right place  
						{
							int indexx = input.IndexOf(element);
							input.Insert(indexx + 1, excercise);

							break;

						}


					}

					else if (action == "Insert")
					{
						if (!input.Contains(lesson)) // insert the lesson to the given index, if it does not exist
						{
							input.Insert(index, lesson);
							break;
						}


						break;
					}


					else if (action == "Swap") // change the place of the two lessons, if they exist!!
					{



						if (input.Contains(firstLesson) && input.Contains(secondLesson))
						{
							string excercise = firstLesson + '-' + "Exercise";


							int index1 = input.IndexOf(firstLesson); // know where is the 1st lesson
							int index2 = input.IndexOf(secondLesson); // know where is the  2nd lesson

							string temp = firstLesson;

							input.RemoveAt(index1); // remove the 1st part of the swap / lesson

							input.Insert(index1, secondLesson);



							if (input.Contains(excercise))
							{
								input.Remove(excercise);
								input.Insert(index1 + 1, excercise);
							}

							excercise = string.Empty;
							excercise = secondLesson + '-' + "Exercise"; // excercise related to the second lesson


							input.RemoveAt(index2);// remove the second lesson  part from its old index


							input.Insert(index2, temp); //insert the second lesson to the new  index



							if (input.Contains(excercise))
							{

								input.Remove(excercise);

								input.Insert(index1 + 1, excercise); // insert the excercise for the second lesson


							}

						}


						break;
					}

				}


			}




			for (int p = 0; p < input.Count; p++)
			{
				Console.WriteLine($"{p + 1}.{input[p]}");
			}
		}
	}
}