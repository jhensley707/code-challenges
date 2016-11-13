using Avenue.Payroll.Business.Interfaces;
using System.Collections.Generic;

namespace Avenue.Payroll.Business.Logic
{
    /// <summary>
    /// The result of the net pay calculation
    /// </summary>
    public class NetPayResponse
    {
        /// <summary>
        /// Location of employee
        /// </summary>
        public string LocationName { get; set; }

        /// <summary>
        /// Total pay of employee
        /// </summary>
        public decimal GrossPay { get; set; }

        /// <summary>
        /// Deductions of employee
        /// </summary>
        public List<Deduction> Deductions { get; set; }

        /// <summary>
        /// Net pay of employee
        /// </summary>
        public decimal NetPay { get; set; }

        /// <summary>
        /// Error message resulting from calculation
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
