using X.Decorator.CQRS.Architecture;

namespace X.Decorator.CQRS.Implementation.Requests
{
    public class ToLowerRequest : IRequest
    {
        public ToLowerRequest(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}
