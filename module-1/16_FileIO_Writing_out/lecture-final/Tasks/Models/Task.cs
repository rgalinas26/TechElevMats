using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Models
{
    /// <summary>
    /// Represents a task or to-do item
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Name (short description) of the task
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// Date the task should be completed
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// True if the task has been completed
        /// </summary>
        public bool Complete { get; set; }

        /// <summary>
        /// Constructor to create a new task. defaults to Not Complete.
        /// </summary>
        /// <param name="taskName">Name of the task</param>
        /// <param name="dueDate">Date the task is due</param>
        public Task(string taskName, DateTime dueDate)
        {
            this.TaskName = taskName;
            this.DueDate = dueDate;
            this.Complete = false;
        }

        /// <summary>
        /// Constructor to be used when loading task in from a data store (text file)
        /// </summary>
        /// <param name="taskName">Name of the task</param>
        /// <param name="dueDate">Date the task is due</param>
        /// <param name="complete">True if the task is completed, false if not</param>
        public Task(string taskName, DateTime dueDate, bool complete)
        {
            this.TaskName = taskName;
            this.DueDate = dueDate;
            this.Complete = complete;
        }

    }
}
