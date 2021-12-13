using Microsoft.AspNetCore.Mvc;
using WebUI.ApiServices;
using WebUI.Dtos;
using WebUI.Filters;

namespace WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoryApiService _categoryApiService;

        public CategoriesController(CategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }

        public async Task<IActionResult> Index()
        {
            var categoriesDto = await _categoryApiService.GetAllAsync();
            return View(categoriesDto);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            await _categoryApiService.AddAsync(categoryDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var categoryDto = await _categoryApiService.GetByIdAsync(id);
            return View(categoryDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            await _categoryApiService.UpdateAsync(categoryDto);
            return RedirectToAction("Index");
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryApiService.RemoveAsync(id);
            return RedirectToAction("Index");
        }
    }
}
