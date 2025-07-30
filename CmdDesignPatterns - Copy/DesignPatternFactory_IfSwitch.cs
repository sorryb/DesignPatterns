using System;
namespace DesignPatternsDemo
{
    /// <summary>
    /// Base class for employees that works in Software Industry.
    /// </summary>
    abstract class SoftwareEmployer
    {
        public abstract string Title { get; }
    }

    class ProjectManager : SoftwareEmployer
    {
        public override string Title
        {
            get { return "Project Manager"; }
        }
    }

    class Tester : SoftwareEmployer
    {
        public override string Title
        {
            get { return "Tester"; }
        }
    }

    class Programmer : SoftwareEmployer
    {
        public override string Title
        {
            get { return "Programmer"; }
        }
    }

    static class Factory
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
                case 2: return  programmer;
                default: return programmer;
            }
        }
    }

    public static class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 2; i++)
            {
                var position = Factory.Get(i);
                Console.WriteLine("We have id = {0}, position = {1} ", i, position.Title);
            }
            Console.ReadLine();
        }
    }
}