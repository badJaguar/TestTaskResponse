using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using TaskAlias = System.Threading.Tasks.Task;

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
            var list = new List<string>();
            var dependencies = from t in tasks
                               select t.Dependencies
                into orderedDeps
                               from task in orderedDeps
                               select task;

            var collection = dependencies as string[] ?? dependencies.ToArray();
            list.AddRange(collection);
            var strings = collection.ToArray();
            Array.Sort(strings);

            var names = from t in tasks
                        select t.Name;
            var g = names.OrderBy




            foreach (var dependency in strings)
            {
                Console.WriteLine($" {dependency}");
            }
            return tasks;
        }
    }
}
//foreach (var v in task.Dependencies)
//{
//    var c = v.Replace("task_", string.Empty);

//    var r = from t in task.Dependencies
//            select t;

//    var d = from b in r
//            select b;

//    var h = from s in d
//            group s by task.Name;
//    foreach (var VARIABLE in h)
//    {
//        Array.IndexOf(task.Dependencies, c);
//        //Console.WriteLine($" {task.Name}");
//    }

//}