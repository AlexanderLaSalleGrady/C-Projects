using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tax_Rate
{
    [TestFixture]
    public class TaxUserMoqTest
    {
        [Test]
        public void MoqTest()
        {
            Mock<ScheduleXRepository> mockRepository = new Mock<ScheduleXRepository>();
            var taxController = new TaxController(mockRepository.Object);
            Assert.IsNotNull(taxController);
        }
    }
}
