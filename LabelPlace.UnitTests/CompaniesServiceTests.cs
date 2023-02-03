using AutoMapper;
using LabelPlace.BusinessLogic.CustomExceptions;
using LabelPlace.BusinessLogic.Dtos.CompanyDtos;
using LabelPlace.BusinessLogic.Mappings;
using LabelPlace.BusinessLogic.Services;
using LabelPlace.Dal.UnitOfWork;
using LabelPlace.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using FluentAssertions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Collections;
using LabelPlace.BusinessLogic.Services.Interfaces;
using LabelPlace.Api.Controllers;
using LabelPlace.Api.Models.CompanyModels;

namespace LabelPlace.UnitTests
{
    [TestFixture]
    public class CompaniesServiceTests
    {
        private CompanyService _service;
        private Mock<IUnitOfWork> _unitOfWork;
        private static readonly IMapper _mapper =
            new MapperConfiguration(c => c.AddProfile<BusinessLogicMappingProfile>())
            .CreateMapper();

        [SetUp]
        public void Init()
        {
            _unitOfWork = new Mock<IUnitOfWork>();

            _service = new CompanyService(_mapper, _unitOfWork.Object);
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnCompanies()
        {
            var companies = GetTestCompanies();

            _unitOfWork
                .Setup(u => u.Companies.GetAllAsync())
                .ReturnsAsync(companies);
            
            var actualCompanies = await _service.GetAllAsync(); 

            actualCompanies.Count().Should().Be(companies.Count);
            actualCompanies.Should().Equal(companies, (c1, c2) => c1.Name == c2.Name);
        }

        [Test]
        public async Task GetAllByCountryAsync_ShouldReturnCompanies()
        {
            var country = "USA";

            var companies = GetTestCompaniesByCountry();

            _unitOfWork
                .Setup(u => u.Companies.GetAllByCountryAsync(country))
                .ReturnsAsync(companies);

            var actualCompanies = await _service.GetAllByCountryAsync(country);

            actualCompanies.Count().Should().Be(2);
            actualCompanies.Should().Equal(companies, (c1, c2) => c1.Country == c2.Country);
        }

        [Test]
        public async Task GetByIdAsync_ShouldReturnCompany_WhenCompanyExists()
        {
            var companyId = 1;
            var companyName = "Apple";

            var company = new Company
            {
                Id = companyId,
                Name = companyName,
                City = "Los Angeles",
                Country = "USA"
            };

            _unitOfWork.Setup(repo => repo.Companies.GetByIdAsync(companyId))
                .ReturnsAsync(company);

            var actualCompany = await _service.GetByIdAsync(companyId);

            actualCompany.Id.Should().Be(companyId);
            actualCompany.Name.Should().Be(companyName);
        }

        [Test]
        public void GetByIdAsync_ShouldThrowException_WhenCompanyDoesNotExist()
        {
            _unitOfWork.Setup(u => u.Companies.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            Func<Task> result = async () => await _service.GetByIdAsync(It.IsAny<int>());

            result.Should().Throw<BusinessLogicNotFoundException>();
        }

        [Test]
        public async Task InsertAsync_ShouldMakeSureThatCallWasOnce()
        {
            var request = new CreateCompanyDtoRequest
            {
                Name = "BMW",
                Country = "Germany",
                City = "Berlin"
            };

            _unitOfWork.Setup(u => u.Companies.InsertAsync(It.IsAny<Company>()));
            _unitOfWork.Setup(u => u.SaveAsync());

            var result = await _service.InsertAsync(request);

            _unitOfWork.Verify(u => u.Companies.InsertAsync(It.IsAny<Company>()), Times.Once());
            _unitOfWork.Verify(u => u.SaveAsync(), Times.Once());
            result.Should().NotBeNull();
        }

       [Test]
        public async Task UpdateAsync_ShouldMakeSureThatCallWasOnce()
        {
            var request = new UpdateCompanyDtoRequest
            {
                Name = "Mersedes",
                Country = "Germany",
                City = "Berlin"
            };

            var expectedCompany = new Company
            {
                Id = 1,
                Name = "Mersedes",
                Country = "Germany",
                City = "Berlin"
            };

            _unitOfWork.Setup(u => u.Companies.GetByIdAsync(1))
                .ReturnsAsync(expectedCompany);

            _unitOfWork.Setup(u => u.Companies.Update(It.IsAny<Company>()));

            await _service.UpdateAsync(1, request);

            _unitOfWork.Verify(u => u.Companies.Update(It.IsAny<Company>()), Times.Once());
        }

        [Test]
        public async Task DeleteAsync_ShouldMakeSureThatCallWasOnce()
        {
            var expectedCompany = new Company
            {
                Id = 1,
                Name = "Mersedes",
                Country = "Germany",
                City = "Berlin"
            };

            _unitOfWork.Setup(u => u.Companies.GetByIdAsync(1))
                .ReturnsAsync(expectedCompany);

            _unitOfWork.Setup(u => u.Companies.Delete(It.IsAny<Company>()));

            await _service.DeleteAsync(1);

            _unitOfWork.Verify(u => u.Companies.Delete(It.IsAny<Company>()), Times.Once());
        }

        private static List<Company> GetTestCompanies()
        {
            List<Company> companies = new()
            {
                new Company { Id = 1, Name = "Apple", City = "Los Angeles", Country = "USA" },
                new Company { Id = 2, Name = "BelShina", City = "Minsk", Country = "Belarus" },
                new Company { Id = 3, Name = "Microsoft", City = "New York", Country = "USA" }
            };

            return companies;
        }

        private static List<Company> GetTestCompaniesByCountry()
        {
            List<Company> companies = new()
            {
                new Company { Id = 1, Name = "Apple", City = "Los Angeles", Country = "USA" },
                new Company { Id = 3, Name = "Microsoft", City = "New York", Country = "USA" }
            };

            return companies;
        }
    }
}
