using System;
using System.Collections;

// Інтерфейс ітератора
public interface IIterator
{
    bool HasNext();
    object Next();
}

// Інтерфейс колекції
public interface IAggregate
{
    IIterator CreateIterator();
}

// Конкретна колекція
public class ConcreteAggregate : IAggregate
{
    private readonly ArrayList _items = new ArrayList();

    public IIterator CreateIterator()
    {
        return new ConcreteIterator(this);
    }

    public int Count
    {
        get { return _items.Count; }
    }

    public object this[int index]
    {
        get { return _items[index]; }
        set { _items.Insert(index, value); }
    }
}

// Конкретний ітератор
public class ConcreteIterator : IIterator
{
    private readonly ConcreteAggregate _aggregate;
    private int _current = 0;

    public ConcreteIterator(ConcreteAggregate aggregate)
    {
        _aggregate = aggregate;
    }

    public bool HasNext()
    {
        return _current < _aggregate.Count;
    }

    public object Next()
    {
        return _aggregate[_current++];
    }
}

// Клієнтський код
class Program
{
    static void Main(string[] args)
    {
        var aggregate = new ConcreteAggregate();
        aggregate[0] = "Item A";
        aggregate[1] = "Item B";
        aggregate[2] = "Item C";

        var iterator = aggregate.CreateIterator();

        while (iterator.HasNext())
        {
            var item = iterator.Next();
            Console.WriteLine(item);
        }
    }
}
