using System;
using X.Decorator.CQRS.Architecture;
using X.Decorator.CQRS.Implementation.Requests;

namespace X.Decorator.CQRS.Implementation.Handlers
{
    class ToLowerHandler : IRequestHandler<ToLowerRequest>
    {
        public void Handle(ToLowerRequest request)
        {
            var result = request.Value?.ToLower();
            Console.WriteLine(result);
        }
    }
}
