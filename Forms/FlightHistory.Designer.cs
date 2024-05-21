namespace AirlineProject.Forms
{
    partial class FlightHistory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.lvFlights = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GATE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SEAT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FLIGHT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DESTINATION = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ARRIVAL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DATE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PowderBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(54, 250);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "ig";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.PowderBlue;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(534, 252);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(184, 46);
            this.button3.TabIndex = 2;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // lvFlights
            // 
            this.lvFlights.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.GATE,
            this.SEAT,
            this.FLIGHT,
            this.DESTINATION,
            this.ARRIVAL,
            this.DATE,
            this.columnHeader1,
            this.columnHeader2});
            this.lvFlights.FullRowSelect = true;
            this.lvFlights.HideSelection = false;
            this.lvFlights.Location = new System.Drawing.Point(6, 12);
            this.lvFlights.Name = "lvFlights";
            this.lvFlights.Size = new System.Drawing.Size(785, 223);
            this.lvFlights.TabIndex = 3;
            this.lvFlights.UseCompatibleStateImageBehavior = false;
            this.lvFlights.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 26;
            // 
            // GATE
            // 
            this.GATE.DisplayIndex = 3;
            this.GATE.Text = "Gate Number";
            this.GATE.Width = 80;
            // 
            // SEAT
            // 
            this.SEAT.DisplayIndex = 8;
            this.SEAT.Text = "Seat Number";
            this.SEAT.Width = 92;
            // 
            // FLIGHT
            // 
            this.FLIGHT.DisplayIndex = 5;
            this.FLIGHT.Text = "Flight Number";
            this.FLIGHT.Width = 80;
            // 
            // DESTINATION
            // 
            this.DESTINATION.DisplayIndex = 6;
            this.DESTINATION.Text = "Destination City";
            this.DESTINATION.Width = 90;
            // 
            // ARRIVAL
            // 
            this.ARRIVAL.DisplayIndex = 7;
            this.ARRIVAL.Text = "Arrival City";
            this.ARRIVAL.Width = 64;
            // 
            // DATE
            // 
            this.DATE.DisplayIndex = 4;
            this.DATE.Text = "Flight Date";
            this.DATE.Width = 70;
            // 
            // columnHeader1
            // 
            this.columnHeader1.DisplayIndex = 1;
            this.columnHeader1.Text = "Company";
            this.columnHeader1.Width = 58;
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 2;
            this.columnHeader2.Text = "Route";
            this.columnHeader2.Width = 45;
            // 
            // FlightHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(800, 308);
            this.Controls.Add(this.lvFlights);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "FlightHistory";
            this.Text = "FlightHistory";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListView lvFlights;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader GATE;
        private System.Windows.Forms.ColumnHeader SEAT;
        private System.Windows.Forms.ColumnHeader FLIGHT;
        private System.Windows.Forms.ColumnHeader DESTINATION;
        private System.Windows.Forms.ColumnHeader ARRIVAL;
        private System.Windows.Forms.ColumnHeader DATE;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}