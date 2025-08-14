## Day 54 — Zero‑allocation Parsing with UTF‑8 Spans & Rune

**What & Why**
Work directly on UTF‑8 bytes and Unicode scalars to cut allocations while parsing and normalizing text. `Utf8Parser` parses primitives from `ReadOnlySpan<byte>`; `Rune` lets you decode, transform (e.g., uppercase), filter, and re‑encode characters **without** creating intermediate strings.

**Key ideas**

* Parse numbers from UTF‑8 directly with `System.Buffers.Text.Utf8Parser.TryParse`.
* Use `System.Text.Rune.DecodeFromUtf8` to read Unicode scalars from a byte span and `EncodeToUtf8` to write them back.
* Normalize on the fly: filter to letters/digits/space, collapse whitespace, and uppercase with `Rune.ToUpperInvariant`.
* Allocate only at the **boundary** (e.g., when returning a final `string` or `byte[]`). Use pools for temporary buffers.

**What the sample shows**

1. **CSV int sum** parsed directly from a UTF‑8 byte span using `Utf8Parser.TryParse`.
2. **Unicode normalization pipeline** using `Rune` to keep letters/digits/spaces and uppercase while writing to a pooled byte buffer.

**Run it**

```bash
cd Week08_PerfSpanMemory/Day54_ZeroAllocParsing_SpanUtf8
 dotnet run
```

## Date: August 15, 2025

🔗 **Code:** [Program.cs](./program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #UTF8 #Rune #Utf8Parser #Span #performance #Day54\_DotNetWithRoy #Week8
