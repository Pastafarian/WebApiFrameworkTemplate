using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Application.Entities;
using MediatR;
using MediatR.Pipeline;
using SimpleInjector;

namespace Api.IoC.Registrations
{
    public static class MediatRRegistration
    {
        public static void Register(Container container)
        {
            var assemblies = GetAssemblies().ToArray();

            container.RegisterSingleton<IMediator, Mediator>();
            container.Register(typeof(IRequestHandler<,>), assemblies);
            
            var notificationHandlerTypes = container.GetTypesToRegister(typeof(INotificationHandler<>), assemblies, new TypesToRegisterOptions
            {
                IncludeGenericTypeDefinitions = true,
                IncludeComposites = false,
            });

            container.Collection.Register(typeof(INotificationHandler<>), notificationHandlerTypes);
            container.Collection.Register(typeof(IPipelineBehavior<,>), new[]
            {
                typeof(RequestPreProcessorBehavior<,>),
                typeof(RequestPostProcessorBehavior<,>),
            });

            container.RegisterInstance(new ServiceFactory(container.GetInstance));
            container.RegisterSingleton<IMediator, Mediator>();
            container.Register(typeof(IRequestHandler<,>), assemblies);
            container.Register(typeof(IRequestHandler<>), assemblies);
            container.Collection.Register(typeof(INotificationHandler<>), assemblies);
            container.RegisterInstance(Console.Out);
        }

        private static IEnumerable<Assembly> GetAssemblies()
        {
            yield return typeof(IMediator).Assembly;
            yield return typeof(Act).Assembly;
        }
    }
}