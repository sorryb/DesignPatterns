using System;

namespace DesignPatternsDemo
{
   /// <summary>
    /// The Strategy design pattern allows an object to have some of the details of its behavior encapsulated in another type, which is then provided to it as a parameter.
    /// This pattern is closely related to dependency injection, which refers to the technique of passing dependencies (or injecting them) into classes, usually through their constructor.
    /// Strategy Design Pattern with Interface.
    /// </summary>
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
}
