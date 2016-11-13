namespace Avenue.Payroll.Business.Logic
{
    /// <summary>
    /// Deduction calculation result
    /// </summary>
    public class Deduction
    {
        /// <summary>
        /// The name of the deduction
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Amount of the deduction
        /// </summary>
        public decimal Amount { get; set; }
    }
}
