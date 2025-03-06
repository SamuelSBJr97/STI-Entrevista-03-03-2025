namespace STI_Entrevista_03_03_2025.CQRS.Commands
{
    public class CreateCadastroVeiculoCommand
    {
        public required string Placa { get; set; }

        public required string Marca { get; set; }

        public required string Modelo { get; set; }

        public required string Cor { get; set; }

        public required string Porte { get; set; }

        public required string TipoDeCarga { get; set; }

        public required string Chassis { get; set; }
    }
}
