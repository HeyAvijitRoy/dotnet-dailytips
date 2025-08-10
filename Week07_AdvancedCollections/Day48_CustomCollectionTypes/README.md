## Custom Collection Types and LINQ

Sometimes the built-in collections aren’t a perfect fit. You might want to enforce invariants (e.g., uniqueness), add domain-specific helpers, or control iteration order. The key to making your **custom collection** work seamlessly with LINQ is to implement `IEnumerable<T>` (and ideally `IReadOnlyCollection<T>` for Count).

In this example, we build a `TodoBucket` that:

* Enforces **unique titles**
* Provides **O(1)** lookups internally via `Dictionary`
* Implements `IEnumerable<Todo>` so **all LINQ operators just work**

### Why this matters

* **LINQ compatibility:** Implementing `GetEnumerator()` is enough to unlock `Where`, `Select`, `OrderBy`, etc.
* **Encapsulation:** You can hide your internal storage while still exposing a clean query surface.
* **Safety:** By not exposing the inner list/dictionary, you prevent callers from bypassing your rules.

### Tips

* Prefer exposing **read-only** views or `IReadOnlyCollection<T>` over raw lists.
* Be explicit about **iteration order** (document it or enforce it).
* If you need immutability, pair the pattern with `System.Collections.Immutable`.

---

## Date: August 9, 2025  
🔗 **Code:** [Program.cs](./program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #Collections #LINQ #Day48\_DotNetWithRoy #Week7
