using STI_Entrevista_03_03_2025.CQRS.DTOs;
using STI_Entrevista_03_03_2025.CQRS.Interfaces;
using STI_Entrevista_03_03_2025.CQRS.Queries;
using STI_Entrevista_03_03_2025.DBModels;

namespace STI_Entrevista_03_03_2025.CQRS.Handlers.Queries
{
    public class GetCadastroVeiculoByIdQueryHandler(IEntrevista_03_03_2025Context context) : IQueryHandler<GetCadastroVeiculoByIdQuery, CadastroVeiculoDto>
    {
        public async Task<CadastroVeiculoDto> Handle(GetCadastroVeiculoByIdQuery query)
        {
            var veiculo = await context.CadastroVeiculos.FindAsync(query.Id);
            return veiculo == null
                ? throw new ArgumentNullException(paramName: nameof(query))
                : new CadastroVeiculoDto
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