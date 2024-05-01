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
        public MainForm()
        {

            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           
        }

       /* private void button1_Click(object sender, EventArgs e)
        {
            Flights flight = new Flights();
            flight.ShowDialog();
        } */

        private void button2_Click(object sender, EventArgs e)
        {
            Tickets tickets = new Tickets();
            tickets.ShowDialog();
            
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
           /* if (comboBox1.SelectedIndex == -1)
            {
                errorProvider1.SetError(comboBox1, "Space can't be left blank");
            } */
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          /*  string departureCity = comboBox1.Text;
            string destination = comboBox1.Text; */
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
            stats.ShowDialog();
        }
    }
}
