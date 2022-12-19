using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaultex_DAL.Entities
{
    public class Organisation
    {
        public Organisation()
        {
            Employees = new HashSet<Employee>();
        }

        public string OrganisationNumber{ get; set; }
        public string OrganisationName { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? AddressLine3 { get; set; }
        public string? AddressLine4 { get; set; }
        public string? Town { get; set;}
        public string? Postcode { get; set;}
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
