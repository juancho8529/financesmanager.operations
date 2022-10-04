using FinancesManager.Operations.Application.Commands;
using FinancesManager.Operations.Application.Queries;
using FinancesManager.Operations.Application.Responses;
using FinancesManager.Operations.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinancesManager.Operations.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OperationController : ControllerBase
{
    private readonly IMediator _mediator;
    public OperationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<OperationResponse>>> Get(Guid userId, DateTime startDate, DateTime endDate)
    {
        var result = await _mediator.Send(new GetAllOperationsQuery(userId, startDate, endDate));
        return Ok(result);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<OperationResponse>> CreateOperation([FromBody] CreateOperationCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
