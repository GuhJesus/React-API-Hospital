using Hospital.Server.Enums;

namespace Hospital.Server.Models
{
    public class Atendimento
    {
        public int Id { get; set; }
        public int NumeroSequencial { get; set; }
        public int PacienteId { get; set; }
        public DateTime DataHoraChegada { get; set; }
        public EStatusAtendimento Status { get; set; }

        public Paciente Paciente { get; set; }
        public Triagem Triagem { get; set; }
    }
}
