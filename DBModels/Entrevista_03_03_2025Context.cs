using Microsoft.EntityFrameworkCore;

namespace STI_Entrevista_03_03_2025.DBModels
{
    public partial class Entrevista_03_03_2025Context : DbContext, IEntrevista_03_03_2025Context
    {
        public Entrevista_03_03_2025Context(DbContextOptions<Entrevista_03_03_2025Context> options) : base(options)
        {
        }

        public virtual DbSet<CadastroVeiculo> CadastroVeiculos { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
