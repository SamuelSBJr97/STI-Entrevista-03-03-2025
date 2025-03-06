
using STI_Entrevista_03_03_2025.CQRS.Commands;
using STI_Entrevista_03_03_2025.CQRS.DTOs;
using STI_Entrevista_03_03_2025.CQRS.Interfaces;
using STI_Entrevista_03_03_2025.DBModels;

namespace STI_Entrevista_03_03_2025.CQRS.Handlers.Commands
{
    public class UpdateCadastroVeiculoCommandHandler(IEntrevista_03_03_2025Context context) : ICommandHandler<UpdateCadastroVeiculoCommand>, ICommandResultHandler<UpdateCadastroVeiculoCommand, CadastroVeiculoDto>
    {
        private readonly IEntrevista_03_03_2025Context _context = context;

        public async Task<CadastroVeiculoDto> HandleResult(UpdateCadastroVeiculoCommand command)
        {
            var veiculo =
                await _context.CadastroVeiculos.FindAsync(command.Id)
                ?? throw new KeyNotFoundException($"CadastroVeiculo with Id {command.Id} not found.");

            veiculo.Placa = command.Placa;
            veiculo.Marca = command.Marca;
            veiculo.Modelo = command.Modelo;
            veiculo.Cor = command.Cor;
            veiculo.Porte = command.Porte;
            veiculo.TipoDeCarga = command.TipoDeCarga;
            veiculo.Chassis = command.Chassis;

            await _context.SaveChangesAsync();

            return MapToDto(veiculo);
        }

        public async Task Handle(UpdateCadastroVeiculoCommand command)
        {
            var veiculo =
                await _context.CadastroVeiculos.FindAsync(command.Id)
                ?? throw new KeyNotFoundException($"CadastroVeiculo with Id {command.Id} not found.");

            veiculo.Placa = command.Placa;
            veiculo.Marca = command.Marca;
            veiculo.Modelo = command.Modelo;
            veiculo.Cor = command.Cor;
            veiculo.Porte = command.Porte;
            veiculo.TipoDeCarga = command.TipoDeCarga;
            veiculo.Chassis = command.Chassis;

            await _context.SaveChangesAsync();
        }

        private static CadastroVeiculoDto MapToDto(CadastroVeiculo veiculo)
        {
            return new CadastroVeiculoDto
            {
                Id = veiculo.Id,
                Placa = veiculo.Placa,
                Marca = veiculo.Marca,
                Modelo = veiculo.Modelo,
                Cor = veiculo.Cor,
                Porte = veiculo.Porte,
                TipoDeCarga = veiculo.TipoDeCarga,
                Chassis = veiculo.Chassis
            };
        }
    }
}
