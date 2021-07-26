using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tax_Rate
{
    interface IRepository
    {
        List<TaxUser> GetValues();
    }
}
