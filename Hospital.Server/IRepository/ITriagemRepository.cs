using Hospital.Server.Models;

namespace Hospital.Server.IRepository
{
    public interface ITriagemRepository
    {
        Task<Triagem> GetByIdAsync(int id);
        Task<IEnumerable<Triagem>> GetAllAsync();
        Task AddAsync(Triagem triagem);
        Task UpdateAsync(Triagem triagem);
        Task DeleteAsync(int id);
    }
}
