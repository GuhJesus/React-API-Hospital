namespace Hospital.Server.DTO
{
    public class TriagemDTO
    {
        public int AtendimentoId { get; set; }
        public string Sintomas { get; set; }
        public string PressaoArterial { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
        public int EspecialidadeId { get; set; }
    }
}
