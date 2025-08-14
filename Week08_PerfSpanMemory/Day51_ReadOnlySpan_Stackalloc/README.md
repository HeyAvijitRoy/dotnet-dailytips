## Day 51 — ReadOnlySpan<char>, stackalloc, and Safe Slicing

**What & Why**
Use `ReadOnlySpan<char>` for **zero‑copy reads** over strings, arrays, and stack memory. Use `stackalloc` to create short‑lived buffers on the stack for fast transformations without touching the GC. Together, they let you parse and normalize text in hot paths with fewer allocations.

**Key ideas**

* Accept `ReadOnlySpan<char>` in parse/normalize APIs so callers can pass strings **without allocating**.
* `stackalloc` creates a `Span<char>` that lives only in the current scope; it’s perfect for small scratch buffers.
* Use span helpers: `IndexOf`, range slices (`[..]`), `Trim()`, and `int.TryParse(ReadOnlySpan<char>, out int)` to avoid intermediate strings.
* Convert to `string` at the **boundary** (`new string(span)` or `span.ToString()`) — not in inner loops.
* Safety: `Span<T>`/`ReadOnlySpan<T>` are `ref struct`s — keep them on the stack; don’t capture in lambdas/async or store in fields.

**What the sample shows**

1. **Email normalization** using `ReadOnlySpan<char>`: lower‑cases domain, removes dots and `+tag` in the local part (Gmail‑style), and trims whitespace — all via slicing.
2. **Whitespace compaction** using a `stackalloc` buffer (mutating `Span<char>` in place) followed by zero‑copy integer parsing.

**Run it**

```bash
cd Week08_PerfSpanMemory/Day51_ReadOnlySpan_Stackalloc
 dotnet run
```

## Date: August 12, 2025  
🔗 **Code:** [Program.cs](./program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #Span #ReadOnlySpan #stackalloc #performance #Day51\_DotNetWithRoy #Week8
