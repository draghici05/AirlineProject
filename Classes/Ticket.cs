using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineProject.Classes
{
    [Serializable]
    public class Ticket
    {
        public int Id { get; set; }
        public string Location {get; set; }
        public int Gate { get; set; }
        public int Seat { get; set; }
        public DateTime FlightDate { get; set; } = DateTime.Now;
        public List<Ticket> Tickets { get; set; }
        public Ticket() { }
        public Ticket(int id, string location, int gate, int seat, DateTime flightDate) : this()
        {
            Id = id;
            Location = location;
            FlightDate = flightDate;
            Gate = gate;
            Seat = seat;
            Tickets = new List<Ticket>();
        }
    }
}
