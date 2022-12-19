using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaultex_BLL.Models;
using Vaultex_DAL.Entities;
using Vaultex_DAL.Repository;

namespace Vaultex_BLL.Services
{
    public class EmployeeService
    {
        private readonly IRepository<Employee> _repository;
        public EmployeeService(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        public async Task<List<EmployeeDTO>> GetEmployees()
        {
            try
            {
                var getData = await _repository.GetAllAsync();

                return getData.Select(a => new EmployeeDTO
                {
                    OrganisationNumber = a.OrganisationNumber,
                    FirstName = a.FirstName,
                    LastName = a.LastName,

                }).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
