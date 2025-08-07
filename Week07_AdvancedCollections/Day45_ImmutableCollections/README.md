## Immutable Collections in .NET

.NET provides powerful **Immutable Collections** under the `System.Collections.Immutable` namespace. Unlike traditional collections like `List<T>`, immutable collections **cannot be changed** after they are created.

This makes them ideal for:

* Multi-threaded environments
* Functional programming patterns
* Safely sharing data across components

In this example, we use `ImmutableList<T>` to demonstrate how any modification (like Add) returns a **new instance**, while keeping the original untouched.

### Key Takeaways:

* ImmutableList ensures data safety and consistency.
* Modifications (Add, Remove, etc.) do not mutate the original — they return a copy.
* You can use them in place of traditional lists when thread-safety and predictability are priorities.

To use these collections, install:

```bash
Install-Package System.Collections.Immutable
```

---

## Date: August 6, 2025  
🔗 **Code:** [Program.cs](./program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #Immutable #Collections #Day45\_DotNetWithRoy #Week7
