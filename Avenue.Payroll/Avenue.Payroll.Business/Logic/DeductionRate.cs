namespace Avenue.Payroll.Business.Logic
{
    /// <summary>
    /// Deduction rate specification
    /// </summary>
    public class DeductionRate
    {
        /// <summary>
        /// The rate applied to the Gross Pay
        /// </summary>
        public decimal? Rate { get; set; }

        /// <summary>
        /// The limit to which the rate is applied
        /// </summary>
        public decimal? Limit { get; set; }
    }
}
