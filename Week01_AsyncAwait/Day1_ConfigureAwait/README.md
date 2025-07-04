﻿# ConfigureAwait(false)

Use `ConfigureAwait(false)` in your async library code or background services to avoid unnecessary context capture.

## 🔍 Why It Matters

- Prevents resuming on UI/ASP.NET context
- Improves performance
- Avoids deadlocks in non-UI apps

📅 **Date:** June 23, 2025  
🔗 **Code:** [Program.cs](./Program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/heyavijitroy/)  
🏷 **Tags:** #dotnetdailytips #DotNetWithRoy #csharp #asyncawait #ConfigureAwait #Day1_DotNetWithRoy
