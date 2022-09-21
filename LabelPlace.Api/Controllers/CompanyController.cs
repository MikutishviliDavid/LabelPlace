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
        public async Task<ActionResult<IEnumerable<CompanyViewModel>>> GetCompaniesAsync()
        {
            var companies = await _companyService.GetAllAsync();

            return _mapper.Map<IEnumerable<CompanyViewModel>>(companies).ToList(); // ?
        }

        [HttpGet("{id}", Name = "GetCompany")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CompanyViewModel>> GetCompanyAsync(int id)
        {
            var company = await _companyService.GetAsync(id);

            return _mapper.Map<CompanyViewModel>(company); // company ?
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CompanyViewModel>> CreateCompanyAsync(CompanyViewModel company)
        {
            var companyDto = _mapper.Map<CompanyDto>(company);

            var createdCompany = await _companyService.InsertAsync(companyDto);

            return CreatedAtAction("GetCompany", 
                new {createdCompany.Id}, 
                _mapper.Map<CompanyViewModel>(createdCompany));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateCompany(int id, CompanyViewModel company)
        {
            company.Id = id;

            var forUpdateCompany = _mapper.Map<CompanyDto>(company);

            _companyService.Update(forUpdateCompany);
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteCompany(int id)
        {
            _companyService.Delete(id);

            return NoContent();
        }
    }
}
