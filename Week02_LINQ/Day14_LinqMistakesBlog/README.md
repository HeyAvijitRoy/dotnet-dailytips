## Top LINQ Mistakes to Avoid in .NET

LINQ makes data querying elegant in .NET. But like every powerful tool, misuse can introduce bugs, waste memory, and create performance bottlenecks.

After spending a full week exploring LINQ, here are the **top 6 mistakes developers make with LINQ in the wild — and how to avoid them.**

---

### 1. Unnecessary ToList()

Calling `.ToList()` forces the query to execute **immediately**, creates a new list in memory, and loses the benefit of deferred execution.

**Bad:**

```csharp
var list = data.Where(x => x.IsActive).ToList();
```

**Better:**

```csharp
foreach (var item in data.Where(x => x.IsActive))
    Console.WriteLine(item);
```

Use `.ToList()` only when you **need a snapshot**, or plan to iterate the results multiple times.

---

### 2. Multiple Enumeration

LINQ queries are lazy. If you enumerate them twice, the query **runs twice**.

**Problem:**

```csharp
var query = GetItems();
Console.WriteLine(query.Count());  // first run
Console.WriteLine(query.First());  // second run
```

**Fix:**

```csharp
var cached = GetItems().ToList();
Console.WriteLine(cached.Count);
Console.WriteLine(cached.First());
```

---

### 3. Forgetting Deferred Execution

LINQ queries only run **when you enumerate them**. If your data source changes between defining the query and running it, you'll get unexpected results.

Example:

```csharp
var numbers = new List<int> { 1, 2, 3 };
var query = numbers.Where(n => n > 1);
numbers.Add(4);

// query sees the updated list!
foreach (var n in query)
    Console.WriteLine(n);
```

---

### 4. Misunderstanding Select vs SelectMany

* `Select()` keeps nested collections intact.
* `SelectMany()` flattens them.

```csharp
people.Select(p => p.Skills);     // IEnumerable<string[]>
people.SelectMany(p => p.Skills); // IEnumerable<string>
```

---

### 5. GroupBy Without Shaping Results

`GroupBy()` returns groupings, not flattened results.

**Wrong:**

```csharp
var groups = numbers.GroupBy(n => n % 2);
```

**Better:**

```csharp
var groups = numbers.GroupBy(n => n % 2)
    .Select(g => new { Key = g.Key, Items = g.ToList() });
```

---

### 6. Ignoring Exceptions in Projections

If your query body throws an exception, LINQ won't catch it:

```csharp
var result = data.Select(x => 1 / x.SomeValue); // division by zero can crash here
```

Handle exceptions where appropriate.

---

### Final Thoughts

LINQ is **deceptively simple but incredibly powerful.**

Mastering it takes:

* Awareness of when queries execute
* Caching results appropriately
* Choosing the right operators (`Select`, `SelectMany`, `GroupBy`, etc.)

Happy querying!

---

🕕 **Date:** July 6, 2025  
🔗 **Code:** [Program.cs](./Program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #linq #linqmistakes #Day14\_DotNetWithRoy #Week2
