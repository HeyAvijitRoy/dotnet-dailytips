// Summary: Shows how switching from IQueryable to IEnumerable too early breaks EF Core optimizations
// Day26
// Author: Avijit Roy

using System;
using System.Collections.Generic;
using System.Linq;

namespace Day26_LinqEfCoreMixing
{
    class Product
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Simulating EF Core DbSet
            IQueryable<Product> products = new List<Product>
            {
                new Product { Id = 1, Category = "Book", Price = 9.99m },
                new Product { Id = 2, Category = "Laptop", Price = 1299.00m },
                new Product { Id = 3, Category = "Book", Price = 19.99m },
                new Product { Id = 4, Category = "Monitor", Price = 299.00m }
            }.AsQueryable();

            // STEP 1: Pure IQueryable - can be translated to SQL in real EF Core
            var query1 = products
                .Where(p => p.Category == "Book")     // Will be translated into SQL WHERE clause
                .Select(p => p.Pric
