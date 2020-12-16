using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NETapp.Models
{
    /// <summary>
    /// /// model associated with personal contact table
    /// </summary>
    public class PersonalContact
    {
        public int PersonalContactId { get; set; }

        public string PersonalFirstName { get; set; }
        public string PersonalLastName { get; set; }
        public string PersonalEmail { get; set; }
        public string PersonalPhoneNumber { get; set; }
        public string PersonalAddressLine1 { get; set; }
        public string PersonalAddressLine2 { get; set; }
        public string PersonalPostcode { get; set; }
        public string PersonalCountry { get; set; }
    }
}
