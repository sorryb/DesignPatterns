using System;

namespace DesignPatternsDemo
{
    /// <summary>
    /// Singleton Design Pattern Demo
    /// Demonstrates a classic singleton implementation.
    /// </summary>
    public static class SingletonPatternDemo
    {
        public static void Execute()
        {
            // Constructor is private -- cannot use new
            Singleton s1 = Singleton.Instance();
            Singleton s2 = Singleton.Instance();

            // Test for same instance
            if (s1 == s2)
            {
                Console.WriteLine("Objects are the same instance");
            }
        }

        /// <summary>
        /// Singleton only one instance.
        /// </summary>
        public class Singleton
        {
            private static Singleton _instance;

            // Constructor is 'protected'
            private Singleton() { }

            public static Singleton Instance()
            {
                // Uses lazy initialization.
                // Note: this is not thread safe.
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
                return _instance;
            }
        }
    }
}





