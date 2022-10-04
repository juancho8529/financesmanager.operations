using FinancesManager.Operations.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancesManager.Operations.Application.Commands;

public class CreateOperationCommand : IRequest<OperationResponse>
{
    public Guid userId { get; set; }
    public bool Earning { get; set; }
    public DateTime EffectedDate { get; set; }
    public float Ammount { get; set; }
    public string Currency { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Categories { get; set; } = string.Empty;
}
