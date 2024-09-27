using Hospital.Server.Context;
using Hospital.Server.IRepository;
using Hospital.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Server.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly HospitalContext _context;

        public EspecialidadeRepository(HospitalContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Especialidade>> GetAllAsync()
        {
            return await _context.Especialidades.ToListAsync();
        }
    }
}
