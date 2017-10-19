using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHoursLibrary
{
    // The hours class will specify whether the business is closed for a
    // particular day or specify the open and close hours
    public class Hours
    {
        private bool _isOpen;
        private DateTime? _open;
        private DateTime? _close;

        // Empty constructor defaults to Closed
        public Hours() { }

        // Constructor with hours enforcing possible combinations
        public Hours(DateTime? open, DateTime? close)
        {
            if ((!open.HasValue && close.HasValue))
            {
                throw new ArgumentException("Requires opening time");
            }

            if ((open.HasValue && !close.HasValue))
            {
                throw new ArgumentException("Requires closing time");
            }

            if ((open.HasValue && close.HasValue))
            {
                _isOpen = true;
            }

            // This logic needs to be designed better but test that opening is before closing
            // Be careful with Date values included in the DateTime. 
            // We only want to use the Hour:Minute:Second
            if (open.Value.Hour > close.Value.Hour)
            {
                throw new ArgumentException("Can't set closing before opening");
            }

            _open = open;
            _close = close;
        }

        public override string ToString()
        {
            if (_isOpen)
            {
                return string.Format("{0:t}-{1:t}", _open, _close);
            }

            return "Closed";
        }
    }
}
