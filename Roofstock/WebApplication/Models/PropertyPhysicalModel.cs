using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApplication.Models
{
    [DataContract, Serializable]
    public class PropertyPhysicalModel
    {
        [DataMember(Name ="yearBuilt")]
        public string YearBuilt { get; set; }
    }
}