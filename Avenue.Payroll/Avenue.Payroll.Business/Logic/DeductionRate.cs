namespace Avenue.Payroll.Business.Logic
{
    /// <summary>
    /// Deduction rate specification
    /// </summary>
    public class DeductionRate
    {
        /// <summary>
        /// Constructor to assign universal rate
        /// </summary>
        /// <param name="rate"></param>
        public DeductionRate(decimal rate)
        {
            Rate = rate;
        }

        /// <summary>
        /// Constructor assigning tiered rate and limit
        /// </summary>
        /// <param name="rate"></param>
        /// <param name="limit"></param>
        public DeductionRate(decimal rate, decimal limit)
        {
            Rate = rate;
            Limit = limit;
        }

        /// <summary>
        /// The rate applied to the Gross Pay
        /// </summary>
        public decimal Rate { get; private set; }

        /// <summary>
        /// The limit to which the rate is applied
        /// </summary>
        public decimal? Limit { get; private set; }
    }
}
