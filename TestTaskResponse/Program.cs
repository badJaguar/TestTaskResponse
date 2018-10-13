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
                new Task("task_a", "task_c"),
                new Task("task_b", "task_c"),
                new Task("task_c", "task_e"),
                new Task("task_d", "task_a", "task_e"),
                new Task("task_e")
            };

            var sortedTasks = Sort(tasks);
            foreach (var task in sortedTasks)
            {
                Console.WriteLine($"- {task}");
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
        /// <param name="tasks">todo: describe tasks parameter on Sort</param>
        public static List<string> Sort(Task[] tasks)
        {
            var result = new List<string>();
            
            foreach (var task in tasks)
            {
                if (!result.Contains(task.Name))
                    result.Add(task.Name);

                foreach (var depency in task.Dependencies)
                    if (!result.Contains(depency))
                    {
                        result.Insert(result.IndexOf(task.Name), depency);
                    }
            }
            return result;
        }
    }

    //var sorted = from t in tasks
    //    orderby t.Dependencies.Rank,
    //        t.Dependencies.Length,
    //        t.Dependencies.ToString()
    //    select t.Name;

    //foreach (var value in sorted)
    //{
    //    Console.WriteLine(value);
    //}
    //return tasks;
}