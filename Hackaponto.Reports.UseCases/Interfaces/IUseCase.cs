namespace Hackaponto.Reports.UseCases.Interfaces
{
    public interface IUseCase { }

    public interface IUseCaseOnlyRequest<TRequest> : IUseCase
    {
        public void Execute(TRequest request);
    }

    public interface IUseCaseOnlyResponse<TResponse> : IUseCase
    {
        public TResponse Execute();
    }

    public interface IUseCase<TRequest, TResponse> : IUseCase
    {
        public TResponse Execute(TRequest request);
    }
}
