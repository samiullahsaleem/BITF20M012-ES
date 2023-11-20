using System;
using System.Collections.Generic;

// Singleton Design Pattern
public sealed class Singleton
{
    private static Singleton instance;
    private static readonly object lockObject = new object();

    private Singleton() { }

    public static Singleton Instance
    {
        get
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }

    public void DisplayMessage()
    {
        Console.WriteLine("Singleton Instance");
    }
}

// Factory Design Pattern
public interface IProduct
{
    void Display();
}

public class ConcreteProductA : IProduct
{
    public void Display()
    {
        Console.WriteLine("Product A");
    }
}

public class ConcreteProductB : IProduct
{
    public void Display()
    {
        Console.WriteLine("Product B");
    }
}

public interface IFactory
{
    IProduct CreateProduct();
}

public class ConcreteFactoryA : IFactory
{
    public IProduct CreateProduct()
    {
        return new ConcreteProductA();
    }
}

public class ConcreteFactoryB : IFactory
{
    public IProduct CreateProduct()
    {
        return new ConcreteProductB();
    }
}

// Abstract Factory Design Pattern
public interface IWindow
{
    void Render();
}

public class WindowsWindow : IWindow
{
    public void Render()
    {
        Console.WriteLine("Rendering Windows Window");
    }
}

public class MacOSWindow : IWindow
{
    public void Render()
    {
        Console.WriteLine("Rendering MacOS Window");
    }
}

public interface IButton
{
    void Click();
}

public class WindowsButton : IButton
{
    public void Click()
    {
        Console.WriteLine("Clicking Windows Button");
    }
}

public class MacOSButton : IButton
{
    public void Click()
    {
        Console.WriteLine("Clicking MacOS Button");
    }
}

public interface IGUIFactory
{
    IWindow CreateWindow();
    IButton CreateButton();
}

public class WindowsFactory : IGUIFactory
{
    public IWindow CreateWindow()
    {
        return new WindowsWindow();
    }

    public IButton CreateButton()
    {
        return new WindowsButton();
    }
}

public class MacOSFactory : IGUIFactory
{
    public IWindow CreateWindow()
    {
        return new MacOSWindow();
    }

    public IButton CreateButton()
    {
        return new MacOSButton();
    }
}

// Builder Design Pattern
public class Product
{
    private List<string> parts = new List<string>();

    public void AddPart(string part)
    {
        parts.Add(part);
    }

    public void Show()
    {
        Console.WriteLine("\nProduct Parts -------");
        foreach (var part in parts)
        {
            Console.WriteLine(part);
        }
    }
}

public interface IBuilder
{
    void BuildPartA();
    void BuildPartB();
    void BuildPartC();
    Product GetResult();
}

public class ConcreteBuilder : IBuilder
{
    private Product product = new Product();

    public void BuildPartA()
    {
        product.AddPart("Part A");
    }

    public void BuildPartB()
    {
        product.AddPart("Part B");
    }

    public void BuildPartC()
    {
        product.AddPart("Part C");
    }

    public Product GetResult()
    {
        return product;
    }
}

public class Director
{
    public void Construct(IBuilder builder)
    {
        builder.BuildPartA();
        builder.BuildPartB();
        builder.BuildPartC();
    }
}

// Prototype Design Pattern
public interface ICloneablePrototype
{
    ICloneablePrototype Clone();
}

public class ConcretePrototype : ICloneablePrototype
{
    public int Id { get; set; }

    public ICloneablePrototype Clone()
    {
        return new ConcretePrototype { Id = this.Id };
    }
}

// Main Program
class Program
{
    static void Main()
    {
        // Singleton
        Singleton singleton1 = Singleton.Instance;
        singleton1.DisplayMessage();

        Singleton singleton2 = Singleton.Instance;
        singleton2.DisplayMessage();

        // Factory
        IFactory factoryA = new ConcreteFactoryA();
        IProduct productA1 = factoryA.CreateProduct();
        productA1.Display();

        IProduct productA2 = factoryA.CreateProduct();
        productA2.Display();

        IFactory factoryB = new ConcreteFactoryB();
        IProduct productB1 = factoryB.CreateProduct();
        productB1.Display();

        IProduct productB2 = factoryB.CreateProduct();
        productB2.Display();

        // Abstract Factory
        IGUIFactory windowsFactory = new WindowsFactory();
        IWindow windowsWindow1 = windowsFactory.CreateWindow();
        IButton windowsButton1 = windowsFactory.CreateButton();

        windowsWindow1.Render();
        windowsButton1.Click();

        IWindow windowsWindow2 = windowsFactory.CreateWindow();
        IButton windowsButton2 = windowsFactory.CreateButton();

        windowsWindow2.Render();
        windowsButton2.Click();

        IGUIFactory macOSFactory = new MacOSFactory();
        IWindow macOSWindow1 = macOSFactory.CreateWindow();
        IButton macOSButton1 = macOSFactory.CreateButton();

        macOSWindow1.Render();
        macOSButton1.Click();

        IWindow macOSWindow2 = macOSFactory.CreateWindow();
        IButton macOSButton2 = macOSFactory.CreateButton();

        macOSWindow2.Render();
        macOSButton2.Click();

        // Builder
        IBuilder builder1 = new ConcreteBuilder();
        Director director1 = new Director();

        director1.Construct(builder1);
        Product product1 = builder1.GetResult();

        product1.Show();

        IBuilder builder2 = new ConcreteBuilder();
        Director director2 = new Director();

        director2.Construct(builder2);
        Product product2 = builder2.GetResult();

        product2.Show();

        // Prototype
        ConcretePrototype prototype1 = new ConcretePrototype { Id = 1 };
        ConcretePrototype clonedPrototype1 = (ConcretePrototype)prototype1.Clone();

        Console.WriteLine($"Original Prototype Id: {prototype1.Id}");
        Console.WriteLine($"Cloned Prototype Id: {clonedPrototype1.Id}");

        ConcretePrototype prototype2 = new ConcretePrototype { Id = 2 };
        ConcretePrototype clonedPrototype2 = (ConcretePrototype)prototype2.Clone();

        Console.WriteLine($"Original Prototype Id: {prototype2.Id}");
        Console.WriteLine($"Cloned Prototype Id: {clonedPrototype2.Id}");

        Console.ReadKey();
    }
}
