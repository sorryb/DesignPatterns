using System;

namespace DesignPatternsDemo
{
    /// <summary>
    /// Generic Factory Pattern Demo
    /// Demonstrates a generic factory for software industry employees.
    /// </summary>
    public static class FactoryPatternGenericsDemo
    {
        public static void Execute()
        {
            ISoftwareEmployer employeeType;

            employeeType = Factory.Create<ProjectManager>();
            Console.WriteLine("Generic position 0: " + employeeType.Title);

            employeeType = Factory.Create<Tester>();
            Console.WriteLine("Generic position 1: " + employeeType.Title);

            employeeType = Factory.Create<Programmer>();
            Console.WriteLine("Generic position 2: " + employeeType.Title);
        }

        public interface ISoftwareEmployer
        {
            string Title { get; }
        }

        public class ProjectManager : ISoftwareEmployer
        {
            public string Title => "Project Manager";
        }

        public class Tester : ISoftwareEmployer
        {
            public string Title => "Tester";
        }

        public class Programmer : ISoftwareEmployer
        {
            public string Title => "Programmer";
        }

        public static class Factory
        {
            public static T Create<T>() where T : ISoftwareEmployer, new()
            {
                return new T();
            }
        }
    }
}