## Day 62: Text perf — Utf8JsonReader, Utf8Parser, Rune (Unicode-safe)

Modern .NET APIs provide high-performance primitives for text processing without unnecessary string allocations.

### Key points:
- **Utf8JsonReader**: parse JSON directly from UTF-8 spans, avoiding JObject allocations.  
- **Utf8Parser**: parse numbers, dates, and more directly from UTF-8 spans.  
- **Rune**: properly handle Unicode code points (beyond single `char`).  

## Date: August 23, 2025  
🔗 **Code:** [Program.cs](./Program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  
**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #performance #Utf8JsonReader #Utf8Parser #Rune #Day62_DotNetWithRoy #Week9
