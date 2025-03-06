using Microsoft.EntityFrameworkCore;

namespace STI_Entrevista_03_03_2025.DBModels
{
    public partial class Entrevista_03_03_2025Context : DbContext, IEntrevista_03_03_2025Context
    {
        public Entrevista_03_03_2025Context(DbContextOptions<Entrevista_03_03_2025Context> options) : base(options)
        {
            EnsureTableExists();
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
        public DbSet<CQRS.Commands.UpdateCadastroVeiculoCommand> UpdateCadastroVeiculoCommand { get; set; } = default!;
        private void EnsureTableExists()
        {
            var connection = Database.GetDbConnection();
            try
            {
                connection.Open();
                using var command = connection.CreateCommand();
                command.CommandText = @"
                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='CadastroVeiculos' AND xtype='U')
                        CREATE TABLE CadastroVeiculos (
                            ID INT PRIMARY KEY IDENTITY,
                            Placa NVARCHAR(10) NOT NULL,
                            Marca NVARCHAR(20) NOT NULL,
                            Modelo NVARCHAR(35) NOT NULL,
                            Cor NVARCHAR(20) NOT NULL,
                            Porte NVARCHAR(20) NOT NULL,
                            Tipo_de_Carga NVARCHAR(20) NOT NULL,
                            Chassis NVARCHAR(20) NOT NULL
                        )";
                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
