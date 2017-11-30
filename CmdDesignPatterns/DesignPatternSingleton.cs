using System;

/// <summary>
/// The Singleton Design Pattern
/// For some types(classes and objects), having more than one instance of the type within an application could result in adverse effects.
/// </summary>
namespace SingletonDesignPattern
{


    /// <summary>
    /// Program startup class for Structural.Singleton.
    /// Singleton Design Pattern.
    /// </summary>
    class Program
        {
            /// <summary>
            /// Entry point into console application.
            /// </summary>
            static void XXXMain()
            {
                // Constructor is private -- cannot use new
                Singleton s1 = Singleton.Instance();
                Singleton s2 = Singleton.Instance();

            

                // Test for same instance
            if (s1 == s2)
                {
                    Console.WriteLine("Objects are the same instance");
                }

                // Wait for user
                Console.ReadKey();
            }
        }

    /// <summary>
    /// Singleton only one instance.
    /// </summary>
    class Singleton
        {
            private static Singleton _instance;

            // Constructor is 'protected'
            private Singleton()
            {
            }

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





