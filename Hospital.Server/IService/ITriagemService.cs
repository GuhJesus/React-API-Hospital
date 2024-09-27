using Hospital.Server.Models;

namespace Hospital.Server.IService
{
    public interface ITriagemService
    {
        Task<Triagem> GetTriagemAsync(int id);
        Task<IEnumerable<Triagem>> GetTriagemsAsync();
        Task<bool> AddTriagemAsync(Triagem triagem);
        Task<bool> UpdateTriagemAsync(Triagem triagem);
        Task<bool> DeleteTriagemAsync(int id);
    }
}
