using System;

namespace X.Decorator.CQRS.Architecture.Decorators
{
    public class LoggerDecorator<TRequest> : IRequestHandler<TRequest>
        where TRequest : IRequest
    {
        private IRequestHandler<TRequest> _innerHandler;

        public LoggerDecorator(IRequestHandler<TRequest> innerHandler)
        {
            _innerHandler = innerHandler;
        }

        public void Handle(TRequest request)
        {
            Console.WriteLine("Logger decorator entry");
            _innerHandler.Handle(request);
            Console.WriteLine("Logger decorator exit");
        }
    }
}
