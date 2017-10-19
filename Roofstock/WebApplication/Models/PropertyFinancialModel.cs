using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApplication.Models
{
    [DataContract, Serializable]
    public class PropertyFinancialModel
    {
        [DataMember(Name = "listPrice")]
        public decimal ListPrice { get; set; }

        [DataMember(Name = "monthlyRent")]
        public decimal MonthlyRent { get; set; }
    }
}