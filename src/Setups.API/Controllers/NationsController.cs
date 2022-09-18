using CommonBase.Data.Dtos;
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

    [HttpGet("{nationId:length(24)}")]
    public async Task<ActionResult<Nation>> Get(string nationId)
    {
      var nation = await service.GetAsync(nationId);

      if (nation is null)
      {
        return NotFound();
      }

      return Ok(nation);
    }


    [HttpPost]
    public async Task<IActionResult> Post([FromBody] NationDto dto)
    {
      var nation = Nation.Create(dto.Id, dto.CountryName, dto.CurrencyName, dto.CurrencySymbol,
       dto.CurrencyId, dto.PhoneCode, dto.MinInitialAmount);
      await service.CreateAsync(nation);

      return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
    }


    [HttpPut("{nationId:length(24)}")]
    public async Task<IActionResult> Update(string nationId, Nation dto)
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

    [HttpDelete("{nationId:length(24)}")]
    public async Task<IActionResult> Delete(string nationId)
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
