
# 🎯 Design Patterns Demo — C# Console Application

A professional and extendable console application to **demonstrate classic Design Patterns** in C# using **command-line arguments**. This project includes clean implementations of well-known GoF (Gang of Four) patterns such as **Strategy** and **Factory**, with room to easily expand.

---

## 🧱 Project Structure

```
DesignPatternsDemo/
├── Program.cs                 # Main entry point with CLI pattern dispatcher
├── DesignPatternsDemo.csproj # .NET 8.0 project file
└── README.md                  # You're reading it!
```

---


## 📦 Prerequisites

Make sure you have the following installed:

- ✅ [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- ✅ Terminal or Command Prompt
- ✅ Code Editor (e.g., Visual Studio Code, Visual Studio)

---

## ⚙️ How It Works

This console app takes a **command-line argument** that maps to a design pattern. The `Program.cs` file routes the input to a static demo class, like `StrategyPatternDemo` or `FactoryPatternDemo`, and calls its `Execute()` method.

You can run the app like this:

```bash
dotnet run <pattern>
```

---

## 🚀 Build & Run

### 🔨 Build

```bash
dotnet build
```

### ▶️ Run

```bash
dotnet run strategy
dotnet run factory
```

> 📌 If no argument is provided, the app will print help info.

---

## 🎓 Supported Design Patterns

| Pattern     | Icon | Description                             | Command               |
|-------------|------|-----------------------------------------|-----------------------|
| Strategy    | 🎯   | Encapsulates interchangeable algorithms | `dotnet run strategy` |
| Factory     | 🏭   | Instantiates objects via a factory class| `dotnet run factory`  |

---

## 💡 Sample Output

### ➤ `dotnet run strategy`

```
Executing Strategy Pattern...

Compressing file.txt using ZIP.
Compressing file.txt using RAR.
```

### ➤ `dotnet run factory`

```
Executing Factory Pattern...

Product A
Product B
```

---

## 🛠 Add More Patterns

To expand the app:
1. Create a new static class, e.g. `SingletonPatternDemo`, with an `Execute()` method.
2. Add a new `case` in the `switch` block in `Program.cs`.

```csharp
case "singleton":
    SingletonPatternDemo.Execute();
    break;
```

This keeps the application modular and easily extensible.

---

## 🗺 Roadmap

- ✅ Strategy Pattern
- ✅ Factory Pattern
- ⏳ Singleton Pattern
- ⏳ Observer Pattern
- ⏳ Decorator Pattern
- ⏳ Command Pattern
- ⏳ Adapter Pattern

---

## 🔐 License

This project is licensed under the **MIT License**. Use freely, fork happily, contribute openly.

---

## 📣 Design Pattern Reference

For more information and a similar sample, see:
[Observer Design Pattern in C# (Refactoring.Guru)](https://refactoring.guru/design-patterns/observer/csharp/example)

---


