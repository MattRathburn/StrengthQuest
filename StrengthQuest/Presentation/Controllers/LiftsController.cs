using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Entities.Models;
using Services;
using Contracts.IServices;
using Contracts;

namespace Presentation.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LiftsController : ControllerBase
  {
    private readonly ILiftService _service;
    private readonly ILoggerService _logger;

    public LiftsController(ILiftService service, ILoggerService logger)
    {
      _service = service;
      _logger = logger;
    }

    // GET: api/Lifts
    [HttpGet]
    public async Task<IEnumerable<Lift>> GetLifts()
    {
      return await _service.GetAllAsync();
    }

    // GET: api/Lifts/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetLift(Guid id)
    {
      var lift = await _service.GetAsync(id);

      if (lift == null)
      {
        return NotFound();
      }

      return Ok(lift);
    }

    // PUT: api/Lifts/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutLift([FromRoute]Guid id, [FromBody]Lift lift)
    {
      if (id != lift.Id)
      {
        return BadRequest();
      }

      var returnedLift = await _service.UpdateAsync(lift);

      if (returnedLift == null)
      {
        return NotFound();
      }

      if (returnedLift.Status.IsSuccessful)
      {
        return StatusCode(200, returnedLift);
      }
      return StatusCode(400, "Could not add lift: " + returnedLift.LiftName);
    }

    // POST: api/Lifts
    [HttpPost]
    public async Task<ActionResult<Lift>> PostLift(Lift lift)
    {
      var returnedLift = await _service.CreateAsync(lift);

      if (returnedLift == null)
      {
        return NotFound();
      }

      if (returnedLift.Status.IsSuccessful)
      {
        return StatusCode(201, returnedLift);
      }
      return StatusCode(400, "Could not add lift: " + returnedLift.LiftName);      
    }

    // DELETE: api/Lifts/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Lift>> DeleteLift(Guid id)
    {
      var returnedLift = await _service.DeleteAsync(id);

      if (returnedLift == null)
      {
        return NotFound();
      }

      if (returnedLift.Status.IsSuccessful)
      {
        return StatusCode(200, returnedLift);
      }

      return StatusCode(400, "Unable to delete lift: " + returnedLift.LiftName);
    }
  }
}
