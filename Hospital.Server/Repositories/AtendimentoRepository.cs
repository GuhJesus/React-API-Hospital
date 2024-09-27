using Hospital.Server.Context;
using Hospital.Server.Enums;
using Hospital.Server.IRepository;
using Hospital.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Server.Repositories
{
    public class AtendimentoRepository : IAtendimentoRepository
    {
        private readonly HospitalContext _context;

        public AtendimentoRepository(HospitalContext context)
        {
            _context = context;
        }

        public async Task<Atendimento> GetByIdAsync(int id)
        {
            return await _context.Atendimentos.FindAsync(id);
        }

        public async Task<IEnumerable<Atendimento>> GetAllAsync()
        {
            return await _context.Atendimentos.ToListAsync();
        }

        public async Task AddAsync(Atendimento atendimento)
        {
            atendimento.NumeroSequencial = GetNumeroSequencial();
            _context.Atendimentos.Add(atendimento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Atendimento atendimento)
        {
            _context.Atendimentos.Update(atendimento);
            await UpdateAsync(atendimento);
        }

        public async Task DeleteAsync(int id)
        {
            var atendimento = await _context.Atendimentos.FindAsync(id);

            if (atendimento != null)
            {
                _context.Atendimentos.Remove(atendimento);
                await _context.SaveChangesAsync();
            }
                
        }

        public int GetNumeroSequencial()
        {
            var NumeroSequencial  = _context.Atendimentos.Any() ? _context.Atendimentos.Max(a => a.NumeroSequencial) : 0;
            NumeroSequencial++;
            return NumeroSequencial;
        }

        public async Task<Atendimento> ProximoAtendimento()
        {
            var proxAtendimento = await _context.Atendimentos.Where(a => (int)a.Status == (int)EStatusAtendimento.AguardandoAtendimento)
                                                             .OrderBy(a => a.NumeroSequencial)
                                                             .FirstOrDefaultAsync();
            return proxAtendimento;
        }
        public async Task<IEnumerable<Atendimento>> ListaAtendimento()
        {
            var proxAtendimento = await _context.Atendimentos.Where(a => (int)a.Status == (int)EStatusAtendimento.AguardandoAtendimento)
                                                             .OrderBy(a => a.NumeroSequencial)
                                                             .ToListAsync();

            return proxAtendimento;
        }

    }

}
