namespace STI_Entrevista_03_03_2025.CQRS.Interfaces
{
    public interface ICommandResultHandler<TCommand, TResult>
    {
        Task<TResult> HandleResult(TCommand command);
    }
}