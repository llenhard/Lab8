using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] students = new string[3, 3] { { "Luke", "pizza", "Detroit" }, { "Jim", "pancakes", "Chicago" }, { "Mark", "chocolate", "Paris" } };
            bool continuing = false;
            string studentName;
            int wantedStudent;

            Console.WriteLine($"Welcome to our C# class. Which student would you like to learn more about? (enter a number 1-{students.GetLength(0)}");

            do
            {
                try
                {
                    Console.Write("Enter a student's ID: ");
                    wantedStudent = int.Parse(Console.ReadLine()) - 1;
                    studentName = students[wantedStudent, 0];

                    Console.WriteLine($"Student {wantedStudent} is {studentName}. What would you like to know about {studentName}? (enter 'hometown' or 'favorite food')");
                    do
                    {
                        switch (Console.ReadLine().ToLower())
                        {
                            case "hometown":
                                string hometown = students[wantedStudent, 2];
                                Console.WriteLine($"{studentName} is from {hometown}");
                                continuing = false;
                                break;
                            case "favorite food":
                                string food = students[wantedStudent, 1];
                                Console.WriteLine($"{wantedStudent}'s favorite food is {food}.");
                                continuing = false;
                                break;
                            default:
                                Console.WriteLine("Invalid entry! Enter 'hometown' or 'favorite food'.");
                                continuing = true;
                                break;
                        }

                    } while (continuing);

                }

                catch (Exception)
                {
                    Console.WriteLine("That isn't a valid student ID.");
                }

                Console.WriteLine("Would you like to try another student ID? (y/n)");

                continuing = Console.ReadLine().ToLower() == "y" ? true : false;

            } while (continuing);
        }


    }
}
