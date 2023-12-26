using System;
using System.Collections.Generic;

// 3. Proxy Design Pattern:

// Subject
interface ISubject
{
    void Request();
}

// RealSubject
class RealSubject : ISubject
{
    public void Request()
    {
        Console.WriteLine("RealSubject: Handling request.");
    }
}

// Proxy
class Proxy : ISubject
{
    private RealSubject _realSubject;

    public void Request()
    {
        if (_realSubject == null)
            _realSubject = new RealSubject();

        Console.WriteLine("Proxy: Checking access before invoking RealSubject.");
        _realSubject.Request();
    }
}

// 4. Flyweight Design Pattern:

// Flyweight
class Flyweight
{
    private readonly string _intrinsicState;

    public Flyweight(string intrinsicState)
    {
        _intrinsicState = intrinsicState;
    }

    public void Operation(string extrinsicState)
    {
        Console.WriteLine($"Flyweight: {_intrinsicState}, Extrinsic State: {extrinsicState}");
    }
}

// FlyweightFactory
class FlyweightFactory
{
    private readonly Dictionary<string, Flyweight> _flyweights = new Dictionary<string, Flyweight>();

    public Flyweight GetFlyweight(string key)
    {
        if (!_flyweights.TryGetValue(key, out var flyweight))
        {
            flyweight = new Flyweight(key);
            _flyweights[key] = flyweight;
        }
        return flyweight;
    }
}

// 5. Facade Design Pattern:

// SubsystemA
class SubsystemA
{
    public void OperationA()
    {
        Console.WriteLine("SubsystemA: Performing operation A");
    }
}

// SubsystemB
class SubsystemB
{
    public void OperationB()
    {
        Console.WriteLine("SubsystemB: Performing operation B");
    }
}

// Facade
class Facade
{
    private readonly SubsystemA _subsystemA;
    private readonly SubsystemB _subsystemB;

    public Facade()
    {
        _subsystemA = new SubsystemA();
        _subsystemB = new SubsystemB();
    }

    public void Operation()
    {
        Console.WriteLine("Facade: Triggering operation");
        _subsystemA.OperationA();
        _subsystemB.OperationB();
    }
}

// 6. Bridge Design Pattern:

// Implementor
interface IImplementor
{
    void OperationImp();
}

// ConcreteImplementorA
class ConcreteImplementorA : IImplementor
{
    public void OperationImp()
    {
        Console.WriteLine("ConcreteImplementorA: OperationImp");
    }
}

// ConcreteImplementorB
class ConcreteImplementorB : IImplementor
{
    public void OperationImp()
    {
        Console.WriteLine("ConcreteImplementorB: OperationImp");
    }
}

// Abstraction
abstract class Abstraction
{
    protected IImplementor implementor;

    public void SetImplementor(IImplementor implementor)
    {
        this.implementor = implementor;
    }

    public abstract void Operation();
}

// RefinedAbstraction
class RefinedAbstraction : Abstraction
{
    public override void Operation()
    {
        implementor.OperationImp();
    }
}

// 7. Decorator Design Pattern:

// Component
interface IComponent
{
    void Operation();
}

// ConcreteComponent
class ConcreteComponent : IComponent
{
    public void Operation()
    {
        Console.WriteLine("ConcreteComponent: Operation");
    }
}

// Decorator
abstract class Decorator : IComponent
{
    protected IComponent component;

    public Decorator(IComponent component)
    {
        this.component = component;
    }

    public virtual void Operation()
    {
        if (component != null)
            component.Operation();
    }
}

// ConcreteDecoratorA
class ConcreteDecoratorA : Decorator
{
    public ConcreteDecoratorA(IComponent component) : base(component)
    {
    }

    public override void Operation()
    {
        base.Operation();
        Console.WriteLine("ConcreteDecoratorA: Extended Operation");
    }
}

// ConcreteDecoratorB
class ConcreteDecoratorB : Decorator
{
    public ConcreteDecoratorB(IComponent component) : base(component)
    {
    }

    public override void Operation()
    {
        base.Operation();
        Console.WriteLine("ConcreteDecoratorB: Extended Operation");
    }
}

// Client
class Client
{
    static void Main()
    {
        // Adapter
        Adaptee adaptee = new Adaptee();
        ITarget target = new Adapter(adaptee);
        target.Request();

        // Composite
        var root = new Composite();
        root.Add(new Leaf("Leaf A"));
        root.Add(new Leaf("Leaf B"));

        var composite = new Composite();
        composite.Add(new Leaf("Leaf C"));
        composite.Add(new Leaf("Leaf D"));

        root.Add(composite);

        root.Display();

        // Proxy
        ISubject proxy = new Proxy();
        proxy.Request();

        // Flyweight
        FlyweightFactory flyweightFactory = new FlyweightFactory();
        Flyweight flyweight1 = flyweightFactory.GetFlyweight("shared");
        Flyweight flyweight2 = flyweightFactory.GetFlyweight("shared");
        flyweight1.Operation("1");
        flyweight2.Operation("2");

        // Facade
        Facade facade = new Facade();
        facade.Operation();

        // Bridge
        Abstraction abstraction = new RefinedAbstraction();
        abstraction.SetImplementor(new ConcreteImplementorA());
        abstraction.Operation();

        // Decorator
        IComponent component = new ConcreteComponent();
        Decorator decoratorA = new ConcreteDecoratorA(component);
        Decorator decoratorB = new ConcreteDecoratorB(decoratorA);

        decoratorA.Operation();
        decoratorB.Operation();
    }
}
