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
        private Company Company { get; set; }
        public FlightHistory()
        {
            Company = new Company();
            InitializeComponent();
            DisplayTickets();
        }

        public void DisplayTickets()
        {
            if (Company.Bookings != null)
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
            }
        }
    }
}
