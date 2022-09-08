using FluentValidation;
using FluentValidation.Results;
using LabelPlace.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LabelPlace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IValidator<CompanyViewModel> _validator;

        public CompanyController(IValidator<CompanyViewModel> validator)
        {
            _validator = validator;
        }

        [HttpPost]
        public IActionResult Create(CompanyViewModel project)
        {
            ValidationResult result = _validator.Validate(project);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);

                // re-render the view when validation failed.
                //return View(model);
            }

            //TODO: Save the data to the database, or some other logic.

            return Ok();
        }
    }
}
