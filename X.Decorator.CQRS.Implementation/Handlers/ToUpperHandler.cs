using System;
using X.Decorator.CQRS.Architecture;
using X.Decorator.CQRS.Implementation.Requests;

namespace X.Decorator.CQRS.Implementation.Handlers
{
    public class ToUpperHandler : IRequestHandler<ToUpperRequest>
    {
        public void Handle(ToUpperRequest request)
        {
            var result = request.Value?.ToUpper();
            Console.WriteLine(result);
        }
    }
}
