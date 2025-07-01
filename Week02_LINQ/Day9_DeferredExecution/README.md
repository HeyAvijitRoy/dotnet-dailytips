# Deferred Execution in LINQ

LINQ doesn't execute immediately. Queries are just expressions until you iterate over them.

This behavior is called **deferred execution**, and it can lead to surprises if you modify the source collection after defining the query.

## 🔄 What’s Happening?

```csharp
var numbers = new List<int> { 1, 2, 3 };
var query = numbers.Where(n => n > 1); // Not executed yet

numbers.Add(4); // Happens *before* we run the query

foreach (var n in query)
    Console.WriteLine(n); // Output: 2, 3, 4
```

## 🧠 Insights
- The query only runs when you enumerate it
- LINQ is like a recipe — not a dish — until you serve it (iterate)
- Can save resources, but be mindful when the source data changes

✅ Use `.ToList()` or `.ToArray()` if you want to **evaluate immediately**

```csharp
var snapshot = query.ToList();
```

## 📅 Date: June 30, 2025
🔗 **Code:** [Program.cs](./Program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  
🏷 **Tags:** #dotnetdailytips #DotNetWithRoy #csharp #LINQ #deferredexecution #Day9_DotNetWithRoy #Week2
