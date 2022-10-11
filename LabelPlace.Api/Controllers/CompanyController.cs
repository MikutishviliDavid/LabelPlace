using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using LabelPlace.Api.ViewModels;
using LabelPlace.BusinessLogic.Dto;
using LabelPlace.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabelPlace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICompanyService _companyService;

        public CompanyController(IMapper mapper, ICompanyService companyService)
        {
            _mapper = mapper;
            _companyService = companyService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<CompanyViewModel>>> GetCompaniesAsync()
        {
            var companies = await _companyService.GetAllAsync();

            return _mapper.Map<List<CompanyViewModel>>(companies); 
        }

        [HttpGet("Country", Name = "GetCompanyByCountry")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<CompanyViewModel>>> GetCompanyByCountryAsync(string country)
        {
            var companies = await _companyService.GetByCountryAsync(country);

            return _mapper.Map<List<CompanyViewModel>>(companies);
        }

        [HttpGet("{id}", Name = "GetCompanyById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CompanyViewModel>> GetCompanyByIdAsync(int id)
        {
            var company = await _companyService.GetByIdAsync(id);

            return _mapper.Map<CompanyViewModel>(company);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CompanyViewModel>> CreateCompanyAsync(CompanyViewModel company)
        {
            var companyDto = _mapper.Map<CompanyDto>(company);

            var createdCompany = await _companyService.InsertAsync(companyDto);

            return CreatedAtAction("GetCompanyById", 
                new {createdCompany.Id}, 
                _mapper.Map<CompanyViewModel>(createdCompany));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCompany(int id, CompanyViewModel company)
        {
            company.Id = id;

            var forUpdateCompany = _mapper.Map<CompanyDto>(company);

            await _companyService.Update(id, forUpdateCompany);
           
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            await _companyService.DeleteAsync(id);
            
            return NoContent();
        }
    }
}
