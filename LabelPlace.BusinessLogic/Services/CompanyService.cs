﻿using LabelPlace.BusinessLogic.Dto;
using LabelPlace.BusinessLogic.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabelPlace.BusinessLogic.Services
{
    public class CompanyService : ICompanyService
    {
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

        public bool Delete(CompanyDto company)
        {
            throw new System.NotImplementedException();
        }  

        public CompanyDto Find(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
