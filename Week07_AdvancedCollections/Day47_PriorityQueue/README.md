## PriorityQueue in .NET

A `PriorityQueue<TElement, TPriority>` is a specialized collection introduced in .NET 6 that processes items based on their **priority** rather than the order they were added.

* **Lower priority value** means higher importance by default.
* Internally managed as a heap, so enqueue/dequeue operations are efficient.
* Perfect for scheduling systems, graph algorithms like Dijkstra’s, or anytime you need to always pick the “next most important” item.

In this example, tasks are assigned integer priorities — lower numbers are handled first. Using `TryDequeue`, we process them in order of importance.

### Key Takeaways:

* Use PriorityQueue when item order depends on a computed priority.
* Avoid manually sorting lists every time you need the next highest/lowest priority.
* Great for simulations, schedulers, and AI decision-making systems.

---

## Date: August 8, 2025  
🔗 **Code:** [Program.cs](./program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #PriorityQueue #Collections #Day47\_DotNetWithRoy #Week7
