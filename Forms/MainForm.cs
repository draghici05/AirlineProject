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

        public MainForm()
        {

            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FlightHistory tickets = new FlightHistory();
            tickets.Show();
            
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
    }
}
