## Day 55 — System.IO.Pipelines: Readers/Writers Basics

**What & Why**
`System.IO.Pipelines` gives you a high‑throughput, allocation‑aware abstraction for streaming I/O. Compared to ad‑hoc `Stream.Read` loops, Pipelines simplify **buffer management, backpressure, and partial message framing** while minimizing copies.

**Key ideas**

* A `PipeWriter` produces bytes; a `PipeReader` consumes them. The `Pipe` coordinates buffers between them.
* Read in a loop with `ReadAsync()`, inspect the `ReadOnlySequence<byte>`, and **advance** using `AdvanceTo(consumed, examined)`.
* Parse message boundaries (e.g., `\n` or custom length prefixes) without copying using `ReadOnlySequence<byte>` and `PositionOf`/`SequenceReader<T>`.
* Write in chunks with `GetSpan(sizeHint)` → fill bytes → `Advance(count)` → `FlushAsync()`; let the Pipe grow as needed.

**What the sample shows**

1. A **producer** that writes UTF‑8 text lines in small, fragmented chunks to simulate network I/O.
2. A **consumer** that parses complete lines (handling `\n`/`\r\n`) using `PositionOf` over a `ReadOnlySequence<byte>` — no intermediate buffers.
3. Proper completion and backpressure handling with `Complete()` and `AdvanceTo()`.

**Run it**

```bash
cd Week08_PerfSpanMemory/Day55_SystemIOPipelines
 dotnet run
```

## Date: August 16, 2025

🔗 **Code:** [Program.cs](./program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #Pipelines #SystemIOPipelines #performance #Day55\_DotNetWithRoy #Week8
