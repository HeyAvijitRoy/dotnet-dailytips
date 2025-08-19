## Week 9: High-Performance .NET — Span, Memory & Pipelines

This week dives into .NET performance-focused types and APIs that help reduce allocations and write zero-copy, high-throughput code. We’ll cover `Span<T>`, `Memory<T>`, pooling, buffer writers, pipelines, and efficient text processing with modern parsers. The week ends with a blog-style deep dive into building a zero-allocation pipeline for CSV/JSON.

| Day | Date         | Topic                                                         | Link                                                          |
| --- | ------------ | ------------------------------------------------------------- | ------------------------------------------------------------- |
| 57  | Aug 18, 2025 | Span<T> & ReadOnlySpan<T> — slicing without allocations       | [View](./Week09_PerfAndPipelines/Day57_SpanBasics)            |
| 58  | Aug 19, 2025 | stackalloc, slicing, and safety pitfalls                      | [View](./Week09_PerfAndPipelines/Day58_StackallocAndSlices)   |
| 59  | Aug 20, 2025 | Memory<T>, IMemoryOwner, and MemoryPool<T>                    | [View](./Week09_PerfAndPipelines/Day59_MemoryAndPools)        |
| 60  | Aug 21, 2025 | IBufferWriter<T> & building fast writers (zero-copy patterns) | [View](./Week09_PerfAndPipelines/Day60_IBufferWriter)         |
| 61  | Aug 22, 2025 | System.IO.Pipelines — producers/consumers done right          | [View](./Week09_PerfAndPipelines/Day61_PipelinesBasics)       |
| 62  | Aug 23, 2025 | Text perf: Utf8JsonReader, Utf8Parser, Rune (Unicode-safe)    | [View](./Week09_PerfAndPipelines/Day62_TextPerf)              |
| 63  | Aug 24, 2025 | Blog: Building a zero-allocation CSV/JSON pipeline            | [View](./Week09_PerfAndPipelines/Day63_ZeroAllocPipelineBlog) |

---

## Date: August 18–24, 2025

🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #performance #Span #Memory #Pipelines #Day57\_DotNetWithRoy #Day58\_DotNetWithRoy #Day59\_DotNetWithRoy #Day60\_DotNetWithRoy #Day61\_DotNetWithRoy #Day62\_DotNetWithRoy #Day63\_DotNetWithRoy #Week9
