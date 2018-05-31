using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.DataAccess;
using Application.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Handlers
{
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
}