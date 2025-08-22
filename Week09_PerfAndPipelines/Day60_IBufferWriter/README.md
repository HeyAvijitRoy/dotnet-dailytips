## Day 60: IBufferWriter<T> & building fast writers (zero-copy patterns)

`IBufferWriter<T>` provides a way to write data efficiently into a resizable buffer without worrying about manual allocations.  
It’s widely used in high-performance .NET APIs like `System.IO.Pipelines` and `Utf8JsonWriter`.

### Key points:
- Use `GetSpan(sizeHint)` or `GetMemory(sizeHint)` to request writable space.  
- Write directly into the buffer and call `Advance(count)` to commit.  
- Common implementation: `ArrayBufferWriter<T>`.  
- Eliminates the need for manual buffer resizing or intermediate arrays.  

## Date: August 21, 2025  
🔗 **Code:** [Program.cs](./Program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #performance #IBufferWriter #buffers #Day60_DotNetWithRoy #Week9
