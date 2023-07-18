using Microsoft.EntityFrameworkCore;
using Sistema_Marcacao_Clinica_Veterinaria.Data.Map;
using Sistema_Marcacao_Clinica_Veterinaria.Models;

namespace Sistema_Marcacao_Clinica_Veterinaria.Data
{
    public class MarcacaoClinicaVeterinariaDBContext : DbContext
    {
        public MarcacaoClinicaVeterinariaDBContext(DbContextOptions<MarcacaoClinicaVeterinariaDBContext> options)
            : base(options) {
            //this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Proprietario> Proprietarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Animal> Animais { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<Marcacao> Marcacoes { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Vacina> Vacinas { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Exame> Exames { get; set; }
        public DbSet<Cirurgia> Cirurgias { get; set; }
        //public DbSet<Diagnostico> Diagnosticos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfiguration(new ProprietarioMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new AnimalMap());
            modelBuilder.ApplyConfiguration(new EspecieMap());
            modelBuilder.ApplyConfiguration(new MarcacaoMap());
            modelBuilder.ApplyConfiguration(new VeterinarioMap());
            //modelBuilder.ApplyConfiguration(new VacinaMap());
            //modelBuilder.ApplyConfiguration(new ConsultaMap());
            //modelBuilder.ApplyConfiguration(new ExameMap());
            //modelBuilder.ApplyConfiguration(new CirurgiaMap());
            //modelBuilder.Entity<Servico>().ToTable("Servicos").UseTptMappingStrategy();
            //modelBuilder.Entity<Servico>().UseTpcMappingStrategy();
            //modelBuilder.Entity<Usuario>().UseTptMappingStrategy();
            //modelBuilder.Entity<Endereco>().HasOne(e => e.proprietario).WithOne(e => e.endereco).HasForeignKey("proprietarioId");

            modelBuilder.Entity<Servico>().ToTable("Servicos").UseTptMappingStrategy<Servico>();
            //modelBuilder.Entity<Servico>().ToTable("Servicos").UseTptMappingStrategy<Exame>();
            //modelBuilder.Entity<Servico>().ToTable("Servicos").UseTptMappingStrategy<Cirurgia>();
            //modelBuilder.Entity<Servico>().ToTable("Servicos").UseTptMappingStrategy<Vacina>();

            base.OnModelCreating(modelBuilder);

        }
    }
}
