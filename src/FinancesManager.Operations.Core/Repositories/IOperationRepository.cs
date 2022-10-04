using FinancesManager.Operations.Core.Entities;
using FinancesManager.Operations.Core.Repositories.Base;

namespace FinancesManager.Operations.Core.Repositories;
public interface IOperationRepository : IRepository<Operation>
{
    //custom operations here
    Task<IEnumerable<Operation>> GetOperationsByDate(Guid userId, DateTime startDate, DateTime endDate);
}
