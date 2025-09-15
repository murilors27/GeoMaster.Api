using GeoMaster.Api.Dtos;
using GeoMaster.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeoMaster.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CalculosController : ControllerBase
{
    private readonly ICalculadoraService _service;

    public CalculosController(ICalculadoraService service) => _service = service;

    [HttpPost("area")]
    [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<double> Area([FromBody] AreaRequest request)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        try
        {
            var result = _service.CalcularArea(request);
            return Ok(result);
        }
        catch (ArgumentException ex) { return BadRequest(ex.Message); }
        catch (InvalidOperationException ex) { return BadRequest(ex.Message); }
    }

    [HttpPost("perimetro")]
    [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<double> Perimetro([FromBody] PerimetroRequest request)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        try { return Ok(_service.CalcularPerimetro(request)); }
        catch (ArgumentException ex) { return BadRequest(ex.Message); }
        catch (InvalidOperationException ex) { return BadRequest(ex.Message); }
    }

    [HttpPost("volume")]
    [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<double> Volume([FromBody] VolumeRequest request)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        try { return Ok(_service.CalcularVolume(request)); }
        catch (ArgumentException ex) { return BadRequest(ex.Message); }
        catch (InvalidOperationException ex) { return BadRequest(ex.Message); }
    }

    [HttpPost("area-superficial")]
    [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<double> AreaSuperficial([FromBody] AreaSuperficialRequest request)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        try { return Ok(_service.CalcularAreaSuperficial(request)); }
        catch (ArgumentException ex) { return BadRequest(ex.Message); }
        catch (InvalidOperationException ex) { return BadRequest(ex.Message); }
    }
}
