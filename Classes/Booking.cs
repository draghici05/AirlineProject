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
        public string FlightNo { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.Now;
        public Route Route { get; set; }
        public Company Company { get; set; }

        public Booking() 
        {
            Id = 1;
            Route = new Route();
            Company = new Company();
        }
        public Booking(int id, int gate, int seat, string flightNo, string departureCity, string arrivalCity, DateTime bookingDate) : this()
        {    
            Id = id;
            Gate = gate;
            Seat = seat;
            FlightNo = flightNo;
            Departure = departureCity;
            Arrival = arrivalCity;
            BookingDate = bookingDate;
        }

    }
}
