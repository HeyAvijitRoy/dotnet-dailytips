// Summary: Demonstrates how to create and use a custom exception class in C#
// Day18
// Author: Avijit Roy

using System;

namespace Day18_CustomExceptions
{
    // Define a custom exception by inheriting from System.Exception
    public class InvalidUserActionException : Exception
    {
        // Default constructor
        public InvalidUserActionException() { }

        // Constructor that takes a message
        public InvalidUserActionException(string message) : base(message) { }

        // Constructor that takes a message and an inner exception (for chaining)
        public InvalidUserActionException(string message, Exception inner) : base(message, inner) { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Custom exception demo starting...");

            try
            {
                // Attempt an action that may be invalid
                PerformAction("forbidden");
            }
            catch (InvalidUserActionException ex)
            {
                // Catch the custom exception and show the message
                Console.WriteLine($"Custom exception caught: {ex.Message}");
            }
        }

        // This method simulates an operation that can fail
        static void PerformAction(string action)
        {
            // If the action is "forbidden", we throw our custom exception
            if (action == "forbidden")
            {
                throw new InvalidUserActionException("This action is not allowed.");
            }

            Console.WriteLine("Action performed successfully.");
        }
    }
}
