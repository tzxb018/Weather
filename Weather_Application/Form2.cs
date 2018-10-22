using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Weather_Application
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        
        private void easternNebraskaWesternIowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Form1();
            f.StartPosition = this.StartPosition;
            f.Show();
            this.Hide();
        }

        private void unitedStatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Form1();
            f.StartPosition = this.StartPosition;
            f.Show();
            this.Hide();
        }

        private void currentTemperatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Label s in this.Controls.OfType<Label>())
            {
                if (s.TabIndex != 23) { 
                    string cityName = s.Name;
                    cityName = cityName.Replace("_", " ");
                    City cityString = new City(cityName);
                    int temperature = (int)cityString.getCurrentTemperature();
                    s.Text = temperature.ToString() + "F\n" + cityName;
                    s.TextAlign = ContentAlignment.MiddleCenter;
            }
            }
            foreach (Panel pnl in this.Controls.OfType<Panel>())
            {
                pnl.Dispose();
            }
            DateTime now = DateTime.Now;
            lblLastUpdate.Text = "Last Updated: " + now.ToString();
        }

        private void currentConditionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Label s in this.Controls.OfType<Label>())
            {
                if (s.TabIndex != 23)
                {
                    string cityName, iconURL;
                    cityName = s.Name;
                    cityName = cityName.Replace("_", " ");
                    City city = new City(cityName);
                    iconURL = city.getIcon();

                    s.Text = cityName;
                    s.TextAlign = ContentAlignment.MiddleCenter;
                    //creating a picturebox in a panel
                    Panel pnl = new Panel();

                    pnl.Size = new System.Drawing.Size(s.Size.Width, 40);
                    pnl.Location = new Point(s.Location.X, s.Location.Y - 30);

                    this.Controls.Add(pnl);

                    PictureBox pc = new PictureBox();
                    pc.SizeMode = PictureBoxSizeMode.Zoom;
                    pc.Size = new Size(s.Size.Width, 40);

                    //placing icon in picturebox
                    //taken from https://stackoverflow.com/questions/28255438/programmatically-create-panel-and-add-picture-boxes
                    var request = WebRequest.Create(iconURL);
                    using (var response = request.GetResponse())
                    using (var stream = response.GetResponseStream())
                    {
                        pc.Image = Bitmap.FromStream(stream);

                    }
                    pnl.Controls.Add(pc);
                }

            }
        }

        private void windToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            foreach (Label s in this.Controls.OfType<Label>())
            {
                if (s.TabIndex != 23)
                {
                    string cityName = s.Name;
                    cityName = cityName.Replace("_", " ");
                    City cityString = new City(cityName);
                    int windSpeed = (int)cityString.getWindSpeed();
                    string dir = cityString.getWindDir();
                    s.Text = dir + " " + windSpeed.ToString() + "mph\n" + cityName;
                    s.TextAlign = ContentAlignment.MiddleCenter;
                }
            }
            foreach (Panel pnl in this.Controls.OfType<Panel>())
            {
                pnl.Dispose();
            }
            DateTime now = DateTime.Now;
            lblLastUpdate.Text = "Last Updated: " + now.ToString();
        }

        private void pressureToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            foreach (Label s in this.Controls.OfType<Label>())
            {
                if (s.TabIndex != 23)
                {
                    string cityName = s.Name;
                    cityName = cityName.Replace("_", " ");
                    City cityString = new City(cityName);
                    int temperature = (int)cityString.getPressure();
                    s.Text = temperature.ToString() + "hPa\n" + cityName;
                    s.TextAlign = ContentAlignment.MiddleCenter;
                }
            }
            foreach (Panel pnl in this.Controls.OfType<Panel>())
            {
                pnl.Dispose();
            }
            DateTime now = DateTime.Now;
            lblLastUpdate.Text = "Last Updated: " + now.ToString();
        }

        private void humidityToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            foreach (Label s in this.Controls.OfType<Label>())
            {
                if (s.TabIndex != 23)
                {
                    string cityName = s.Name;
                    cityName = cityName.Replace("_", " ");
                    City cityString = new City(cityName);
                    int temperature = (int)cityString.getHumidity();
                    s.Text = temperature.ToString() + "%\n" + cityName;
                    s.TextAlign = ContentAlignment.MiddleCenter;
                }
            }
            foreach (Panel pnl in this.Controls.OfType<Panel>())
            {
                pnl.Dispose();
            }
            DateTime now = DateTime.Now;
            lblLastUpdate.Text = "Last Updated: " + now.ToString();
        }
    }
}
