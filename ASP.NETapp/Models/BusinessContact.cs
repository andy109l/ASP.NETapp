using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NETapp.Models
{
    /// <summary>
    /// model associated with business contact table
    /// </summary>
    public class BusinessContact
    {
        public int BusinessContactId { get; set; }

        public string BusinessFirstName { get; set; }
        public string BusinessLastName { get; set; }
        public string BusinessEmail { get; set; }
        public string BusinessPhoneNumber { get; set; }
        public string BusinessAddressLine1 { get; set; }
        public string BusinessAddressLine2 { get; set; }
        public string BusinessPostcode { get; set; }
        public string BusinessCountry { get; set; }
        public string BusinessCompany { get; set; }

    }
}
