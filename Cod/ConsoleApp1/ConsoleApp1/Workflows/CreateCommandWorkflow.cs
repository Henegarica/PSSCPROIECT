using ConsoleApp1.Data;
using CSharp.Choices;
using static LanguageExt.Prelude;
using LanguageExt;
using Array = System.Array;

namespace ConsoleApp1;

public record CreateCommand();

[AsChoice]
public static partial class CreateCommandResult
{
    public interface ICreateCommandResult
    {
    }

    public record CommandCreated(Order Order) : ICreateCommandResult;

    public record CreateCommandFailed(string Reason) : ICreateCommandResult;
}

public class CreateCommandWorkflow
{
    public CreateCommandWorkflow()
    {
        //read data from file
    }

    public async Task<CreateCommandResult.ICreateCommandResult> ExecuteAsync(CreateCommand cmd)
    {
        Either<string, Order> expr = from products in LoadProducts()
            from isValid in ValidateCommand(cmd)
            from order in Order.Create(123, products).ToEither("Cannot create a valid Order")
            from saveOrder in SaveOrder(order)
            select order;

        return expr.Match(
            Right: order => (CreateCommandResult.ICreateCommandResult)new CreateCommandResult.CommandCreated(order),
            Left: error => new CreateCommandResult.CreateCommandFailed(error));
    }

    public static Either<string, Product[]> LoadProducts()
    {
        return Right<string, Product[]>(Array.Empty<Product>());
    }

    public static Either<string, Unit> ValidateCommand(CreateCommand cmd)
    {
        //presupunem ca avem o comanda valida
        return Right<string, Unit>(unit);
    }

    public static Either<string, Unit> SaveOrder(Order order)
    {
        return Right<string, Unit>(unit);
    }
}