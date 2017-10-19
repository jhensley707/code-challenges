using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHoursLibrary
{
    public class BusinessHours
    {
        // By default, initial class will be closed all days
        public Hours Monday = new Hours();
        public Hours Tuesday = new Hours();
        public Hours Wednesday = new Hours();
        public Hours Thursday = new Hours();
        public Hours Friday = new Hours();
        public Hours Saturday = new Hours();
        public Hours Sunday = new Hours();
    }
}
