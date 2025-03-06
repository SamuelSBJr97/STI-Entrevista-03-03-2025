
using STI_Entrevista_03_03_2025.CQRS.Commands;
using STI_Entrevista_03_03_2025.CQRS.Interfaces;
using STI_Entrevista_03_03_2025.DBModels;

namespace STI_Entrevista_03_03_2025.CQRS.Handlers.Commands
{
    public class DeleteCadastroVeiculoHandler(IEntrevista_03_03_2025Context context) : ICommandHandler<DeleteCadastroVeiculoCommand>
    {
        private readonly IEntrevista_03_03_2025Context _context = context;

        public async Task Handle(DeleteCadastroVeiculoCommand command)
        {
            var veiculo =
                await _context.CadastroVeiculos.FindAsync(command.Id)
                ?? throw new KeyNotFoundException($"CadastroVeiculo with Id {command.Id} not found.");
            _context.CadastroVeiculos.Remove(veiculo);
            await _context.SaveChangesAsync();
        }
    }
}
