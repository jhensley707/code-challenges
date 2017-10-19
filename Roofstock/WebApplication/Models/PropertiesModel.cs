using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApplication.Models
{
    [DataContract, Serializable]
    public class PropertiesModel
    {
        [DataMember(Name = "properties")]
        public IEnumerable<PropertyModel> Properties { get; set; }
    }
}