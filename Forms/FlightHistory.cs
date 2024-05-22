using AirlineProject.Classes;
using AirlineProject.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlineProject.Forms
{
    public partial class FlightHistory : Form
    {
        #region sqlite 
        private const string ConnectionString = "Data source = database.sqlite";
        #endregion
        private List<Booking> _bookings;
        public FlightHistory()
        {
            InitializeComponent();
            _bookings = new List<Booking>();
        }
        private void CreateBooking(Booking booking)
        {
            string query = "INSERT INTO Booking (Id, Company, Route, Gate, BookingDate, FlightNo, Departure, Arrival, Seat) VALUES" +
                "(@Id, @Company, @Route, @Gate, @BookingDate, @FlightNo, @Departure, @Arrival, @Seat)";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@Id", booking.Id.ToString());
                command.Parameters.AddWithValue("@Company", booking.Company.ToString());
                command.Parameters.AddWithValue("@Route", booking.Route.ToString());
                command.Parameters.AddWithValue("@Gate", booking.Gate.ToString());
                command.Parameters.AddWithValue("@BookingDate", booking.BookingDate.ToString());
                command.Parameters.AddWithValue("@FlightNo", booking.FlightNo.ToString());
                command.Parameters.AddWithValue("@Departure", booking.Departure.ToString());
                command.Parameters.AddWithValue("@Arrival", booking.Arrival.ToString());
                command.Parameters.AddWithValue("@Seat", booking.Seat.ToString());

                command.ExecuteNonQuery();
            }
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
        public ListView checkList()
        {
            return lvFlights;
        }

        private void lvFlights_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FlightHistory asdf = new FlightHistory();
            asdf.Close();
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
        
        private void CreateReport()
        {
            List<Booking> bookings = _bookings;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text file (*.txt)|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    if (bookings == null || bookings.Count == 0)
                    {
                        MessageBox.Show("There are no bookings in the history", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    sw.WriteLine("The number of bookings: " + bookings.Count);
                    foreach (Booking booking in bookings)
                    {
                        string line = "Route name - " + booking.Route.RouteName + " Flight number: " + booking.FlightNo + " Departure city - " + booking.Departure + " Arrival city - " + booking.Arrival;
                        sw.WriteLine(line);
                    }
                    sw.Close();
                    MessageBox.Show("Report has been created", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void exportReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateReport();
        }
    }
}