using System;

namespace DesignPatternsDemo
{
    /// <summary>
    /// Factory Pattern Demo (If/Switch version)
    /// Demonstrates a factory using if/switch for software industry employees.
    /// </summary>
    public static class FactoryPatternIfSwitchDemo
    {
        public static void Execute()
        {
            for (int i = 0; i <= 2; i++)
            {
                var position = Factory.Get(i);
                Console.WriteLine($"We have id = {i}, position = {position.Title}");
            }
        }

        public abstract class SoftwareEmployer
        {
            public abstract string Title { get; }
        }

        public class ProjectManager : SoftwareEmployer
        {
            public override string Title => "Project Manager";
        }

        public class Tester : SoftwareEmployer
        {
            public override string Title => "Tester";
        }

        public class Programmer : SoftwareEmployer
        {
            public override string Title => "Programmer";
        }

        public static class Factory
        {
            public static SoftwareEmployer Get(int id)
            {
                ProjectManager pm = new ProjectManager();
                Programmer programmer = new Programmer();
                Tester tester = new Tester();

                switch (id)
                {
                    case 0: return pm;
                    case 1: return tester;
                    case 2: return programmer;
                    default: return programmer;
                }
            }
        }
    }
}