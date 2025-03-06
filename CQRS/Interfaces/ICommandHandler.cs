namespace STI_Entrevista_03_03_2025.CQRS.Interfaces
{
    public interface ICommandHandler<TCommand>
    {
        Task Handle(TCommand command);
    }
}