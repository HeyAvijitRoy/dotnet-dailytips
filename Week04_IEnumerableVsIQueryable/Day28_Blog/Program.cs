// Week 4 Demo: IEnumerable vs IQueryable
// Author: Avijit Roy

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Day 22: Intro ===");
        RunDay22();

        Console.WriteLine("\n=== Day 23: Where Clause ===");
        RunDay23();

        Console.WriteLine("\n=== Day 24: Deferred Execution ===");
        RunDay24();

        Console.WriteLine("\n=== Day 25: Immediate Execution ===");
        RunDay25();

        Console.WriteLine("\n=== Day 26: EF Core Gotchas (Simulated) ===");
        RunDay26();

        Console.WriteLine("\n=== Day 27: Efficient Querying ===");
        RunDay27();
    }

    // Day 22
    static void RunDay22()
    {
        var numbers = Enumerable.Range(1, 10).ToList();
        IEnumerable<int> evenEnum = numbers.Where(n => n % 2 == 0);
        IQueryable<int> evenQuery = numbers.AsQueryable().Where(n => n % 2 == 0);

        Console.WriteLine("IEnumerable:");
        Console.WriteLine(string.Join(", ", evenEnum));

        Console.WriteLine("IQueryable:");
        Console.WriteLine(string.Join(", ", evenQuery));
    }

    // Day 23
    static void RunDay23()
    {
        var users = new List<User> {
            new User { Id = 1, Role = "Admin" },
            new User { Id = 2, Role = "User" },
            new User { Id = 3, Role = "Admin" }
        };

        IEnumerable<User> enumResult = users.Where(u => u.Role == "Admin");
        IQueryable<User> queryResult = users.AsQueryable().Where(u => u.Role == "Admin");

        Console.WriteLine("IEnumerable Admins: " + enumResult.Count());
        Console.WriteLine("IQueryable Admins: " + queryResult.Count());
    }

    // Day 24
    static void RunDay24()
    {
        var query = Enumerable.Range(1, 5).AsQueryable().Where(n =>
        {
            Console.WriteLine($"Filtering: {n}");
            return n % 2 == 1;
        });

        Console.WriteLine("Deferred Execution — Now executing:");
        foreach (var n in query) Console.WriteLine(n);
    }

    // Day 25
    static void RunDay25()
    {
        var result = Enumerable.Range(1, 6).Where(n => n > 2).ToList();
        Console.WriteLine("Executed immediately with ToList():");
        Console.WriteLine(string.Join(", ", result));
    }

    // Day 26
    static void RunDay26()
    {
        IQueryable<User> users = new List<User>
        {
            new User { Id = 1, Email = "admin@example.com" },
            new User { Id = 2, Email = "user@site.org" }
        }.AsQueryable();

        try
        {
            // Simulating EF Core limitation
            bool CustomFilter(User u) => u.Email.EndsWith(".com");
            var result = users.Where(CustomFilter); // Not translatable in EF Core
            Console.WriteLine("Custom filter result:");
            foreach (var u in result) Console.WriteLine(u.Email);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"⚠️ Simulated failure: {ex.Message}");
        }
    }

    // Day 27
    static void RunDay27()
    {
        IQueryable<User> users = new List<User>
        {
            new User { Id = 1, Name = "Alice", Email = "a@x.com", IsActive = true },
            new User { Id = 2, Name = "Bob", Email = "b@x.com", IsActive = false },
            new User { Id = 3, Name = "Charlie", Email = "c@x.com", IsActive = true }
        }.AsQueryable();

        var efficient = users.Where(u => u.IsActive).Select(u => u.Email);
        Console.WriteLine("Active user emails:");
        foreach (var email in efficient) Console.WriteLine(email);
    }

    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
