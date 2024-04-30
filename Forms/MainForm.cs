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
            dateTimePicker1.MinDate = DateTime.Today;
            dateTimePicker1.MaxDate = DateTime.Today.AddDays(14);
            dateTimePicker2.MinDate = DateTime.Today;
            dateTimePicker2.MaxDate = dateTimePicker1.MaxDate.AddDays(21);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string departureCity = comboBox1.Text;
            string destination = comboBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Flights flight = new Flights();
            flight.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tickets tickets = new Tickets();
            tickets.Show();
            
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                errorProvider1.SetError(comboBox1, "Space can't be left blank");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string departureCity = comboBox1.Text;
            string destination = comboBox1.Text;
        }
    }
}
