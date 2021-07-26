/*
 Program: Federal Income Tax Calculator

 Programmer: Alexander Grady

 Description: Class designed for a program that
 calculates federal income tax based on four different schedules.
 Each test method will act as a main function; such that a user 
 would provide input (including income and schedule status). These
 values will then be sent to the CalculateTaxRate.cs class for calculation
 of the tax amount owed.

 Date last modified: 2/12/18

 Updates (2/12/18): 
 - Changed CalculateTaxesDue() to FederalTaxFormula()
 - Changed CheckStatus() to CalculateTaxesDue()
 - Switch case replaced if statements in CalculateTaxesDue()
 - selectScheduleValues() removed 
 - Started to build a form for application

 Todo:
 - Change constructor CalculateTaxRate() to only accept one argument
    -unesscessary for status to be saved by class if never invoked from
     CalculateTaxRate class

 */

using System;

namespace Tax_Rate
{

    public class CalculateTaxRate
    {
        //class variables
        private String status;
        private double incomeAmount;        
        private double taxRate;
        private double amountOver;
        private double addedTaxRate;
        private double taxAmountDue;

        //constructor passing status and income values
        public CalculateTaxRate(String stat, double income)
        {
            this.status = stat;
            this.incomeAmount = income;           
            taxRate = 0;
            amountOver = 0;
            addedTaxRate = 0;
            taxAmountDue = 0;
        }

        /*get method for tax amount due*/
        public double getTaxAmountDue()
        {
            return taxAmountDue;
        }

        //25 lines from refactoring
        /*method to calculate taxes due*/
        public void CalculateTaxesDue(String i)
        {
            switch (i)
            {
                case "single":
                    scheduleX();
                    FederalTaxFormula();
                    break;
                case "mjqw":
                    schedule_Y1();
                    FederalTaxFormula();
                    break;
                case "mfs":
                    schedule_Y2();
                    FederalTaxFormula();
                    break;
                case "hoh":
                    scheduleZ();
                    FederalTaxFormula();
                    break;
            }
        }

        /*tax rate formula*/
        private void FederalTaxFormula()
        {
            taxAmountDue = (taxRate * (incomeAmount - amountOver)) + addedTaxRate;
        } 


        // 31 lines before refactoring
        ///*select schedule then caluclate values*/
        //public void selectScheduleValues()
        //{
        //    CheckStatus();
        //    CalculateTaxesDue();
        //}

        ///*tax rate formula*/
        //private void CalculateTaxesDue()
        //{
        //    taxAmountDue = (taxRate * (incomeAmount - amountOver)) + addedTaxRate;
        //}

        ///*method to determine schedule for user*/
        //private void CheckStatus()
        //{
        //    if (status == "single")
        //    {
        //        //select Schedule X
        //        scheduleX();
        //    }
        //    else if (status == "mjqw")
        //    {
        //        //select Schedule Y-1
        //        schedule_Y1();
        //    }
        //    else if (status == "mfs")
        //    {
        //        //select Schedule Y-2
        //        schedule_Y2();
        //    }
        //    else if (status == "hoh")
        //    {
        //        //select Schedule Z
        //        scheduleZ();
        //    }
        //}

        //Schedule X — Single
        private void scheduleX()
        {
            //MINIMUM
            if (incomeAmount >= 0 && incomeAmount <= 9075)
            {
                taxRate = 0.10;
                //addTaxRate = 0;
                //amountOver = 0;
            }
            //GRADE A
            else if (incomeAmount > 9075 && incomeAmount <= 36900)
            {
                taxRate = 0.15;
                addedTaxRate = 907.50;
                amountOver = 9075;
            }
            //GRADE B
            else if (incomeAmount > 36900 && incomeAmount <= 89350)
            {
                taxRate = 0.25;
                addedTaxRate = 5081.25;
                amountOver = 36900;
            }
            //GRADE C
            else if (incomeAmount > 89350 && incomeAmount <= 186350)
            {
                taxRate = 0.28;
                addedTaxRate = 18193.75;
                amountOver = 89350;
            }
            //GRADE D
            else if (incomeAmount > 186350 && incomeAmount <= 405100)
            {
                taxRate = 0.33;
                addedTaxRate = 45353.75;
                amountOver = 186350;
            }
            //GRADE E
            else if (incomeAmount > 405100 && incomeAmount <= 406750)
            {
                taxRate = 0.35;
                addedTaxRate = 117541.25;
                amountOver = 405100;
            }
            //MAXIMUM
            else if (incomeAmount > 406750)
            {
                taxRate = 0.396;
                addedTaxRate = 118118.75;
                amountOver = 406750;
            }
        }

        //Schedule Y-1 — Married filing Jointly or Qualifying Widow(er) 
        private void schedule_Y1()
        {
            //MINIMUM
            if (incomeAmount >= 0 && incomeAmount <= 18150)
            {
                taxRate = 0.10;
                //addTaxRate = 0;
                //amountOver = 0;
            }
            //GRADE A
            else if (incomeAmount > 18150 && incomeAmount <= 73800)
            {
                taxRate = 0.15;
                addedTaxRate = 1815;
                amountOver = 18150;
            }
            //GRADE B
            else if (incomeAmount > 73800 && incomeAmount <= 148850)
            {
                taxRate = 0.25;
                addedTaxRate = 10162.50;
                amountOver = 73800;
            }
            //GRADE C
            else if (incomeAmount > 148850 && incomeAmount <= 226850)
            {
                taxRate = 0.28;
                addedTaxRate = 28925;
                amountOver = 148850;
            }
            //GRADE D
            else if (incomeAmount > 226850 && incomeAmount <= 405100)
            {
                taxRate = 0.33;
                addedTaxRate = 50765;
                amountOver = 226850;
            }
            //GRADE E
            else if (incomeAmount > 405100 && incomeAmount <= 457600)
            {
                taxRate = 0.35;
                addedTaxRate = 109587.50;
                amountOver = 405100;
            }
            //MAXIMUM
            else if (incomeAmount > 457600)
            {
                taxRate = 0.396;
                addedTaxRate = 127962.50;
                amountOver = 457600;
            }
        }

        //Schedule Y-2 — Married Filing Separately
        private void schedule_Y2()
        {
            //MINIMUM
            if (incomeAmount >= 0 && incomeAmount <= 9075)
            {
                taxRate = 0.10;
                //addTaxRate = 0;
                //amountOver = 0;
            }
            //GRADE A
            else if (incomeAmount > 9075 && incomeAmount <= 36900)
            {
                taxRate = 0.15;
                addedTaxRate = 907.50;
                amountOver = 9075;
            }
            //GRADE B
            else if (incomeAmount > 36900 && incomeAmount <= 74425)
            {
                taxRate = 0.25;
                addedTaxRate = 5081.25;
                amountOver = 36900;
            }
            //GRADE C
            else if (incomeAmount > 74425 && incomeAmount <= 113425)
            {
                taxRate = 0.28;
                addedTaxRate = 14462.50;
                amountOver = 74425;
            }
            //GRADE D
            else if (incomeAmount > 113425 && incomeAmount <= 202550)
            {
                taxRate = 0.33;
                addedTaxRate = 25382.50;
                amountOver = 113425;
            }
            //GRADE E
            else if (incomeAmount > 202550 && incomeAmount <= 228800)
            {
                taxRate = 0.35;
                addedTaxRate = 54793.75;
                amountOver = 202550;
            }
            //MAXIMUM
            else if (incomeAmount > 228800)
            {
                taxRate = 0.396;
                addedTaxRate = 63981.25;
                amountOver = 228800;
            }
        }

        //Schedule Z — Head of Household
        private void scheduleZ()
        {
            //MINIMUM
            if (incomeAmount >= 0 && incomeAmount <= 12950)
            {
                taxRate = 0.10;
                //addTaxRate = 0;
                //amountOver = 0;
            }
            //GRADE A
            else if (incomeAmount > 12950 && incomeAmount <= 49400)
            {
                taxRate = 0.15;
                addedTaxRate = 1295;
                amountOver = 12950;
            }
            //GRADE B
            else if (incomeAmount > 49400 && incomeAmount <= 127550)
            {
                taxRate = 0.25;
                addedTaxRate = 6762.50;
                amountOver = 49400;
            }
            //GRADE C
            else if (incomeAmount > 127550 && incomeAmount <= 206600)
            {
                taxRate = 0.28;
                addedTaxRate = 26300;
                amountOver = 127550;
            }
            //GRADE D
            else if (incomeAmount > 206600 && incomeAmount <= 405100)
            {
                taxRate = 0.33;
                addedTaxRate = 48434;
                amountOver = 206600;
            }
            //GRADE E
            else if (incomeAmount > 405100 && incomeAmount <= 432200)
            {
                taxRate = 0.35;
                addedTaxRate = 113939;
                amountOver = 405100;
            }
            //MAXIMUM
            else if (incomeAmount > 432200)
            {
                taxRate = 0.396;
                addedTaxRate = 123424;
                amountOver = 432200;
            }
        }
    }
}

