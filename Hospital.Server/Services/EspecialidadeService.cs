using Hospital.Server.IRepository;
using Hospital.Server.Models;

namespace Hospital.Server.IService
{
    public class EspecialidadeService : IEspecialidadeService
    {
        private readonly IEspecialidadeRepository _especialidadeRepository;
        public EspecialidadeService(IEspecialidadeRepository especialidadeRepository)
        {
            _especialidadeRepository = especialidadeRepository;
        }
        public async Task<IEnumerable<Especialidade>> GetEspecialidadesAsync()
        {
            return await _especialidadeRepository.GetAllAsync();

        }
    }
}
