using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tax_Rate
{
    public class ScheduleXRepository : IRepository 
    {
        public List<TaxUser> GetValues()
        {
            //dummy database
            var listOfSingleTaxPayers = new List<TaxUser>();
            listOfSingleTaxPayers.Add(
                new TaxUser
                {
                    Income = 5000, 
                    statusCode = "single"
                    
                });

            listOfSingleTaxPayers.Add(
                new TaxUser
                {
                    Income = 18000,
                    statusCode = "single"

                });

            listOfSingleTaxPayers.Add(
                new TaxUser
                {
                    Income = 80000,
                    statusCode = "single"

                });

            listOfSingleTaxPayers.Add(
                new TaxUser
                {
                    Income = 180000,
                    statusCode = "single"

                });

            listOfSingleTaxPayers.Add(
                new TaxUser
                {
                    Income = 280000,
                    statusCode = "single"

                });

            listOfSingleTaxPayers.Add(
                new TaxUser
                {
                    Income = 406000,
                    statusCode = "single"

                });

            listOfSingleTaxPayers.Add(
                new TaxUser
                {
                    Income = 300000000,
                    statusCode = "single"

                });

            return listOfSingleTaxPayers;
        }
    }
}
