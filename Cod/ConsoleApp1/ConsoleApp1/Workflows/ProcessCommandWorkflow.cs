using ConsoleApp1.Data;
using CSharp.Choices;
using LanguageExt;
using static LanguageExt.Prelude;
using Array = System.Array;


namespace ConsoleApp1.Workflows
{
    public record ProcessCommand();

    [AsChoice]
    public static partial class ProcessCommandResult
    {
        public interface IProcessCommandResult
        {

        }
        public record ProcessCommandCompleted(Process process) : IProcessCommandResult;
        public record ProcessCommandFailed(string reason) : IProcessCommandResult;
    }
    public class ProcessCommandWorkflow
    {
        public ProcessCommandWorkflow()
        {

        }

        public async Task<ProcessCommandResult.IProcessCommandResult> ExecuteAsync(ProcessCommand processCommand)
        {
            Either<string, Process> expr = from products in LoadProducts()
                                         from isValid in ValidateCommand(processCommand)
                                         from order in Process.Create(123, products).ToEither("Cannot create a valid Order")
                                         from saveOrder in SaveOrder(order)
                                         select order;

            return expr.Match(
                Right: order => (ProcessCommandResult.IProcessCommandResult)new ProcessCommandResult.ProcessCommandCompleted(order),
                Left: error => new ProcessCommandResult.ProcessCommandFailed(error));
        }

        public static Either<string, Address[]> LoadProducts()
        {
            return Right<string, Address[]>(Array.Empty<Address>());
        }

        public static Either<string, Unit> ValidateCommand(ProcessCommand processCommand)
        {
            return Right<string, Unit>(unit);
        }
        public static Either<string, Unit> SaveOrder(Process process)
        {
            return Right<string, Unit>(unit);
        }
    }
}
