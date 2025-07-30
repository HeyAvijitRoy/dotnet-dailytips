## JSON Serialization of DateOnly and TimeOnly in .NET

By default, `System.Text.Json` does **not** support `DateOnly` or `TimeOnly` in .NET 6 or 7. Attempting to serialize or deserialize these types without custom converters will result in a runtime error.

### Why this matters:

If you're building APIs or persisting settings with `DateOnly` or `TimeOnly`, you **must** configure JSON support explicitly (unless you're using .NET 8+).

### Solution:

* Add custom converters using `JsonConverter<T>`
* Register them globally in `JsonSerializerOptions`, or annotate properties with `[JsonConverter(typeof(...))]`

### Example:

```csharp
[JsonConverter(typeof(DateOnlyJsonConverter))]
public DateOnly StartDate { get; set; }

[JsonConverter(typeof(TimeOnlyJsonConverter))]
public TimeOnly StartTime { get; set; }
```

### Notes:

* Use `yyyy-MM-dd` for `DateOnly`
* Use `HH:mm` or `hh:mm tt` for `TimeOnly`
* Newtonsoft.Json also requires custom converters

---

## Date: July 24, 2025

🔗 **Code:** [Program.cs](./Program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #json #DateOnly #TimeOnly #Day32\_DotNetWithRoy #Week5
