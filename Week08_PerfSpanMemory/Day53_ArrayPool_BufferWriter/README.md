## Day 53 — ArrayPool<T>, IBufferWriter<T>, and Fast Buffering

**What & Why**
`ArrayPool<T>` lets you **rent & reuse** arrays to cut GC pressure in hot paths. `IBufferWriter<T>` (with `ArrayBufferWriter<T>`) gives you a **growable, zero-copy-ish writer** that hands out spans; you fill them and `Advance()` — no manual resizing.

**Key ideas**

* Rent with `ArrayPool<T>.Shared.Rent(size)`; **always** return with `Return(array, clearArray: true)` if data is sensitive.
* Compute required sizes when possible (e.g., Base64 encoded length) to rent just enough.
* `IBufferWriter<T>` pattern: `GetSpan(sizeHint) -> write -> Advance(count)`; repeat.
* Use `ArrayBufferWriter<byte>`/`char` for variable-sized output; turn into a `string` or `byte[]` at the boundary.

**What the sample shows**

1. **Base64 encode with pooled buffers**: UTF‑8 bytes in a rented `byte[]`, then Base64 chars into a rented `char[]`, allocating only once at the very end.
2. **CSV building with `IBufferWriter<char>`** using `int.TryFormat` and `Advance()` — no `StringBuilder`, no intermediate strings.
3. Lifetime hygiene: pooled arrays are valid only until returned; `ArrayBufferWriter<T>` stays valid as long as the instance lives.

**Run it**

```bash
cd Week08_PerfSpanMemory/Day53_ArrayPool_BufferWriter
 dotnet run
```

## Date: August 14, 2025  
🔗 **Code:** [Program.cs](./program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #ArrayPool #IBufferWriter #performance #memory #Day53\_DotNetWithRoy #Week8
