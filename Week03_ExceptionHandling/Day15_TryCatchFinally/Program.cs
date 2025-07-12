// Summary: Demonstrates multiple catch blocks handling different exception types
// Day16
// Author: Avijit Roy

using System;
using System.IO;

namespace Day16_MultipleCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting multiple catch example...");

            try
            {
                // Prompt user to input a file path
                Console.WriteLine("Enter file path:");
                string path = Console.ReadLine();

                // Try to read the file — may throw FileNotFoundException
                string content = File.ReadAllText(path);

                // Prompt user for a number to divide
                Console.WriteLine("Enter a number to divide 100 by:");
                int divisor = int.Parse(Console.ReadLine());

                // Division operation — may throw DivideByZeroException
                int result = 100 / divisor;

                Console.WriteLine($"Result: {result}");
            }
            catch (FileNotFoundException ex)
            {
                // Specific handler for missing file
                Console.WriteLine($"File error: {ex.Message}");
            }
            catch (DivideByZeroException ex)
            {
                // Specific handler for divide-by-zero
                Console.WriteLine($"Math error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Catch-all handler for any other exceptions
                Console.WriteLine($"General error: {ex.Message}");
            }
            finally
            {
                // Always runs — used for cleanup or logging
                Console.WriteLine("End of operation (finally block).");
            }
        }
    }
}
