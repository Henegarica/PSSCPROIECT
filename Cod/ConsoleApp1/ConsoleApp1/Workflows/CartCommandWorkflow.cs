using ConsoleApp1.Data;
using CSharp.Choices;
using static LanguageExt.Prelude;
using LanguageExt;
using Array = System.Array;
using LanguageExt.ClassInstances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.CreateCommandResult;

namespace ConsoleApp1.Workflows
{
    public record CartCommand();

    [AsChoice]
    public static partial class CartCommandResult
    {
        public interface ICartCommandResult
        {
        }
        public record CartAccepted(Order Order) : ICartCommandResult;

        public record CartFailed(string Reason) : ICartCommandResult;
    }

    public class CartCommandWorkflow
    {
        public CartCommandWorkflow()
        {

        }

        public async Task<CartCommandResult.ICartCommandResult> ExecuteAsync(CartCommand cmd)
        {
            Either<string, Order> expr = from products in LoadProducts()
                                         from isValid in ValidateCommand(cmd)
                                         from order in Order.Create(123, products).ToEither("Cannot create a valid Order")
                                         from saveOrder in SaveOrder(order)
                                         select order;

            return expr.Match(
                Right: order => (CartCommandResult.ICartCommandResult)new CartCommandResult.CartAccepted(order),
                Left: error => new CartCommandResult.CartFailed(error));
        }

        public static Either<string, Product[]> LoadProducts()
        {
            return Right<string, Product[]>(Array.Empty<Product>());
        }

        public static Either<string, Unit> ValidateCommand(CartCommand cmd)
        {
            //presupunem ca avem o comanda valida
            return Right<string, Unit>(unit);
        }

        public static Either<string, Unit> SaveOrder(Order order)
        {
            return Right<string, Unit>(unit);
        }
    }
}
