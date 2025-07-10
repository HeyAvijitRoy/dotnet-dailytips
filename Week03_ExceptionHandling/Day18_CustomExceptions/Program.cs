// Summary: Demonstrates how to create and use a custom exception class in C#
// Day18
// Author: Avijit Roy

using System;

namespace Day18_CustomExceptions
{
    // Define a custom exception class
    public class InvalidUserActionException : Exception
    {
        public InvalidUserActionException() { }

        public InvalidUserActionException(string message) : base(message) { }

        public InvalidUserActionException(string message, Exception inner) : base(message, inner) { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Custom exception demo starting...");

            try
            {
                PerformAction("forbidden");
            }
            catch (InvalidUserActionException ex)
            {
                Console.WriteLine($"Custom exception caught: {ex.Message}");
            }
        }

        static void PerformAction(string action)
        {
            if (action == "forbidden")
            {
                throw new InvalidUserActionException("This action is not allowed.");
            }

            Console.WriteLine("Action performed successfully.");
        }
    }
}
