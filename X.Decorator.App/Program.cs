using X.Decorator.App.Infrastructure.DependencyInjection;
using X.Decorator.CQRS.Architecture;
using X.Decorator.CQRS.Implementation.Requests;

namespace X.Decorator.App
{
    class Program
    {
        private static readonly string Text = " -> Passeratti";

        static void Main(string[] args)
        {
            IoC.Configure();

            var requestLower = new ToLowerRequest(Text);
            var requestUpper = new ToUpperRequest(Text);

            ExecuteHandler(requestLower);
            ExecuteHandler(requestUpper);
        }

        public static void ExecuteHandler<TRequest>(TRequest request) 
            where TRequest : IRequest
        {
            var handlerType = typeof(IRequestHandler<>).MakeGenericType(request.GetType());
            var handler = IoC.Container.Resolve(handlerType) as IRequestHandler<TRequest>;

            handler.Handle(request);
        }
    }
}
