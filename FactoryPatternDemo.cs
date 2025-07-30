using System;

namespace DesignPatternsDemo
{
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
