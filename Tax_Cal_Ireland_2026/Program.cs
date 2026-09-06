using System;
using System.Text;

public class IrishTaxCalculator
{
    // Tax rates and bands 2026
    public static double CalculateIncomeTax(double income, string status = "single")
    {
        double standardRateBand = status switch
        {
            "single" => 44000,
            "childCarer" => 48000,
            "marriedOneIncome" => 53000,
            "marriedTwoIncomes" => 88000,
            _ => 44000
        };

        double tax = 0;
        if (income <= standardRateBand)
            tax = income * 0.20;
        else
        {
            tax = standardRateBand * 0.20;
            tax += (income - standardRateBand) * 0.40;
        }
        return tax;
    }

    public static double CalculateUSC(double income)
    {
        double usc = 0;
        if (income > 70044)
        {
            usc += (income - 70044) * 0.08;
            income = 70044;
        }
        if (income > 27382)
        {
            usc += (income - 27382) * 0.03;
            income = 27382;
        }
        if (income > 12012)
        {
            usc += (income - 12012) * 0.02;
            income = 12012;
        }
        usc += income * 0.005;
        return usc;
    }

    public static double CalculatePRSI(double income)
    {
        return income * 0.041; // 4.1% for 2026
    }

    public static double ApplyTaxCredits(double tax)
    {
        double totalCredits = 2000; // Personal tax credit
        totalCredits += 2000; // Employee tax credit
        totalCredits += 1000; // Rent tax credit (if eligible)
        // Add other credits as needed
        return Math.Max(0, tax - totalCredits);
    }

    public static void CalculateTotalTax(double grossIncome, bool isSelfEmployed, string status = "single")
    {
        Console.OutputEncoding = Encoding.UTF8;

        double incomeTax = CalculateIncomeTax(grossIncome, status);
        double usc = CalculateUSC(grossIncome);
        double prsi = isSelfEmployed ? CalculatePRSI(grossIncome) : 0;
        double taxAfterCredits = ApplyTaxCredits(incomeTax);

        double totalDeductions = taxAfterCredits + usc + prsi;
        double netIncome = grossIncome - totalDeductions;

        Console.WriteLine($"Gross Income: €{grossIncome:F2}");
        Console.WriteLine($"Income Tax (before credits): €{incomeTax:F2}");
        Console.WriteLine($"Tax Credits: €1,650 + €1,650 + €1,000 = €4,300");
        Console.WriteLine($"Income Tax (after credits): €{taxAfterCredits:F2}");
        Console.WriteLine($"USC: €{usc:F2}");
        if (isSelfEmployed)
            Console.WriteLine($"PRSI: €{prsi:F2}");
        Console.WriteLine($"Total Deductions: €{totalDeductions:F2}");
        Console.WriteLine($"Net Income: €{netIncome:F2}");
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.Write("Enter your gross annual income: ");
        double income = Convert.ToDouble(Console.ReadLine());

        Console.Write("Are you self employed? (yes/no): ");
        bool isSelfEmployed = string.Equals(Console.ReadLine()?.Trim(), "yes", StringComparison.OrdinalIgnoreCase);

        Console.WriteLine("Select your tax status:");
        Console.WriteLine("1. Single");
        Console.WriteLine("2. Single/Widowed Parent (Child Carer)");
        Console.WriteLine("3. Married, one income");
        Console.WriteLine("4. Married, two incomes");
        Console.Write("Enter choice (1-4): ");
        string status = Console.ReadLine()?.Trim() switch
        {
            "2" => "childCarer",
            "3" => "marriedOneIncome",
            "4" => "marriedTwoIncomes",
            _ => "single"
        };

        IrishTaxCalculator.CalculateTotalTax(income, isSelfEmployed, status);
    }
}