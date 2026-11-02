using EstoreAdminModel.Models.Brands;
using EstoreAdminModel.Services;
using EStoreAdminRepository;

namespace EstoreAdminService
{
    public class BrandService : IBrandService
    {
        private readonly BrandRepository _brandRepository;

        public BrandService(BrandRepository brandRepository)
        {
            this._brandRepository = brandRepository;
        }

        public void CreateBrand(CreateBrandModel createBrandModel)
        {
            if (createBrandModel == null)
            {
                throw new ArgumentNullException(nameof(createBrandModel));
            }

            BrandModel brandModel = new BrandModel
            {
                Id = Guid.NewGuid(),
                Name = createBrandModel.Name
            };

            this._brandRepository.Add(brandModel);
            this._brandRepository.SaveChanges();
        }

        public void DeleteBrand(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                throw new ArgumentException("Invalid brand Id");
            }

            BrandModel? brandModel
                = this._brandRepository.Brands.Where(b => b.Id == Id).FirstOrDefault();

            if (brandModel == null)
                throw new ArgumentException("Brand not found");

            this._brandRepository.Remove(brandModel);
            this._brandRepository.SaveChanges();
        }

        public UpdateBrandModel EditBrand(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                throw new ArgumentException("Invalid brand Id");
            }

            BrandModel? brandModel
                = this._brandRepository.Brands.Where(b => b.Id == Id).FirstOrDefault();

            if (brandModel == null)
                throw new ArgumentException("Brand not found");

            UpdateBrandModel updateBrandModel = new UpdateBrandModel()
            {
                Id = brandModel.Id,
                Name = brandModel.Name
            };

            return updateBrandModel;

        }

        public List<BrandModel> GetAllBrands()
        {
            List<BrandModel> brandModels = 
                this._brandRepository.Brands.ToList();

            return brandModels;

        }

        public void GetBrand()
        {

        }

        public void UpdateBrand(UpdateBrandModel updateBrandModel)
        {
            if (updateBrandModel == null)
            {
                throw new ArgumentNullException(nameof(updateBrandModel));
            }

            BrandModel brandModel
                = new BrandModel()
                {
                    Id = updateBrandModel.Id,
                    Name = updateBrandModel.Name
                };

            this._brandRepository.Update(brandModel);
            this._brandRepository.SaveChanges();
        }
    }
}
