# Week 8: High‑Performance .NET — Span, Memory, and Pipelines

This week is all about **writing fast, allocation‑aware C#**. We’ll focus on `Span<T>`, `Memory<T>`, pooling, and `System.IO.Pipelines` so you can push throughput, reduce GC pressure, and keep your APIs safe.

---

## What you’ll learn

* When and why to use **Span<T>** and **ReadOnlySpan<T>** for zero‑copy slicing
* Safe stack usage with **stackalloc** and rules around `ref struct`
* Owning vs non‑owning buffers with **Memory<T>**, **IMemoryOwner<T>**, and lifetime concerns
* Buffer reuse with **ArrayPool<T>** and writing efficiently via **IBufferWriter<T>**
* Practical **zero‑allocation parsing** with UTF‑8 primitives and `Rune`
* Streaming I/O with **System.IO.Pipelines** (readers/writers, backpressure, and framing)

---

## How to use this week

Each day contains a single, runnable `Program.cs` demonstrating the concept with clear comments and a short **Carbon-ready** snippet for social. Clone the repo and run any day:

```bash
cd Week08_PerfSpanMemory/Day50_SpanBasics
dotnet run
```

> Target: .NET 8 (or later)

---

## Daily Topics & Links

| Day    | Topic                                            | Link                                                            |
| ------ | ------------------------------------------------ | --------------------------------------------------------------- |
| Day 50 | Span<T> fundamentals & slicing                   | [View](./Week08_PerfSpanMemory/Day50_SpanBasics)                |
| Day 51 | ReadOnlySpan, stackalloc, slicing safely         | [View](./Week08_PerfSpanMemory/Day51_ReadOnlySpan_Stackalloc)   |
| Day 52 | Memory<T>, IMemoryOwner, pooling patterns        | [View](./Week08_PerfSpanMemory/Day52_Memory_IMemoryOwner)       |
| Day 53 | ArrayPool<T>, buffering & IBufferWriter<T>       | [View](./Week08_PerfSpanMemory/Day53_ArrayPool_BufferWriter)    |
| Day 54 | Zero-allocation parsing (Span-based UTF-8, Rune) | [View](./Week08_PerfSpanMemory/Day54_ZeroAllocParsing_SpanUtf8) |
| Day 55 | System.IO.Pipelines — readers/writers basics     | [View](./Week08_PerfSpanMemory/Day55_SystemIOPipelines)         |
| Day 56 | Blog — Practical zero-allocation patterns        | [View](./Week08_PerfSpanMemory/Day56_ZeroAllocPatterns_Blog)    |

---

## Notes & Gotchas

* `Span<T>`/`ReadOnlySpan<T>` are **stack‑only** (`ref struct`) and cannot be captured by lambdas, boxed, or stored on the heap.
* `stackalloc` memory is valid only for the current scope; return or escape is unsafe.
* Prefer **ReadOnlySpan<T>** for consumer‑only APIs; expose mutating spans sparingly and document ownership.
* Pools reduce allocations but require **discipline**: return arrays, don’t leak, and beware of retaining oversized buffers.
* Pipelines simplify framing and backpressure but still need **protocol boundaries** and error handling.

---


**Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  
**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #performance #memory #span #pipelines #Week8

**Dates:** Aug 11–17, 2025
