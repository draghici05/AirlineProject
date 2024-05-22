using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using AirlineProject.Classes;
using System.Runtime.InteropServices;

namespace AirlineProject.Forms
{
    public partial class Statistics : Form
    {
        private List<Booking> _bookings;
        public Statistics()
        {
            InitializeComponent();
            
        }
     
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/draghici05/AirlineProject");
        }

        private void binarySerializationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = File.Create(sfd.FileName))
                {
                    if (_bookings != null)
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, _bookings);
                    }
                }
            }
        }
        private void binaryDeserializationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FlightHistory fh = new FlightHistory();
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = File.OpenRead(ofd.FileName))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    _bookings = (List<Booking>)bf.Deserialize(fs);
                    DisplayBookings();
                }
            }
        }
        private void DisplayBookings()
        {
            if (_bookings != null && _bookings.Count > 0)
            {
                FlightHistory flightHistory = new FlightHistory();
                foreach (var booking in _bookings)
                {
                    flightHistory.DisplayTickets(booking);
                }
                flightHistory.ShowDialog();
            }
        }

    }
}
