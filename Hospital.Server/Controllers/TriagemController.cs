using Hospital.Server.DTO;
using Hospital.Server.IService;
using Hospital.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TriagemController : ControllerBase
    {
        private readonly ITriagemService _triagemService;

        public TriagemController(ITriagemService triagemService)
        {
            _triagemService = triagemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTriagems()
        {
            var triagem = await _triagemService.GetTriagemsAsync();
            return Ok(triagem);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Triagem>> GetTriagem(int id)
        {
            var triagem = await _triagemService.GetTriagemAsync(id);
            if (triagem == null)
                return NotFound();

            return Ok(triagem);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTriagem([FromBody] TriagemDTO triagemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Triagem triagem = new Triagem();

            triagem.AtendimentoId = triagemDto.AtendimentoId;
            triagem.Sintomas = triagemDto.Sintomas;
            triagem.PressaoArterial = triagemDto.PressaoArterial;
            triagem.Peso = triagemDto.Peso;
            triagem.Altura = triagemDto.Altura;
            triagem.EspecialidadeId = triagemDto.EspecialidadeId;

            var novaTriagem = await _triagemService.AddTriagemAsync(triagem);

            return CreatedAtAction(nameof(GetTriagem), new { id = triagem.Id }, novaTriagem);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTriagem(int id, Triagem triagem)
        {
            if (id != triagem.Id)
                return BadRequest();

            if (await _triagemService.UpdateTriagemAsync(triagem))
                return NoContent();

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTriagem(int id)
        {
            if (await _triagemService.DeleteTriagemAsync(id))
                return NoContent();

            return NotFound();
        }
    }
}
