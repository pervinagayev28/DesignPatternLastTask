//********************************** Memento ******************************************

namespace Memento
{
    public class Editor
    {
        public string Content { get; set; }

        public EditorMemento CreateMemento()
        {
            return new EditorMemento(Content);
        }

        public void RestoreMemento(EditorMemento memento)
        {
            Content = memento.Content;
            Console.WriteLine($"Restored editor content to: {Content}");
        }
    }


    public class EditorMemento
    {
        public string Content { get; }

        public EditorMemento(string content)
        {
            Content = content;
        }
    }
}

//********************************** State ******************************************

namespace State
{
    public interface IState
    {
        void Handle(Context context);
    }

    public class ConcreteStateA : IState
    {
        public void Handle(Context context)
        {
            Console.WriteLine("State A handling the request.");
            context.State = new ConcreteStateB();
        }
    }

    public class ConcreteStateB : IState
    {
        public void Handle(Context context)
        {
            Console.WriteLine("State B handling the request.");
            context.State = new ConcreteStateA();
        }
    }

    public class Context
    {
        private IState state;

        public Context(IState initialState)
        {
            state = initialState;
        }
        public IState State
        {
            get { return state; }
            set
            {
                state = value;
                Console.WriteLine($"State changed to {state.GetType().Name}");
            }
        }
        public void Request()
        {
            state.Handle(this);
        }
    }
   
}

//********************************** Observer ******************************************


namespace Obserever
{
    public interface IObserver
    {
        void Update(string message);
    }

    public class ConcreteObserver : IObserver
    {
        public string Name { get; }

        public ConcreteObserver(string name)
        {
            Name = name;
        }

        public void Update(string message)
        {
            Console.WriteLine($"{Name} received a message: {message}");
        }
    }

    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void NotifyObservers(string message);
    }

    public class ConcreteSubject : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void NotifyObservers(string message)
        {
            foreach (var observer in observers)
            {
                observer.Update(message);
            }
        }
    }
}






















//********************************** Memento ******************************************