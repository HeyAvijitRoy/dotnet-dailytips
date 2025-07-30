## Parsing and Formatting DateOnly & TimeOnly in .NET

Just like `DateTime`, the new `DateOnly` and `TimeOnly` types in .NET 6+ support powerful parsing and formatting methods.

These types are ideal when working with date/time input from users, displaying readable strings, or storing consistent data formats in your models.

### Parsing:

* Use `ParseExact` when you know the exact format:

```csharp
DateOnly date = DateOnly.ParseExact("07/15/2025", "MM/dd/yyyy");
TimeOnly time = TimeOnly.ParseExact("08:30 AM", "hh:mm tt");
```

### Formatting:

* Use `.ToString("format")` for display:

```csharp
date.ToString("MMMM dd, yyyy"); // July 15, 2025
time.ToString("h:mm tt");       // 8:30 AM
```

These APIs support all standard .NET date/time format strings, giving you consistency and power — without the mess of full `DateTime` values.

---

## Date: July 23, 2025

🔗 **Code:** [Program.cs](./Program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/) 

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #DateOnly #TimeOnly #Day31\_DotNetWithRoy #Week5
