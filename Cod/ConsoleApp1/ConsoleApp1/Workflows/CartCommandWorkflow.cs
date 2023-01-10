using ConsoleApp1.Data;
using CSharp.Choices;
using static LanguageExt.Prelude;
using LanguageExt;

namespace ConsoleApp1.Workflows
{
    public enum DeliveryMethod
    {
        Card, Cash
    }
    public record ShipCommand(int OrderId, DeliveryMethod DeliveryMethod);

    [AsChoice]
    public static partial class ShipCommandResult
    {
        public interface IShipCommandResult
        {
        }

        public record CommandShipped(Order Order) : IShipCommandResult;

        public record ShipCommandFailed(string Reason) : IShipCommandResult;
        public class ShipCommandWorkflow
        {
            public async Task<ShipCommandResult.IShipCommandResult> ExecuteAsync(ShipCommand cmd)
            {
                Either<string, Order> expr = from order in LoadOrder(cmd.OrderId)
                                             from deliveryCost in CalculateDeliveryCost(cmd.DeliveryMethod)
                                             from confirmShipment in ConfirmShipment(order, deliveryCost)
                                             from ship in Ship(order, cmd.DeliveryMethod)
                                             from updateStatus in UpdateStatus(order)
                                             select order;

                return expr.Match(
                    Right: order => (ShipCommandResult.IShipCommandResult)new ShipCommandResult.CommandShipped(order),
                    Left: error => new ShipCommandResult.ShipCommandFailed(error));
            }

            public static Either<string, Order> LoadOrder(int orderId)
            {
                
                return Right<string, Order>(new Order());
            }

            public static Either<string, decimal> CalculateDeliveryCost(DeliveryMethod deliveryMethod)
            {
                return Right<string, decimal>(10m);
            }

            public static Either<string, Unit> ConfirmShipment(Order order, decimal deliveryCost)
            {
                return Right<string, Unit>(unit);
            }

            public static Either<string, Unit> Ship(Order order, DeliveryMethod deliveryMethod)
            {
                return Right<string, Unit>(unit);
            }
            public static Either<string, Unit> UpdateStatus(Order order)
            {
                //order.Status = OrderStatus.Shipped;
                return Right<string, Unit>(unit);
            }
        }
    }
}
