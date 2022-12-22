using LanguageExt;
using static LanguageExt.Prelude;

namespace ConsoleApp1.Data;

public record Quantity
{
    public uint Value { get; }

    private Quantity(uint value)
    {
        Value = value;
    }

    public Option<Quantity> Create(int value)
        => (value > 0) ? Some(new Quantity((uint)value)) : Option<Quantity>.None;
}

public record Product(int Id, Quantity Quantity, uint Price, uint Stock);

public record Order
{
    private Order(int id, Product[] products)
    {
    }

    public static Option<Order> Create(int id, Product[] products) =>
        Some(new Order(id, products));
}

public record Process
{
    private Process(int id, Address[] addresses)
    {

    }

    public static Option<Process> Create(int id, Address[] addresses) =>
        Some(new Process(id, addresses));
}