using System.Collections.Generic;
using Application.Entities;
using MediatR;

namespace Application.Queries
{
    public class GetActsQuery : IRequest<List<Act>>
    {
        
    }
}