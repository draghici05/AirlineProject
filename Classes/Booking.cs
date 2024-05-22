using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AirlineProject.Classes
{
    [Serializable]
    public class Booking
    {
        public int Id { get; set; } 
        public int Gate { get; set; }
        public int Seat { get; set; }
        public int FlightNo { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.Now;
        public List<Route> Routes { get; set; }
        public Company Company { get; set; }

        public Booking() 
        {
            Id = 1;
            Routes = new List<Route>();
            Company = new Company();
        }
        public Booking(int id, int gate, int seat, int flightNo, DateTime bookingDate) : this()
        {    
            Id = id;
            Gate = gate;
            Seat = seat;
            FlightNo = flightNo;
            BookingDate = bookingDate;
        }

    }
}
