using Hr.LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using Hr.LeaveManagement.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;
using Hr.LeaveManagement.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;
using Hr.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;
using Hr.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hr.LeaveManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class LeaveAllocationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveAllocationsController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    // GET: api/<LeaveAllocationsController>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<LeaveAllocationDto>>> GetAsync()
    {
        var data = await _mediator.Send(new GetLeaveAllocationsQuery());
        return Ok(data);
    }

    // GET api/<LeaveAllocationsController>/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<LeaveAllocationDetailsDto>> GetByIdAsync(int id)
    {
        var data = await _mediator.Send(new GetLeaveAllocationDetailsQuery(id));
        return Ok(data);
    }

    // POST api/<LeaveAllocationsController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Post([FromBody] CreateLeaveAllocationCommand request)
    {
        var response = await _mediator.Send(request);
        return CreatedAtAction(nameof(Post), new { id = response });
    }

    // PUT api/<LeaveAllocationsController>/5
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveAllocationCommand request)
    {
        await _mediator.Send(request);
        return NoContent();
    }

    // DELETE api/<LeaveAllocationsController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        await _mediator.Send(new DeleteLeaveAllocationCommand(id));
        return NoContent();
    }
}
