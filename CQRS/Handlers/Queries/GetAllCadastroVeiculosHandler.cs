using Microsoft.EntityFrameworkCore;
using STI_Entrevista_03_03_2025.CQRS.DTOs;
using STI_Entrevista_03_03_2025.CQRS.Interfaces;
using STI_Entrevista_03_03_2025.CQRS.Queries;
using STI_Entrevista_03_03_2025.DBModels;

namespace STI_Entrevista_03_03_2025.CQRS.Handlers.Queries
{
    public class GetAllCadastroVeiculosHandler(IEntrevista_03_03_2025Context context) : IQueryHandler<GetAllCadastroVeiculosQuery, IEnumerable<CadastroVeiculoDto>>
    {
        public async Task<IEnumerable<CadastroVeiculoDto>> Handle(GetAllCadastroVeiculosQuery query)
        {
            return
                await
                context.CadastroVeiculos.Select(x =>
                new CadastroVeiculoDto
                {
                    Id = x.Id,
                    Placa = x.Placa,
                    Marca = x.Marca,
                    Chassis = x.Chassis,
                    Cor = x.Cor,
                    Modelo = x.Modelo,
                    Porte = x.Porte,
                    TipoDeCarga = x.TipoDeCarga
                }).ToListAsync();
        }
    }
}
