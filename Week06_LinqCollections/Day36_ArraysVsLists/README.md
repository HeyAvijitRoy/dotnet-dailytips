## LINQ on Arrays vs Lists

LINQ works seamlessly across different collection types in .NET, but how it behaves under the hood can influence performance.

Arrays are fixed-size and indexed — they provide faster enumeration.
Lists are more flexible but introduce some overhead, especially in large-scale LINQ operations or multiple enumerations.

This example measures the performance of a simple `.Where()` query on both arrays and lists to highlight potential performance differences, even if the result is logically identical.

### What You’ll Learn

* How LINQ performs on arrays vs lists
* Why it matters to cache results from deferred LINQ queries
* Subtle allocation/performance tradeoffs when chaining LINQ on collections

## Date: July 28, 2025

🔗 **Code:** [Program.cs](./program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  
**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #LINQ #Collections #Day36\_DotNetWithRoy #Week6
