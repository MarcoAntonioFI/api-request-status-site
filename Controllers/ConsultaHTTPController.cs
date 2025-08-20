using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class  MonitoramentoController : ControllerBase
{
    private readonly IMonitoramentoService _monitoramentoService;

    public MonitoramentoController(IMonitoramentoService monitoramentoService)
    {
        _monitoramentoService = monitoramentoService;
    }

    [HttpGet("verificar")]
    public async Task<IActionResult> VerificarSiteAsync([FromQuery] string url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            return BadRequest("URL não pode ser vazia.");
        }
        var resultado = await _monitoramentoService.VerificarSiteAsync(url);
        if (resultado)
        {
            return Ok("Site está online.");
        }
        else
        {
            return StatusCode(503, "Site está offline ou inacessível.");
        }
    }
}

