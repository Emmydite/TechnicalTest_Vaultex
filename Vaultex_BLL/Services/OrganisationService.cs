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
    public class OrganisationService
    {
        private readonly IRepository<Organisation> _repository;
        public OrganisationService(IRepository<Organisation> repository)
        {
            _repository = repository;
        }

        public async Task<List<OrganisationDTO>> GetOrganisations()
        {
            var getData = await _repository.GetAllAsync();

            return getData.Select(a => new OrganisationDTO
            {
                OrganisationNumber = a.OrganisationNumber,
                OrganisationName = a.OrganisationName,
                AddressLine1 = a.AddressLine1,
                AddressLine2 = a.AddressLine2,
                AddressLine3 = a.AddressLine3,
                AddressLine4 = a.AddressLine4,
                Town = a.Town,
                Postcode = a.Postcode,
            }).ToList();
        }
    }
}
