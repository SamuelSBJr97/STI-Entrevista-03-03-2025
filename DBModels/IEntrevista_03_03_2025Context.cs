using Microsoft.EntityFrameworkCore;

namespace STI_Entrevista_03_03_2025.DBModels
{
    public interface IEntrevista_03_03_2025Context
    {
        DbSet<CadastroVeiculo> CadastroVeiculos { get; set; }
        Task<int> SaveChangesAsync();
    }
}
