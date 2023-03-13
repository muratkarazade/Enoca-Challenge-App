using AutoMapper;
using Enoca.Core.DTOs;
using Enoca.Core.Models;
using Enoca.Core.Services;
using Enoca.Repository;
using Enoca.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Enoca.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompaniesController : CustomBaseController
    {
        
        private readonly IMapper _mapper;
        private readonly ICompanyService _companyService;

        public CompaniesController(IMapper mapper, ICompanyService companyService)
        {
            
            _mapper = mapper;
            _companyService = companyService;
        }
        /// <summary>
        /// Mevcut tüm şirketleri getirmek için HTTP GET isteği.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCompaniesAsync()
        {            
            var companies = await _companyService.GetAllAsync();
            if (companies == null )
            {
                return NoContent(); // Boş şirket listesi durumunda HTTP 204 Yanıtı döndürür.
            }
            return StatusCode(200,companies);
        }

        /// <summary>
        /// Belirtilen Id değeri ile eşleşen şirketi getirmek için HTTP GET isteği.
        /// </summary>
        /// <param name="id">Şirketin Id'si</param>
        /// <returns>HTTP yanıtı ve istenen şirket verileri</returns>
        [HttpGet("{id}")]        
        public async Task<IActionResult> GetByIdCompanyAsync(int id)
        {
            var company = await _companyService.GetByIdAsync(id);
            return Ok(company);
        }

        /// <summary>
        /// Yeni şirket ekler.
        /// </summary>
        /// <param name="createCompanyDto"></param>
        /// <returns>Status code ve eklenen şirketin bilgileri</returns>
        [HttpPost]
        public async Task<IActionResult> AddCompanyAsync([FromBody] CreateCompanyDto createCompanyDto)
        {
            // Gelen istek için gerekli kontroller yapılır ve hatalı ise BadRequest döndürülür.
            if (createCompanyDto == null && !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            TimeSpan startTime;
            TimeSpan finishTime;

            if (!TimeSpan.TryParse(createCompanyDto.OrderStartTimeString, out startTime))
            {
                return BadRequest("Hatalı Format. ('hh:mm:ss')");
            }

            if (!TimeSpan.TryParse(createCompanyDto.OrderFinishTimeString, out finishTime))
            {
                return BadRequest("Hatalı Format. ('hh:mm:ss')");
            }

            var company = _mapper.Map<Company>(createCompanyDto);

            company.OrderStartTime = startTime;
            company.OrderFinishTime = finishTime;

            // Yeni şirket oluşturulur ve veritabanına ekler.
            await _companyService.AddAsync(company);

            var companyDto = _mapper.Map<CompanyDto>(company);

            return StatusCode(201, companyDto); 
        }


        /// <summary>
        /// Mevcut bir şirketi günceller.
        /// </summary>
        /// <param name="companyDto">Güncellenecek şirket verileri</param>
        /// <returns>Status code ve status açıklaması</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompanyAsync(CompanyDto companyDto)
        {
            if(companyDto == null)
                return NotFound();
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
                
            await _companyService.UpdateAsync(_mapper.Map<Company>(companyDto)); 
            return StatusCode(200,"Başarılı bir şekilde güncellendi.");
        }


        /// <summary>
        /// Mevcut bir şirketi siler.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code ve açıklaması</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCompanyAsync(int id)
        {
            var product = await _companyService.GetByIdAsync(id);
            if(product == null)
                return NotFound(ModelState);
            await _companyService.RemoveAsync(product);
            return StatusCode(200, "Şirket başarıı bir şekilde silindi.");
        }


        /// <summary>
        /// Şirketin Onay durumunu günceller.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="companyStatusUpdateDto"></param>
        /// <returns>Status code ve açıklaması</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIsStatusAsync(int id, [FromBody] CompanyStatusUpdateDto companyStatusUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var company = await _companyService.GetByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }           
            company.IsStatus = companyStatusUpdateDto.IsStatus;
            await _companyService.UpdateAsync(company);
            return StatusCode(200, "Onay durumu güncellendi!");
        }


        /// <summary>
        /// Belirtilen ID'li şirketin onay durumunu getirir.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="companyStatusUpdateDto"></param>
        /// <returns>boolean türünde onay durumu</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyStatusAsync(int id, CompanyStatusUpdateDto companyStatusUpdateDto)
        {
            var company = await _companyService.GetByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            bool status =  company.IsStatus;
            return Ok(status);

        }

        /// <summary>
        /// Belirtilen ID'li şirketin şipariş başlangıç ve bitiş sürelerini günceller.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="orderTimeUpdateDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderTimeAsync(int id, [FromBody] OrderTimeUpdateDto orderTimeUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var company = await _companyService.GetByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            TimeSpan startTime;
            TimeSpan finishTime;
            if (!TimeSpan.TryParse(orderTimeUpdateDto.OrderStartTimeString, out startTime))
            {
                return BadRequest("Hatalı Format. ('hh:mm:ss')");
            }
            if (!TimeSpan.TryParse(orderTimeUpdateDto.OrderFinishTimeString, out finishTime))
            {
                return BadRequest("Hatalı Format. ('hh:mm:ss')");
            }
            company.OrderStartTime = startTime;
            company.OrderFinishTime = finishTime;

            await _companyService.UpdateAsync(company);
            return StatusCode(200, company);

        }


    }
}
