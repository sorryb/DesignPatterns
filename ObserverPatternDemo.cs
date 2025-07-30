using System;
using System.Collections.Generic;

namespace DesignPatternsDemo
{
    /// <summary>
    /// The Observer Design Pattern
    /// Defines a one-to-many dependency between objects so that when one object changes state,
    /// all its dependents are notified and updated automatically.
    /// </summary>
    public static class ObserverPatternDemo
    {
        public static void Execute()
        {
            ConcreteSubject subject = new ConcreteSubject();
            subject.Attach(new ConcreteObserver(subject, "A"));
            subject.Attach(new ConcreteObserver(subject, "B"));
            subject.Attach(new ConcreteObserver(subject, "C"));

            subject.SubjectState = "State 1";
            subject.Notify();

            subject.SubjectState = "State 2";
            subject.Notify();
        }

        // The 'Subject' abstract class
        public abstract class Subject
        {
            private readonly List<Observer> _observers = new List<Observer>();

            public void Attach(Observer observer)
            {
                _observers.Add(observer);
            }

            public void Detach(Observer observer)
            {
                _observers.Remove(observer);
            }

            public void Notify()
            {
                foreach (Observer o in _observers)
                {
                    o.Update();
                }
            }
        }

        // The 'ConcreteSubject' class
        public class ConcreteSubject : Subject
        {
            public string SubjectState { get; set; }
        }

        // The 'Observer' abstract class
        public abstract class Observer
        {
            public abstract void Update();
        }

        // The 'ConcreteObserver' class
        public class ConcreteObserver : Observer
        {
            private readonly ConcreteSubject _subject;
            private readonly string _name;
            private string _observerState;

            public ConcreteObserver(ConcreteSubject subject, string name)
            {
                _subject = subject;
                _name = name;
            }

            public override void Update()
            {
                _observerState = _subject.SubjectState;
                Console.WriteLine($"Observer {_name}'s new state is '{_observerState}'");
            }
        }
    }
}
