using System;

public class UKTaxCalculator
{
    // Income Tax Rates and Bands 2026 (England & Northern Ireland)
    public static double CalculateIncomeTax(double income)
    {
        double tax = 0;
        double personalAllowance = 12570;
        double reducedAllowanceThreshold = 100000;
        double noAllowanceThreshold = 125140;

        if (income > reducedAllowanceThreshold && income <= noAllowanceThreshold)
            personalAllowance -= (income - reducedAllowanceThreshold) / 2;
        else if (income > noAllowanceThreshold)
            personalAllowance = 0;

        double taxableIncome = Math.Max(0, income - personalAllowance);

        if (taxableIncome <= 37700)
            tax = taxableIncome * 0.20;
        else if (taxableIncome <= 125140)
        {
            tax = 37700 * 0.20;
            tax += (taxableIncome - 37700) * 0.40;
        }
        else
        {
            tax = 37700 * 0.20;
            tax += (125140 - 37700) * 0.40;
            tax += (taxableIncome - 125140) * 0.45;
        }

        return tax;
    }

    public static double CalculateNationalInsurance(double income)
    {
        double ni = 0;
        double weeklyIncome = income / 52;

        if (weeklyIncome > 1258)
        {
            if (weeklyIncome <= 2250)
                ni = (weeklyIncome - 1258) * 0.12 * 52;
            else
            {
                ni = (2250 - 1258) * 0.12 * 52;
                ni += (weeklyIncome - 2250) * 0.02 * 52;
            }
        }

        return ni;
    }

    public static void CalculateTotalTax(double grossIncome)
    {
        double incomeTax = CalculateIncomeTax(grossIncome);
        double ni = CalculateNationalInsurance(grossIncome);
        double totalDeductions = incomeTax + ni;
        double netIncome = grossIncome - totalDeductions;

        Console.WriteLine($"Gross Income: £{grossIncome:F2}");
        Console.WriteLine($"Income Tax: £{incomeTax:F2}");
        Console.WriteLine($"National Insurance: £{ni:F2}");
        Console.WriteLine($"Total Deductions: £{totalDeductions:F2}");
        Console.WriteLine($"Net Income: £{netIncome:F2}");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter your gross annual income: ");
        double income = Convert.ToDouble(Console.ReadLine());
        UKTaxCalculator.CalculateTotalTax(income);
    }
}

