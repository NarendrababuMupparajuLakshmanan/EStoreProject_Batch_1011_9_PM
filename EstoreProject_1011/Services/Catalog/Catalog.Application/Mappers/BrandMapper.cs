using Catalog.Core.DTOs;
using Catalog.Core.Models;

namespace Catalog.Application.Mappers
{
    public static class BrandMapper
    {

        public static List<BrandDTO> ToBrandMappers
            (this List<BrandModel> brandModels)
        {

            List<BrandDTO> brandDTOs = null;

            //Check your Object is null or not
            if (brandModels != null)
            {
                //it will create object for DTO
                brandDTOs = new List<BrandDTO>();
                foreach (BrandModel brandModel in brandModels)
                {
                    brandDTOs.Add(brandModel.ToBrandMapper());
                }
            }

            //it will return BrandDTO as an output
            return brandDTOs;
        }

        public static BrandDTO ToBrandMapper
            (this BrandModel brandModel)
        {
            BrandDTO brandDTO = null;

            if (brandModel != null)
            {
                brandDTO = new BrandDTO(
                    brandModel.Id,
                    brandModel.Name);
            }

            return brandDTO;
        }
    }
}
