// Summary: Demonstrates PriorityQueue to process tasks by importance
// Day47
// Author: Avijit Roy

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create a PriorityQueue where lower priority number = higher importance
        var taskQueue = new PriorityQueue<string, int>();

        // Enqueue tasks with priorities
        taskQueue.Enqueue("Write documentation", 3);
        taskQueue.Enqueue("Fix critical bug", 1);
        taskQueue.Enqueue("Code review", 2);

        Console.WriteLine("Processing tasks by priority:");
        while (taskQueue.TryDequeue(out var task, out var priority))
        {
            Console.WriteLine($"Task: {task} (Priority {priority})");
        }
    }
}
