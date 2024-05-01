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
        public BookFlight()
        {
            InitializeComponent();
        }

        private void BookFlight_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Today;
            dateTimePicker1.MaxDate = DateTime.Today.AddDays(14);
            dateTimePicker2.MinDate = DateTime.Today;
            dateTimePicker2.MaxDate = dateTimePicker1.MaxDate.AddDays(21);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {         
            string departureCity = comboBox1.Text;
            string destination = comboBox1.Text;   //de scris tot in usercontrol           
        }
   
    }
}
