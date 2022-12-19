using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaultex_DAL.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string OrganisationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual Organisation Organisation { get; set; }
    }
}
