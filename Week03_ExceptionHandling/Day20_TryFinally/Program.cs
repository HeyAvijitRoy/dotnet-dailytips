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
                PerformOperation();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught in Main: {ex.Message}");
            }

            Console.WriteLine("Program finished.");
        }

        static void PerformOperation()
        {
            try
            {
                Console.WriteLine("Opening resource...");
                throw new InvalidOperationException("Something went wrong while using the resource.");
            }
            finally
            {
                Console.WriteLine("Cleaning up resource (finally block).");
            }
        }
    }
}
