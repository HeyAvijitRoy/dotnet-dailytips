// Summary: Demonstrates using exception filters (when) to handle exceptions conditionally
// Day19
// Author: Avijit Roy

using System;

namespace Day19_ExceptionFilters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting exception filters demo...");

            try
            {
                SimulateError("timeout");
            }
            catch (Exception ex) when (ex.Message.Contains("timeout"))
            {
                Console.WriteLine("Handled a timeout-specific error.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Caught a general error: {ex.Message}");
            }

            Console.WriteLine("Program finished.");
        }

        static void SimulateError(string errorType)
        {
            if (errorType == "timeout")
            {
                throw new Exception("This is a timeout error.");
            }

            throw new Exception("This is a general error.");
        }
    }
}
