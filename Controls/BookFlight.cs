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

namespace AirlineProject.Controls
{
    public partial class BookFlight : UserControl
    {
        private FlightHistory historyForm;
        private Company Company { get; set; }
        private Booking Booking { get; set; }
        public BookFlight()
        {
            Company = new Company();
            historyForm = new FlightHistory();
            InitializeComponent();
        }

        private void BookFlight_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Today;
            dateTimePicker1.MaxDate = DateTime.Today.AddDays(60);         
           /* string departureCity = comboBox1.Text;
            string arrivalCity = comboBox2.Text; */
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

            Booking booking = new Booking();
            Company.Bookings.Add(booking);
            historyForm.DisplayTickets();
            
        }

        private bool ValidDestination()
        {
            return !string.IsNullOrEmpty(comboBox1.Text.Trim());
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            /* if (ValidDestination())
             {
                 e.Cancel = true;
                 formError.SetError((Control)sender, "Can't leave empty spaces");
             } */
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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidDestinations();
        }

        private void comboBox4_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox4 != null)
            {
                string noCompany = comboBox4.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(noCompany))
                {
                    Random random = new Random();
                    noCompany = comboBox4.Items[random.Next(comboBox4.Items.Count)].ToString();
                }
            }
        }

    }
}
