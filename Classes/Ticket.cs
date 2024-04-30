using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineProject.Classes
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Location {get; set; }
        public DateTime FlightDate { get; set; } = DateTime.Now;
        public List<Ticket> Tickets { get; set; }
        public Ticket() { }
        public Ticket(int id, string location, DateTime flightDate) : this()
        {
            Id = id;
            Location = location;
            FlightDate = flightDate;
            Tickets = new List<Ticket>();
        }
    }
}
