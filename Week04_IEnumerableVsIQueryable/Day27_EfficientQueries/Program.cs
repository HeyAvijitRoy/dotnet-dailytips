// Summary: Demonstrates writing efficient queries using IQueryable with filtering and projection
// Day27
// Author: Avijit Roy

using System;
using System.Collections.Generic;
using System.Linq;

namespace Day27_EfficientQueries
{
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }

    class Program
    {
        static void Main()
        {
            // Simulating a database table with IQueryable
            IQueryable<User> users = new List<User>
            {
                new User { Id = 1, Name = "Alice", Email = "alice@example.com", IsActive = true },
                new User { Id = 2, Name = "Bob", Email = "bob@example.com", IsActive = false },
                new User { Id = 3, Name = "Charlie", Email = "charlie@example.com", IsActive = true }
            }.AsQueryable();

            // Inefficient: fetches all users, then filters and projects in memory
            var inefficient = users.ToList()
                                   .Where(u => u.IsActive)
                                   .Select(u => u.Email);

            Console.WriteLine("Inefficient query result:");
            foreach (var email in inefficient)
            {
                Console.WriteLine(email);
            }

            Console.WriteLine("\n--------------------------\n");

            // Efficient: filters and projects using IQueryable (can translate to SQL)
            var efficient = users.Where(u => u.IsActive)
                                 .Select(u => u.Email);

            Console.WriteLine("Efficient query result:");
            foreach (var email in efficient)
            {
                Console.WriteLine(email);
            }
        }
    }
}
