## Using Lookup vs Dictionary in LINQ

Both `Lookup<TKey, TValue>` and `Dictionary<TKey, TValue>` provide key-based access, but they serve different purposes.

* A `Dictionary` maps **one key to one value**. It throws if duplicate keys are added.
* A `Lookup` maps **one key to a collection of values** — making it ideal for grouping and repeated key access.

This example shows how to use LINQ’s `.ToLookup()` to build a grouped index and explains why `Lookup` is safer and more useful when dealing with 1-to-many mappings.

### What You’ll Learn

* The difference between `Lookup` and `Dictionary`
* How to group data with `.ToLookup()`
* When to prefer `Lookup` for multi-value groupings

## Date: August 1, 2025

🔗 **Code:** [Program.cs](./program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #LINQ #Lookup #Dictionary #Collections #Day40_DotNetWithRoy #Week6
