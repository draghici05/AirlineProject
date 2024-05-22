using AirlineProject.Classes;
using AirlineProject.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace AirlineProject.Controls
{
    public partial class BookFlight : UserControl
    {
      //  private FlightHistory historyForm;
        private Company Company { get; set; }
        public List<Booking> Bookings;
        public BookFlight()
        {
            Company = new Company();
            Bookings = new List<Booking>();
            InitializeComponent();
        }

        private void BookFlight_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Today;
            dateTimePicker1.MaxDate = DateTime.Today.AddDays(60);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidDestinations();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidDestination())
            {
                MessageBox.Show("One or more spaces are empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Random random = new Random();

            Booking booking = new Booking
            {
                Id = Bookings.Count + 1,
                Gate = random.Next(1, 20),
                Seat = random.Next(1, 175),
                BookingDate = dateTimePicker1.Value,
                Departure = comboBox1.SelectedItem.ToString(), 
                Arrival = comboBox2.SelectedItem.ToString(),
                FlightNo = "FL" + random.Next(10, 125).ToString(),
            };

            if (comboBox3.SelectedItem != null)
            {
                var routeName = (_RouteName)Enum.Parse(typeof(_RouteName), comboBox3.SelectedItem.ToString());
                booking.Route = new Route(routeName);
            }

            if (comboBox4.SelectedItem != null)
            {
                var companyName = (_CompanyName)Enum.Parse(typeof(_CompanyName), comboBox4.SelectedItem.ToString());
                booking.Company = new Company(companyName);
            }
            
            Bookings.Add(booking);
            FlightHistory form = new FlightHistory(Bookings);
            form.ShowDialog();
        }

        private bool ValidDestination()
        {
            return !string.IsNullOrEmpty(comboBox1.Text.Trim());
        }

        private void comboBox3_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox3.SelectedIndex == -1)
            {
                e.Cancel = true;
                EmptyPassengers.SetError((Control)sender, "Must be at least 1 passenger");
            }
        }

        private void ValidDestinations()
        {
           if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
           {
                if (comboBox1.SelectedItem.ToString() == comboBox2.SelectedItem.ToString())
                {
                    MessageBox.Show("Departure city cannot be the same as destination city.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
           }
        }
    }
}
