using System;
using System.Text;

public class MonacoTaxCalculator
{
    // Monaco does not levy personal income tax on residents
    public static double CalculateIncomeTax(double income)
    {
        return 0; // No personal income tax for residents
    }

    // Social Security Contributions (approximate rates for employees)
    public static double CalculateSocialSecurity(double income)
    {
        // Based on French social security system (Monaco aligns with France)
        double rate = 0.14; // Approximate average rate for health, pension, etc.
        return income * rate;
    }

    // Wealth Tax (Taxe d'habitation / property tax - not income-based)
    public static double CalculatePropertyTax(double propertyValue)
    {
        double rate = 0.005; // Approximate annual rate (0.5%)
        return propertyValue * rate;
    }

    public static void CalculateTotalTax(double grossIncome, double propertyValue = 0)
    {
        Console.OutputEncoding = Encoding.UTF8;

        double incomeTax = CalculateIncomeTax(grossIncome);
        double socialSecurity = CalculateSocialSecurity(grossIncome);
        double propertyTax = CalculatePropertyTax(propertyValue);
        double totalDeductions = incomeTax + socialSecurity + propertyTax;
        double netIncome = grossIncome - totalDeductions;

        Console.WriteLine($"Gross Income: €{grossIncome:F2}");
        Console.WriteLine($"Income Tax: €{incomeTax:F2} (Monaco has no personal income tax)");
        Console.WriteLine($"Social Security Contributions: €{socialSecurity:F2}");
        Console.WriteLine($"Property Tax (if applicable): €{propertyTax:F2}");
        Console.WriteLine($"Total Deductions: €{totalDeductions:F2}");
        Console.WriteLine($"Net Income: €{netIncome:F2}");
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.Write("Enter your gross annual income (€): ");
        double income = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter your property value (€, if known): ");
        double propertyValue = Convert.ToDouble(Console.ReadLine());

        MonacoTaxCalculator.CalculateTotalTax(income, propertyValue);
    }
}