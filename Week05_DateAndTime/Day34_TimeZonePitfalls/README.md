## Time Zone Conversion Pitfalls and Fixes in .NET

Time zones are one of the most error-prone areas in application development. Simple mistakes like using `DateTime.Now` or ignoring `.Kind` can result in data loss, incorrect scheduling, or confusing user interfaces.

### Common Pitfalls:

* Using `DateTime.Now` (local, but no offset!)
* Ignoring `DateTime.Kind` (Unspecified, Utc, Local)
* Performing manual offset math
* Mixing `DateTime` and `DateTimeOffset` improperly

### Fixes:

* Use `DateTimeOffset.UtcNow` for logs and schedules
* Use `TimeZoneInfo.ConvertTimeFromUtc()` for reliable conversions
* Never use manual `AddHours(-5)` for time zone shifts

### Example:

```csharp
var utcNow = DateTime.UtcNow;
var estZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
var estTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, estZone);
```

You can also convert offset-aware times:

```csharp
DateTimeOffset local = DateTimeOffset.Now;
var pst = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
var pstTime = TimeZoneInfo.ConvertTime(local, pst);
```

---

## Date: July 26, 2025

🔗 **Code:** [Program.cs](./Program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #datetime #timezone #Day34\_DotNetWithRoy #Week5
