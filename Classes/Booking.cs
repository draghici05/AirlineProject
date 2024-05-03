using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineProject.Classes
{
    [Serializable]
    internal class Booking
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.Now;

        public Booking() { }
        public Booking(string firstName, string lastName, int bookingId, DateTime bookingDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BookingId = bookingId;
            BookingDate = bookingDate;
        }
    }
}
