// 1. Template Method Design Pattern

// Abstract class defining the template method
abstract class AbstractClass
{
    // The template method that defines the algorithm structure
    public void TemplateMethod()
    {
        // Call the primitive operations
        Operation1();
        Operation2();
    }

    // Primitive operation 1, to be implemented by subclasses
    protected abstract void Operation1();

    // Primitive operation 2, to be implemented by subclasses
    protected abstract void Operation2();
}

// Concrete class implementing the template method
class ConcreteClass : AbstractClass
{
    // Implementation for Operation1
    protected override void Operation1()
    {
        Console.WriteLine("ConcreteClass: Operation1");
    }

    // Implementation for Operation2
    protected override void Operation2()
    {
        Console.WriteLine("ConcreteClass: Operation2");
    }
}

// 2. Mediator Design Pattern

// Mediator interface
interface IMediator
{
    void SendMessage(string message, Colleague colleague);
}

// Colleague class
class Colleague
{
    protected IMediator mediator;

    public Colleague(IMediator mediator)
    {
        this.mediator = mediator;
    }

    // Send a message through the mediator
    public virtual void Send(string message)
    {
        mediator.SendMessage(message, this);
    }

    // Receive a message from the mediator
    public virtual void Receive(string message)
    {
        Console.WriteLine($"Colleague received: {message}");
    }
}

// Concrete mediator class
class ConcreteMediator : IMediator
{
    private Colleague colleague1;
    private Colleague colleague2;

    // Setters for colleagues
    public Colleague Colleague1
    {
        set { colleague1 = value; }
    }

    public Colleague Colleague2
    {
        set { colleague2 = value; }
    }

    // Send a message to the specified colleague
    public void SendMessage(string message, Colleague colleague)
    {
        if (colleague == colleague1)
            colleague2.Receive(message);
        else
            colleague1.Receive(message);
    }
}

// 3. Chain of Responsibility Design Pattern

// Handler interface
abstract class Handler
{
    protected Handler successor;

    // Set the next handler in the chain
    public void SetSuccessor(Handler successor)
    {
        this.successor = successor;
    }

    // Handle the request, or pass it to the next handler
    public abstract void HandleRequest(int request);
}

// Concrete handler class
class ConcreteHandler1 : Handler
{
    public override void HandleRequest(int request)
    {
        if (request < 10)
        {
            // Handle the request
            Console.WriteLine($"ConcreteHandler1 handled the request: {request}");
        }
        else if (successor != null)
        {
            // Pass the request to the next handler
            successor.HandleRequest(request);
        }
    }
}

class ConcreteHandler2 : Handler
{
    public override void HandleRequest(int request)
    {
        if (request >= 10 && request < 20)
        {
            // Handle the request
            Console.WriteLine($"ConcreteHandler2 handled the request: {request}");
        }
        else if (successor != null)
        {
            // Pass the request to the next handler
            successor.HandleRequest(request);
        }
    }
}

// 4. Observer Design Pattern

// Subject interface
interface ISubject
{
    void AddObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}

// Observer interface
interface IObserver
{
    void Update(string data);
}

// Concrete subject class
class ConcreteSubject : ISubject
{
    private List<IObserver> observers = new List<IObserver>();
    private string data;

    // Add an observer to the list
    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    // Remove an observer from the list
    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    // Notify all observers when the data changes
    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(data);
        }
    }

    // Set new data and notify observers
    public void SetData(string newData)
    {
        data = newData;
        NotifyObservers();
    }
}

// Concrete observer class
class ConcreteObserver : IObserver
{
    // Update logic based on the new data
    public void Update(string data)
    {
        Console.WriteLine($"ConcreteObserver received update: {data}");
    }
}

// Usage example
var subject = new ConcreteSubject();
var observer1 = new ConcreteObserver();
var observer2 = new ConcreteObserver();

// Subscribe observers to the subject
subject.AddObserver(observer1);
subject.AddObserver(observer2);

// Set new data in the subject, which will notify observers
subject.SetData("New data");

// 5. Strategy Design Pattern

// Strategy interface
interface IStrategy
{
    void Execute();
}

// Concrete strategy classes
class ConcreteStrategyA : IStrategy
{
    // Implementation for strategy A
    public void Execute()
    {
        Console.WriteLine("Executing ConcreteStrategyA");
    }
}

class ConcreteStrategyB : IStrategy
{
    // Implementation for strategy B
    public void Execute()
    {
        Console.WriteLine("Executing ConcreteStrategyB");
    }
}

// Context class
class Context
{
    private IStrategy strategy;

    // Set the strategy for the context
    public void SetStrategy(IStrategy strategy)
    {
        this.strategy = strategy;
    }

    // Execute the current strategy
    public void ExecuteStrategy()
    {
        strategy.Execute();
    }
}

// Usage example
var context = new Context();
var strategyA = new ConcreteStrategyA();
var strategyB = new ConcreteStrategyB();

// Set and execute the first strategy
context.SetStrategy(strategyA);
context.ExecuteStrategy();

// Set and execute the second strategy
context.SetStrategy(strategyB);
context.ExecuteStrategy();

// 6. Command Design Pattern

// Command interface
interface ICommand
{
    void Execute();
}

// Receiver class
class Receiver
{
    // Perform the action
    public void Action()
    {
        Console.WriteLine("Receiver: Performing action");
    }
}

// Concrete command class
class ConcreteCommand : ICommand
{
    private Receiver receiver;

    // Initialize with a specific receiver
    public ConcreteCommand(Receiver receiver)
    {
        this.receiver = receiver;
    }

    // Execute the command by delegating to the receiver
    public void Execute()
    {
        receiver.Action();
    }
}

// Invoker class
class Invoker
{
    private ICommand command;

    // Set the command to be executed
    public void SetCommand(ICommand command)
    {
        this.command = command;
    }

    // Execute the currently set command
    public void ExecuteCommand()
    {
        command.Execute();
    }
}

// Usage example
var receiver = new Receiver();
var command = new ConcreteCommand(receiver);
var invoker = new Invoker();

// Set and execute the command
invoker.SetCommand(command);
invoker.ExecuteCommand();

// 7. State Design Pattern

// State interface
interface IState
{
    void Handle(Context context);
}

// Concrete state classes
class ConcreteStateA : IState
{
    // Handle state A behavior
    public void Handle(Context context)
    {
        Console.WriteLine("Handling state A");
        context.SetState(new ConcreteStateB());
    }
}

class ConcreteStateB : IState
{
    // Handle state B behavior
    public void Handle(Context context)
    {
        Console.WriteLine("Handling state B");
        context.SetState(new ConcreteStateA());
    }
}

// Context class
class Context
{
    private IState state;

    // Set the current state
    public void SetState(IState state)
    {
        this.state = state;
    }

    // Request handling, which delegates to the current state
    public void Request()
    {
        state.Handle(this);
    }
}

// Usage example
var context = new Context();
var stateA = new ConcreteStateA();
var stateB = new ConcreteStateB();

// Set and handle the first state
context.SetState(stateA);
context.Request();

// Set and handle the second state
context.SetState(stateB);
context.Request();

// 8. Visitor Design Pattern

// Element interface
interface IElement
{
    // Accept a visitor for the specific element type
    void Accept(IVisitor visitor);
}

// Concrete element classes
class ConcreteElementA : IElement
{
    // Accept a visitor for ConcreteElementA
    public void Accept(IVisitor visitor)
    {
        visitor.VisitElementA(this);
    }
}

class ConcreteElementB : IElement
{
    // Accept a visitor for ConcreteElementB
    public void Accept(IVisitor visitor)
    {
        visitor.VisitElementB(this);
    }
}

// Visitor interface
interface IVisitor
{
    // Visit operation for ConcreteElementA
    void VisitElementA(ConcreteElementA elementA);

    // Visit operation for ConcreteElementB
    void VisitElementB(ConcreteElementB elementB);
}

// Concrete visitor class
class ConcreteVisitor : IVisitor
{
    // Visit and perform operation on ConcreteElementA
    public void VisitElementA(ConcreteElementA elementA)
    {
        Console.WriteLine("Visiting and operating on ConcreteElementA");
    }

    // Visit and perform operation on ConcreteElementB
    public void VisitElementB(ConcreteElementB elementB)
    {
        Console.WriteLine("Visiting and operating on ConcreteElementB");
    }
}

// Usage example
var elementA = new ConcreteElementA();
var elementB = new ConcreteElementB();
var visitor = new ConcreteVisitor();

// Accept the visitor for each element
elementA.Accept(visitor);
elementB.Accept(visitor);

// 9. Interpreter Design Pattern

// Abstract expression class
abstract class AbstractExpression
{
    // Interpret the expression in the given context
    public abstract void Interpret(Context context);
}

// Terminal expression class
class TerminalExpression : AbstractExpression
{
    // Interpret the terminal expression
    public override void Interpret(Context context)
    {
        Console.WriteLine("Interpreting terminal expression");
    }
}

// Non-terminal expression class
class NonTerminalExpression : AbstractExpression
{
    private AbstractExpression expression;

    // Initialize with a subexpression
    public NonTerminalExpression(AbstractExpression expression)
    {
        this.expression = expression;
    }

    // Interpret the non-terminal expression using the subexpression
    public override void Interpret(Context context)
    {
        Console.WriteLine("Interpreting non-terminal expression");
        expression.Interpret(context);
    }
}

// Context class
class Context
{
    // Context information
}

// Usage example
var context = new Context();
var terminalExpression = new TerminalExpression();
var nonTerminalExpression = new NonTerminalExpression(terminalExpression);

// Interpret the non-terminal expression, which in turn interprets the terminal expression
nonTerminalExpression.Interpret(context);

// 10. Iterator Design Pattern

// Iterator interface
interface IIterator<T>
{
    // Get the next item in the iteration
    T Next();

    // Check if there are more items in the iteration
    bool HasNext();
}

// Aggregate interface
interface IAggregate<T>
{
    // Create an iterator for the aggregate
    IIterator<T> CreateIterator();
}

// Concrete iterator class
class ConcreteIterator<T> : IIterator<T>
{
    private List<T> collection;
    private int index = 0;

    // Initialize with the collection to iterate over
    public ConcreteIterator(List<T> collection)
    {
        this.collection = collection;
    }

    // Get the next item in the iteration
    public T Next()
    {
        var result = collection[index];
        index++;
        return result;
    }

    // Check if there are more items in the iteration
    public bool HasNext()
    {
        return index < collection.Count;
    }
}

// Concrete aggregate class
class ConcreteAggregate<T> : IAggregate<T>
{
    private List<T> collection = new List<T>();

    // Add an item to the collection
    public void AddItem(T item)
    {
        collection.Add(item);
    }

    // Create an iterator for the collection
    public IIterator<T> CreateIterator()
    {
        return new ConcreteIterator<T>(collection);
    }
}

// Usage example
var aggregate = new ConcreteAggregate<int>();
aggregate.AddItem(1);
aggregate.AddItem(2);
aggregate.AddItem(3);

// Create an iterator for the aggregate
var iterator = aggregate.CreateIterator();

// Iterate over the collection and process each item
while (iterator.HasNext())
{
    var item = iterator.Next();
    Console.WriteLine($"Processing item: {item}");
}

// 11. Memento Design Pattern

// Originator class
class Originator
{
    private string state;

    // Get or set the state
    public string State
    {
        get { return state; }
        set
        {
            state = value;
            Console.WriteLine($"State set to: {state}");
        }
    }

    // Create a memento representing the current state
    public Memento CreateMemento()
    {
        return new Memento(state);
    }

    // Restore the state from a memento
    public void RestoreMemento(Memento memento)
    {
        state = memento.State;
        Console.WriteLine($"State restored to: {state}");
    }
}

// Memento class
class Memento
{
    // Get the state
    public string State { get; }

    // Initialize with a specific state
    public Memento(string state)
    {
        State = state;
    }
}

// Caretaker class
class Caretaker
{
    // Get or set the memento
    public Memento Memento { get; set; }
}

// Usage example
var originator = new Originator();
var caretaker = new Caretaker();

// Set the initial state
originator.State = "State 1";

// Create a memento representing the current state
caretaker.Memento = originator.CreateMemento();

// Change the state
originator.State = "State 2";

// Restore the state from the memento
originator.RestoreMemento(caretaker.Memento);
