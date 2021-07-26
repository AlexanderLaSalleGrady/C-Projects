using System;
using Tax_Rate;

namespace TaxRateCalculator
{
    class ConsoleMenu
    {
        static void Main(string[] args)
        {
            bool x = false;
            double income;
            String status;
         
            while (x == false){
                Console.WriteLine("Welcome to the Federal Tax Rate calculator.");
                Console.WriteLine();
                Console.Write("Enter total income earned: ");
                income = double.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("Please choose the correct code for the schedule necessary for your tax rate" + 
                    "\n" + "needed to perform tax calculations:" + "\n" + "\n" + "Single: single" + "\n" +
                    "\n" + "Married filing Jointly or Qualifying Widow(er)): mjqw" + "\n" + 
                    "\n" + "Married Filing Separately: mfs" + "\n" + "\n" + "Head of Household: hoh" + "\n");
                Console.Write("Enter code: ");

                status = Console.ReadLine();

                Console.WriteLine();
                CalculateTaxRate taxRate = new CalculateTaxRate(status, income);

                //change in updated version
                taxRate.CalculateTaxesDue(status);

                Console.WriteLine("The amount due for your Federal Taxes is: " + 
                    "$" + taxRate.getTaxAmountDue());
                Console.WriteLine();
                Console.WriteLine("Do you wish to continue? (Y/N)");

                if (Console.ReadLine() == "y".ToUpper()){}
                else
                {
                    x = true;
                }

            }
        }
    }
}
