using FinancesManager.Operations.Application.Mappers;
using FinancesManager.Operations.Application.Queries;
using FinancesManager.Operations.Application.Responses;
using FinancesManager.Operations.Core.Entities;
using FinancesManager.Operations.Core.Repositories;
using MediatR;

namespace FinancesManager.Operations.Application.Handlers;

public class GetAllOperationsHandler : IRequestHandler<GetAllOperationsQuery, IEnumerable<OperationResponse>>
{
    private readonly IOperationRepository operationRepository;
    public GetAllOperationsHandler(IOperationRepository _operationRepository)
    {
        operationRepository = _operationRepository;
    }

    public async Task<IEnumerable<OperationResponse>> Handle(GetAllOperationsQuery request, CancellationToken cancellationToken)
    {
        var operations = await operationRepository.GetOperationsByDate(request.UserId, request.StartDate, request.EndDate);
        var operationsResponse = OperationMapper.
            Mapper.
            Map<IEnumerable<Operation>,List<OperationResponse>>(operations);
        return operationsResponse;
    }
}
