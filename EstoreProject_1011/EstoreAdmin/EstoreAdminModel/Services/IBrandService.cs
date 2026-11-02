using EstoreAdminModel.Models.Brands;

namespace EstoreAdminModel.Services
{
    public interface IBrandService
    {
        List<BrandModel> GetAllBrands();

        void DeleteBrand(Guid Id);

        void CreateBrand(CreateBrandModel createBrandModel);

        UpdateBrandModel EditBrand(Guid Id);

        void UpdateBrand(UpdateBrandModel updateBrandModel);

    }
}
