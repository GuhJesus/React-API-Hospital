using Hospital.Server.Models;

namespace Hospital.Server.IService
{
    public interface IPacienteService
    {
        Task<Paciente> GetPacienteAsync(int id);
        Task<IEnumerable<Paciente>> GetPacientesAsync();
        Task<bool> AddPacienteAsync(Paciente paciente);
        Task<bool> UpdatePacienteAsync(Paciente paciente);
        Task<bool> DeletePacienteAsync(int id);
    }
}
