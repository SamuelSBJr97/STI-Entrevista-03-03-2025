namespace STI_Entrevista_03_03_2025.CQRS.Queries
{
    public class GetCadastroVeiculoByIdQuery
    {
        public int Id { get; set; }

        public static GetCadastroVeiculoByIdQuery NewGetCadastroVeiculoByIdQuery(int id)
        {
            return new GetCadastroVeiculoByIdQuery { Id = id };
        }
    }
}