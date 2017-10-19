using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApplication.Models
{
    [DataContract, Serializable]
    public class PropertyModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "address")]
        public PropertyAddressModel Address { get; set; }

        [DataMember(Name = "financial")]
        public PropertyFinancialModel Financial { get; set; }

        [DataMember(Name = "physical")]
        public PropertyPhysicalModel Physical { get; set; }
    }
}