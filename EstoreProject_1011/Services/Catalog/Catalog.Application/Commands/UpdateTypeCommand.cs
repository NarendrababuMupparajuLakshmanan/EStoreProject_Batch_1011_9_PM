using Catalog.Core.DTOs;
using MediatR;

namespace Catalog.Application.Commands
{
    public record UpdateTypeCommand(TypeDTO TypeDTO)
        : IRequest<bool>
    {
    }
}
