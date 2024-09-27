namespace Hospital.Server.Models
{
    public class Triagem
    {
        public int Id { get; set; }
        public int AtendimentoId { get; set; }
        public string Sintomas { get; set; }
        public string  PressaoArterial { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
        public int EspecialidadeId { get; set; }


        public Atendimento Atendimento { get; set; }
        public Especialidade Especialidade { get; set; }

    }
}
