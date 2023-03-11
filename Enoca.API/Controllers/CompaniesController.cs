using AutoMapper;
using Enoca.Core.DTOs;
using Enoca.Core.Models;
using Enoca.Core.Services;
using Enoca.Repository;
using Enoca.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enoca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : CustomBaseController
    {
        private readonly ICompanyService _companySevice;
        private readonly IMapper _mapper;

        public CompaniesController(ICompanyService companySevice, IMapper mapper)
        {
            _companySevice = companySevice;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var companies = await _companySevice.GetAllAsync();
            return Ok(companies);
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var company = await _companySevice.GetByIdAsync(id);
            return Ok(company);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddAsync([FromBody]Company company)
        {
            // Burada, CompanyService sınıfından bir örnek alınarak _companyService değişkeni oluşturulabilir.

            //if (companyDto == null)
            //{
            //    return BadRequest("Company cannot be null");
            //}

            var mapperConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<CompanyDto, Company>();
                cfg.CreateMap<Company, CompanyDto>();
            });
            IMapper mapper = mapperConfig.CreateMapper(); // Burada, AutoMapper kütüphanesi ile bir IMapper örneği oluşturulur.

            //var company = await _companySevice.AddAsync(mapper.Map<Company>(companyDto));
            //var companyDtoResult = mapper.Map<CompanyDto>(company);
            //return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, companyDtoResult));

            //var company = _mapper.Map<Company>(companyDto);
            //await _companySevice.AddAsync(company);

            var company = _mapper.Map<Company>(CompanyDto);
            await _companyRepository.AddAsync(company);

            return Ok();
        }



        [HttpPut]
        public async Task<IActionResult> Update(CompanyStatusUpdateDto companyDto)
        {
            await _companySevice.UpdateAsync(_mapper.Map<Company>(companyDto)); 
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _companySevice.GetByIdAsync(id);
            await _companySevice.RemoveAsync(product);
            return Ok(true);
        }
    }
}
