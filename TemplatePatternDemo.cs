using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace DesignPatternsDemo
{
	/// <summary>
	/// Demonstrates the Template Method design pattern applied to file processing.
	/// Adds a small runnable demo method `Execute()` used by the sample Program.
	/// </summary>
	public static class TemplatePatternDemo
	{
		public static void Execute()
		{
			Console.WriteLine("Executing Template Method Pattern demo...\n");

			// Create sample files in the current working directory
			File.WriteAllText("sample.txt", "Hello Template Pattern!\nThis is a SAMPLE text file.");
			File.WriteAllText("data.json", "{\"name\":\"Alice\",\"age\":30,\"items\":[1,2,3]}");

			var txtProcessor = new UpperCaseFileProcessor();
			txtProcessor.ExecuteAsync("sample.txt").GetAwaiter().GetResult();

			var jsonProcessor = new JsonPrettyPrinter();
			jsonProcessor.ExecuteAsync("data.json").GetAwaiter().GetResult();

			Console.WriteLine("Demo finished.");
		}

		// --- Template Method implementation ---

		public abstract class FileProcessorBase
		{
			public async Task ExecuteAsync(string filePath)
			{
				ValidateFile(filePath);
				string content = await ReadFileAsync(filePath);
				string processed = ProcessContent(content);
				await SaveOutputAsync(filePath, processed);
			}

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

		// Concrete processors
		public class UpperCaseFileProcessor : FileProcessorBase
		{
			protected override string ProcessContent(string content)
			{
				Console.WriteLine("Converting text to uppercase...");
				return content.ToUpperInvariant();
			}
		}

		public class JsonPrettyPrinter : FileProcessorBase
		{
			protected override string ProcessContent(string content)
			{
				Console.WriteLine("Formatting JSON...");
				using var doc = JsonDocument.Parse(content);
				return JsonSerializer.Serialize(doc, new JsonSerializerOptions { WriteIndented = true });
			}
		}
	}
}

