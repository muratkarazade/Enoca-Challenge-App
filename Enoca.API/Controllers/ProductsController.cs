using AutoMapper;
using Enoca.Core.DTOs;
using Enoca.Core.Models;
using Enoca.Core.Repositories;
using Enoca.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enoca.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : CustomBaseController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController( IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }


        [HttpPost]
        public async Task<IActionResult> AddProductAsync([FromBody] ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productService.AddAsync(_mapper.Map<Product>(productDto));
            productDto = _mapper.Map<ProductDto>(productDto);
            return Ok(productDto);
        }
    }
}
