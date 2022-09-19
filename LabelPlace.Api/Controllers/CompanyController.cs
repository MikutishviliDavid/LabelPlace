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
        private readonly IValidator<CompanyViewModel> _validator;
        private readonly IMapper _mapper;
        private readonly ICompanyService _companyService;

        public CompanyController(IValidator<CompanyViewModel> validator, IMapper mapper, ICompanyService companyService)
        {
            _validator = validator;
            _mapper = mapper;
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyViewModel>>> GetCompaniesAsync()
        {
            var companies = await _companyService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<CompanyViewModel>>(companies));
        }

        [HttpGet("{id:int}")]
        public ActionResult GetCompanyAsync(int id)
        {
            var company = _companyService.Get(id);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CompanyViewModel>(company));
        }

        [HttpPost]
        //[ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(typeof(CompanyViewModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateCompanyAsync(CompanyViewModel company)
        {
            ValidationResult result = await _validator.ValidateAsync(company);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var companyModel = _mapper.Map<CompanyDto>(company);
            await _companyService.InsertAsync(companyModel);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCompany(int id, CompanyViewModel company)
        {
            ValidationResult result = await _validator.ValidateAsync(company);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            company.Id = id;
            var forUpdateCompany = _mapper.Map<CompanyDto>(company);

            if (!_companyService.Update(forUpdateCompany))
            {
                return NotFound(result.Errors);
            }

            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteCompany(int id)
        {
            if (!_companyService.Delete(id))
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
