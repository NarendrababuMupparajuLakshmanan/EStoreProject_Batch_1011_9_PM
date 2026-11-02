using EstoreAdminModel.Models.Brands;
using EstoreAdminModel.Services;
using EstoreAdminService;
using Microsoft.AspNetCore.Mvc;

namespace EStoreAdminModule.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        /// <summary>
        /// Dependency Injection
        /// </summary>
        /// <param name="brandService"></param>
        public BrandController(IBrandService brandService)
        {
            this._brandService = brandService;
        }

        [HttpGet]
        [Route("ListBrand")]
        public ActionResult Index()
        {
            

            List<BrandModel> brandModels
                = this._brandService.GetAllBrands();

            return View(brandModels);
        }

        [HttpGet]
        [Route("DeleteBrand/{Id:guid}")]
        public ActionResult DeleteBrand(Guid Id)
        {
            this._brandService.DeleteBrand(Id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("CreateBrand")]
        public ActionResult CreateBrand()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateBrand")]
        public ActionResult CreateBrand(CreateBrandModel createBrandModel)
        {
            this._brandService.CreateBrand(createBrandModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("EditBrand/{Id:guid}")]
        public ActionResult EditBrand(Guid Id)
        {

            UpdateBrandModel updateBrandModel
                                = this._brandService.EditBrand(Id);

            return View(updateBrandModel);
        }

        [HttpPost]
        [Route("EditBrand/{Id:guid}")]
        public ActionResult EditBrand(UpdateBrandModel updateBrandModel, Guid Id)
        {
            this._brandService.UpdateBrand(updateBrandModel);
            return RedirectToAction("Index");
        }
    }
}
