using System;
using Tasks.Models;

namespace Tasks
{
    class Program
    {
        static private TaskList theGlobalTaskList;
        static void Main(string[] args)
        {
            Console.WriteLine("*** Welcome to Task List ***\r\n");

            // Create the tasklist by loading in the previously saved tasks, if they exist
            theGlobalTaskList = new TaskList(@".\Tasks.txt");
            theGlobalTaskList.Load();

            // Create a loop that will run the menu until the user breaks out by typing "Q"
            while (true)
            {
                // Clear the screen
                Console.Clear();

                // Call the local method which prints the task list on the screen
                ListTasks();

                // Display the menu to the user
                Console.WriteLine();
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("(A)dd a task");
                Console.WriteLine("(C)omplete a task");
                Console.WriteLine("(D)elete a task");
                Console.WriteLine("(Q)uit");

                // Wait for input from the user
                string input = Console.ReadLine().Trim().ToUpper();

                // If they typed nothing, simply go back to the top of this while and re-display everything.
                if (input.Length == 0)
                {
                    continue;
                }

                // If the user typed "q", break out of the while loop (exit the program)
                if (input.Substring(0, 1) == "Q")
                {
                    break;
                }

                // The following switch statement handles the rest of the possible selections from the user. If
                // the user's selection is not handled below, control will fall to the end of the switch. And the 
                // while loop will start again.
                Task task;
                switch (input.Substring(0, 1))
                {
                    // Add a task
                    case "A":
                        task = GetTaskInfo();
                        theGlobalTaskList.AddTask(task);
                        break;

                    // Complete a task
                    case "C":
                        task = SelectATask();
                        task.Complete = true;
                        theGlobalTaskList.Save();
                        break;

                    // Delete a task
                    case "D":
                        task = SelectATask();
                        theGlobalTaskList.RemoveTask(task);
                        break;
                }
            }
        }

        /// <summary>
        /// Prompt the user for a task number displayed in the list. f valid, return that Task object
        /// </summary>
        /// <returns>Task object selected by the user</returns>
        private static Task SelectATask()
        {
            Task task = null;
            while (task == null)
            {
                try
                {
                    Console.Write($"Please enter the Task Number (0 - {theGlobalTaskList.List.Length - 1}): ");
                    int taskNumber = int.Parse(Console.ReadLine().Trim());
                    if (taskNumber >= 0 && taskNumber < theGlobalTaskList.List.Length)
                    {
                        task = theGlobalTaskList.List[taskNumber];
                    }
                    else
                    {
                        Console.WriteLine("That was not a correct task number.");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("That was not a correct task number.");
                }
            }
            return task;
        }

        /// <summary>
        /// Prompt the user for the information needed to add a new task: Name and due date.
        /// </summary>
        /// <returns>A new task that holds the user's task information. Not yet added to the task list</returns>
        private static Task GetTaskInfo()
        {
            Console.WriteLine("\r\n***Add a task ***");
            Console.Write("\tTask Name: ");
            string taskName = Console.ReadLine();

            DateTime dueDate = DateTime.MinValue;
            while (dueDate == DateTime.MinValue)
            {
                try
                {
                    Console.Write("\tDue Date: ");
                    dueDate = DateTime.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("That was not the correct format for a date. Try mm/dd/yyyy.");
                }
            }
            Task newTask = new Task(taskName, dueDate);
            return newTask;
        }

        /// <summary>
        /// Display the tasks that are currently in the task list.
        /// </summary>
        private static void ListTasks()
        {
            for (int i = 0; i < theGlobalTaskList.List.Length; i++)
            {
                Task task = theGlobalTaskList.List[i];
                Console.WriteLine($"{i} {task.TaskName} {task.DueDate} {task.Complete}");
            }
        }
    }
}
