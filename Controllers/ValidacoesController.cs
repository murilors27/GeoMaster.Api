using GeoMaster.Api.Dtos;
using GeoMaster.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeoMaster.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ValidacoesController : ControllerBase
{
	private readonly ICalculadoraService _service;
	public ValidacoesController(ICalculadoraService service) => _service = service;

	[HttpPost("forma-contida")]
	[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public ActionResult<bool> FormaContida([FromBody] FormaContidaRequest request)
	{
		if (!ModelState.IsValid) return ValidationProblem(ModelState);
		try { return Ok(_service.EstaContida(request)); }
		catch (ArgumentException ex) { return BadRequest(ex.Message); }
		catch (InvalidOperationException ex) { return BadRequest(ex.Message); }
	}
}
