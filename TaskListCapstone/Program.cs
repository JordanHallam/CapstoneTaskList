using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace TaskListCapstone
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> taskList = new List<Task>();


            while (true)
            {
                int userSelect = MenuNavigation(taskList);
                if (userSelect == 1)
                {
                    PrintList(taskList);
                }
                else if (userSelect == 2)
                {
                    AddTask(taskList);
                }
                else if (userSelect == 3)
                {
                    RemoveTask(taskList);
                }
                else if (userSelect == 4)
                {
                    MarkTaskComplete(taskList);
                }
                else if (userSelect == 5)
                {
                    Console.WriteLine("Goodbye");
                    break;
                }
                Console.WriteLine();
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void PrintList(List<Task> taskList)
        {
            int taskNumber = 1;
            foreach (Task task in taskList)
            {
                Console.WriteLine("Task # " + taskNumber);
                task.Showtask();
                taskNumber++;
            }
        }

        public static void AddTask(List<Task> taskList)
        {


            Console.WriteLine("Who is working on this task?");
            string teamMember = Console.ReadLine();

            Console.WriteLine("Please enter a task description:");
            string taskDescription = Console.ReadLine();

            Console.WriteLine("When is this task due by?");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());


            Task userTask = new Task(teamMember, taskDescription, dueDate, false);
            taskList.Add(userTask);
            Console.WriteLine("Your task has been added");
        }

        public static List<Task> RemoveTask(List<Task> taskList)
        {
            int chooseTask = -1;
            try
            {
                while (chooseTask < 0 || chooseTask > taskList.Count) //out of range handling
                {

                    Console.WriteLine("Whcich task would you like to delete? 1-" + taskList.Count);
                    chooseTask = int.Parse(Console.ReadLine()) - 1;
                    if (chooseTask < 0 || chooseTask > taskList.Count) //out of range handling
                    {
                        Console.WriteLine("You don't have that many items on your list");

                    }
                }
                string confirmation = "b";
                while (confirmation != "y") //continue loop
                {
                    taskList[chooseTask].Showtask();
                    Console.WriteLine(" \nAre you sure you want to delete? Y/N");
                    confirmation = Console.ReadLine().ToLower();
                    if (confirmation == "y")
                    {
                        taskList.RemoveAt(chooseTask);
                        Console.WriteLine("Task has been removed");
                        return taskList;
                    }
                    else if (confirmation == "n")
                    {
                        Console.WriteLine("Nothing has been removed");
                        return taskList;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please confirm Y/N");
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Oops! Looks like you did not enter a number Lets try again");
            }
            return taskList;
        }
        public static List<Task> MarkTaskComplete(List<Task> taskList)
        {
            int chooseTask = -1;
            try
            {
                while (chooseTask < 0 || chooseTask > taskList.Count) //out of range handling
                {

                    Console.WriteLine("Whcich task would you like to mark complete? 1-" + taskList.Count);
                    chooseTask = int.Parse(Console.ReadLine()) - 1;
                    if (chooseTask < 0 || chooseTask > taskList.Count) //out of range handling
                    {
                        Console.WriteLine("You don't have that many items on your list");

                    }
                }
                string confirmation = "b";
                while (confirmation != "y") //continue loop
                {
                    taskList[chooseTask].Showtask();
                    Console.WriteLine(" \nAre you sure you want to mark complete? Y/N");
                    confirmation = Console.ReadLine().ToLower();
                    if (confirmation == "y")
                    {

                        taskList[chooseTask].MarkComplete();
                        Console.WriteLine("Task has been marked complete");
                        return taskList;
                    }
                    else if (confirmation == "n")
                    {
                        Console.WriteLine("Task has not been marked complete");
                        return taskList;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please confirm Y/N");
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Oops! Looks like you did not enter a number Lets try again");
            }
            return taskList;
        }
        public static int MenuNavigation(List<Task> taskList)
        {
            Console.WriteLine("1.List Tasks (Current Tasks:" + taskList.Count + ") \n2.Add Task\n3.Delete Task\n4.Mark Task Complete \n5.Quit");

            Console.WriteLine("Please enter a number to choose an action");
            int userSelect = 0;
            try
            {
                userSelect = int.Parse(Console.ReadLine());

            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number. Please enter a number 1-5");

            }
            return userSelect;
        }

    }
}

