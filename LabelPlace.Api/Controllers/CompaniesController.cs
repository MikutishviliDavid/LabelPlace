using AutoMapper;
using LabelPlace.Api.ViewModels.CompanyViewModels;
using LabelPlace.BusinessLogic.Dto.CompanyDtos;
using LabelPlace.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabelPlace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICompanyService _companyService;

        public CompaniesController(IMapper mapper, ICompanyService companyService)
        {
            _mapper = mapper;
            _companyService = companyService;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var companiesDto = await _companyService.GetAllAsync();

            var companies = _mapper.Map<List<GetCompanyResponse>>(companiesDto);

            return Ok(companies);
        }

        [HttpGet("by-country")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllByCountryAsync(string country)
        {
            var companiesDto = await _companyService.GetAllByCountryAsync(country);

            var companies = _mapper.Map<List<GetCompanyResponse>>(companiesDto);

            return Ok(companies);
        }

        [HttpGet("by-id", Name = "GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var companyDto = await _companyService.GetByIdAsync(id);

            var commany = _mapper.Map<GetCompanyResponse>(companyDto);

            return Ok(commany);
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(CreateCompanyRequest request)
        {
            var companyDto = _mapper.Map<CreateCompanyDtoRequest>(request);

            var createdCompany = await _companyService.InsertAsync(companyDto);

            return CreatedAtAction("GetById",
                new {createdCompany.Id}, 
                _mapper.Map<CreateCompanyResponse>(createdCompany));
        }

        [HttpPut("by-id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(int id, UpdateCompanyRequest request)
        {
            request.Id = id;

            var forUpdateCompany = _mapper.Map<UpdateCompanyDto>(request);

            await _companyService.UpdateAsync(id, forUpdateCompany);
           
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _companyService.DeleteAsync(id);
            
            return NoContent();
        }
    }
}
