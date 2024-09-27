using Hospital.Server.Models;

namespace Hospital.Server.IService
{
    public interface IEspecialidadeService
    {
        Task<IEnumerable<Especialidade>> GetEspecialidadesAsync();
    }
}
