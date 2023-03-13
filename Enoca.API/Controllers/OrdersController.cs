using AutoMapper;
using Enoca.Core.DTOs;
using Enoca.Core.Models;
using Enoca.Core.Services;
using Enoca.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enoca.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;
        private readonly ICompanyService _companyService;
        private readonly IProductService _productService;

        public OrdersController(IMapper mapper, IOrderService orderService, ICompanyService companyService, IProductService productService)
        {
            _mapper = mapper;
            _orderService = orderService;
            _companyService = companyService;
            _productService = productService;            
        }

        /// <summary>
        /// Belirtilen ID'deki şirketin onay durumu kontrol eder 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>boolean türünde geri döüş yapar</returns>
        [HttpGet("{id}")]
        public async Task<bool> GetCompanyStatusAsync(int id)
        {
            var company = await _companyService.GetByIdAsync(id);
            if (company == null)
            {
                return false;
            }
            var status = company.IsStatus;
            return status;

        }

        /// <summary>
        /// Belirtilen ID'ye sahip ürünü getirir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null) { return NotFound(); }
            return Ok(product);
        }


        /// <summary>
        /// Sipariş oluşturma için gerekli HTTP POST metodu.
        /// </summary>
        /// <param name="orderDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync([FromBody] OrderDto orderDto)
        {
            //Ürün kontrolü yapar.
            var product = await _productService.GetByIdAsync(orderDto.ProductId);
           
            if (product == null)
            {
                return BadRequest("Ürün Bulunamadı!");
            }

            var companyId = orderDto.CompanyId;
            //Firma kontrolü yapar.
            var company = await _companyService.GetByIdAsync(companyId);
            if (company == null)
                return BadRequest("Firma Bulunamadı!");
           
            //Şipariş verilen şirketin onay olduğunun kontrolü.
            var companyStatus = await GetCompanyStatusAsync(companyId);
            if (!companyStatus)
                return BadRequest("Firma Onaylı Değil");

            //Yapılan siparişin uygun saatler içerisinde oluduğunun kontrolü.
            var now = DateTime.Now.TimeOfDay;
            if (now < company.OrderStartTime || now > company.OrderFinishTime)
            {
                return BadRequest("Firma Sipariş Alma Saatleri İçerisinde Değil!");
            }          

            //**  DEĞERLENDİRİLEBİLİR **** {Sipariş sayısı stok miktarı kontrolü!}//            
            var order = new Order
            {                
                ProductId = orderDto.ProductId,
                OrdererName = orderDto.OrdererName,
                CreatedDate = DateTime.UtcNow
            };

            await _orderService.AddAsync(order);
            await _productService.UpdateAsync(product);

            return Ok($"Siparişiniz Başırılı Bir Şekilde Oluşturuldu! \n{company.Name} firmasından {product.Name} ürünü sipariş ettiniz.");
        }
    }
}

