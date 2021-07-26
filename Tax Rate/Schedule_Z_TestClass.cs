
/*Description: Test class for Schedule Z*/

using NUnit.Framework;

namespace Tax_Rate
{
    [TestFixture]
    public class Schedule_Z_TestClass
    {
        /*Schedule Z test with an 
        income using the minimum tax rate*/
        [Test]
        public void Schedule_Z_Calculation_Minimum()
        {
            //input values
            double income = 12950;
            string status = "hoh";

            //expected output
            double amountDue = 1295;

            //select schedule and calculate amount due
            CalculateTaxRate calc = new CalculateTaxRate(status, income);
            calc.CalculateTaxesDue(status);
            //determine value of test
            Assert.AreEqual(amountDue, calc.getTaxAmountDue());
        }

        /*Schedule Z test with an income amount of $25000*/
        [Test]
        public void Schedule_Z_Calculation_GradeA()
        {
            //input values
            double income = 25000;
            string status = "hoh";

            //expected output
            double amountDue = 3102.50;

            //select schedule and calculate amount due
            CalculateTaxRate calc = new CalculateTaxRate(status, income);
            calc.CalculateTaxesDue(status);

            //determine value of test
            Assert.AreEqual(amountDue, calc.getTaxAmountDue());
        }

        /*Schedule Z test with an income amount of $50000*/
        [Test]
        public void Schedule_Z_Calculation_GradeB()
        {
            //input values
            double income = 50000;
            string status = "hoh";

            //expected output
            double amountDue = 6912.50;

            //select schedule and calculate amount due
            CalculateTaxRate calc = new CalculateTaxRate(status, income);
            calc.CalculateTaxesDue(status);

            //determine value of test
            Assert.AreEqual(amountDue, calc.getTaxAmountDue());
        }

        /*Schedule Z test with an income amount of $200000*/
        [Test]
        public void Schedule_Z_Calculation_GradeC()
        {
            //input values
            double income = 200000;
            string status = "hoh";

            //expected output
            double amountDue = 46586;

            //select schedule and calculate amount due
            CalculateTaxRate calc = new CalculateTaxRate(status, income);
            calc.CalculateTaxesDue(status);

            //determine value of test
            Assert.AreEqual(amountDue, calc.getTaxAmountDue());
        }

        /*Schedule Z test with an income amount of $300000*/
        [Test]
        public void Schedule_Z_Calculation_GradeD()
        {
            //input values
            double income = 300000;
            string status = "hoh";

            //expected output
            double amountDue = 79256;

            //select schedule and calculate amount due
            CalculateTaxRate calc = new CalculateTaxRate(status, income);
            calc.CalculateTaxesDue(status);

            //determine value of test
            Assert.AreEqual(amountDue, calc.getTaxAmountDue());
        }

        /*Schedule Z test with an income amount of $420000*/
        [Test]
        public void Schedule_Z_Calculation_GradeE()
        {
            //input values
            double income = 420000;
            string status = "hoh";

            //expected output
            double amountDue = 119154;

            //select schedule and calculate amount due
            CalculateTaxRate calc = new CalculateTaxRate(status, income);
            calc.CalculateTaxesDue(status);

            //determine value of test
            Assert.AreEqual(amountDue, calc.getTaxAmountDue());
        }

        /*Schedule Z test with an 
        income using the maximum tax rate*/
        [Test]
        public void Schedule_Z_Calculation_Maximum()
        {
            //input values
            double income = 500000;
            string status = "hoh";

            //expected output
            double amountDue = 150272.80;

            //select schedule and calculate amount due
            CalculateTaxRate calc = new CalculateTaxRate(status, income);
            calc.CalculateTaxesDue(status);

            //determine value of test
            Assert.AreEqual(amountDue, calc.getTaxAmountDue());
        }
    }
}
