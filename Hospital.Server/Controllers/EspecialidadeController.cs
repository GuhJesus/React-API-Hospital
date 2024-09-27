using Hospital.Server.IService;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidadeService _especialidadeService;

        public EspecialidadeController(IEspecialidadeService especialidadeService)
        {
            _especialidadeService = especialidadeService;
        }

        [HttpGet("ListaEspecialidade")]
        public async Task<IActionResult> GetEspecialidades()
        {
            var especialidades = await _especialidadeService.GetEspecialidadesAsync();
            return Ok(especialidades);
        }
    }
}
