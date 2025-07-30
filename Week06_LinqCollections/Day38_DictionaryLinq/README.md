## LINQ with Dictionary – Select, Where, Keys

Dictionaries can be used seamlessly with LINQ — but understanding how LINQ interacts with the `KeyValuePair<TKey, TValue>` structure is essential.

This example shows how to:

* Filter dictionaries based on values
* Select just keys or just values
* Use `.Keys` and `.Values` for simpler and more performant queries when key/value pairing is not needed

### What You’ll Learn

* How to filter dictionaries using LINQ
* Why `.Values.Where(...)` is faster than `.Where(kv => kv.Value > x)`
* When to use `.Select(kv => kv.Key)` vs `.Keys.Where(...)`

## Date: July 30, 2025

🔗 **Code:** [Program.cs](./program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #LINQ #Dictionary #Collections #Day38\_DotNetWithRoy #Week6
