using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TechnicalTest_Vaultex.Controllers;
using Vaultex_BLL.Models;
using Vaultex_BLL.Services;
using Vaultex_DAL.Entities;
using Vaultex_DAL.Repository;

namespace Vaultex.Test
{
    public class EmployeeUnitTest
    {
        private readonly Mock<IRepository<Employee>> _mockEmpRepo;
        private readonly Mock<IRepository<Organisation>> _mockOrgRepo;

        private readonly OrganisationService _organisationService;
        private readonly EmployeeService _employeesService;
        private readonly HomeController _controller;

        public EmployeeUnitTest()
        {

            _mockEmpRepo = new Mock<IRepository<Employee>>();
            _mockOrgRepo= new Mock<IRepository<Organisation>>();

            _organisationService = new OrganisationService(_mockOrgRepo.Object);
            _employeesService = new EmployeeService(_mockEmpRepo.Object);

            _controller = new HomeController(_employeesService, _organisationService);
        }

        [Fact]
        public async Task Index_ActionExecutes_ReturnsViewForIndex()
        {
            var result = await _controller.Index();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Test_Index_Returns_NumberOfEmployees()
        {
            //Arrange
            _mockEmpRepo.Setup(repo => repo.GetAllAsync())
                 .ReturnsAsync(GetTestEmployees().AsQueryable());

            //Act
            var result = await _controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var employees = Assert.IsType<List<EmployeeDTO>>(viewResult.Model);
            Assert.Equal(3, employees.Count);
        }

        [Fact]
        public async Task CheckIf_Employee_Has_OrganisationNumber()
        {
            //Arrange
            _mockEmpRepo.Setup(repo => repo.GetAllAsync())
              .ReturnsAsync(GetTestEmployees().AsQueryable());

            //Act
            var result = await _controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var returnValue = Assert.IsType<List<EmployeeDTO>>(viewResult.Model);

            var value = returnValue.FirstOrDefault();

            Assert.True(!string.IsNullOrEmpty(value.OrganisationNumber));
        }

        //dummy test records
        private List<Employee> GetTestEmployees()
        {
            var employees = new List<Employee>();

            employees.Add(new Employee()
            {
                Id = 1,
                OrganisationNumber = "09740322",
                FirstName = "Janet",
                LastName = "Smith"
            });
            employees.Add(new Employee()
            {
                Id = 2,
                OrganisationNumber = "09740322",
                FirstName = "Frank",
                LastName = "Bloswick"
            });
            employees.Add(new Employee()
            {
                Id= 3,
                OrganisationNumber = "09740322",
                FirstName = "Tonya",
                LastName = "Bazinaw"
            });

            return employees;
        }
    }
}