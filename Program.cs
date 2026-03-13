using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Title = "To-Do";
        string filepath = "tasks.txt";
        List<String> tasks = new List<string>();
        if (File.Exists(filepath))
        {
            tasks = File.ReadAllLines(filepath).ToList();
        }
        string[] menu = { "Tasks", "Add", "Remove", "Save & Exit" };
        ConsoleKey key, key2;
        bool run = (true);
        int index = 0, index2 = 0;
        while (run)
        {
            Console.Clear();
            Console.WriteLine("\t==To-Do==");
            for (int i = 0; i < menu.Length; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(">" + menu[i]);
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(" " + menu[i]);
                }
            }
            key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Enter)
            {
                Console.Clear();
                switch (index)
                {
                    case 0:
                        if (tasks.Count == 0)
                        {
                            Console.WriteLine("There are no tasks in the list.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("\t==Tasks==");
                            for (int i = 0; i < tasks.Count; i++)
                            {
                                Console.WriteLine(tasks[i]);
                            }
                            Console.ReadKey();
                        }
                        break;
                    case 1:
                        Console.Write("Enter task: ");
                        string? task = Console.ReadLine();
                        if (task == null)
                        {
                            Console.WriteLine("Task cannot be null.");
                            Console.ReadKey();
                        }
                        else
                        {
                            tasks.Add(task);
                            Console.WriteLine("Task Added");
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        if (tasks.Count == 0)
                        {
                            Console.WriteLine("No tasks remaining.");
                            Console.ReadKey();
                        }
                        else
                        {
                            index2 = 0;
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("\t==Remove a task==");
                                for (int i = 0; i < tasks.Count; i++)
                                {
                                    if (i == index2)
                                    {
                                        Console.BackgroundColor = ConsoleColor.White;
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.WriteLine(">" + tasks[i]);
                                        Console.ResetColor();
                                    }
                                    else
                                    {
                                        Console.WriteLine(" " + tasks[i]);
                                    }
                                }
                                key2 = Console.ReadKey(true).Key;
                                if (key2 == ConsoleKey.UpArrow)
                                {
                                    index2--;
                                    if (index2 < 0)
                                    {
                                        index2 = tasks.Count - 1;
                                    }
                                }
                                else if (key2 == ConsoleKey.DownArrow)
                                {
                                    index2++;
                                    if (index2 == tasks.Count)
                                    {
                                        index2 = 0;
                                    }
                                }
                            } while (key2 != ConsoleKey.Enter);
                            Console.WriteLine(tasks[index2] + " is removed.");
                            tasks.RemoveAt(index2);
                            Console.ReadKey();
                        }
                        break;
                    case 3:
                        run = false;
                        File.WriteAllLines(filepath, tasks);
                        Console.WriteLine("Tasks Saved.\nExiting program...");
                        System.Threading.Thread.Sleep(2000);
                        break;
                }
            }
            else if (key == ConsoleKey.UpArrow)
            {
                index--;
                if (index < 0)
                {
                    index = menu.Length - 1;
                }
            }
            else if (key == ConsoleKey.DownArrow)
            {
                index++;
                if (index == menu.Length)
                {
                    index = 0;
                }
            }
        }
    }
}