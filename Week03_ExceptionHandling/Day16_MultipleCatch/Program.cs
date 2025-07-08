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
                int result = 10 / int.Parse("0"); // This will throw DivideByZeroException
                Console.WriteLine($"Result: {result}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Caught a DivideByZeroException: {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Caught a FormatException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Caught a general exception: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Inside finally block: Cleaning up resources...");
            }

            Console.WriteLine("Program ended.");
        }
    }
}
