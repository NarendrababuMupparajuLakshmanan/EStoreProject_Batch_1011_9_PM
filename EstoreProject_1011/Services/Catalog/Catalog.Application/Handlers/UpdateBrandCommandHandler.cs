using Catalog.Application.Commands;
using Catalog.Core.DTOs;
using Catalog.Core.Models;
using Catalog.Infrastructure;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class UpdateBrandCommandHandler
        : IRequestHandler<UpdateBrandCommand, BrandDTO>
    {
        private readonly BrandRepository _brandRepository;

        public UpdateBrandCommandHandler(BrandRepository brandRepository)
        {
            this._brandRepository = brandRepository;
        }

        public async Task<BrandDTO> Handle(UpdateBrandCommand request, 
            CancellationToken cancellationToken)
        {
            if (request.BrandDTO != null)
            {
                BrandModel brandModel = new BrandModel()
                {
                    Id = request.BrandDTO.Id,
                    Name = request.BrandDTO.Name
                };

                this._brandRepository.Update(brandModel);
                this._brandRepository.SaveChanges();

            }

            return request.BrandDTO;
        }
    }
}

