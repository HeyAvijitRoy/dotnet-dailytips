## Custom LINQ Extension Methods: Build Your Own

LINQ in .NET is powerful not only because of its built-in methods, but because you can extend it with your own. In this post, we’ll create a `ChunkBy()` extension method that splits a list into smaller sub-lists, like `Chunk()` in .NET 6+.

### Example Use Case

```csharp
var numbers = Enumerable.Range(1, 10);
var chunks = numbers.ChunkBy(3);

foreach (var chunk in chunks)
{
    Console.WriteLine(string.Join(", ", chunk));
}
```

Output:

```
1, 2, 3
4, 5, 6
7, 8, 9
10
```

### Why Build Custom LINQ Methods?

* Encapsulate complex query patterns
* Make code more readable and expressive
* Encourage reuse of query logic

### Key Concepts

* Use **extension methods on IEnumerable** to integrate with LINQ syntax.
* Use **yield return** to keep it lazy and memory-efficient.
* Follow LINQ method naming patterns: `Filter`, `Chunk`, `GroupBySomething`, etc.

---

## Date: July 5, 2025  
🔗 **Code:** [Program.cs](./Program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  
#### **Tags:** #dotnetdailytips #DotNetWithRoy #csharp #CustomLINQ #Day13\_DotNetWithRoy #Week2
