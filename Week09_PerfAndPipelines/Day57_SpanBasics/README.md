## Day 57: Span<T> & ReadOnlySpan<T> — slicing without allocations

`Span<T>` and `ReadOnlySpan<T>` allow you to work with slices of arrays, strings, or stack-allocated memory **without copying or allocating new objects**. This makes them extremely powerful for high-performance scenarios like parsing, processing large datasets, and avoiding unnecessary GC pressure.

### Key points:
- Use `AsSpan` to slice arrays or strings without creating new objects.
- `Span<T>` is mutable; `ReadOnlySpan<T>` is safe for read-only views.
- `stackalloc` can create spans over temporary stack memory for lightweight operations.

## Date: August 18, 2025  
🔗 **Code:** [Program.cs](./Program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #performance #Span #memory #Day57_DotNetWithRoy #Week9
