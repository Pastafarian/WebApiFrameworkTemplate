using MediatR;
using SimpleInjector;

namespace Api.IoC.Registrations
{
    public static class DecoratorRegistration
    {
        public static void Register(Container container)
        {
            container.RegisterDecorator(
                typeof(IRequestHandler<,>),
                typeof(RequireDapperConnectionAsyncRequestHandlerDecorator<,>),
                context => typeof(IRequireDapperConnection).IsAssignableFrom(context.ImplementationType));
        }
    }
}
/*
     public class GetActsQueryHandler : EfHandler, IRequestHandler<GetActsQuery, List<Act>>
    {
        public GetActsQueryHandler(DataContext context)
        {
            Context = context;
        }

        public async Task<List<Act>> Handle(GetActsQuery request, CancellationToken cancellationToken)
        {
            return await Context.Acts.ToListAsync(cancellationToken);
        }
    }

    public abstract class EfHandler
    {
        protected DataContext Context;
    }
 */
