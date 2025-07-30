## Avoiding Multiple Enumeration in LINQ

One of the most common performance traps in LINQ is unintentionally enumerating the same query multiple times. LINQ queries are **deferred** by default — meaning every call to `.Count()`, `.First()`, `.ToList()` re-runs the entire query pipeline.

This is especially dangerous when your data source is remote (like a DB), expensive (like a stream), or mutating.

### What You’ll Learn

* Why LINQ queries are deferred by design
* What happens when you enumerate a LINQ query multiple times
* How to safely cache results using `.ToList()` or `.ToArray()`

## Date: July 31, 2025

🔗 **Code:** [Program.cs](./program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #LINQ #Performance #Collections #Day39\_DotNetWithRoy #Week6
