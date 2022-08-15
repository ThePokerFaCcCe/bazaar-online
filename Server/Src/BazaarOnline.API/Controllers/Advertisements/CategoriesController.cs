using BazaarOnline.Application.DTOs.CategoryDTOs;
using BazaarOnline.Application.Interfaces.Categories;
using BazaarOnline.Application.Securities.Attributes;
using BazaarOnline.Application.ViewModels.Categories;
using BazaarOnline.Application.ViewModels.Features;
using BazaarOnline.Infra.Data.Seeds.DefaultDatas;
using Microsoft.AspNetCore.Mvc;

namespace BazaarOnline.API.Controllers.Advertisements
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<List<CategoryListDetailViewModel>> GetCategoryList()
        {
            return Ok(_categoryService.GetCategoryListDetails());
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryDetailViewModel> GetCategoryDetail(int id)
        {
            var category = _categoryService.GetCategoryDetail(id);
            if (category == null) return NotFound();

            return Ok(category);
        }

        [HttpGet("{id}/Children")]
        public ActionResult<List<CategoryListDetailViewModel>> GetCategoryChildren(int id)
        {
            if (_categoryService.FindCategory(id) == null) return NotFound();

            return Ok(_categoryService.GetCategoryChildrenDetail(id));
        }

        [HttpPost]
        [HasPermission(DefaultPermissions.CreateCategoryId)]
        public ActionResult CreateCategory(CategoryCreateDTO createDTO)
        {
            if (!ModelState.IsValid) return BadRequest(createDTO);

            var result = _categoryService.CreateCategory(createDTO);
            return CreatedAtAction(nameof(GetCategoryDetail), new { Id = result.Id }, null);
        }


        [HttpPut("{id}")]
        [HasPermission(DefaultPermissions.UpdateCategoryId)]
        public ActionResult UpdateCategory(int id, [FromBody] CategoryUpdateDTO updateDTO)
        {
            if (!ModelState.IsValid) return BadRequest(updateDTO);

            var category = _categoryService.FindCategory(id);
            if (category == null) return NotFound();

            _categoryService.UpdateCategory(category, updateDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        [HasPermission(DefaultPermissions.DeleteCategoryId)]
        public ActionResult DeleteCategory(int id)
        {
            var category = _categoryService.FindCategory(id);
            if (category == null) return NotFound();

            _categoryService.DeleteCategory(category);
            return NoContent();
        }

        [HttpPut("{id}/Features")]
        [HasPermission(DefaultPermissions.UpdateCategoryId)]
        public ActionResult AddCategoryFeatures(int id, [FromBody] CategoryFeatureAddDTO addDTO)
        {
            var category = _categoryService.FindCategory(id);
            if (category == null) return NotFound();

            if (!ModelState.IsValid) return BadRequest(addDTO);

            _categoryService.UpdateCategoryFeatures(category, addDTO);
            return Ok();
        }

        [HttpGet("{id}/Features")]
        public ActionResult<List<FeatureDetailViewModel>> GetCategoryFeatures(int id)
        {
            var category = _categoryService.FindCategory(id);
            if (category == null) return NotFound();

            return Ok(_categoryService.GetCategoryFeatureDetails(category));
        }

        [HttpGet("{id}/Features/Hierarchy")]
        public ActionResult<List<FeatureDetailViewModel>> GetCategoryFeaturesHierarchy(int id)
        {
            var category = _categoryService.FindCategory(id);
            if (category == null) return NotFound();

            return Ok(_categoryService.GetCategoryFeatureDetailsHierarchy(category));
        }

    }
}
