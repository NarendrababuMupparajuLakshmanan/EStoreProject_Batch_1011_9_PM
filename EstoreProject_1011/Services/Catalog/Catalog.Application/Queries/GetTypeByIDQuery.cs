using Catalog.Core.DTOs;
using MediatR;

namespace Catalog.Application.Queries
{
    public record GetTypeByIDQuery(Guid Id)
        : IRequest<TypeDTO>
    {
    }
}
