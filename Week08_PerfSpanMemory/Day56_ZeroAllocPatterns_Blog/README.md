## Day 56 — Practical Zero-Allocation Patterns (Weekly Blog)

This week I focused on cutting allocations out of hot paths and keeping data as UTF-8 as long as possible. The result: fewer temporary strings/arrays, less GC pressure, and smoother throughput under load.

**What & Why**
- **Span<T>/ReadOnlySpan<char>**: slice data without copying, avoid `Substring`.
- **ReadOnlySpan + stackalloc**: small, scoped buffers for transient work.
- **Memory<T>/IMemoryOwner**: rent from `MemoryPool<T>`, slice safely, and dispose.
- **ArrayPool<T>/IBufferWriter<T>**: grow output efficiently; format with `TryFormat`.
- **UTF-8 first**: parse with `Utf8Parser.TryParse`, transform with `Rune` at scalar level.
- **Pipelines**: handle partial reads/writes and backpressure with fewer copies.

**What the sample shows**
- A producer emits fragmented UTF-8 lines (socket-like).
- The consumer:
  - Reads lines via **System.IO.Pipelines** (no intermediate strings).
  - Extracts fields from **UTF-8 bytes** and **parses ints with Utf8Parser**.
  - **Normalizes Unicode** using `Rune` (letters/digits/space, uppercase).
  - **Formats the result** using `ArrayBufferWriter<char>` and `TryFormat`.

**How to run**
1. `cd Week08_PerfSpanMemory/Day56_ZeroAllocPatterns_Blog`
2. `dotnet run`

## Date: August 17, 2025  
🔗 **Code:** [Program.cs](./program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #performance #Span #UTF8 #Pipelines #ArrayPool #MemoryPool #Day56_DotNetWithRoy #Week8
