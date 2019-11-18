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

namespace Presentation.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LiftsController : ControllerBase
  {
    private readonly AppDbContext _context;
    private readonly ILiftService _service;

    public LiftsController(AppDbContext context, ILiftService service)
    {
      _service = service;
      _context = context;
    }

    // GET: api/Lifts
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Lift>>> GetLifts()
    {
      return await _context.Lifts.ToListAsync();
    }

    // GET: api/Lifts/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Lift>> GetLift(Guid id)
    {
      var lift = await _context.Lifts.FindAsync(id);

      if (lift == null)
      {
        return NotFound();
      }

      return lift;
    }

    // PUT: api/Lifts/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutLift(Guid id, Lift lift)
    {
      if (id != lift.Id)
      {
        return BadRequest();
      }

      try
      {
        
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!LiftExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/Lifts
    [HttpPost]
    public async Task<ActionResult<Lift>> PostLift(Lift lift)
    {
      _context.Lifts.Add(lift);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetLift", new { id = lift.Id }, lift);
    }

    // DELETE: api/Lifts/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Lift>> DeleteLift(Guid id)
    {
      return  await _service.DeleteAsync(id);
    }

    private bool LiftExists(Guid id)
    {
      return _context.Lifts.Any(e => e.Id == id);
    }
  }
}
