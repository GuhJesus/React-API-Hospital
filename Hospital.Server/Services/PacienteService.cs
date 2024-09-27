using Hospital.Server.IRepository;
using Hospital.Server.Models;

namespace Hospital.Server.IService
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task<Paciente> GetPacienteAsync(int id)
        {
            return await _pacienteRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Paciente>> GetPacientesAsync()
        {
            return await _pacienteRepository.GetAllAsync();
        }

        public async Task<bool> AddPacienteAsync(Paciente paciente)
        {
            if (paciente == null || string.IsNullOrEmpty(paciente.Nome))
                return false; // Validação simples

            await _pacienteRepository.AddAsync(paciente);

            return true;
        }

        public async Task<bool> UpdatePacienteAsync(Paciente paciente)
        {
            var existingPaciente = await _pacienteRepository.GetByIdAsync(paciente.Id);
            if (existingPaciente == null)
                return false;

            await _pacienteRepository.UpdateAsync(paciente);
            return true;
        }

        public async Task<bool> DeletePacienteAsync(int id)
        {
            await _pacienteRepository.DeleteAsync(id);
            return true;
        }
    }
}
