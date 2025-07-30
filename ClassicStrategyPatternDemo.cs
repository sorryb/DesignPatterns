using System;

namespace DesignPatternsDemo.Strategy
{
    /// <summary>
    /// The Strategy design pattern allows an object to have some of the details of its behavior encapsulated in another type, which is then provided to it as a parameter.
    /// This pattern is closely related to dependency injection, which refers to the technique of passing dependencies (or injecting them) into classes, usually through their constructor.
    /// Strategy Design Pattern with Abstract class.
    /// </summary>
    public static class ClassicStrategyPatternDemo
    {
        /// <summary>
        /// Entry point into console application. Strategy Design Pattern sample.
        /// </summary>
        public static void Execute()
        {
            Context context;

            // Three contexts following different strategies
            context = new Context(new ConcreteStrategyA());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyB());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyC());
            context.ContextInterface();

            // Wait for user
            // Console.ReadKey(); // Uncomment if running standalone
        }

        /// <summary>
        /// The 'Strategy' abstract class
        /// </summary>
        public abstract class Strategy
        {
            public abstract void AlgorithmInterface();
        }

        /// <summary>
        /// A 'ConcreteStrategy' class
        /// </summary>
        public class ConcreteStrategyA : Strategy
        {
            public override void AlgorithmInterface()
            {
                Console.WriteLine("A. Called ConcreteStrategyA.AlgorithmInterface() but in Context Class.");
            }
        }

        /// <summary>
        /// A 'ConcreteStrategy' class
        /// </summary>
        public class ConcreteStrategyB : Strategy
        {
            public override void AlgorithmInterface()
            {
                Console.WriteLine("B. Called ConcreteStrategyB.AlgorithmInterface() but in Context Class.");
            }
        }

        /// <summary>
        /// A 'ConcreteStrategy' class
        /// </summary>
        public class ConcreteStrategyC : Strategy
        {
            public override void AlgorithmInterface()
            {
                Console.WriteLine("C. Called ConcreteStrategyC.AlgorithmInterface() but in Context Class.");

                //string name = "SBS";
                //int count = 0;

                //foreach (char c in name)
                //{
                //    count += (int)c;
                //}

                //Console.WriteLine("Suma literelor este : " + count.ToString());
            }
        }

        /// <summary>
        /// The 'Context' class
        /// </summary>
        public class Context
        {
            private readonly Strategy _strategy;

            public Context(Strategy strategy)
            {
                _strategy = strategy;
            }

            public void ContextInterface()
            {
                _strategy.AlgorithmInterface();
            }
        }
    }
}
