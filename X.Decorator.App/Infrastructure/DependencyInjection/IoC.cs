using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System.Linq;
using System.Reflection;
using X.Decorator.CQRS.Architecture;
using X.Decorator.CQRS.Architecture.Decorators;

namespace X.Decorator.App.Infrastructure.DependencyInjection
{
    public class IoC
    {
        public static readonly WindsorContainer Container = new WindsorContainer();

        public static void Configure()
        {
            var handlersAssembly = Assembly.Load("X.Decorator.CQRS.Implementation");
            var allTypes = handlersAssembly.GetTypes().Cast<TypeInfo>();

            var handlerTypes =
                    allTypes
                        .Where(t => !t.IsGenericTypeDefinition)
                        .Where(t => t.ImplementedInterfaces.All(i => i.IsGenericType))
                        .Where(t => t.ImplementedInterfaces.Any(i =>
                            i.GetGenericTypeDefinition().Equals(typeof(IRequestHandler<>))))
                        .ToList();

            var decoratorHandlerTypes = 
                    handlerTypes
                        .SelectMany(t => t.ImplementedInterfaces)
                        .ToList();

            Container.Register(
                Component.For(decoratorHandlerTypes)
                .ImplementedBy(typeof(LoggerDecorator<>))
                .LifestyleTransient());

            Container.Register(
                Classes.From(handlerTypes)
                    .BasedOn(typeof(IRequestHandler<>))
                    .WithServiceAllInterfaces()
                    .LifestyleTransient()
                );
        }
    }
}
