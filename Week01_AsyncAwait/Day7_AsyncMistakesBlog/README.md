# Day 7 – Top 6 Async Mistakes in .NET

This post summarizes the most common mistakes developers make when working with async/await in .NET — gathered from experience, real-world debugging, and code reviews.

## ✅ Covered Mistakes

1. **Blocking async code** with `.Result` or `.Wait()`
2. **Forgetting ConfigureAwait(false)** in library/background code
3. **Using async void** outside event handlers
4. **Assuming await foreach is concurrent**
5. **Ignoring cancellation tokens**
6. **Using GetAwaiter().GetResult()** — similar to `.Result` but sneakier

Each mistake is demonstrated in the sample playground below.

---

## 🔍 Code Walkthrough

This `Program.cs` file simulates all the mistakes above.  
You’ll see blocking behavior, cancellation, and sequential processing in a single run.

> ⚠️ **Note:** This playground is for illustrative/learning purposes only. Do not use this pattern in production.

### ▶ Program.cs: Async Mistakes Playground

[View Full Code →](./Program.cs)

---

## 📸 Post Link

[LinkedIn Post (Day 7)](https://www.linkedin.com/search/results/all/?keywords=%23day7_dotnetwithroy&origin=HASH_TAG_FROM_FEED&sid=mf%2C)

## 📁 Folder

`Week01_AsyncAwait/Day7_AsyncMistakesBlog/`

---

## 🔖 Tags

**Date:** 2025-06-29  
**Author:** [@HeyAvijitRoy](https://github.com/heyavijitroy)  
**GitHub:** https://github.com/heyavijitroy/dotnet-dailytips  
**Tags:** #DotNetWithRoy #dotnetdailytips #Day7_DotNetWithRoy #csharp #asyncawait #asynctips
