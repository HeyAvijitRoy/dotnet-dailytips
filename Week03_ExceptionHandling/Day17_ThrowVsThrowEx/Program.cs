// Summary: Demonstrates the difference between 'throw;' and 'throw ex;' in preserving stack trace
// Day17
// Author: Avijit Roy

using System;

namespace Day17_ThrowVsThrowEx
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting throw vs throw ex demo...");

            try
            {
                CauseError(); // Call method that throws an exception
            }
            catch (Exception ex)
            {
                // Outer catch receives the re-thrown exception
                Console.WriteLine($"Outer catch caught: {ex.Message}");
                Console.WriteLine("Stack Trace:");
                Console.WriteLine(ex.StackTrace); // Stack trace is useful for debugging
            }
        }

        static void CauseError()
        {
            try
            {
                int[] numbers = new int[2];

                // This line will throw IndexOutOfRangeException
                Console.WriteLine(numbers[5]);
            }
            catch (Exception ex)
            {
                // Inner catch handles the exception first
                Console.WriteLine($"Inner catch: {ex.Message}");

                // Uncomment one of the following to test the difference:
                // Re-throw the exception — the two options behave differently:
                throw;      // ✅ Preserves the original stack trace (recommended)
                // throw ex; // ❌ Resets the stack trace to this point (avoid this)
            }
        }
    }
}
