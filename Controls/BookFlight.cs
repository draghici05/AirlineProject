using AirlineProject.Classes;
using AirlineProject.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace AirlineProject.Controls
{
    public partial class BookFlight : UserControl
    {
        private const string ConnectionString = "Data source = database.sqlite";

        private Company Company { get; set; }
        //private List<Booking> _bookings;
        public List<Booking> _bookings;
        private ListView lvFlights;
        public BookFlight()
        {
            Company = new Company();
            _bookings = new List<Booking>();
            InitializeComponent();
        }
        private int _currentBookingIndex = 0;

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
                Id = _bookings.Count + 1,
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

            _bookings.Add(booking);
            FlightHistory form = new FlightHistory(_bookings);
            form.ShowDialog();
            CreateBooking(booking);
        }

        private void CreateBooking(Booking booking)
        {
            string query = "INSERT INTO Bookin (Company, Route, Gate, [Flight Date], [Flight Number], [Departure City], [Arrival City], Seat) VALUES" +
                "(@Company, @Route, @Gate, @BookingDate, @FlightNo, @Departure, @Arrival, @Seat)";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    //command.Parameters.AddWithValue("@Id", booking.Id);
                    command.Parameters.AddWithValue("@Company", booking.Company.CompanyName);
                    command.Parameters.AddWithValue("@Route", booking.Route.RouteName);
                    command.Parameters.AddWithValue("@Gate", booking.Gate);
                    command.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
                    command.Parameters.AddWithValue("@FlightNo", booking.FlightNo);
                    command.Parameters.AddWithValue("@Departure", booking.Departure);
                    command.Parameters.AddWithValue("@Arrival", booking.Arrival);
                    command.Parameters.AddWithValue("@Seat", booking.Seat);

                    command.ExecuteNonQuery();
                }
            }
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

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pageSetupDialog.PageSettings = printDocument.DefaultPageSettings;

            if (pageSetupDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.DefaultPageSettings = pageSetupDialog.PageSettings;
            }
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font font = new Font("Microsoft Sans Serif", 24);   

            var pageSettings = e.PageSettings;
            var printAreaHeight = e.MarginBounds.Height;
            var printAreaWidth = e.MarginBounds.Width;
            var marginLeft = pageSettings.Margins.Left;
            var marginTop = pageSettings.Margins.Top;

            if (pageSettings.Landscape)
            {
                var intTemp = printAreaHeight;
                printAreaHeight = printAreaWidth;
                printAreaWidth = intTemp;
            }

            const int rowHeight = 40;
            var columnWidth = printAreaWidth / 3;

            StringFormat fmt = new StringFormat(StringFormatFlags.LineLimit);
            fmt.Trimming = StringTrimming.EllipsisCharacter;

            var currentY = marginTop;
            if (_bookings != null) {
                while (_currentBookingIndex < _bookings.Count)
                {
                    var currentX = marginLeft;
                    currentY += rowHeight;

                    e.Graphics.DrawString(
                        "Id #" + (_currentBookingIndex + 1).ToString(),
                        font,
                        Brushes.Black,
                        new PointF(currentX, currentY), 
                        fmt);
                    e.Graphics.DrawString(
                        "Route name - " + _bookings[_currentBookingIndex].Route,
                        font,
                        Brushes.Black,
                        new PointF(currentX, currentY),
                        fmt); ;
                    e.Graphics.DrawString(
                        "Departure city - " + _bookings[_currentBookingIndex].Departure,
                        font,
                        Brushes.Black,
                        new PointF(currentX, currentY),
                        fmt);
                    e.Graphics.DrawString(
                        "Arrival city - " + _bookings[_currentBookingIndex].Arrival,
                        font,
                        Brushes.Black,
                        new PointF(currentX, currentY),
                        fmt);
                    _currentBookingIndex++;
                    
                    if(_currentBookingIndex < _bookings.Count)
                    {
                        e.HasMorePages = true;
                        break;
                    }
                }
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
             PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;

            printDocument.PrintPage += printDocument_PrintPage;
            printPreviewDialog.ShowDialog();
        }

       /* private void CopyDetails(Booking booking)
        {
            string copiedDetails = "$Flight Number - {booking.FlightNo}\n" + "$Flight Date - {booking.BookingDate}\n"
                                 + "$Departure city - {booking.Departure}\n" + "$Arrival city - {booking.Arrival}\n"
                                 + "$Gate number - {booking.Gate}\n" + "$Seat number - {booking.Seat}\n";
            Clipboard.SetText(copiedDetails);
        } */
        private void button2_Click(object sender, EventArgs e)
        {
            /* if (lvFlights.SelectedItems.Count > 0)
            {
                Booking copyBooking = lvFlights.SelectedItems[0].Tag as Booking;
                if (copyBooking != null)
                {
                    CopyDetails(copyBooking);
                }
            } */
        }
       /* private Booking PasteDetails()
        {
            if (Clipboard.ContainsText())
            {
                string copiedDetails = Clipboard.GetText();
            }
            return null;
        } */

        private void button3_Click(object sender, EventArgs e)
        {
           /* Booking pasteDetails = PasteDetails();
            if (pasteDetails != null)
            {
               
            } */
        }
    }
}
        
