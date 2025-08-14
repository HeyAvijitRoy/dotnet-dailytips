## Day 52 — Memory<T>, IMemoryOwner, and Pooling Patterns

**What & Why**
`Memory<T>` and `ReadOnlyMemory<T>` are heap-friendly, sliceable views you can pass **safely across async/iterator boundaries** (unlike `Span<T>`). Pair them with `MemoryPool<T>`/`IMemoryOwner<T>` to **rent** buffers, reduce allocations, and control lifetimes explicitly.

**Key ideas**

* Prefer `ReadOnlyMemory<T>` for input-only APIs and `Memory<T>` for writable output buffers.
* Use `MemoryPool<T>.Shared.Rent(size)` to get an `IMemoryOwner<T>`; dispose it to return the buffer to the pool.
* Slice with `Memory<T>.Slice(start, length)` — no copies.
* Never return `Memory<T>` that points to a pooled buffer **beyond the owner’s lifetime**. Convert at the boundary (e.g., `new string(span)` or copy to a stable array) if you must persist.
* Bridge text and bytes efficiently with `Encoding.UTF8.TryGetBytes(ReadOnlySpan<char>, Span<byte>, out int)` into a rented `Memory<byte>`.

**What the sample shows**

1. **Uppercasing with a pooled `Memory<char>`** and converting to string only at the boundary.
2. **UTF‑8 encoding into a pooled `Memory<byte>`** with `TryGetBytes`, slicing to the written count.
3. **Safe slicing within the owner’s scope** to avoid lifetime bugs.

**Run it**

```bash
cd Week08_PerfSpanMemory/Day52_Memory_IMemoryOwner
 dotnet run
```

## Date: August 13, 2025  
🔗 **Code:** [Program.cs](./program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #Memory #IMemoryOwner #MemoryPool #performance #Day52\_DotNetWithRoy #Week8
