using X.Decorator.CQRS.Architecture;

namespace X.Decorator.CQRS.Implementation.Requests
{
    public class ToUpperRequest : IRequest
    {
        public ToUpperRequest(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}
