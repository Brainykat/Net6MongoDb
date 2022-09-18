using CommonBase.Data.Entities;
using CommonBase.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Setups.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class NationsController : ControllerBase
  {
    private readonly INationService service;
    public NationsController(INationService service)
    {
      this.service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet]
    public async Task<IActionResult> Get()
      => Ok(await service.GetAsync());

    [HttpGet("{nationId}")]
    public async Task<ActionResult<Nation>> Get(Guid nationId)
    {
      var nation = await service.GetAsync(nationId);

      if (nation is null)
      {
        return NotFound();
      }

      return Ok(nation);
    }


    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Nation dto)
    {
      await service.CreateAsync(dto);

      return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
    }


    [HttpPut("{nationId}")]
    public async Task<IActionResult> Update(Guid nationId, Nation dto)
    {
      var book = await service.GetAsync(nationId);

      if (book is null)
      {
        return NotFound();
      }

      dto.Id = book.Id;

      await service.UpdateAsync(nationId, dto);

      return NoContent();
    }

    [HttpDelete("{nationId}")]
    public async Task<IActionResult> Delete(Guid nationId)
    {
      var book = await service.GetAsync(nationId);

      if (book is null)
      {
        return NotFound();
      }

      await service.RemoveAsync(nationId);

      return NoContent();
    }
  }
}
