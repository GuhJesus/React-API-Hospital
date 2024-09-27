using Hospital.Server.Models;
using Hospital.Server.IService;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtendimentoController : ControllerBase
    {
        private readonly IAtendimentoService _atendimentoService;

        public AtendimentoController(IAtendimentoService atendimentoService)
        {
            _atendimentoService = atendimentoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAtendimentosAsync()
        {
            var atendimentos = await _atendimentoService.GetAtendimentosAsync();
            return Ok(atendimentos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAtendimento(int id)
        {
            var atendimento = await _atendimentoService.GetAtendimentoAsync(id);
            if (atendimento == null)
            {
                return NotFound();
            }
            return Ok(atendimento);
        }

        [HttpPost]
        public async Task<IActionResult> AddAtendimento([FromBody] Atendimento atendimento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var novoAtendimento = await _atendimentoService.AddAtendimentoAsync(atendimento);
            return CreatedAtAction(nameof(GetAtendimento), new { id = atendimento.Id }, novoAtendimento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAtendimento(int id, [FromBody] Atendimento atendimento)
        {
            if (id != atendimento.Id)
            {
                return BadRequest("O ID do atendimento não corresponde.");
            }

            try
            {
                await _atendimentoService.UpdateAtendimentoAsync(atendimento);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtendimento(int id)
        {
            try
            {
                await _atendimentoService.DeleteAtendimentoAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("ProximoAtendimento")]
        public async Task<IActionResult> ProximoAtendimento()
        {
            var proxAtendimento = await _atendimentoService.ProximoAtendimento();
            if (proxAtendimento == null)
            {
                return NotFound();
            }
            return Ok(proxAtendimento);
        }

        [HttpGet("ListaAtendimento")]
        public async Task<IActionResult> ListaAtendimento()
        {
            var proxAtendimento = await _atendimentoService.ListaAtendimento();
            if (proxAtendimento == null)
            {
                return NotFound();
            }
            return Ok(proxAtendimento);
        }
    }

}
