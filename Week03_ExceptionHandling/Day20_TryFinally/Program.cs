// Summary: Demonstrates try-finally block without catch to ensure cleanup happens even on exceptions
// Day20
// Author: Avijit Roy

using System;

namespace Day20_TryFinally
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting try-finally demo...");

            try
            {
                // Attempt to perform an operation that throws
                PerformOperation();
            }
            catch (Exception ex)
            {
                // Catch the exception thrown from PerformOperation()
                Console.WriteLine($"Exception caught in Main: {ex.Message}");
            }

            Console.WriteLine("Program finished.");
        }

        static void PerformOperation()
        {
            try
            {
                Console.WriteLine("Opening resource...");

                // Simulate an error during operation
                throw new InvalidOperationException("Something went wrong while using the resource.");
            }
            finally
            {
                // This block always executes — even when an exception is thrown
                Console.WriteLine("Cleaning up resource (finally block).");
            }
        }
    }
}
