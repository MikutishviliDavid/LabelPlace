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
        //[Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAllAsync()
        {
            var companiesDto = await _companyService.GetAllAsync();

            var companies = _mapper.Map<List<GetCompanyResponse>>(companiesDto);

            return Ok(companies);
        }

        [HttpGet("by-country")]
        //[Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAllByCountryAsync(string country)
        {
            var companiesDto = await _companyService.GetAllByCountryAsync(country);

            var companies = _mapper.Map<List<GetCompanyResponse>>(companiesDto);

            return Ok(companies);
        }

        [HttpGet("{id}", Name = "GetById")]
        //[Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var companyDto = await _companyService.GetByIdAsync(id);

            var commany = _mapper.Map<GetCompanyResponse>(companyDto);

            return Ok(commany);
        }

        [HttpPost]
        //[Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateAsync(CreateCompanyRequest request)
        {
            var companyDto = _mapper.Map<CreateCompanyDtoRequest>(request);

            var createdCompany = await _companyService.InsertAsync(companyDto);

            var response = _mapper.Map<CreateCompanyResponse>(createdCompany);

            return CreatedAtAction("GetById", new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(int id, UpdateCompanyRequest request)
        {
            var CompanyDto = _mapper.Map<UpdateCompanyDto>(request);

            await _companyService.UpdateAsync(id, CompanyDto);
           
            return NoContent();
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _companyService.DeleteAsync(id);
            
            return NoContent();
        }
    }
}
