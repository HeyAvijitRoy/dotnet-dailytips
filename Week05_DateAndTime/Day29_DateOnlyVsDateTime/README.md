## DateOnly vs DateTime in .NET

When you only care about the **date**, not the **time**, using `DateTime` can introduce hidden bugs and unnecessary complexity.

The `DateOnly` struct, introduced in .NET 6, is a better choice when you're modeling things like birthdays, due dates, holidays, or schedule days — anything where the time-of-day doesn’t matter.

### Why not use DateTime?

* `DateTime` always includes a time, defaulting to `00:00:00` even when you don’t need it
* This can cause problems in comparisons, serialization, and databases

### Why use DateOnly?

* Clean, intent-focused representation of a date
* No timezone ambiguity
* Works well in UI and business logic scenarios

### Example:

```csharp
DateTime dt = new DateTime(1995, 5, 23);  // includes time
DateOnly dob = new DateOnly(1995, 5, 23); // pure date
```

Use `DateOnly.FromDateTime(DateTime.Now)` to get today’s date without the time.

---

## Date: July 21, 2025

🔗 **Code:** [Program.cs](./Program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  


**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #DateOnly #datetime #Day29\_DotNetWithRoy #Week5
