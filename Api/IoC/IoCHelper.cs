using Api.IoC.Registrations;
using SimpleInjector;

namespace Api.IoC
{
    public static class IoCHelper
    {
        public static void RegisterDependencies(Container container)
        {
            MediatRRegistration.Register(container);
        }
    }
}