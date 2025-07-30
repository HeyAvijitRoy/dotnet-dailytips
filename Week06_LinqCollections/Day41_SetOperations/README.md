## Set-based operations in LINQ – Except, Intersect, Union

LINQ provides built-in set operations that make list comparison and combination tasks easy and readable:

* `Except()` returns elements in the first sequence that are not in the second
* `Intersect()` returns elements common to both
* `Union()` returns all unique elements across both sequences

These methods rely on the default equality comparer unless you supply a custom one.

### What You’ll Learn

* How to compare two collections using set logic
* Use cases for `Except`, `Intersect`, and `Union`
* Caveats around custom object comparisons and `IEquatable<T>`

## Date: August 2, 2025

🔗 **Code:** [Program.cs](./program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #LINQ #SetOperations #Collections #Day41_DotNetWithRoy #Week6
