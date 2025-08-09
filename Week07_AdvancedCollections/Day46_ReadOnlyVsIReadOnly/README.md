## ReadOnlyCollection vs IReadOnlyList

`ReadOnlyCollection<T>` and `IReadOnlyList<T>` both expose read-only *views* over a sequence, but they are not the same thing — and neither one makes your data immutable.

* **IReadOnlyList<T> (interface):** A read-only *contract* (Count + indexer). Many types (e.g., `List<T>`, arrays) can be viewed as `IReadOnlyList<T>`. If a caller still has the concrete `List<T>`, they can mutate it — the `IReadOnlyList<T>` view will reflect those changes.
* **ReadOnlyCollection<T> (class):** A read-only *wrapper* around an existing list. You can’t call Add/Remove on the wrapper, but if the *underlying* list changes, the wrapper’s view updates.
* **Neither is immutable.** For true immutability, prefer `System.Collections.Immutable` (e.g., `ImmutableList<T>`).

### What to use when

* **API surface / method parameters:** Accept `IReadOnlyList<T>` when you want to expose a read-only contract without committing to a concrete type.
* **Return a defensive view:** Return `ReadOnlyCollection<T>` via `list.AsReadOnly()` to discourage mutation by consumers (still not immutable!).
* **Require immutability:** Use `ImmutableList<T>` to prevent any accidental changes.

### Demo highlights

* Casting a `List<T>` to `IReadOnlyList<T>` doesn’t freeze it; mutations through the original list are visible through the interface.
* `ReadOnlyCollection<T>` blocks direct edits, but still reflects changes to the source list.

---

## Date: August 7, 2025  

🔗 **Code:** [Program.cs](./program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  
**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #ReadOnly #Collections #Day46\_DotNetWithRoy #Week7
