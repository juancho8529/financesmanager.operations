using FinancesManager.Operations.Application.Commands;
using FinancesManager.Operations.Application.Mappers;
using FinancesManager.Operations.Application.Responses;
using FinancesManager.Operations.Core.Entities;
using FinancesManager.Operations.Core.Repositories;
using MediatR;

namespace FinancesManager.Operations.Application.Handlers;

public class CreateOperationHandler : IRequestHandler<CreateOperationCommand, OperationResponse>
{
    private readonly IOperationRepository _operationRepo;
    public CreateOperationHandler(IOperationRepository operationRepository)
    {
        _operationRepo = operationRepository;
    }
    public async Task<OperationResponse> Handle(CreateOperationCommand request, CancellationToken cancellationToken)
    {
        var operationEntitiy = OperationMapper.Mapper.Map<Operation>(request);
        if (operationEntitiy is null)
        {
            throw new ApplicationException("Issue with mapper");
        }
        var newOperation = await _operationRepo.AddAsync(operationEntitiy);
        var operationResponse = OperationMapper.Mapper.Map<Operation, OperationResponse>(newOperation);
        return operationResponse;
    }
}
