using FinancesManager.Operations.Application.Responses;
using MediatR;

namespace FinancesManager.Operations.Application.Queries;

public class GetAllOperationsQuery: IRequest<IEnumerable<OperationResponse>>
{
    public GetAllOperationsQuery(Guid userId, DateTime startDate, DateTime endDate) {
        UserId = userId;
        StartDate = startDate;
        EndDate = endDate;
    }

    public Guid UserId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
