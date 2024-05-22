using AirlineProject.Classes;
using AirlineProject.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlineProject.Forms
{
    public partial class FlightHistory : Form
    {
        private List<Booking> _bookings;
        //    Booking _booking = new Booking()  
        public FlightHistory()
        {
            InitializeComponent();
            _bookings = new List<Booking>();
        }

        public FlightHistory(List<Booking> bookings) : this()
        {
            _bookings = bookings;
            foreach (var booking in _bookings)
            {
                DisplayTickets(booking);
            }
        }

        public void DisplayTickets(Booking booking)
        {
            ListViewItem lvi = new ListViewItem(booking.Gate.ToString());
            lvi.SubItems.Add(booking.Seat.ToString());
            lvi.SubItems.Add(booking.FlightNo.ToString());
            lvi.SubItems.Add(booking.BookingDate.ToString());
            lvi.SubItems.Add(booking.Company.ToString());
            lvi.Tag = booking;

            lvFlights.Items.Add(lvi);
        }
    }
}
/* if (Company.Bookings != null)
            {
                lvFlights.Items.Clear();
                lvFlights.Sort();
                foreach (var ticket in Company.Bookings)
                {
                    ListViewItem lvi = new ListViewItem(ticket.Id.ToString());
                    lvi.SubItems.Add(ticket.BookingDate.ToString());
                    lvi.Tag = ticket;

                    lvFlights.Items.Add(lvi);
                }  
            }*/
