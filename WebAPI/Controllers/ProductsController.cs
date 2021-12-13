using AutoMapper;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;
using WebAPI.Filters;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(result));
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilter))]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productService.GetById(id);
            return Ok(_mapper.Map<ProductDto>(result));
        }

        [HttpGet("{id}/category")]
        [ServiceFilter(typeof(NotFoundFilter))]
        public async Task<IActionResult> GetWithCategoryById(int id)
        {
            var result = await _productService.GetWithCategoryByIdAsync(id);
            return Ok(_mapper.Map<ProductWithCategoryDto>(result));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var result = await _productService.AddAsync(_mapper.Map<Product>(productDto));
            return Created(string.Empty, _mapper.Map<ProductDto>(result));
        }

        [HttpPut]
        public IActionResult Update(ProductDto productDto)
        {
            _productService.Update(_mapper.Map<Product>(productDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilter))]
        public IActionResult Remove(int id)
        {
            var product = _productService.GetById(id).Result;
            _productService.Remove(product);

            return NoContent();
        }
    }
}
