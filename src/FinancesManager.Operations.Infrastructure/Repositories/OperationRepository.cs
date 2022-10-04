using FinancesManager.Operations.Core.Entities;
using FinancesManager.Operations.Core.Repositories;
using FinancesManager.Operations.Infrastructure.Data;
using FinancesManager.Operations.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace FinancesManager.Operations.Infrastructure.Repositories;

public class OperationRepository : Repository<Operation>, IOperationRepository
{
    public OperationRepository(OperationContext operationContext) : base(operationContext) { }
    public async Task<IEnumerable<Operation>> GetOperationsByDate(Guid userId, DateTime startDate, DateTime endDate) => 
        _dbContext.Operations.Where(o =>
            o.UserId == userId && 
            (o.EffectedDate >= startDate && o.EffectedDate <= endDate));
}
