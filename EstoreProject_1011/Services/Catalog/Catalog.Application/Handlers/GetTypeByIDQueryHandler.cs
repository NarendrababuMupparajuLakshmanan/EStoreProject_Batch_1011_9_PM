using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Core.DTOs;
using Catalog.Core.Models;
using Catalog.Infrastructure;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetTypeByIDQueryHandler
        : IRequestHandler<GetTypeByIDQuery, TypeDTO>
    {
        private readonly TypeRepository _typeRepository;

        public GetTypeByIDQueryHandler(TypeRepository typeRepository)
        {
            this._typeRepository = typeRepository;
        }

        public async Task<TypeDTO> Handle(GetTypeByIDQuery request, CancellationToken cancellationToken)
        {
            TypeModel? typeModel
                = this._typeRepository.Types
                .Where(x => x.Id == request.Id)
                .FirstOrDefault();

            return typeModel.ToTypeMapper();
        }
    }
}
