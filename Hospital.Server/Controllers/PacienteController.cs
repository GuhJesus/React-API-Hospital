using Hospital.Server.DTO;
using Hospital.Server.IService;
using Hospital.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;
        private readonly IAtendimentoService _atendimentoService;

        public PacienteController(IPacienteService pacienteService, IAtendimentoService atendimentoService)
        {
            _pacienteService = pacienteService;
            _atendimentoService = atendimentoService;
        }


        [HttpGet]
        public async Task<IActionResult> GetPacientes()
        {
            var pacientes = await _pacienteService.GetPacientesAsync();
            return Ok(pacientes);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> GetPaciente(int id)
        {
            var paciente = await _pacienteService.GetPacienteAsync(id);
            if (paciente == null)
                return NotFound();

            return Ok(paciente);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePaciente([FromBody] PacienteDTO pacienteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paciente = new Paciente
            {
                Nome = pacienteDto.Nome,
                Telefone = pacienteDto.Telefone,
                Sexo = pacienteDto.Sexo,
                Email = pacienteDto.Email
            };

            var novoPaciente = await _pacienteService.AddPacienteAsync(paciente);

            await _atendimentoService.CreateAutoAtendimento(paciente.Id);

            return CreatedAtAction(nameof(GetPaciente), new { id = paciente.Id }, novoPaciente);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePaciente(int id, Paciente paciente)
        {
            if (id != paciente.Id)
                return BadRequest();

            if (await _pacienteService.UpdatePacienteAsync(paciente))
                return NoContent();

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePaciente(int id)
        {
            if (await _pacienteService.DeletePacienteAsync(id))
                return NoContent();

            return NotFound();
        }
    }
}
