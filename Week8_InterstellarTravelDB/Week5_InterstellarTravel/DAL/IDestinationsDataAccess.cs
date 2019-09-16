using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8_InterstellarTravel.DAL
{
    interface IDestinationsDataAccess
    {
       IEnumerable<Models.Destination> GetDestinations();
       Models.Destination GetDestinationById(int id);
    }
}
