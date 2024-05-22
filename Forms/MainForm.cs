using AirlineProject.Classes;
using AirlineProject.Controls;
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

namespace AirlineProject
{
    public partial class MainForm : Form
    {
        #region SQlite
        private const string ConnectionString = "Data source = bazasqlite.db";
        private readonly List<FlightHistory> tickets;
        #endregion

        private List<Booking> _bookings;
        public MainForm()
        {
            InitializeComponent();
            _bookings = new List<Booking>();
            this.KeyPreview = true;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FlightHistory tickets = new FlightHistory(_bookings);
            tickets.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            bookFlight1.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            homePage1.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Statistics stats = new Statistics();
            stats.Show();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                if (e.KeyCode == Keys.S)
                {                  
                    Statistics open = new Statistics();
                    open.ShowDialog();
                }
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is version 0.01 of the Travel App" +
                            "\n Here are some useful shortucts: \n ALT + S to display Statistics", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
