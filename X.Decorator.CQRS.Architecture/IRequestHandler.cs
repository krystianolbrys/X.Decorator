namespace X.Decorator.CQRS.Architecture
{
    public interface IRequestHandler<TRequest>
        where TRequest : IRequest
    {
        void Handle(TRequest request);
    }
}
