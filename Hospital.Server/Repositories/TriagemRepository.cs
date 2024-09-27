using Hospital.Server.Context;
using Hospital.Server.IRepository;
using Hospital.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Server.Repositories
{
    public class TriagemRepository : ITriagemRepository
    {
        private readonly HospitalContext _context;

        public TriagemRepository(HospitalContext context)
        {
            _context = context;
        }

        public async Task<Triagem> GetByIdAsync(int id)
        {
            return await _context.Triagens.FindAsync(id);
        }

        public async Task<IEnumerable<Triagem>> GetAllAsync()
        {
            return await _context.Triagens.ToListAsync();
        }

        public async Task AddAsync(Triagem triagem)
        {
            _context.Triagens.Add(triagem);

            var atendimento = await _context.Atendimentos.FindAsync(triagem.AtendimentoId);

            if (atendimento != null)
            {
                atendimento.Status = Enums.EStatusAtendimento.TriagemCompleta;
                _context.Atendimentos.Update(atendimento);
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Triagem triagem)
        {
            _context.Triagens.Update(triagem);
            await UpdateAsync(triagem);
        }

        public async Task DeleteAsync(int id)
        {
            var triagem = await _context.Triagens.FindAsync(id);

            if (triagem != null)
            {
                _context.Triagens.Remove(triagem);
                await _context.SaveChangesAsync();
            }
                
        }

    }

}
