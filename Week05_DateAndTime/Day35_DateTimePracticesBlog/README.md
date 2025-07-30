## Real-world Date/Time Best Practices in .NET

Date and time issues are some of the most subtle — and dangerous — bugs in software development. This week explored how to work with time in .NET the right way, using modern types and APIs.

Here’s a summary of real-world best practices:

### ✅ Use `DateOnly` and `TimeOnly` when appropriate

* Use `DateOnly` for birthdays, holidays, and non-time-sensitive dates
* Use `TimeOnly` for clocks, alarms, opening/closing times
* Cleaner and avoids misuse of `DateTime`

### 🔧 Format and parse with precision

* Always use `ParseExact()` and `ToString("format")` to avoid culture and format mismatches

### 🔄 JSON serialization needs converters (pre .NET 8)

* Use `JsonConverter<DateOnly>` and `JsonConverter<TimeOnly>` in System.Text.Json or Newtonsoft.Json

### 🌐 Favor `DateTimeOffset` over `DateTime`

* `DateTimeOffset` includes offset info and avoids ambiguity
* Use `UtcNow` for logs and `Now` for local scheduling

### 🌍 Always use `TimeZoneInfo` for conversions

* Never use `.AddHours()` for timezone logic — it breaks on DST boundaries
* Use `TimeZoneInfo.ConvertTimeFromUtc()` or `ConvertTime(...)` for safe conversions

### Decision Table:

| Use Case             | Type or API             |
| -------------------- | ----------------------- |
| Birthday, holiday    | `DateOnly`              |
| Alarm, open time     | `TimeOnly`              |
| UTC timestamp/log    | `DateTimeOffset.UtcNow` |
| Local schedule       | `DateTimeOffset.Now`    |
| Time zone conversion | `TimeZoneInfo`          |
| JSON output          | Add converters          |

---

## Date: July 27, 2025

🔗 **Code:** [Program.cs](./Program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #datetime #dateonly #timeonly #Day35\_DotNetWithRoy #Week5
