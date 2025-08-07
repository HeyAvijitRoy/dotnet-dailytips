## Dictionary of Lists with LINQ

Working with collections where a key maps to multiple items is a common pattern in .NET. A `Dictionary<TKey, List<TValue>>` is perfect when you need to group items dynamically, like students by class, orders by category, or logs by severity.

However, managing these structures often leads to verbose code with repetitive checks like `if (!dict.ContainsKey(key))...` — this is where combining **LINQ** with the **Dictionary of Lists** pattern can simplify operations.

In this example, we demonstrate:

* How to safely add items into a Dictionary of Lists.
* Using LINQ queries to filter items under a specific key.
* Aggregating counts across all keys using Select.

### Key Takeaways:

* Always use `TryGetValue` to simplify adding items into a Dictionary of Lists.
* LINQ queries on the List<T> under a key are straightforward and powerful.
* Aggregations across keys become elegant with LINQ's Select and projection.

---

## Date: August 4, 2025 
🔗 **Code:** [Program.cs](./program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  
**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #Dictionary #LINQ #Day43\_DotNetWithRoy #Week7
