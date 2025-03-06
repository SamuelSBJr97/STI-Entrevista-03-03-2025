using STI_Entrevista_03_03_2025.CQRS.Commands;
using STI_Entrevista_03_03_2025.CQRS.DTOs;
using STI_Entrevista_03_03_2025.CQRS.Interfaces;
using STI_Entrevista_03_03_2025.DBModels;

namespace STI_Entrevista_03_03_2025.CQRS.Handlers.Commands
{
    public class CreateCadastroVeiculoCommandHandler(IEntrevista_03_03_2025Context context) : ICommandHandler<CreateCadastroVeiculoCommand>, ICommandResultHandler<CreateCadastroVeiculoCommand, CadastroVeiculoDto>
    {
        private readonly IEntrevista_03_03_2025Context _context = context;

        public async Task Handle(CreateCadastroVeiculoCommand command)
        {
            var veiculo = MapToEntity(command);
            _context.CadastroVeiculos.Add(veiculo);
            await _context.SaveChangesAsync();
        }

        public async Task<CadastroVeiculoDto> HandleResult(CreateCadastroVeiculoCommand command)
        {
            var veiculo = MapToEntity(command);
            var result = _context.CadastroVeiculos.Add(veiculo);
            await _context.SaveChangesAsync();

            return MapToDto(result.Entity);
        }

        private static CadastroVeiculo MapToEntity(CreateCadastroVeiculoCommand command)
        {
            return new CadastroVeiculo
            {
                Placa = command.Placa,
                Marca = command.Marca,
                Modelo = command.Modelo,
                Cor = command.Cor,
                Porte = command.Porte,
                TipoDeCarga = command.TipoDeCarga,
                Chassis = command.Chassis
            };
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
