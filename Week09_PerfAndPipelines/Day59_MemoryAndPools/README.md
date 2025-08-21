## Day 59: Memory<T>, IMemoryOwner, and MemoryPool<T>

`Memory<T>` extends the capabilities of `Span<T>` by allowing slices to live beyond the current method, making it usable with async code.  
`MemoryPool<T>` provides reusable buffers to avoid constant allocations and reduce GC pressure.

### Key points:
- `Span<T>` is stack-only, while `Memory<T>` can be stored and awaited across async calls.  
- `MemoryPool<T>` lets you rent reusable buffers via `IMemoryOwner<T>`.  
- Always call `Dispose()` on the `IMemoryOwner` to return buffers to the pool.  
- Excellent for high-throughput scenarios like networking or serialization.

## Date: August 20, 2025  
🔗 **Code:** [Program.cs](./Program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  
**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #performance #Memory #MemoryPool #Day59_DotNetWithRoy #Week9
