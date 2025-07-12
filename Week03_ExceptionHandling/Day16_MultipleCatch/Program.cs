// Summary: Demonstrates basic try-catch-finally flow in C#
// Day15
// Author: Avijit Roy

using System;

namespace Day15_TryCatchFinally
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting program...");

            try
            {
                Console.WriteLine("Inside try block.");

                // This line will throw DivideByZeroException
                // int.Parse("0") evaluates to 0, so 10 / 0 triggers the exception
                int result = 10 / int.Parse("0");

                // This line won't be reached due to the exception
                Console.WriteLine($"Result: {result}");
            }
            catch (DivideByZeroException ex)
            {
                // This specific block handles division by zero errors
                Console.WriteLine($"Caught a DivideByZeroException: {ex.Message}");
            }
            catch (FormatException ex)
            {
                // This block would handle invalid number format if int.Parse failed
                Console.WriteLine($"Caught a FormatException: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Fallback catch for all other exceptions
                Console.WriteLine($"Caught a general exception: {ex.Message}");
            }
            finally
            {
                // This block always executes — ideal for cleanup logic
                Console.WriteLine("Inside finally block: Cleaning up resources...");
            }

            Console.WriteLine("Program ended.");
        }
    }
}
