using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Core.DTOs;
using Catalog.Core.Models;
using Catalog.Infrastructure;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetBrandByIDQueryHandler
        : IRequestHandler<GetBrandByIDQuery, BrandDTO>
    {
        private readonly BrandRepository _brandRepository;

        public GetBrandByIDQueryHandler(BrandRepository brandRepository)
        {
            this._brandRepository = brandRepository;
        }

        public async Task<BrandDTO> Handle(GetBrandByIDQuery request, 
            CancellationToken cancellationToken)
        {
            BrandModel? brandModel
                = this._brandRepository.Brands
                        .Where(e => e.Id == request.Id).FirstOrDefault();

            return brandModel.ToBrandMapper();
        }
    }
}

