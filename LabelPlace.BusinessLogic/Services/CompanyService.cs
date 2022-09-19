using LabelPlace.BusinessLogic.Dto;
using LabelPlace.BusinessLogic.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabelPlace.BusinessLogic.Services
{
    public class CompanyService : ICompanyService
    {
        public static List<CompanyDto> CompanyModels = new List<CompanyDto>
        {
            new CompanyDto
            {
                Id = 1,   
                Name = "Apple",
                Country = "USA",
                City = "California"
            },
            new CompanyDto
            {
                Id = 2,
                Name = "Microsoft",
                Country = "USA",
                City = "New Youk City"
            }
        };

        public async Task<IEnumerable<CompanyDto>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public CompanyDto Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task InsertAsync(CompanyDto company)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(CompanyDto company)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }  

        public CompanyDto Find(int id)
        {
            return CompanyModels.Find(c => c.Id == id);
        }
    }
}
