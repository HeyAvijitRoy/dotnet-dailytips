## Day 50 — Span<T> Fundamentals & Slicing

**What & Why**
`Span<T>` and `ReadOnlySpan<T>` let you work with contiguous memory **without allocating** new arrays/strings. You can slice, parse, and transform data in place—great for hot paths, parsers, and I/O—while lowering GC pressure.

**Key ideas**

* Use `AsSpan()` to create slices over strings/arrays **without copies**.
* Prefer `ReadOnlySpan<char>` in APIs that only need to read text. It accepts both strings and stack/array data.
* Use `IndexOf`, slicing (`[..]`, `Slice`), and `TryParse(ReadOnlySpan<char>)` for zero‑copy parsing.
* Converting spans to strings (via `.ToString()`) **allocates**—do it at boundaries (e.g., UI/logging), not inside tight loops.
* `Span<T>` is a `ref struct` (stack‑only); don’t capture it in lambdas, `async`, or iterators, and don’t store it in fields.

**How**

* Example 1: Tokenize delimited data with `IndexOf` + slicing, avoiding `Substring` allocations.
* Example 2: Mutate a section of an array using `AsSpan(start, length)` to show in‑place edits.
* Example 3: Parse CSV numbers with `int.TryParse(ReadOnlySpan<char>, out int)` for zero‑copy parsing.

**Run it**

```bash
cd Week08_PerfSpanMemory/Day50_SpanBasics
 dotnet run
```

## Date: August 11, 2025  
🔗 **Code:** [Program.cs](./program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #Span #performance #memory #Day50\_DotNetWithRoy #Week8
