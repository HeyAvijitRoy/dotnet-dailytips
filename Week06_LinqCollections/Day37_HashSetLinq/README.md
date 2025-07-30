## Working with HashSet and LINQ

LINQ and `HashSet<T>` can be a powerful combo — but only if you understand how they work together.

While `HashSet.Contains()` gives near-instant lookups, LINQ's set methods like `.Intersect()` or `.Except()` can have unexpected performance behavior if the collections are not already hash-based.

This example contrasts using `Where + Contains` versus `Intersect` to filter a large list using a `HashSet` — and reveals how choosing the right approach can drastically improve performance.

### What You’ll Learn

* How to leverage `HashSet.Contains()` for lightning-fast filtering
* When to avoid `Intersect()` on large sequences
* The difference between LINQ semantics and real performance

## Date: July 29, 2025

🔗 **Code:** [Program.cs](./program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #LINQ #HashSet #Collections #Day37\_DotNetWithRoy #Week6
