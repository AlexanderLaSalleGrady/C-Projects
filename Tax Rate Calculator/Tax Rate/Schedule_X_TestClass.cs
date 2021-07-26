
/*
 * 
 * Description: Test class for Schedule X
 * 
 * Update: 
 * calc.selectScheduleValues() changed to calc.CalculateTaxesDue(status);
 *
 */


using NUnit.Framework;

namespace Tax_Rate
{
    [TestFixture]
    public class Schedule_X_TestClass
    {
        /*Schedule X test with an 
        income using the minimum tax rate*/
        [Test]
        public void Schedule_X_Calculation_Minimum()
        {
            //input values
            double income = 5000;
            string status = "single";

            //expected output
            double amountDue = 500;

            //select schedule and calculate amount due
            CalculateTaxRate calc = new CalculateTaxRate(status, income);
            calc.CalculateTaxesDue(status);

            //determine value of test
            Assert.AreEqual(amountDue, calc.getTaxAmountDue());
        }

        /*Schedule X test with an income amount of $18,000*/
        [Test]
        public void Schedule_X_Calculation_GradeA()
        {
            //input values
            double income = 18000;
            string status = "single";

            //expected output
            double amountDue = 2246.25;

            //select schedule and calculate amount due
            CalculateTaxRate calc = new CalculateTaxRate(status, income);
            calc.CalculateTaxesDue(status);

            //determine value of test
            Assert.AreEqual(amountDue, calc.getTaxAmountDue());
        }

        /*Schedule X test with an income amount of $80,000*/
        [Test]
        public void Schedule_X_Calculation_GradeB()
        {
            //input values
            double income = 80000;
            string status = "single";

            //expected output
            double amountDue = 15856.25;

            //select schedule and calculate amount due
            CalculateTaxRate calc = new CalculateTaxRate(status, income);
            calc.CalculateTaxesDue(status);

            //determine value of test
            Assert.AreEqual(amountDue, calc.getTaxAmountDue());
        }

        /*Schedule X test with an income amount of $180,000*/
        [Test]
        public void Schedule_X_Calculation_GradeC()
        {
            //input values
            double income = 180000;
            string status = "single";

            //expected output
            double amountDue = 43575.75;

            //select schedule and calculate amount due
            CalculateTaxRate calc = new CalculateTaxRate(status, income);
            calc.CalculateTaxesDue(status);

            //determine value of test
            Assert.AreEqual(amountDue, calc.getTaxAmountDue());
        }

        /*Schedule X test with an income amount of $280,000*/
        [Test]
        public void Schedule_X_Calculation_GradeD()
        {
            //input values
            double income = 280000;
            string status = "single";

            //expected output
            double amountDue = 76258.25;

            //select schedule and calculate amount due
            CalculateTaxRate calc = new CalculateTaxRate(status, income);
            calc.CalculateTaxesDue(status);

            //determine value of test
            Assert.AreEqual(amountDue, calc.getTaxAmountDue());
        }

        /*Schedule X test with an income amount of $406,000*/
        [Test]
        public void Schedule_X_Calculation_GradeE()
        {
            //input values
            double income = 406000;
            string status = "single";

            //expected output
            double amountDue = 117856.25;

            //select schedule and calculate amount due
            CalculateTaxRate calc = new CalculateTaxRate(status, income);
            calc.CalculateTaxesDue(status);

            //determine value of test
            Assert.AreEqual(amountDue, calc.getTaxAmountDue());
        }

        /*Schedule X test with an 
        income using the maximum tax rate*/
        [Test]
        public void Schedule_X_Calculation_Maximum()
        {
            //input values
            double income = 300000000;
            string status = "single";

            //expected output
            double amountDue = 118757045.75;

            //select schedule and calculate amount due
            CalculateTaxRate calc = new CalculateTaxRate(status, income);
            calc.CalculateTaxesDue(status);

            //determine value of test
            Assert.AreEqual(amountDue, calc.getTaxAmountDue());
        }
    }
}
