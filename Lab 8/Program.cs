using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_8
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> students = new List<string> { "Luke", "John", "Joe" };
            List<string> food = new List<string> { "pizza", "pie", "cookies" };
            List<string> town = new List<string> { "Detroit", "Chicago", "Miami" };
            List<string> color = new List<string> { "red", "blue", "pink" };
            string input;

            Console.WriteLine("Welcome to our C# class.");

            do
            {
                Console.WriteLine($"We currently have {students.Count + 1} students in the class. Type a student's number (1-{students.Count})" +
                    $"if you want to find out more information about one, or type 'new' if you want to add a new student.");

                input = Console.ReadLine();
                try
                {
                    int selectedStudent = int.Parse(input)-1;
                    Console.Write($"Student {selectedStudent + 1}'s name is {students[selectedStudent]}. ");
                    do
                    {
                        Console.WriteLine("Would you like to know their favorite food, hometown, or favorite color? (type favorite food, hometown, or favorite color)");
                        string response = Console.ReadLine();
                        string toOutput = "something went wrong";
                        bool valid = true;

                        switch (response)
                        {
                            case "favorite food":
                                toOutput = food[selectedStudent];
                                break;
                            case "hometown":
                                toOutput = town[selectedStudent];
                                break;
                            case "favorite color":
                                toOutput = color[selectedStudent];
                                break;
                            default:
                                Console.WriteLine("Invalid entry!");
                                valid = false;
                                break;
                        }

                        Console.WriteLine(valid ? $"{students[selectedStudent]}'s {response} is {toOutput}" : null);

                        Console.WriteLine($"Would you like to ask something else about {students[selectedStudent]}?(y/n)");
                    } while (Console.ReadLine().ToLower() == "y");
                }
                catch (Exception)
                {
                    if (input == "new")
                    {
                        AddStudent(students, food, town, color);
                    }
                    else
                    {
                        Console.WriteLine("Invalid entry! Try again.");
                    }
                }
                Console.WriteLine("Would you like to try another student/add a new student?(y/n)");
            } while (Console.ReadLine().ToLower() == "y");
        }

        public static void AddEntry(List<string> category, string data)
        {
            Console.WriteLine($"Please enter in the {data} of your student.");

            string input = Console.ReadLine();

            if(Regex.IsMatch(input, "[a-zA-Z0-9]{1,30}"))
            {
                category.Add(input);
                return;
            }

            Console.WriteLine($"Invalid entry! Be sure you are entering {data} correctly.");

            AddEntry(category, data);
            return;
        }

        public static void AddStudent(List<string> name, List<string> food, List<string> town, List<string> color)
        {
            AddEntry(name, "name");
            AddEntry(food, "favorite food");
            AddEntry(town, "hometown");
            AddEntry(color, "favorite color");
            return;
        }
    }
}
