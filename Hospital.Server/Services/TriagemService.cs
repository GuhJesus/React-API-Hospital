using Hospital.Server.IRepository;
using Hospital.Server.Models;

namespace Hospital.Server.IService
{
    public class TriagemService : ITriagemService
    {
        private readonly ITriagemRepository _triagemRepository;

        public TriagemService(ITriagemRepository triagemRepository)
        {
           _triagemRepository = triagemRepository;
        }

        public async Task<Triagem> GetTriagemAsync(int id)
        {
            return await _triagemRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Triagem>> GetTriagemsAsync()
        {
            return await _triagemRepository.GetAllAsync();
        }

        public async Task<bool> AddTriagemAsync(Triagem triagem)
        {
            if (triagem == null)
                return false; // Validação simples

            await _triagemRepository.AddAsync(triagem);
            return true;
        }

        public async Task<bool> UpdateTriagemAsync(Triagem triagem)
        {
            var existingTriagem = await _triagemRepository.GetByIdAsync(triagem.Id);
            if (existingTriagem == null)
                return false;

            await _triagemRepository.UpdateAsync(triagem);
            return true;
        }

        public async Task<bool> DeleteTriagemAsync(int id)
        {
            await _triagemRepository.DeleteAsync(id);
            return true;
        }
    }
}
