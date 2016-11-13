using Avenue.Payroll.Business.Interfaces;
using Avenue.Payroll.Business.Logic;
using System.Collections.Generic;

namespace Avenue.Payroll.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var grossPayCalculator = new GrossPayCalculator();
            var irelandDeductions = new List<IDeduction>
            {
                new IrelandIncomeTaxDeduction(),
                new IrelandUniversalSocialChargeDeduction(),
                new IrelandPensionDeduction()
            };
            var italyDeductions = new List<IDeduction>
            {
                new ItalyIncomeTaxDeduction(),
                new ItalySocialSecurityDeduction()
            };
            var germanyDeductions = new List<IDeduction>
            {
                new GermanyIncomeTaxDeduction(),
                new GermanyPensionDeduction()
            };
            var irelandHandler = new PayRollHandler("Ireland", new NetPayCalculator(grossPayCalculator, irelandDeductions));
            var italyHandler = new PayRollHandler("Italy", new NetPayCalculator(grossPayCalculator, italyDeductions));
            var germanyHandler = new PayRollHandler("Germany", new NetPayCalculator(grossPayCalculator, germanyDeductions));

            irelandHandler.RegisterNext(italyHandler);
            italyHandler.RegisterNext(germanyHandler);

            decimal hoursWorked;
            decimal hourlyRate;

            while (ConsoleInput.TryReadDecimal("Please enter the hours worked: ", out hoursWorked))
            {
                if (!ConsoleInput.TryReadDecimal("Please enter the hourly rate: ", out hourlyRate))
                {
                    break;
                }

                System.Console.WriteLine("Please enter the employee's location: ");
                var location = System.Console.ReadLine();

                if (string.IsNullOrEmpty(location))
                {
                    break;
                }

                // Calculate the Net pay
                var response = irelandHandler.CalculateNetPay(location, hoursWorked, hourlyRate);

                if (response == null)
                {
                    System.Console.WriteLine("No response calculated");
                    continue;
                }

                if (response.ErrorMessage != null)
                {
                    System.Console.WriteLine(response.ErrorMessage);
                    continue;
                }

                System.Console.WriteLine();
                System.Console.WriteLine("Employee location: {0}", response.LocationName);
                System.Console.WriteLine();
                System.Console.WriteLine("Gross amount: ${0:F2}", response.GrossPay);
                System.Console.WriteLine();
                System.Console.WriteLine("Less deductions");
                System.Console.WriteLine();
                foreach (var deduction in response.Deductions)
                {
                    System.Console.WriteLine("Deduction Name: ${0:F2}", deduction.Amount);
                }
                System.Console.WriteLine("Net amount: ${0:F2}", response.NetPay);
                System.Console.WriteLine();
            }
        }
    }
}
