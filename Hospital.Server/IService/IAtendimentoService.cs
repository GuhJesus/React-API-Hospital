using Hospital.Server.Models;

namespace Hospital.Server.IService
{
    public interface IAtendimentoService
    {
        Task<Atendimento> GetAtendimentoAsync(int id);
        Task<IEnumerable<Atendimento>> GetAtendimentosAsync();
        Task<bool> AddAtendimentoAsync(Atendimento atendimento);
        Task<bool> UpdateAtendimentoAsync(Atendimento atendimento);
        Task<bool> DeleteAtendimentoAsync(int id);
        Task<bool> CreateAutoAtendimento(int id);

        Task<Atendimento> ProximoAtendimento();
        Task<IEnumerable<Atendimento>> ListaAtendimento();
    }
}
