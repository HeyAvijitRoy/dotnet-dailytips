## Day 58: stackalloc, slicing, and safety pitfalls

`stackalloc` allows you to allocate memory directly on the stack for temporary arrays.  
When paired with `Span<T>`, it provides a powerful zero-allocation approach for short-lived buffers.

### Key points:
- `stackalloc` is best for **small and predictable sizes**.  
- Memory is freed automatically at method exit (stack unwinds).  
- Avoid using large `stackalloc` allocations — they may cause **stack overflow**.  
- You can slice stack-allocated spans without creating new arrays.

## Date: August 19, 2025  
🔗 **Code:** [Program.cs](./Program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #performance #stackalloc #Span #Day58_DotNetWithRoy #Week9
