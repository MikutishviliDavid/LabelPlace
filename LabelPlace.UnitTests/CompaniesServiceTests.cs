using AutoMapper;
using LabelPlace.BusinessLogic.CustomExceptions;
using LabelPlace.BusinessLogic.Dto.CompanyDtos;
using LabelPlace.BusinessLogic.Profiles;
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

namespace LabelPlace.UnitTests
{
    public class CompaniesServiceTests
    {
        private readonly CompaniesService _service;
        private readonly Mock<IUnitOfWork> _companyRepoMock = new Mock<IUnitOfWork>();
        //private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
        private static IMapper _mapper;

        public CompaniesServiceTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }// it's too complicated, it can be simpler

            _service = new CompaniesService(_mapper, _companyRepoMock.Object);
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnCompanies()
        {
            var companiesDto = GetTestCompanies();

            _companyRepoMock
                .Setup(repo => repo.Companies.GetAllAsync())
                .ReturnsAsync(companiesDto);
            
            var actualCompanies = await _service.GetAllAsync(); 

            actualCompanies.Count().Should().Be(companiesDto.Count);
            actualCompanies.Should().Equal(companiesDto, (c1, c2) => c1.Name == c2.Name);
        }

        [Test]
        public async Task GetAllByCountryAsync_ShouldReturnCompanies()
        {
            var country = "USA";

            var companiesDto = GetTestCompanies();

            _companyRepoMock
                .Setup(repo => repo.Companies.GetAllByCountryAsync(country))
                .ReturnsAsync(companiesDto);

            var actualCompanies = await _service.GetAllByCountryAsync(country);// why count == 3

            actualCompanies.Count().Should().Be(2);
            actualCompanies.Should().Equal(companiesDto, (c1, c2) => c1.Country == c2.Country);
        }

        [Test]
        public async Task GetByIdAsync_ShouldReturnCompany_WhenCompanyExists()
        {
            var companyId = 1;
            var companyName = "Apple";

            var companyDto = new Company
            {
                Id = companyId,
                Name = companyName,
                City = "Los Angeles",
                Country = "USA"
            };

            _companyRepoMock.Setup(repo => repo.Companies.GetByIdAsync(companyId))
                .ReturnsAsync(companyDto);

            var actualCompany = await _service.GetByIdAsync(companyId);

            actualCompany.Id.Should().Be(companyId);
            actualCompany.Name.Should().Be(companyName);
        }

        [Test]
        public void GetByIdAsync_ShouldThrowException_WhenCompanyDoesNotExist()
        {
            _companyRepoMock.Setup(repo => repo.Companies.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            Func<Task> result = async () => await _service.GetByIdAsync(It.IsAny<int>());

            result.Should().Throw<BusinessLogicNotFoundException>();
        }

        [Test]
        public async Task InsertAsync_ShouldReturnCompany_WhenCompanyWasCreated()
        {
            var request = new CreateCompanyDtoRequest
            {
                Name = "BMW",
                Country = "Germany",
                City = "Berlin",
            };

            var expectedCompany = new Company
            {
                Id = 1,
                Name = "BMW",
                Country = "Germany",
                City = "Berlin",
            };

            var expectedCompanyResponse = new CreateCompanyDtoResponse { Id = 1 };

            _companyRepoMock
                 .Setup(repo => repo.Companies.InsertAsync(expectedCompany))
                 .Returns(Task.FromResult(expectedCompanyResponse));

            var result = await _service.InsertAsync(request);

            //result.Id.Should().Be(expectedCompany.Id);
            result.Should().NotBeNull();
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
    }
}
