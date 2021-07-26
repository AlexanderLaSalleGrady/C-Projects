
/*Description: Test class for Schedule Y-2*/

using NUnit.Framework;

namespace Tax_Rate
{
    [TestFixture]
    public class Schedule_Y2_TestClass
    {
        /*Schedule Y-2 test with an 
        income using the minimum tax rate*/
        [Test]
        public void Schedule_Y2_Calculation_Minimum()
        {
            //input values
            double income = 9075;
            string status = "mfs";

            //expected output
            double amountDue = 907.50;

            //select schedule and calculate amount due
            CalculateTaxRate calc = new CalculateTaxRate(status, income);
            calc.CalculateTaxesDue(status);

            //determine value of test
            Assert.AreEqual(amountDue, calc.getTaxAmountDue());
        }

        /*Schedule Y-2 test with an income amount of $25000*/
        [Test]
        public void Schedule_Y2_Calculation_GradeA()
        {
            //input values
            double income = 25000;
            string status = "mfs";

            //expected output
            double amountDue = 3296.25;

            //select schedule and calculate amount due
            CalculateTaxRate calc = new CalculateTaxRate(status, income);
            calc.CalculateTaxesDue(status);

            //determine value of test
            Assert.AreEqual(amountDue, calc.getTaxAmountDue());
        }

        /*Schedule Y-2 test with an income amount of $50000*/
        [Test]
        public void Schedule_Y2_Calculation_GradeB()
        {
            //input values
            double income = 50000;
            string status = "mfs";

            //expected output
            double amountDue = 8356.25;

            //select schedule and calculate amount due
            CalculateTaxRate calc = new CalculateTaxRate(status, income);
            calc.CalculateTaxesDue(status);

            //determine value of test
            Assert.AreEqual(amountDue, calc.getTaxAmountDue());
        }

        /*Schedule Y-2 test with an income amount of $100000*/
        [Test]
        public void Schedule_Y2_Calculation_GradeC()
        {
            //input values
            double income = 100000;
            string status = "mfs";

            //expected output
            double amountDue = 21623.5;

            //select schedule and calculate amount due
            CalculateTaxRate calc = new CalculateTaxRate(status, income);
            calc.CalculateTaxesDue(status);

            //determine value of test
            Assert.AreEqual(amountDue, calc.getTaxAmountDue());
        }

        /*Schedule Y-2 test with an income amount of $200000*/
        [Test]
        public void Schedule_Y2_Calculation_GradeD()
        {
            //input values
            double income = 200000;
            string status = "mfs";

            //expected output
            double amountDue = 53952.25;

            //select schedule and calculate amount due
            CalculateTaxRate calc = new CalculateTaxRate(status, income);
            calc.CalculateTaxesDue(status);

            //determine value of test
            Assert.AreEqual(amountDue, calc.getTaxAmountDue());
        }

        /*Schedule Y-2 test with an income amount of $220000*/
        [Test]
        public void Schedule_Y2_Calculation_GradeE()
        {
            //input values
            double income = 220000;
            string status = "mfs";

            //expected output
            double amountDue = 60901.25;

            //select schedule and calculate amount due
            CalculateTaxRate calc = new CalculateTaxRate(status, income);
            calc.CalculateTaxesDue(status);

            //determine value of test
            Assert.AreEqual(amountDue, calc.getTaxAmountDue());
        }

        /*Schedule Y-2 test with an 
        income using the maximum tax rate*/
        [Test]
        public void Schedule_Y2_Calculation_Maximum()
        {
            //input values
            double income = 300000;
            string status = "mfs";

            //expected output
            double amountDue = 92176.45;

            //select schedule and calculate amount due
            CalculateTaxRate calc = new CalculateTaxRate(status, income);
            calc.CalculateTaxesDue(status);

            //determine value of test
            Assert.AreEqual(amountDue, calc.getTaxAmountDue());
        }
    }
}
