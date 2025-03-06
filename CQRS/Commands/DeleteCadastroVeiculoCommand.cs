namespace STI_Entrevista_03_03_2025.CQRS.Commands
{
    public class DeleteCadastroVeiculoCommand
    {
        public int Id { get; set; }

        public static DeleteCadastroVeiculoCommand NewDeleteCadastroVeiculoCommand(int id)
        {
            return new DeleteCadastroVeiculoCommand { Id = id };
        }
    }
}
