using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tasks.Models
{
    /// <summary>
    /// Represnts the user's list of tasks to complete
    /// </summary>
    public class TaskList
    {
        /// <summary>
        /// Path to the backing data store (a text file to save and load from).
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Internal structure where we hold the tasks.
        /// </summary>
        private List<Task> privateListOfTasks;

        /// <summary>
        /// Public access to the task list. An immutable array.
        /// </summary>
        public Task[] List
        {
            get
            {
                return this.privateListOfTasks.ToArray();
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="path">Path to the backing data store (text file to store tasks)</param>
        public TaskList(string path)
        {
            this.Path = path;
        }

        /// <summary>
        /// Load data from the file (path) into a new task list
        /// </summary>
        public void Load()
        {
            this.privateListOfTasks = new List<Task>();
            if (File.Exists(this.Path))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(this.Path))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            string[] fields = line.Split("|");

                            //Task task = new Task(fields[0], DateTime.Parse(fields[1]), bool.Parse(fields[2]));
                            string taskName = fields[0];
                            DateTime dueDate = DateTime.Parse(fields[1]);
                            bool complete = bool.Parse(fields[2]);
                            Task task = new Task(taskName, dueDate, complete);

                            privateListOfTasks.Add(task);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"There was an exception loading the file {this.Path}. Task list was not completely loaded.");
                }
            }
        }

        /// <summary>
        /// Stores the task list into the file (Path)
        /// </summary>
        public void Save()
        {
            // Create a stream writer and write each task to the stream
            using (StreamWriter sw = new StreamWriter(this.Path, false))
            {
                foreach (Task task in this.privateListOfTasks)
                {
                    string outputLine = string.Join("|", task.TaskName, task.DueDate, task.Complete);
                    sw.WriteLine(outputLine);
                }
            }
        }

        public void AddTask(Task task)
        {
            this.privateListOfTasks.Add(task);
            this.Save();
        }

        public void RemoveTask(Task task)
        {
            if (this.privateListOfTasks.Contains(task))
            {
                this.privateListOfTasks.Remove(task);
                this.Save();
            }
        }
    }
}
