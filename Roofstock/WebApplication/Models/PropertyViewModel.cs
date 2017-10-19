using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApplication.Models
{
    [DataContract, Serializable]
    public class PropertyViewModel
    {
        public string Address { get; set; }

        public string YearBuilt { get; set; }

        public decimal ListPrice { get; set; }

        public decimal MonthlyRent { get; set; }

        public decimal GrossYield
        {
            get { return (ListPrice > 0) ? (MonthlyRent * 12 / ListPrice) : 0M; }
        }
    }
}