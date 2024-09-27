using Hospital.Server.Enums;
using Hospital.Server.IRepository;
using Hospital.Server.Models;

namespace Hospital.Server.IService
{
    public class AtendimentoService : IAtendimentoService
    {
        private readonly IAtendimentoRepository _atendimentoRepository;

        public AtendimentoService(IAtendimentoRepository atendimentoRepository)
        {
            _atendimentoRepository = atendimentoRepository;
        }

        public async Task<Atendimento> GetAtendimentoAsync(int id)
        {
            return await _atendimentoRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Atendimento>> GetAtendimentosAsync()
        {
            return await _atendimentoRepository.GetAllAsync();
        }

        public async Task<bool> AddAtendimentoAsync(Atendimento atendimento)
        {
            if (atendimento == null)
                return false; // Validação simples

            await _atendimentoRepository.AddAsync(atendimento);
            return true;
        }

        public async Task<bool> UpdateAtendimentoAsync(Atendimento atendimento)
        {
            var existingAtendimento = await _atendimentoRepository.GetByIdAsync(atendimento.Id);
            if (existingAtendimento == null)
                return false;

            await _atendimentoRepository.UpdateAsync(atendimento);
            return true;
        }

        public async Task<bool> DeleteAtendimentoAsync(int id)
        {
            await _atendimentoRepository.DeleteAsync(id);
            return true;
        }

        public async Task<bool> CreateAutoAtendimento(int id)
        {
            if (id == 0)
                return false; // Validação simples

            Atendimento autoAtendimento = new Atendimento();
            autoAtendimento.PacienteId = id;
            autoAtendimento.DataHoraChegada = DateTime.Now;
            autoAtendimento.Status = EStatusAtendimento.AguardandoAtendimento;

            await _atendimentoRepository.AddAsync(autoAtendimento);

            return true;
        }

        public async Task<Atendimento> ProximoAtendimento()
        { 
            return await _atendimentoRepository.ProximoAtendimento();
        }

        public async Task<IEnumerable<Atendimento>> ListaAtendimento()
        {
            return await _atendimentoRepository.ListaAtendimento();
        }
    }
}
