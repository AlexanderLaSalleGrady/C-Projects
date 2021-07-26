using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tax_Rate
{
    class TaxController
    {
        IRepository repository;

        public TaxController(IRepository repository)
        {
            this.repository = repository;
        }

        public void SendToCorrectSchedule()
        {
            var taxUsers = this.repository.GetValues();
            foreach(var taxUser in taxUsers)
            {
                if(taxUser.statusCode == "single")
                {
                    
                }
                else if (taxUser.statusCode == "mjqw")
                {

                }
                else if (taxUser.statusCode == "mfs")
                {

                }
                else if (taxUser.statusCode == "hoh")
                {

                    
                }
            }
        }
    }
}
