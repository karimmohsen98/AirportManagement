using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interface
{
    public interface IServiceFlight:IService<Flight>
    {
        public List<DateTime> GetFlightDates(string destination);
        public void GetFlights(string filterType, string filterValue);

        public List<Flight> GetFlightsByDate(string DateDepart);
    }
}
