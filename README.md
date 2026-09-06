# Tax Calculator

A collection of simple C# console applications that estimate annual take-home pay for different jurisdictions, based on projected 2026 tax rates and bands.

## Calculators

- **[Tax_Cal_Ireland_2026](Tax_Cal_Ireland_2026/)** — Calculates Irish income tax (single/child carer/married bands), USC, PRSI (for the self-employed), and tax credits.
- **[Tax_Cal_Uk_2026](Tax_Cal_Uk_2026/)** — Calculates UK income tax (including personal allowance taper above £100k) and National Insurance.
- **[Tax_Cal_Monaco_2026](Tax_Cal_Monaco_2026/)** — Reflects Monaco's lack of personal income tax, calculating social security contributions and an optional property tax estimate.

## Usage

Each calculator is a standalone .NET console app. Run one with:

```bash
cd Tax_Cal_Ireland_2026
dotnet run
```

You'll be prompted for your gross annual income and any jurisdiction-specific details (e.g. self-employment status and marital status for Ireland, property value for Monaco), and the app will print a breakdown of deductions and net income.

## Disclaimer

These calculators use simplified, approximate tax rules for illustrative purposes only and should not be relied on for financial or legal advice.
