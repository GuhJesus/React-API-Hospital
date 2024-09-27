using Hospital.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Server.Context
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<Triagem> Triagens { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura relacionamento 1:N entre Paciente e Atendimento
            modelBuilder.Entity<Atendimento>()
                .HasOne(a => a.Paciente)
                .WithMany(p => p.Atendimentos)
                .HasForeignKey(a => a.PacienteId)
                .OnDelete(DeleteBehavior.Cascade); // Quando um Paciente for deletado, os Atendimentos também serão.

            // Configura relacionamento 1:1 entre Atendimento e Triagem
            modelBuilder.Entity<Triagem>()
                .HasOne(t => t.Atendimento)
                .WithOne(a => a.Triagem)
                .HasForeignKey<Triagem>(t => t.AtendimentoId)
                .OnDelete(DeleteBehavior.Cascade); // Quando um Atendimento for deletado, a Triagem correspondente também será.

            // Configura relacionamento entre Triagem e Especialidade
            modelBuilder.Entity<Triagem>()
                .HasOne(t => t.Especialidade)
                .WithMany() // Não há uma lista de triagens dentro de Especialidade
                .HasForeignKey(t => t.EspecialidadeId)
                .OnDelete(DeleteBehavior.Restrict); // Se a Especialidade for deletada, a Triagem não será afetada.

            // Configurações adicionais, como chaves únicas ou índices, se necessário
            modelBuilder.Entity<Paciente>()
                .HasIndex(p => p.Email)
                .IsUnique(); // Garante que o Email seja único para cada paciente.

            modelBuilder.Entity<Atendimento>()
                .Property(a => a.Status)
                .HasConversion<int>();
        }

    }
}
