using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    internal class Program
    {
        static List<string> toDo = new List<string>();

        static void AddToDo()
        {
            Console.Write("Enter a new task to your To-Do list: ");
            string addItem = Console.ReadLine();
            if (!string.IsNullOrEmpty(addItem))
            {   
                toDo.Add(addItem);
                Console.Write("Item succesfully added to the list! Please press Enter to continue...");
            }
            else
            {
                Console.Write("Error! No input provided.\nPlease press Enter to continue...");
            }
        }

        static void ViewList()
        {
            if (toDo.Count == 0)
            {
                Console.Write("Your ToDo list is empty.\nPlease press Enter to continue...");
            }
            else
            {
                Console.WriteLine("Your current To-Do List:");
                for (int i = 0; i < toDo.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {toDo[i]}");
                }
                Console.Write("Please press Enter to continue...");
            }
           
        }

        static void RemoveItem()
        {
            bool isValidInput;
            if (toDo.Count == 0)
            {
                Console.Write("Your ToDo list is empty.\nPlease press Enter to continue...");
            }
            else
            {
                for (int i = 0; i < toDo.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {toDo[i]}");
                }
                Console.Write("Which item do you want to remove? ---> ");
                isValidInput = Int32.TryParse(Console.ReadLine(), out int remove);
                if (!isValidInput || remove < 1 || remove > toDo.Count)
                {
                    Console.Write("Invalid input! Please press Enter to continue...");
                }
                else
                {
                    toDo.RemoveAt(remove - 1);
                    Console.Write("Item succesfully removed from the list! Please press Enter to continue...");
                }
            }
        }

        static void ClearList()
        {
            Console.Write("Warning! This will clear the whole list. Are you sure? (Y/N): ");

            string confirm = Console.ReadLine().ToUpper();
                      

                if (confirm != "Y" && confirm != "N")
                {
                    Console.WriteLine("Error! Please enter Y or N");
                }
                else
                {
                    if (confirm == "Y")
                    {
                        toDo.Clear();
                        Console.Write("Succcess!You'r ToDo list was cleared. Please press Enter to continue...");
                    }
                    else
                    {
                        Console.Write("No worries! Nothing was deleted. Please press enter to continue...");
                    }                    
                }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("###ToDo List###");
                Console.WriteLine("[A]dd");
                Console.WriteLine("[V]iew");
                Console.WriteLine("[D]elete");
                Console.WriteLine("[C]lear List");
                Console.WriteLine("[E]xit");

                char input = Convert.ToChar(Console.ReadLine().ToUpper());

                switch (input)
                {
                    case 'A':
                        AddToDo();
                        break;
                    case 'V':
                        ViewList();
                        break;
                    case 'D':
                        RemoveItem();
                        break;
                    case 'C':
                        ClearList();
                        break;
                    case 'E':
                        return;                        
                    default:
                        Console.Write("Error! Invalid Input!\nPlease press Enter to continue...");
                        break;
                }



                Console.ReadLine();
            }
        }
    }
}
