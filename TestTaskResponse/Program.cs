using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskResponse
{
    /// <summary>
    /// The class represents a uniquely named task and a list of dependencies for it.
    /// Dependency is a task that has to be finished before the current task may be started.
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Unique name of the task
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Array of task dependencies
        /// </summary>
        public string[] Dependencies { get; }

        public Task(string name, params string[] dependencies)
        {
            Name = name;
            Dependencies = dependencies;
        }
    }

    class Program
    {
        static void Main()
        {
            // The following array is an example of specific tasks and dependencies between them.
            // For example the following constructor:
            // new Task("task_a", "task_c")
            // means that task_a may be started only after task_c is complete
            var tasks = new[]
            {
                new Task("task_a", "task_c"), // 4 1 3
                new Task("task_b", "task_c"), // 5 2 3
                new Task("task_c", "task_e"), // 8 3 5
                new Task("task_d", "task_a", "task_e"), // 10 4 1 5 DBCA
                new Task("task_e") //5
            };

            var sortedTasks = Sort(tasks);
            foreach (var task in sortedTasks)
            {
                Console.WriteLine($"- {task.Name}");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// <example></example>
        /// Implement a function that accepts a list of tasks (and their dependencies) as an input
        /// and produces a list of tasks in the correct order (the order in which they may be executed)
        ///
        /// For example if we provide the following input
        /// var tasks = new Task[]
        /// {
        ///     new Task("task_a", "task_b", "task_c"),
        ///     new Task("task_b"),
        ///     new Task("task_c", "task_b"),
        /// }
        /// 
        /// the output shall be:
        /// - task_b
        /// - task_c
        /// - task_a
        /// </summary>
        /// <param name="tasks"></param>
        public static Task[] Sort(Task[] tasks)
        {
            foreach (var task in tasks)
            {

                foreach (var val in task.Dependencies)
                {
                    var v = Array.IndexOf(task.Dependencies, val);
                    Console.WriteLine(v);
                }
            }

            return tasks;
        }
    }
}