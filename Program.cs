/*
CREATED BY Perss00n
Email: Perss00n@gmail.com
Discord: Perss00n
*/

using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        // List to store the to-do items
        static List<string> toDo = new List<string>();

        // Method to add a new task to the to-do list
        static void AddToDo()
        {
            Console.Write("Enter a new task to your To-Do list: "); // Prompt user for a new task
            string addItem = Console.ReadLine(); // Read user input
            if (!string.IsNullOrEmpty(addItem)) // Check if input is not empty
            {   
                toDo.Add(addItem); // Add the item to the list
                Console.Write("Item successfully added to the list! Please press Enter to continue...");
            }
            else
            {
                Console.Write("Error! No input provided.\nPlease press Enter to continue...");
            }
        }

        // Method to view all tasks in the to-do list
        static void ViewList()
        {
            if (toDo.Count == 0) // Check if the list is empty
            {
                Console.Write("Your ToDo list is empty.\nPlease press Enter to continue...");
            }
            else
            {
                Console.WriteLine("Your current To-Do List:"); // Display the current to-do list
                for (int i = 0; i < toDo.Count; i++) // Iterate through each item
                {
                    Console.WriteLine($"{i + 1}. {toDo[i]}"); // Display item with its index
                }
                Console.Write("Please press Enter to continue...");
            }
        }

        // Method to remove a task from the to-do list
        static void RemoveItem()
        {
            bool isValidInput;
            if (toDo.Count == 0) // Check if the list is empty
            {
                Console.Write("Your ToDo list is empty.\nPlease press Enter to continue...");
            }
            else
            {
                for (int i = 0; i < toDo.Count; i++) // Display all items with indices
                {
                    Console.WriteLine($"{i + 1}. {toDo[i]}");
                }
                Console.Write("Which item do you want to remove? ---> "); // Prompt user for index of item to remove
                isValidInput = Int32.TryParse(Console.ReadLine(), out int remove); // Try to parse user input as an integer
                if (!isValidInput || remove < 1 || remove > toDo.Count) // Check if input is valid
                {
                    Console.Write("Invalid input! Please press Enter to continue...");
                }
                else
                {
                    toDo.RemoveAt(remove - 1); // Remove item at the specified index
                    Console.Write("Item successfully removed from the list! Please press Enter to continue...");
                }
            }
        }

        // Method to clear all tasks from the to-do list
        static void ClearList()
        {
            Console.Write("Warning! This will clear the whole list. Are you sure? (Y/N): "); // Prompt user for confirmation

            string confirm = Console.ReadLine().ToUpper(); // Read user input and convert to uppercase
                      
            if (confirm != "Y" && confirm != "N") // Check if input is valid
            {
                Console.WriteLine("Error! Please enter Y or N");
            }
            else
            {
                if (confirm == "Y") // If user confirms, clear the list
                {
                    toDo.Clear();
                    Console.Write("Success! Your ToDo list was cleared. Please press Enter to continue...");
                }
                else
                {
                    Console.Write("No worries! Nothing was deleted. Please press enter to continue...");
                }                    
            }
        }

        // Main method where the program starts
        static void Main(string[] args)
        {
            while (true) // Infinite loop to keep the program running
            {
                Console.WriteLine("###ToDo List###");
                Console.WriteLine("[A]dd"); // Option to add a new task
                Console.WriteLine("[V]iew"); // Option to view all tasks
                Console.WriteLine("[D]elete"); // Option to delete a task
                Console.WriteLine("[C]lear List"); // Option to clear all tasks
                Console.WriteLine("[E]xit"); // Option to exit the program

                char input = Convert.ToChar(Console.ReadLine().ToUpper()); // Read user input and convert to uppercase

                // Switch case to handle different user choices
                switch (input)
                {
                    case 'A':
                        AddToDo(); // Call method to add a new task
                        break;
                    case 'V':
                        ViewList(); // Call method to view the to-do list
                        break;
                    case 'D':
                        RemoveItem(); // Call method to remove a task
                        break;
                    case 'C':
                        ClearList(); // Call method to clear all tasks
                        break;
                    case 'E':
                        return; // Exit the loop and end the program                        
                    default:
                        Console.Write("Error! Invalid Input!\nPlease press Enter to continue...");
                        break;
                }

                Console.ReadLine(); // Wait for user to press Enter before continuing
            }
        }
    }
}
