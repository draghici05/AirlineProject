using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineProject.Classes
{
    public enum _CompanyName
    {
        Rocket,
        Disco,
        Salad,
        Chaos
    };

    [Serializable]
    public class Company
    {
        public _CompanyName CompanyName { get; set; }
        public List<Booking> Bookings { get; set; }
        public Company() 
        {
            Bookings = new List<Booking>();
        }
        public Company(_CompanyName companyName) : this()
        {
            CompanyName = companyName;
        }
    }
}
