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
                Console.WriteLine("Enter file path:");
                string path = Console.ReadLine();
                string content = File.ReadAllText(path); // Can throw FileNotFoundException

                Console.WriteLine("Enter a number to divide 100 by:");
                int divisor = int.Parse(Console.ReadLine());
                int result = 100 / divisor; // Can throw DivideByZeroException

                Console.WriteLine($"Result: {result}");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File error: {ex.Message}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Math error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("End of operation (finally block).");
            }
        }
    }
}
