using NSwag.Generation.Processors.Contexts;
using NSwag.Generation.Processors;

namespace EventReservation.API.NswagConfig
{
    class FlattenOperationsProcessor : IOperationProcessor
    {
        public bool Process(OperationProcessorContext context)
        {
            context.OperationDescription.Operation.OperationId = $"{context.MethodInfo.Name}";
            return true;
        }
    }
}

