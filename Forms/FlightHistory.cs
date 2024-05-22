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
        public FlightHistory()
        {
            InitializeComponent();
            _bookings = new List<Booking>();
        }

        public FlightHistory(List<Booking> bookings) : this()
        {
            if (bookings != null)
            {

                _bookings = bookings;
                foreach (var booking in _bookings)
                {
                    DisplayTickets(booking);
                }
            }
        }

        public void DisplayTickets(Booking booking)
        {
            //lvFlights.Items.Clear();
            ListViewItem lvi = new ListViewItem(booking.Id.ToString());
            lvi.SubItems.Add(booking.Company.CompanyName.ToString());
            lvi.SubItems.Add(booking.Route.RouteName.ToString());
            lvi.SubItems.Add(booking.Gate.ToString());
            lvi.SubItems.Add(booking.BookingDate.ToString("dd/MM/yyyy"));
            lvi.SubItems.Add(booking.FlightNo.ToString());
            lvi.SubItems.Add(booking.Departure);
            lvi.SubItems.Add(booking.Arrival);
            lvi.SubItems.Add(booking.Seat.ToString());
            lvi.Tag = booking;

            lvFlights.Items.Add(lvi);
        }

        private void lvFlights_MouseDoubleClick(object sender, MouseEventArgs e)
        {
          /*   if (lvFlights.SelectedItems.Count == 1)
            {
                Booking booking = lvFlights.SelectedItems[0].Tag as Booking;
                MainForm form = new MainForm();
                form.BringToFront();
            } */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lvFlights.SelectedItems.Count == 1)
            {
                Booking deleteBooking = lvFlights.SelectedItems[0].Tag as Booking;
                DialogResult confirmation = MessageBox.Show("Are you sure you want to remove booking?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmation == DialogResult.Yes)
                {
                    lvFlights.Items.Remove(lvFlights.SelectedItems[0]);
                    _bookings.Remove(deleteBooking);
                }
            }
        }
    }
}