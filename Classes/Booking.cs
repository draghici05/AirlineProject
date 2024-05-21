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
        public string Flight { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.Now;

        public Booking() 
        {
            Id = 1;
        }
        public Booking(int id, int gate, int seat, int flight, DateTime bookingDate) : this()
        {    
            Id = id;
            Gate = gate;
            Seat = seat;
            Flight = flight;
            BookingDate = bookingDate;
        }

    }
}
