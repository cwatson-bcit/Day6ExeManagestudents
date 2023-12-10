using System;
using System.Collections.Generic;

namespace Day6ExeManagestudents
{
    class Program
    {
        static void Main()
        {
            Dictionary<int, string> studentDictionary = new Dictionary<int, string>()
            {
                {101, "Aarav"},
                {102, "Beatriz"},
                {103, "Chen"},
                {104, "Dalia"},
                {105, "Emeka"}
            };

            MainMenu(studentDictionary);
        }

        static void MainMenu(Dictionary<int, string> studentDictionary)
        {
            bool isNotExit = true;
            while (isNotExit)
            {
                Console.Clear();
                Console.WriteLine("\n\tMain Menu:");
                Console.WriteLine("\t1. List all Students");
                Console.WriteLine("\t2. Return Student");
                Console.WriteLine("\t3. Update Student");
                Console.WriteLine("\t4. Delete Student");
                Console.WriteLine("\t5. Add Student");
                Console.WriteLine("\t6. Exit");
                Console.Write("\n\tEnter your choice: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ListAllStudents(studentDictionary);
                        break;
                    case "2":
                        ReturnStudent(studentDictionary);
                        break;
                    case "3":
                        UpdateStudent(studentDictionary);
                        break;
                    case "4":
                        DeleteStudent(studentDictionary);
                        break;
                    case "5":
                        AddStudent(studentDictionary);
                        break;
                    case "6":
                        Console.WriteLine("\n\tThank you for using the student registry.");
                        isNotExit = false;
                        break;
                    default:
                        Console.WriteLine("\n\tInvalid choice. Please select a valid option (between 1 and 6).");
                        break;
                }
                Console.Write("\n\tPress any key to continue...");
                Console.ReadKey();
            }
        }

        static void ListAllStudents(Dictionary<int, string> studentDictionary)
        {
            Console.WriteLine($"\n\tStudent List\n\t------------");

            foreach (var student in studentDictionary)
            {
                Console.WriteLine($"\tID: {student.Key}, Name: {student.Value}");
            }
        }

        static void ReturnStudent(Dictionary<int, string> studentDictionary)
        {
            int studentId = GetStudentId("\tEnter Student ID: ");

            if (studentDictionary.TryGetValue(studentId, out string name))
            {
                Console.WriteLine($"\n\tStudent Name: {name}");
            }
            else
            {
                Console.WriteLine("\n\tStudent not found.");
            }
        }

        static void UpdateStudent(Dictionary<int, string> studentDictionary)
        {
            int studentId = GetStudentId("\n\tEnter Student ID to update: ");

            if (studentDictionary.ContainsKey(studentId))
            {
                Console.Write("\tEnter new name for the student: ");
                studentDictionary[studentId] = Console.ReadLine(); ;
                Console.WriteLine("\tStudent updated successfully.");
            }
            else
            {
                Console.WriteLine("\n\tStudent not found.");
            }
        }

        static void DeleteStudent(Dictionary<int, string> studentDictionary)
        {
            int studentId = GetStudentId("\n\tEnter Student ID to delete: ");

            if (studentDictionary.Remove(studentId))
            {
                Console.WriteLine("\tStudent removed successfully.");
            }
            else
            {
                Console.WriteLine("\n\tStudent not found.");
            }
        }

        static void AddStudent(Dictionary<int, string> studentDictionary)
        {
            int studentId = GetStudentId("\n\tEnter new Student ID: ");

            if (!studentDictionary.ContainsKey(studentId))
            {
                Console.Write("\n\tEnter Student Name: ");
                studentDictionary.Add(studentId, Console.ReadLine());
                Console.WriteLine("\n\tStudent added successfully.");
            }
            else
            {
                Console.WriteLine("\n\tDuplicate ID or invalid input.");
            }
        }

        static int GetStudentId(string prompt)
        {
            Console.Write(prompt);
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    return id;
                }
                else
                {
                    Console.Write("\n\tInvalid input. Please enter a numeric ID: ");
                }
            }
        }
    }
}