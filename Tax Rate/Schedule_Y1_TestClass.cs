
/*Description: Test class for Schedule Y-1*/

using NUnit.Framework;

namespace Tax_Rate
{
    [TestFixture]
    public class Schedule_Y1_TestClass
    {        
        /*Schedule Y-1 test with an 
        income using the minimum tax rate*/
        [Test]
        public void Schedule_Y1_Calculation_Minimum()
        {
            //input values
            double income = 18150;
            string status = "mjqw";

            //expected output
            double amountDue = 1815;

            //select schedule and calculate amount due
            CalculateTaxRate calc = new CalculateTaxRate(status, income);
            calc.CalculateTaxesDue(status);

            //determine value of test
            Assert.AreEqual(amountDue, calc.getTaxAmountDue());
        }

        /*Schedule Y-1 test with an income amount of $50000*/
        [Test]
        public void Schedule_Y1_Calculation_GradeA()
        {
            //input values
            double income = 50000;
            string status = "mjqw";

            //expected output
            double amountDue = 6592.50;

            //select schedule and calculate amount due
            CalculateTaxRate calc = new CalculateTaxRate(status, income);
            calc.CalculateTaxesDue(status);

            //determine value of test
            Assert.AreEqual(amountDue, calc.getTaxAmountDue());
        }

        /*Schedule Y-1 test with an income amount of $100000*/
        [Test]
        public void Schedule_Y1_Calculation_GradeB()
        {
            //input values
            double income = 100000;
            string status = "mjqw";

            //expected output
            double amountDue = 16712.50;

            //select schedule and calculate amount due
            CalculateTaxRate calc = new CalculateTaxRate(status, income);
            calc.CalculateTaxesDue(status);

            //determine value of test
            Assert.AreEqual(amountDue, calc.getTaxAmountDue());
        }

        /*Schedule Y-1 test with an income amount of $200000*/
        [Test]
        public void Schedule_Y1_Calculation_GradeC()
        {
            //input values
            double income = 200000;
            string status = "mjqw";

            //expected output
            double amountDue = 43247;

            //select schedule and calculate amount due
            CalculateTaxRate calc = new CalculateTaxRate(status, income);
            calc.CalculateTaxesDue(status);

            //determine value of test
            Assert.AreEqual(amountDue, calc.getTaxAmountDue());
        }

        /*Schedule Y-1 test with an income amount of $300000*/
        [Test]
        public void Schedule_Y1_Calculation_GradeD()
        {
            //input values
            double income = 300000;
            string status = "mjqw";

            //expected output
            double amountDue = 74904.50;

            //select schedule and calculate amount due
            CalculateTaxRate calc = new CalculateTaxRate(status, income);
            calc.CalculateTaxesDue(status);

            //determine value of test
            Assert.AreEqual(amountDue, calc.getTaxAmountDue());
        }

        /*Schedule Y-1 test with an income amount of $450000*/
        [Test]
        public void Schedule_Y1_Calculation_GradeE()
        {
            //input values
            double income = 450000;
            string status = "mjqw";

            //expected output
            double amountDue = 125302.50;

            //select schedule and calculate amount due
            CalculateTaxRate calc = new CalculateTaxRate(status, income);
            calc.CalculateTaxesDue(status);

            //determine value of test
            Assert.AreEqual(amountDue, calc.getTaxAmountDue());
        }

        /*Schedule Y-1 test with an 
        income using the maximum tax rate*/
        [Test]
        public void Schedule_Y1_Calculation_Maximum()
        {
            //input values
            double income = 1000000;
            string status = "mjqw";

            //expected output
            double amountDue = 342752.90;

            //select schedule and calculate amount due
            CalculateTaxRate calc = new CalculateTaxRate(status, income);
            calc.CalculateTaxesDue(status);

            //determine value of test
            Assert.AreEqual(amountDue, calc.getTaxAmountDue());
        }
    }
}


