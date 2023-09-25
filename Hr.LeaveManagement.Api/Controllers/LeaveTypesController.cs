using Hr.LeaveManagement.Application.Exceptions;
using Hr.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using Hr.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType;
using Hr.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;
using Hr.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using Hr.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Hr.LeaveManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveTypesController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveTypesController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    // GET: api/<LeaveTypesController>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<LeaveTypeDto>>> Get()
    {
        var leaveTypes = await _mediator.Send(new GetAllLeaveTypesQuery());
        return Ok(leaveTypes);
    }

    // GET api/<LeaveTypesController>/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<LeaveTypeDetailsDto>> Get(int id)
    {
        var leaveTypeDetail = await _mediator.Send(new GetLeaveTypeDetailsQuery(id));
        return Ok(leaveTypeDetail);
    }

    // POST api/<LeaveTypesController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Post([FromBody] CreateLeaveTypeCommand request)
    {
        var response = await _mediator.Send(request);
        return CreatedAtAction(nameof(Post), new { id = response });
    }

    // PUT api/<LeaveTypesController>/5
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveTypeCommand request)
    {
        await _mediator.Send(request);
        return NoContent();
    }

    // DELETE api/<LeaveTypesController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteLeaveTypeCommand(id));
        return NoContent();
    }
}
