using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Queries.Handlers;
using MediatR;

namespace Application.Decorators
{
    public class EfTransactionDecorator<TRequest> : IRequestHandler<TRequest> where TRequest : IRequest
    {
        private readonly IRequestHandler<TRequest> decoratee;
        private EfHandler efHandler;

        public EfTransactionDecorator(IRequestHandler<TRequest> decoratee,
            EfHandler efHandler)
        {
            this.decoratee = decoratee;
            this.efHandler = efHandler;
        }

        public async Task<Unit> Handle(TRequest request, CancellationToken cancellationToken)
        {
            if (!(decoratee is EfHandler efHandler))
                throw new ArgumentException("Please set up DI such that this decorator is only applied to request handlers implementing IRequireDapperConnection");

            using (var t = efHandler.Context.Database.BeginTransaction())
            {
                try
                {
                    return await decoratee.Handle(request, cancellationToken);
                    await efHandler.Context.SaveChangesAsync(cancellationToken);
                    t.Commit();
                }
                catch (Exception e)
                {
                    t.Rollback();
                    throw;
                }
                
            }
        }
    }
}