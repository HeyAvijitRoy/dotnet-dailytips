## Day 63: Blog — Building a zero-allocation CSV/JSON pipeline

This demo shows how to process streaming JSON (or CSV) data in .NET without unnecessary allocations, by combining `Span<T>`, `Memory<T>`, `IBufferWriter<T>`, and `System.IO.Pipelines`.

### Key points:
- Use `Pipe` to manage producer/consumer flow of bytes.  
- Parse JSON with `Utf8JsonReader` directly from UTF-8 spans.  
- Use `Utf8Parser` to parse numbers without string conversions.  
- Avoid intermediate `string.Split()` or `Substring()` calls.  
- Output results with `IBufferWriter<T>` for efficient writing.

This approach minimizes GC pressure and enables scalable, high-throughput pipelines for text-heavy workloads.

## Date: August 24, 2025  
🔗 **Code:** [Program.cs](./Program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  
**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #performance #Pipelines #Utf8JsonReader #Utf8Parser #Span #Day63_DotNetWithRoy #Week9
