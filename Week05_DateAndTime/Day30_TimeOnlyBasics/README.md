## TimeOnly in .NET — Just Time, No Date

The `TimeOnly` struct, introduced in .NET 6, is designed to represent a **time-of-day** value without any date component.

This is perfect for things like:

* Store hours
* Alarm times
* Meeting start/end times
* Scheduling systems

### Why not use DateTime?

* `DateTime` always includes a date, which may be irrelevant or misleading
* Comparing `DateTime`s can become confusing when you only care about time
* It can create bugs when crossing date boundaries unintentionally

### Why use TimeOnly?

* Explicitly represents only the time portion
* Makes business logic and comparisons cleaner
* Reduces noise in models and APIs

### Examples:

```csharp
TimeOnly start = new TimeOnly(9, 30); // 9:30 AM
TimeOnly now = TimeOnly.FromDateTime(DateTime.Now);

if (now < start)
    Console.WriteLine("Not time yet");
```

---

## Date: July 22, 2025

🔗 **Code:** [Program.cs](./Program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #TimeOnly #datetime #Day30\_DotNetWithRoy #Week5
