using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechnicalTest_Vaultex.Models;
using Vaultex_BLL.Services;

namespace TechnicalTest_Vaultex.Controllers
{
    public class HomeController : Controller
    {
        private readonly OrganisationService _organisationService;
        private readonly EmployeeService _employeesService;

        //private readonly ILogger<HomeController> _logger;

        public HomeController(EmployeeService employeesService, OrganisationService organisationService)
        {
            _employeesService = employeesService;
            _organisationService = organisationService;
        }

        public async Task<IActionResult> Index()
        {
            var getEmployees = await _employeesService.GetEmployees();

            return View(getEmployees);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}