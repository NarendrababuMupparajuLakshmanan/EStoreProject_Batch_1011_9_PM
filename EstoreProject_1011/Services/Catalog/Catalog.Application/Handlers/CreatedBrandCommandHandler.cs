using Catalog.Application.Commands;
using Catalog.Core.Models;
using Catalog.Infrastructure;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class CreatedBrandCommandHandler
        : IRequestHandler<CreatedBrandCommand, Guid>
    {
        private readonly BrandRepository _brandRepository;

        public CreatedBrandCommandHandler(BrandRepository brandRepository)
        {
            this._brandRepository = brandRepository;
        }

        public async Task<Guid> Handle(CreatedBrandCommand request, 
            CancellationToken cancellationToken)
        {
            BrandModel brandModel = new BrandModel()
            {
                Id = Guid.NewGuid(),
                Name = request.CreateBrandDTO.Name
            };

            this._brandRepository.Add(brandModel);
            this._brandRepository.SaveChanges();

            return brandModel.Id;
        }
    }
}
