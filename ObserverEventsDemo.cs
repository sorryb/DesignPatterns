using System;

namespace DesignPatternsDemo
{
    /// <summary>
    /// C# Events Demo
    /// Demonstrates the use of C# events and delegates, which are a language-supported implementation of the Observer pattern.
    /// </summary>
    /// <remarks>
    /// This demo shows how to use events to notify subscribers of state changes in a publisher
    /// using both the built-in 
    ///   -  EventHandler and 
    ///   -  Custom Delegate.
    /// It illustrates the Observer pattern in a C# context, where subscribers react to changes in
    /// the publisher's state.
    /// </remarks>
    public static class ObserverEventsDemo
    {
        public static void Execute()
        {
            Publisher publisher = new Publisher();
            Subscriber subA = new Subscriber("A");
            Subscriber subB = new Subscriber("B");
            Subscriber subC = new Subscriber("C");

            publisher.StateChanged += subA.OnStateChanged;
            publisher.StateChanged += subB.OnStateChanged;
            publisher.StateChanged += subC.OnStateChanged;

            publisher.State = "State 1";
            publisher.NotifyStateChanged();

            publisher.State = "State 2";
            publisher.NotifyStateChanged();
        }

        /// <summary>
        /// Publisher class with an event
        /// </summary>
        public class Publisher
        {
            public string State { get; set; }


            /// <summary>
            /// Event using EventHandler instead of a custom delegate
            /// </summary>
            public event EventHandler<StateChangedEventArgs> StateChanged;

            /// <summary>
            /// Event using a custom delegate
            /// </summary>
            public delegate void StateChangedDelegate(string state);
            public event StateChangedDelegate StateChangedCustom;

            /// <summary>
            /// Notifies all subscribers of a state change
            /// </summary>
            public void NotifyStateChanged()
            {
                StateChanged?.Invoke(this, new StateChangedEventArgs(State));
            }
        }

        /// <summary>
        /// Custom EventArgs for state changes
        /// </summary>
        public class StateChangedEventArgs : EventArgs
        {
            public string State { get; }
            public StateChangedEventArgs(string state)
            {
                State = state;
            }
        }

        /// <summary>
        /// Subscriber class
        /// </summary>
        public class Subscriber
        {
            private readonly string _name;
            private string _subscriberState;

            public Subscriber(string name)
            {
                _name = name;
            }

            /// <summary>
            /// Event handler method for state changes
            /// </summary>
            public void OnStateChanged(object sender, StateChangedEventArgs e)
            {
                _subscriberState = e.State;
                Console.WriteLine($"Subscriber {_name}'s received Publisher state which is '{_subscriberState}'");
            }
        }
    }
}
