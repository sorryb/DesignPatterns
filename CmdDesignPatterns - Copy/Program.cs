using System;

namespace DesignPatternsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: dotnet run [pattern]");
                Console.WriteLine("Available patterns: strategy, factory");
                return;
            }

            string pattern = args[0].ToLower();

            switch (pattern)
            {
                case "strategy":
                    StrategyPatternDemo.Execute();
                    break;

                case "factory":
                    FactoryPatternDemo.Execute();
                    break;

                default:
                    Console.WriteLine($"Unknown pattern: {pattern}");
                    break;
            }
        }
    }

    // Example of Strategy pattern usage
    public static class StrategyPatternDemo
    {
        public static void Execute()
        {
            Console.WriteLine("Executing Strategy Pattern...\n");

            ICompressionStrategy zipStrategy = new ZipCompression();
            Compressor compressor = new Compressor(zipStrategy);
            compressor.Compress("file.txt");

            ICompressionStrategy rarStrategy = new RarCompression();
            compressor = new Compressor(rarStrategy);
            compressor.Compress("file.txt");
        }

        public interface ICompressionStrategy
        {
            void Compress(string fileName);
        }

        public class ZipCompression : ICompressionStrategy
        {
            public void Compress(string fileName) => Console.WriteLine($"Compressing {fileName} using ZIP.");
        }

        public class RarCompression : ICompressionStrategy
        {
            public void Compress(string fileName) => Console.WriteLine($"Compressing {fileName} using RAR.");
        }

        public class Compressor
        {
            private readonly ICompressionStrategy _strategy;

            public Compressor(ICompressionStrategy strategy)
            {
                _strategy = strategy;
            }

            public void Compress(string fileName)
            {
                _strategy.Compress(fileName);
            }
        }
    }

    // Example of Factory pattern usage
    public static class FactoryPatternDemo
    {
        public static void Execute()
        {
            Console.WriteLine("Executing Factory Pattern...\n");

            IProduct productA = ProductFactory.CreateProduct("A");
            productA.Show();

            IProduct productB = ProductFactory.CreateProduct("B");
            productB.Show();
        }

        public interface IProduct
        {
            void Show();
        }

        public class ProductA : IProduct
        {
            public void Show() => Console.WriteLine("Product A");
        }

        public class ProductB : IProduct
        {
            public void Show() => Console.WriteLine("Product B");
        }

        public static class ProductFactory
        {
            public static IProduct CreateProduct(string type)
            {
                return type switch
                {
                    "A" => new ProductA(),
                    "B" => new ProductB(),
                    _ => throw new ArgumentException("Invalid product type")
                };
            }
        }
    }
}
