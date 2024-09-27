using Hospital.Server.Models;

namespace Hospital.Server.IRepository
{
    public interface IAtendimentoRepository
    {
        Task<Atendimento> GetByIdAsync(int id);
        Task<IEnumerable<Atendimento>> GetAllAsync();
        Task AddAsync(Atendimento atendimento);
        Task UpdateAsync(Atendimento atendimento);
        Task DeleteAsync(int id);
        int GetNumeroSequencial();

        Task<Atendimento> ProximoAtendimento();
        Task<IEnumerable<Atendimento>> ListaAtendimento();
    }
}
