using System;

namespace DesignPatternsDemo
{
    /// <summary>
    /// Chain of Responsibility Design Pattern Demo
    /// Demonstrates a chain of handlers processing a request.
    /// </summary>
    public static class ChainOfResponsibilityPatternDemo
    {
        public static void Execute()
        {
            Handler handler1 = new ConcreteHandlerA();
            Handler handler2 = new ConcreteHandlerB();
            Handler handler3 = new ConcreteHandlerC();

            handler1.SetNext(handler2).SetNext(handler3);

            int[] requests = { 2, 7, 14, 22, 18, 3, 6, 25 };
            foreach (int request in requests)
            {
                handler1.Handle(request);
            }
        }

        // Handler base class
        public abstract class Handler
        {
            private Handler _nextHandler;

            public Handler SetNext(Handler handler)
            {
                _nextHandler = handler;
                return handler;
            }

            public virtual void Handle(int request)
            {
                if (_nextHandler != null)
                {
                    _nextHandler.Handle(request);
                }
            }
        }

        // Concrete Handlers
        public class ConcreteHandlerA : Handler
        {
            public override void Handle(int request)
            {
                if (request < 10)
                {
                    Console.WriteLine($"HandlerA handled request {request}");
                }
                else
                {
                    base.Handle(request);
                }
            }
        }

        public class ConcreteHandlerB : Handler
        {
            public override void Handle(int request)
            {
                if (request >= 10 && request < 20)
                {
                    Console.WriteLine($"HandlerB handled request {request}");
                }
                else
                {
                    base.Handle(request);
                }
            }
        }

        public class ConcreteHandlerC : Handler
        {
            public override void Handle(int request)
            {
                if (request >= 20)
                {
                    Console.WriteLine($"HandlerC handled request {request}");
                }
                else
                {
                    base.Handle(request);
                }
            }
        }
    }
}
