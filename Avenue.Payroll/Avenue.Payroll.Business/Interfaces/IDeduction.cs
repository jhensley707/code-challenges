namespace Avenue.Payroll.Business.Interfaces
{
    /// <summary>
    /// A deduction based on gross pay
    /// </summary>
    public interface IDeduction
    {
        /// <summary>
        /// The name of the deduction
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Amount of the deduction
        /// </summary>
        decimal Amount { get; }

        /// <summary>
        /// Determines the deduction amount for the grossPay
        /// </summary>
        /// <param name="grossPay">Gross pay amount earned</param>
        void CalculateDeduction(decimal grossPay);
    }
}
