using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineProject.Classes
{
    public enum _RouteName 
    {
        TrailRoute,
        VisionHorizion,
        GrantPass,
        OriginLights
    };

    [Serializable]
    public class Route
    {   
        public _RouteName RouteName { get; set; }
        //public string DepartureCity { get; set; }
        //public string ArrivalCity { get; set; }

        public Route() { }
        public Route( _RouteName routeName /* string departureCity, string arrivalCity */) : this()
        {
            RouteName = routeName;
            /*DepartureCity = departureCity;
            ArrivalCity = arrivalCity;*/
        }
    }
}
