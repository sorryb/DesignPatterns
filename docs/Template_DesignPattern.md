# 🧩 Example: File Processing Template (Abstract Class)

This example demonstrates the **Template Method Design Pattern** in C#, applied to file processing.  
It defines a general workflow for reading, processing, and saving different types of files (e.g., text, XML, JSON).  
Each concrete subclass customizes only the variable parts.

---

## 📘 Abstract Class: FileProcessor

```csharp
using System;
using System.IO;
using System.Threading.Tasks;

namespace TemplateDesignPatternExample
{
    /// <summary>
    /// Abstract base class defining the algorithm skeleton.
    /// </summary>
    public abstract class FileProcessor
    {
        public async Task ExecuteAsync(string filePath)
        {
            ValidateFile(filePath);
            string content = await ReadFileAsync(filePath);
            string processed = ProcessContent(content);
            await SaveOutputAsync(filePath, processed);
        }

        // --- Template steps (hooks) ---

        protected virtual void ValidateFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path cannot be empty.");

            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File not found: {filePath}");
        }

        protected virtual async Task<string> ReadFileAsync(string filePath)
        {
            return await File.ReadAllTextAsync(filePath);
        }

        protected abstract string ProcessContent(string content);

        protected virtual async Task SaveOutputAsync(string filePath, string processed)
        {
            string outPath = Path.ChangeExtension(filePath, ".out.txt");
            await File.WriteAllTextAsync(outPath, processed);
            Console.WriteLine($"Processed file saved to: {outPath}");
        }
    }
}
```

---

## 🧠 Example 1: `UpperCaseFileProcessor`

Concrete class that transforms text files to uppercase.

```csharp
using System;

namespace TemplatePatternExample
{
    public class UpperCaseFileProcessor : FileProcessor
    {
        protected override string ProcessContent(string content)
        {
            Console.WriteLine("Converting text to uppercase...");
            return content.ToUpperInvariant();
        }
    }
}
```

---

## 🧠 Example 2: `JsonPrettyPrinter`

Another subclass that formats JSON neatly.

```csharp
using System;
using System.Text.Json;

namespace TemplatePatternExample
{
    public class JsonPrettyPrinter : FileProcessor
    {
        protected override string ProcessContent(string content)
        {
            Console.WriteLine("Formatting JSON...");
            using var doc = JsonDocument.Parse(content);
            return JsonSerializer.Serialize(doc, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
```

---

## 🚀 Usage Example

```csharp
using System.Threading.Tasks;

namespace TemplatePatternExample
{
    internal static class Program
    {
        private static async Task Main()
        {
            var txtProcessor = new UpperCaseFileProcessor();
            await txtProcessor.ExecuteAsync("sample.txt");

            var jsonProcessor = new JsonPrettyPrinter();
            await jsonProcessor.ExecuteAsync("data.json");
        }
    }
}
```

---

## ✅ Key Takeaways

- The **Template Method pattern** defines a *skeleton of an algorithm* in a base class, allowing subclasses to redefine specific steps.
- It promotes **code reuse** and enforces **consistent workflows**.
- Perfect for file operations, data imports, validations, or any process with common structure but variable details.
