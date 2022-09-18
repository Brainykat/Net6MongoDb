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
    private readonly ILogger<NationsController> logger;
    public NationsController(INationService service, ILogger<NationsController> logger)
    {
      this.service = service ?? throw new ArgumentNullException(nameof(service));
      this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    public async Task<IActionResult> Get()
      => Ok(await service.GetAsync());

    [HttpGet("{nationId:length(24)}")]
    public async Task<ActionResult<Nation>> Get(string nationId)
    {
      try
      {
        var nation = await service.GetAsync(nationId);

        if (nation is null)
        {
          return NotFound();
        }

        return Ok(nation);
      }
      catch (Exception ex)
      {
        logger.LogError(ex.Message, ex);
        return StatusCode(StatusCodes.Status500InternalServerError, ex);
      }
    }


    [HttpPost]
    public async Task<IActionResult> Post([FromBody] NationDto dto)
    {
      try
      {
        var nation = Nation.Create(dto.Id, dto.CountryName, dto.CurrencyName, dto.CurrencySymbol,
       dto.CurrencyId, dto.PhoneCode, dto.MinInitialAmount);
        await service.CreateAsync(nation);

        return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
      }
      catch (Exception ex)
      {
        logger.LogError(ex.Message, ex);
        return StatusCode(StatusCodes.Status500InternalServerError, ex);
      }
      
    }


    [HttpPut("{nationId:length(24)}")]
    public async Task<IActionResult> Update(string nationId, Nation dto)
    {
      try
      {
        var nation = await service.GetAsync(nationId);

        if (nation is null)
        {
          return NotFound();
        }

        dto.Id = nation.Id;

        await service.UpdateAsync(nationId, dto);

        return NoContent();
      }
      catch (Exception ex)
      {
        logger.LogError(ex.Message, ex);
        return StatusCode(StatusCodes.Status500InternalServerError, ex);
      }
    }

    [HttpDelete("{nationId:length(24)}")]
    public async Task<IActionResult> Delete(string nationId)
    {
      try
      {
        var nation = await service.GetAsync(nationId);

        if (nation is null)
        {
          return NotFound();
        }

        await service.RemoveAsync(nationId);

        return NoContent();
      }
      catch (Exception ex)
      {
        logger.LogError(ex.Message, ex);
        return StatusCode(StatusCodes.Status500InternalServerError, ex);
      }
      
    }
  }
}
