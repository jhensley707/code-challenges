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
            var irelandDeductions = new List<IDeductionCalculator>
            {
                new DeductionCalculator("Income Tax", new List<DeductionRate>
                    { new DeductionRate(0.25M, 600M), new DeductionRate(0.40M) }),
                new DeductionCalculator("Universal Social Charge", new List<DeductionRate>
                    { new DeductionRate(0.07M, 500), new DeductionRate(0.08M) }),
                new DeductionCalculator("Pension", new List<DeductionRate> { new DeductionRate(0.04M) }),
            };
            var italyDeductions = new List<IDeductionCalculator>
            {
                new DeductionCalculator("Income Tax", new List<DeductionRate> { new DeductionRate(0.25M) }),
                new DeductionCalculator("Social Security", new List<DeductionRate> { new DeductionRate(0.0919M) }),
            };
            var germanyDeductions = new List<IDeductionCalculator>
            {
                new DeductionCalculator("Income Tax", new List<DeductionRate>
                    { new DeductionRate(0.25M, 400M), new DeductionRate(0.32M) }),
                new DeductionCalculator("Pension", new List<DeductionRate> { new DeductionRate(0.02M) }),
            };
            var netPayCalculators = new Dictionary<string, INetPayCalculator>();
            netPayCalculators.Add("Ireland", new NetPayCalculator(grossPayCalculator, irelandDeductions));
            netPayCalculators.Add("Italy", new NetPayCalculator(grossPayCalculator, italyDeductions));
            netPayCalculators.Add("Germany", new NetPayCalculator(grossPayCalculator, germanyDeductions));

            var payRollHandler = new PayRollHandler(netPayCalculators);

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
                var response = payRollHandler.CalculateNetPay(location, hoursWorked, hourlyRate);

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
                    System.Console.WriteLine("{0}: ${1:F2}", deduction.Name, deduction.Amount);
                }
                System.Console.WriteLine("Net amount: ${0:F2}", response.NetPay);
                System.Console.WriteLine();
            }
        }
    }
}
