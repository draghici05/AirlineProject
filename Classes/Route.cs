using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineProject.Classes
{
    [Serializable]
    public class Route
    {   
        public int RouteId { get; set; }
        public string RouteName { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }

        public Route() { }
        public Route(int routeId, string routeName, string departureCity, string arrivalCity) : this()
        {
            RouteId = routeId;
            RouteName = routeName;
            DepartureCity = departureCity;
            ArrivalCity = arrivalCity;
        }
    }
}
