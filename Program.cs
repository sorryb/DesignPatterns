
using System;
using DesignPatternsDemo.Strategy;

namespace DesignPatternsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: dotnet run [pattern]");
                Console.WriteLine("Available patterns:");
                Console.WriteLine("  strategy");
                Console.WriteLine("  strategy-classic");
                Console.WriteLine("  factory");
                Console.WriteLine("  factory-generic");
                Console.WriteLine("  factory-ifswitch");
                Console.WriteLine("  singleton");
                Console.WriteLine("  observer");
                Console.WriteLine("  observer-events");
                Console.WriteLine("  adapter");
                return;
            }

            string pattern = args[0].ToLower();

            switch (pattern)
            {
                case "strategy":
                    StrategyPatternDemo.Execute();
                    break;
                case "observer":
                    ObserverPatternDemo.Execute();
                    break;
                case "strategy-classic":
                    ClassicStrategyPatternDemo.Execute();
                    break;
                case "factory":
                    FactoryPatternDemo.Execute();
                    break;
                case "factory-generic":
                    FactoryPatternGenericsDemo.Execute();
                    break;
                case "factory-ifswitch":
                    FactoryPatternIfSwitchDemo.Execute();
                    break;
                case "singleton":
                    SingletonPatternDemo.Execute();
                    break;
                case "observer-events":
                    ObserverEventsDemo.Execute();
                    break;
                case "adapter":
                    AdapterPatternDemo.Execute();
                    break;
                default:
                    Console.WriteLine($"Unknown pattern: {pattern}");
                    break;
            }
        }
    }
}
