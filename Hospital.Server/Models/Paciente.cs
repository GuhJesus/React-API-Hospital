namespace Hospital.Server.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Telefone { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }

        public List<Atendimento> Atendimentos { get; set; }
    }
}