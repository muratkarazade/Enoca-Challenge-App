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


        /// <summary>
        /// Belirtilen ID'ye sahip ürünü getirir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            if(id == 0) return BadRequest(); 
            var product = await _productService.GetByIdAsync(id);
            if(product == null) return NotFound();
            return Ok(product);
        }

        /// <summary>
        /// Mevcut tüm ürünleri getirir.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var products = await _productService.GetAllAsync();
            if(products == null) return NoContent();
            return Ok(products);
        }


        /// <summary>
        /// Yeni bir ürün ekler.
        /// </summary>
        /// <param name="productDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddProductAsync([FromBody] ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productService.AddAsync(_mapper.Map<Product>(productDto));
            productDto = _mapper.Map<ProductDto>(productDto);
            return StatusCode(201,productDto);
        }
    }
}
