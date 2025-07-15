// Summary: Demonstrates where clause difference between IEnumerable and IQueryable
// Day23
// Author: Avijit Roy

using System;
using System.Collections.Generic;
using System.Linq;

namespace Day23_WhereClause
{
    class User
    {
        public int Id { get; set; }
        public string Role { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Simulated in-memory user list (like data from a DB)
            List<User> users = new List<User>
            {
                new User { Id = 1, Role = "Admin" },
                new User { Id = 2, Role = "User" },
                new User { Id = 3, Role = "Admin" },
                new User { Id = 4, Role = "Guest" }
            };

            // IEnumerable: filtering is done in-memory after full data is loaded.
            IEnumerable<User> enumerableResult = users.Where(u =>
            {
                Console.WriteLine($"Filtering (IEnumerable): {u.Role}"); // Executes immediately during iteration
                return u.Role == "Admin";
            });

            Console.WriteLine("\n--- IEnumerable Execution ---");

            // Triggers the filtering logic for IEnumerable (in-memory)
            foreach (var user in enumerableResult)
            {
                Console.WriteLine($"Result: User {user.Id} - {user.Role}");
            }

            // IQueryable: simulates a database-aware query. The filter is not evaluated until iteration.
            // In real-world (e.g., EF Core), this would translate to SQL WHERE clause.
            IQueryable<User> queryableUsers = users.AsQueryable(); // Mocking IQueryable behavior
            var queryableResult = queryableUsers.Where(u =>
            {
                Console.WriteLine($"Filtering (IQueryable): {u.Role}"); // Deferred until enumeration
                return u.Role == "Admin";
            });

            Console.WriteLine("\n--- IQueryable Execution ---");

            // Execution is deferred and then applied during enumeration
            foreach (var user in queryableResult)
            {
                Console.WriteLine($"Result: User {user.Id} - {user.Role}");
            }
        }
    }
}
