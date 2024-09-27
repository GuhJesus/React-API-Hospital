using Hospital.Server.Models;

namespace Hospital.Server.IRepository
{
    public interface IEspecialidadeRepository
    {
        Task<IEnumerable<Especialidade>> GetAllAsync();
    }
}
