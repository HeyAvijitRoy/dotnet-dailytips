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
                CauseError();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Outer catch caught: {ex.Message}");
                Console.WriteLine("Stack Trace:");
                Console.WriteLine(ex.StackTrace);
            }
        }

        static void CauseError()
        {
            try
            {
                int[] numbers = new int[2];
                Console.WriteLine(numbers[5]); // IndexOutOfRangeException
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Inner catch: {ex.Message}");
                // Uncomment one of the following to test the difference:

                throw;    // Preserves original stack trace ✅
                // throw ex; // Resets the stack trace ❌
            }
        }
    }
}
