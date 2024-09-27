using Hospital.Server.Enums;

namespace Hospital.Server.DTO
{
    public class AtendimentoDTO
    {
        public int PacienteId { get; set; }
        public DateTime DataHoraChegada { get ; set; }
        public EStatusAtendimento Status{ get; set; }
    }
}
