using System;
namespace DesignPatternsDemo.Generics
{
    /// <summary>
    /// Base class for employees that works in Software Industry.
    /// </summary>
    public interface SoftwareEmployer
    {
        string Title { get; }
    }

    class ProjectManager : SoftwareEmployer
    {
        public /*override*/ string Title
        {
            get { return "Project Manager"; }
        }
    }

    class Tester : SoftwareEmployer
    {
        public /*override*/ string Title
        {
            get { return "Tester"; }
        }
    }

    class Programmer : SoftwareEmployer
    {
        public /*override*/ string Title
        {
            get { return "Programmer"; }
        }
    }


    static class Factory
    {
        public static T Create<T>() where T : SoftwareEmployer, new()
        {
            return new T();
        }
    }

    public static class Program
    {
        static void XXXMain(string[] args)
        {
            SoftwareEmployer employeeType;

            employeeType = Factory.Create<ProjectManager>();
            Console.WriteLine("Generic position 0: " + employeeType.Title);

            employeeType = Factory.Create<Tester>();
            Console.WriteLine("Generic position 1: " + employeeType.Title);

            employeeType = Factory.Create<Programmer>();
            Console.WriteLine("Generic position 2: " + employeeType.Title);

            Console.ReadLine();
        }
    }
}