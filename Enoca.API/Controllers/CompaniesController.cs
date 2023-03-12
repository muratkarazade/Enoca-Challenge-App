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

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var companies = await _companyService.GetAllAsync();
            return Ok(companies);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCompanyAsync(int id)
        {
            var company = await _companyService.GetByIdAsync(id);
            return Ok(company);
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateCompanyDto createCompanyDto)
        {
            if (createCompanyDto == null)
            {
                return BadRequest("Company cannot be null");
            }

            if (!ModelState.IsValid)
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

            await _companyService.AddAsync(company);

            var companyDto = _mapper.Map<CompanyDto>(company);

            return Ok(companyDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CompanyDto companyDto)
        {
            await _companyService.UpdateAsync(_mapper.Map<Company>(companyDto)); 
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _companyService.GetByIdAsync(id);
            await _companyService.RemoveAsync(product);
            return Ok(true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIsStatusAsync(int id, [FromBody] CompanyStatusUpdateDto companyStatusUpdateDto)
        {
            var company = await _companyService.GetByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }
           
            company.IsStatus = companyStatusUpdateDto.IsStatus;
            await _companyService.UpdateAsync(company);
            return Ok();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyStatusAsync(int id, CompanyStatusUpdateDto companyStatusUpdateDto)
        {
            var company = await _companyService.GetByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            bool result =  company.IsStatus;
            return Ok(result);

        }


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
            return Ok();

        }


    }
}
