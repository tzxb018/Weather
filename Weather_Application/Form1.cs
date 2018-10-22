using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace Weather_Application
{
    public partial class Weather : Form
    {
        List<City> ListOfCities = new List<City>();
        public static bool isImperial = true;
        int range = 5;
        String[] cityNames = {"Norfolk","Columbus", "Fremont", "Tekamah", "Lincoln", "Beatrice", "Omaha", "Council Bluffs", "Nebraska City", "Red Oak", "Atlantic", "York", "Hebron", "Falls City", "Harlan", "Maryville", "Wahoo", "Seward", "Fairbury" };
        int[] zipCodes = {      68701,    68601,     68025,      68061,     68508,     68310,     68114,     51501,             68410,         51566,     50022,    68467,   68370,      68355,      51593,      64468,      68066,   68434,   68352};
        Point[] labelPos = { new Point(49,68), //nor
                               new Point(62,144), //col
                               new Point(166,136), //fe
                               new Point(205,76),  //te
                               new Point(166, 307),// li
                               new Point(164, 403), //be
                               new Point(235, 183), //om
                               new Point(296, 188), //cb
                               new Point(222, 311), //nc
                               new Point(354, 240), //red
                               new Point(386, 180), //at
                               new Point(53,  267),   //york
                               new Point(52, 403), //hebron
                               new Point(287, 416), //falls city
                               new Point(343, 121), //harlan
                               new Point(398,379), //maryville
                               new Point(177, 212), //wahoo
                               new Point(108, 280), //seward
                               new Point(106, 410) //fiarbury
                           }; 

        Color[] precipScaleRain = { //might need to change values
            Color.FromArgb(150, 50, 255, 51), // <.5
            Color.FromArgb(150, 0, 102, 0), //.5-1
            Color.FromArgb(150, 242, 255, 50), //1-2
            Color.FromArgb(150, 255, 0, 0), //2-3
            Color.FromArgb(150, 204, 0, 204), //3+
                                  };
        Color[] precipScaleSnow = { //might need to change values
            Color.FromArgb(150, 192, 192, 192), // <.5
            Color.FromArgb(150, 153, 204, 255), //.5-1
            Color.FromArgb(150, 0, 128, 255), //1-3
            Color.FromArgb(150, 102, 78, 255), //3-6
            Color.FromArgb(150, 0, 0, 153), //6-9
            Color.FromArgb(150, 51, 0, 102), //9+
                                  };
        Color[] precipWind = { //might need to change values
            Color.FromArgb(150, 50, 255, 255), // 0-10
            Color.FromArgb(150, 50, 255, 84), //10-20
            Color.FromArgb(150, 242, 255, 50), //20-30
            Color.FromArgb(150, 255, 79, 51), //30-40
            Color.FromArgb(150, 240, 0, 0), //40+
                                  };

        Color[] tempScale = {
            Color.FromArgb(150,244, 70, 212), //0-5 0
            Color.FromArgb(150, 235, 52, 212), //5-10 1 
            Color.FromArgb(150,170, 66, 244), //10-15 2
            Color.FromArgb(150,128, 71, 229), //15-20 3
            Color.FromArgb(150,66, 75, 244), //20-25 4
            Color.FromArgb(150,66, 109, 244), //25-30 5
            Color.FromArgb(150,66, 170, 244), //30-35 6
            Color.FromArgb(150,54, 187, 244), //35-40 7
            Color.FromArgb(150,66, 244, 241), //40-45 8
            Color.FromArgb(150,66, 244, 190), //45-50 9
            Color.FromArgb(150,66, 244, 104), //50-55 10
            Color.FromArgb(150,146, 236, 45), //55-60 11
            Color.FromArgb(150,232, 244, 66), //60-65 12
            Color.FromArgb(150,246, 197, 15), //65-70 13
            Color.FromArgb(150,244, 125, 14), //70-75 14
            Color.FromArgb(150,242, 85, 21), //75-80 15
            Color.FromArgb(150,242, 21, 21), //80-85 16
            Color.FromArgb(150,242, 21, 90), //85-90 17
            Color.FromArgb(150, 242, 21, 143), //90-95 18 
            Color.FromArgb(150, 242, 21, 135), //95-100 19
            Color.FromArgb(150,242,21,182) //100+ 20
        };
        Color[] tempScaleNeg = {
            Color.FromArgb(150,255,111,228), //0-(-10) 0
            Color.FromArgb(150,248,156,231), //-10~-20 1
            Color.FromArgb(150,251,204,242) // <-20 2
        };

        Color[] totalScaleTemp =
        {
            Color.FromArgb(150,251,204,242), // <-20 2
            Color.FromArgb(150,248,156,231), //-10~-20 1
            Color.FromArgb(150,255,111,228), //0-(-10) 0, 
            Color.FromArgb(150,244, 70, 212), //0-5 0
            Color.FromArgb(150, 235, 52, 212), //5-10 1 
            Color.FromArgb(150,170, 66, 244), //10-15 2
            Color.FromArgb(150,128, 71, 229), //15-20 3
            Color.FromArgb(150,66, 75, 244), //20-25 4
            Color.FromArgb(150,66, 109, 244), //25-30 5
            Color.FromArgb(150,66, 170, 244), //30-35 6
            Color.FromArgb(150,54, 187, 244), //35-40 7
            Color.FromArgb(150,66, 244, 241), //40-45 8
            Color.FromArgb(150,66, 244, 190), //45-50 9
            Color.FromArgb(150,66, 244, 104), //50-55 10
            Color.FromArgb(150,146, 236, 45), //55-60 11
            Color.FromArgb(150,232, 244, 66), //60-65 12
            Color.FromArgb(150,246, 197, 15), //65-70 13
            Color.FromArgb(150,244, 125, 14), //70-75 14
            Color.FromArgb(150,242, 85, 21), //75-80 15
            Color.FromArgb(150,242, 21, 21), //80-85 16
            Color.FromArgb(150,242, 21, 90), //85-90 17
            Color.FromArgb(150, 242, 21, 143), //90-95 18 
            Color.FromArgb(150, 242, 21, 135), //95-100 19
            Color.FromArgb(150,242,21,182) //100+ 20
        };

        Color[] cloudScale = 
        {
            Color.FromArgb(0,100,100,100),
            Color.FromArgb(10,100,100,100),
            Color.FromArgb(20,100,100,100),
            Color.FromArgb(30,100,100,100),
            Color.FromArgb(40,100,100,100),
            Color.FromArgb(50,100,100,100),
            Color.FromArgb(60,100,100,100),
            Color.FromArgb(70,100,100,100),
            Color.FromArgb(80,100,100,100),
            Color.FromArgb(90,100,100,100),
            Color.FromArgb(100,100,100,100),
            Color.FromArgb(110,100,100,100),
            Color.FromArgb(120,100,100,100),
            Color.FromArgb(130,100,100,100),
            Color.FromArgb(140,100,100,100),
            Color.FromArgb(150,100,100,100),
            Color.FromArgb(160,100,100,100),
            Color.FromArgb(175,100,100,100),
        };
                          

        int sizeX, sizeY;
        
        public Weather()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
        }
        private void Weather_Load(object sender, EventArgs e)
        {
            double xRatio = (double)(this.Size.Width) /(double)516;
            double yRatio = (double)(this.Size.Height) / (double)536;
            for (int i = 0; i < cityNames.Length; i++)
            {
                City c = new City(zipCodes[i], (int)(labelPos[i].X * xRatio), (int)((labelPos[i].Y -8) * yRatio));
                c.setName(cityNames[i]);
                picMap.Controls.Add(c.placeLabel(cityNames[i], ""));
                ListOfCities.Add(c);
            }
            sizeX = this.Size.Width;
            sizeY = this.Size.Height;
            Graphics g = picMap.CreateGraphics();
        }
        private void Weather_ResizeEnd(object sender, EventArgs e)
        {
            double xRatio = (double)(Size.Width) / (double)sizeX;
            double yRatio = (double)(Size.Height) / (double)sizeY;
            sizeX = this.Size.Width;
            sizeY = this.Size.Height;
            //picMap.Size = new Size((int)(picMap.Size.Width * xRatio), (int)(picMap.Size.Height * yRatio));
            //foreach (Label l in picMap.Controls.OfType<Label>())
            //{
            //    l.Location = new Point((int)(l.Location.X * xRatio), (int)(l.Location.Y * yRatio));
            //}
            //for (int i = 0; i < labelPos.Length; i++)
            //{
            //    labelPos[i].X = (int)(xRatio * labelPos[i].X);
            //    labelPos[i].Y = (int)(yRatio * labelPos[i].Y);
            //    ListOfCities[i].updatePoint(labelPos[i].X, labelPos[i].Y);
            //}
            //btnSwitchUnits.Location = new Point((int)(btnSwitchUnits.Location.X * xRatio), (int)(btnSwitchUnits.Location.Y * yRatio));
            //lblOpenWeather.Location = new Point((int)(lblOpenWeather.Location.X * xRatio), (int)(lblOpenWeather.Location.Y));
            //foreach (Panel p in picMap.Controls.OfType<Panel>())
            //{
            //    p.Location = new Point((int)(p.Location.X * xRatio), (int)(p.Location.Y * yRatio));
            //}
            //foreach (Label l in this.Controls.OfType<Label>())
            //{
            //    if (!l.Name.Equals("lblOpenWeather"))
            //    {
            //        l.Location = new Point((int)(l.Location.X * xRatio), (int)(l.Location.Y * yRatio));
            //    }
            //}

        }

        //Make Scale
        private void makeScale(Color[] colorScale, string one, string two)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);
            lblBack.Visible = true;
            lblBack2.Visible = false;
            lblFront.Visible = true;
            lblFront2.Visible = false;
            lblBack.Text = two;
            lblFront.Text = one;
            lblFront.Location = new Point (0,lblFront.Location.Y);
            lblBack.Location = new Point(picMap.Width - lblBack.Width, lblBack.Location.Y);
            int x= 0;

            double size = (picMap.Width - (lblFront.Width  + lblBack.Width + 3)) / colorScale.Length;
            for (double i = lblFront.Width + 3; i <= picMap.Width - (lblBack.Width + 3); i += size)
            {
                Rectangle r = new Rectangle((int)i, picMap.Height + 2, (int)size, 13);
                Pen p = new Pen(Color.Black, 1);
                p.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                if (x >= colorScale.Length) break;
                Color c = colorScale[x];
                //c = Color.FromArgb(255, c.R, c.G, c.B);
                SolidBrush b = new SolidBrush(c);
                g.FillRectangle(b,r);
                g.DrawRectangle(p, r);
                x++;
            }
            
        }
        private void makeScale(Color[] colorScale, int height, string one, string two) //for double lines
        {
            Graphics g = this.CreateGraphics();
            lblBack.Visible = true;
            lblBack2.Visible = true;
            lblFront.Visible = true;
            lblFront2.Visible = true;
            lblBack2.Text = two;
            lblFront2.Text = one;
            lblFront2.Location = new Point(0, lblFront2.Location.Y);
            lblBack2.Location = new Point(picMap.Width - lblBack2.Width, lblBack2.Location.Y);
            int x = 0;

            double size = (picMap.Width - (lblFront2.Width + lblBack2.Width + 3)) / colorScale.Length;
            for (double i = lblFront.Width + 3; i <= picMap.Width - (lblBack.Width + 3); i += size)
            {
                Rectangle r = new Rectangle((int)i, height + 2, (int)size, 13);
                Pen p = new Pen(Color.Black, 1);
                p.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                if (x >= colorScale.Length) break;
                Color c = colorScale[x];
                //c = Color.FromArgb(255, c.R, c.G, c.B);
                SolidBrush b = new SolidBrush(c);
                g.FillRectangle(b, r);
                g.DrawRectangle(p, r);
                x++;
            }
        }

        //Current Weather Info
        private void temperatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<City> temp = ListOfCities;
            btnSwitchUnits.Enabled = false;
            Graphics g = picMap.CreateGraphics();
            picMap.Refresh();
            picMap.Controls.Clear();

            foreach (City c in temp)
            {
                double temperatureText;
                string cityName;
                temperatureText = Math.Round(c.getCurrentTemperature(), MidpointRounding.ToEven);
                cityName = c.getName();
                if (isImperial)
                {
                    Label lab = c.placeLabel(cityName, temperatureText.ToString() + " F");
                    
                    picMap.Controls.Add(lab);
                }
                else
                    picMap.Controls.Add(c.placeLabel(cityName, temperatureText.ToString() + " C"));
            }

            

            for (int i = 0; i < this.Width; i += range)
            {
                for (int j = 0; j < this.Height; j += range)
                {
                    double minDist = 999.999;
                    int minPoint = 0;
                    for (int k = 0; k < labelPos.Length; k++)
                    {
                        if (Math.Sqrt(Math.Pow(labelPos[k].X - i, 2) + Math.Pow(labelPos[k].Y - j, 2)) < minDist)
                        {
                            minDist = Math.Sqrt(Math.Pow(labelPos[k].X - i, 2) + Math.Pow(labelPos[k].Y - j, 2));
                            minPoint = k;
                        }
                    }
                    int tempColor;
                    if (isImperial)
                        tempColor = (int)(ListOfCities[minPoint].currTemperature / 5);
                    else
                    {
                        tempColor = (int)(ListOfCities[minPoint].currTemperature / 5);
                    }
                    if (tempColor > 20) tempColor = 20;
                    Color colourTemp;
                    if (tempColor >= 0)
                    {
                        colourTemp = tempScale[tempColor];
                    }
                    else
                    {
                        tempColor = (int)(ListOfCities[minPoint].currTemperature / 10);
                        if (tempColor < -2) tempColor = -2;

                        colourTemp = tempScaleNeg[Math.Abs(tempColor)];
                    }


                    SolidBrush b = new SolidBrush(colourTemp);
                    Rectangle r = new Rectangle(i, j, range, range);
                    g.FillRectangle(b, r);

                }
            }
            

            makeScale(totalScaleTemp, "Frigid", "Blazin");
            DateTime now = DateTime.Now;
            lblLastUpdate.BackColor = Color.Transparent;
            lblLastUpdate.Text = "Last Updated: " + now.ToString();
            btnSwitchUnits.Enabled = true;           
        }
        private void windToolStripMenuItem_Click(object sender, EventArgs e)
        {
            picMap.Refresh();
            Graphics g = picMap.CreateGraphics();
            List<City> temp = ListOfCities;
            btnSwitchUnits.Enabled = false;

            picMap.Controls.Clear();

            

            foreach (City c in temp)
            {
                string infoText;
                string cityName;
                int windSpeed = (int)c.getWindSpeed();
                if (isImperial)
                    infoText = (windSpeed.ToString()) + " mph";
                else
                    infoText = (windSpeed.ToString()) + " kph";

                cityName = c.getName();
                Label l = c.placeLabel(cityName, infoText.ToString());
                l.Location = new Point(l.Location.X - 3, l.Location.Y);
                picMap.Controls.Add(l);

                //arrows
                int degreeForArrow = c.getWindDegree();

                if (degreeForArrow >= 180)
                    degreeForArrow -= 180;
                else
                    degreeForArrow += 180;

                int sides = 3;
                List<Point> triangle = new List<Point>();
                triangle.Clear();
                int len;
                if (windSpeed <= 10) len = 10;
                else if (windSpeed > 10 && windSpeed <= 30)
                    len = (int)(10 + .7 * (windSpeed - 10));
                else
                    len = 25;

                while (sides > 0)
                {
                    sides--;
                    if (sides == 2) degreeForArrow += 60;
                    else degreeForArrow += 150;

                    double anglex, angley;
                    anglex = Math.Cos(((degreeForArrow * 3.14) / 180));
                    angley = Math.Sin(((degreeForArrow * 3.14) / 180));

                    Point p = new Point((int)(l.Location.X + (l.Size.Width / 2) + len * anglex), (int)((l.Location.Y - 15) + len * angley));
                    triangle.Add(p);
                }
                g.FillPolygon(Brushes.Black, triangle.ToArray());
                
            }

            for (int i = 0; i < this.Width; i += range)
            {
                for (int j = 0; j < this.Height; j += range)
                {
                    double minDist = 999.999;
                    int minPoint = 0;
                    for (int k = 0; k < labelPos.Length; k++)
                    {
                        if (Math.Sqrt(Math.Pow(labelPos[k].X - i, 2) + Math.Pow(labelPos[k].Y - j, 2)) < minDist)
                        {
                            minDist = Math.Sqrt(Math.Pow(labelPos[k].X - i, 2) + Math.Pow(labelPos[k].Y - j, 2));
                            minPoint = k;
                        }
                    }
                    int tempColor;

                    tempColor = (int)(ListOfCities[minPoint].currWind / 10);

                    if (tempColor > 4) tempColor = 4;
                    Color colourTemp;
                    colourTemp = precipWind[tempColor];


                    SolidBrush b = new SolidBrush(colourTemp);
                    Rectangle r = new Rectangle(i, j, range, range);
                    g.FillRectangle(b, r);

                }
            }

            makeScale(precipWind, "Calm", "Gusty");

            DateTime now = DateTime.Now;
            lblLastUpdate.BackColor = Color.Transparent;
            lblLastUpdate.Text = "Last Updated: " + now.ToString();
            btnSwitchUnits.Enabled = true;
            picMap.SendToBack();
        }
        private void humidityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics g = picMap.CreateGraphics();
            picMap.Refresh();
            List<City> temp = ListOfCities;
            btnSwitchUnits.Enabled = false;

            picMap.Controls.Clear();

            foreach (City c in temp)
            {
                string infoText;
                string cityName;
                infoText = c.getHumidity().ToString() + "%";
                cityName = c.getName();
                picMap.Controls.Add(c.placeLabel(cityName, infoText.ToString()));
            }

            DateTime now = DateTime.Now;
            lblLastUpdate.Text = "Last Updated: " + now.ToString();
        }
        private void currentConditionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics g = picMap.CreateGraphics();
            picMap.Refresh();
            List<City> temp = ListOfCities;
            btnSwitchUnits.Enabled = false;
            lblBack.Visible = false;
            lblBack2.Visible = false;
            lblFront.Visible = false;
            lblFront2.Visible = false;

            picMap.Controls.Clear();

            foreach (City c in temp)
            {
                string cityName, iconURL;
                cityName = c.getName();
                picMap.Controls.Add(c.placeLabel(cityName));
                iconURL = c.getIcon();
                //creating a picturebox in a panel
                Panel pnl = new Panel();

                pnl.Size = new System.Drawing.Size(60, 60);
                int remainder = 60 - c.placeLabel(cityName).Size.Width;
                pnl.Location = new Point(c.placeLabel(cityName).Location.X - remainder / 2, c.placeLabel(cityName).Location.Y - 44);

                picMap.Controls.Add(pnl);

                PictureBox pc = new PictureBox();
                pc.SizeMode = PictureBoxSizeMode.Zoom;
                pc.Size = new Size(60, 60);

                //placing icon in picturebox
                //taken from https:stackoverflow.com/questions/28255438/programmatically-create-panel-and-add-picture-boxes
                try
                {
                    var request = WebRequest.Create(iconURL);
                    using (var response = request.GetResponse())
                    using (var stream = response.GetResponseStream())
                    {
                        pc.Image = Bitmap.FromStream(stream);
                    }
                    pnl.Controls.Add(pc);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error getting the images. Please try again later.", "ERROR");
                    break;
                }
            }

            DateTime now = DateTime.Now;
            lblLastUpdate.Text = "Last Updated: " + now.ToString();
        } 
        private void windChillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //35.74 + 0.6215T – 35.75(V ^ 0.16) + 0.4275T(V ^ 0.16)
            Graphics g = picMap.CreateGraphics();
            picMap.Refresh();
            List<City> temp = ListOfCities;
            btnSwitchUnits.Enabled = true;

            picMap.Controls.Clear();

            foreach (City c in temp)
            {
                int windChill;
                double windSpeed = c.getWindSpeed();
                string cityName;
                windChill = (int)c.getCurrentWindChill();
                cityName = c.getName();

                if (isImperial)
                    picMap.Controls.Add(c.placeLabel(cityName, windChill.ToString() + " F"));
                else
                {
                    picMap.Controls.Add(c.placeLabel(cityName, windChill.ToString() + " C"));
                }
            }

            for (int i = 0; i < this.Size.Width; i += range)
            {
                for (int j = 0; j < this.Size.Height; j += range)
                {
                    double minDist = 9999.999;
                    int minPoint = 0;
                    for (int k = 0; k < labelPos.Length; k++)
                    {
                        if (Math.Sqrt(Math.Pow(labelPos[k].X - i, 2) + Math.Pow(labelPos[k].Y - j, 2)) < minDist)
                        {
                            minDist = Math.Sqrt(Math.Pow(labelPos[k].X - i, 2) + Math.Pow(labelPos[k].Y - j, 2));
                            minPoint = k;
                        }
                    }

                    int tempColor;
                    if (isImperial)
                        tempColor = (int)(ListOfCities[minPoint].currWindChill / 5);
                    else
                    {
                        tempColor = (int)(ListOfCities[minPoint].currWindChill / 5);
                    }
                    if (tempColor > 20) tempColor = 20;
                    Color colourTemp;
                    if (tempColor >= 0)
                    {
                        colourTemp = tempScale[tempColor];
                    }
                    else
                    {
                        tempColor = (int)(ListOfCities[minPoint].currWindChill / 10);
                        if (tempColor < -2) tempColor = -2;

                        colourTemp = tempScaleNeg[Math.Abs(tempColor)];
                    }
                    SolidBrush b = new SolidBrush(colourTemp);
                    Rectangle r = new Rectangle(i, j, range, range);
                    g.FillRectangle(b, r);
                }
            }

            makeScale(totalScaleTemp, "Cold" , "Hot");
            DateTime now = DateTime.Now;
            lblLastUpdate.Text = "Last Updated: " + now.ToString();
            btnSwitchUnits.Enabled = true;
        }
        private void cloudCoverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<City> temp = ListOfCities;
            btnSwitchUnits.Enabled = false;

            Graphics g = picMap.CreateGraphics();
            picMap.Refresh();
            picMap.Controls.Clear();


            foreach (City c in temp)
            {
                int cloudText;
                string cityName, cloudType;
                cloudText = c.getCloudCover();
                cityName = c.getName();
                //cloudType = c.getCloudCoverType();
                picMap.Controls.Add(c.placeLabel(cityName));
            }

            for (int i = 0; i < this.Width; i += range)
            {
                for (int j = 0; j < this.Height; j += range)
                {
                    double minDist = 999.999;
                    int minPoint = 0;
                    for (int k = 0; k < labelPos.Length; k++)
                    {
                        if (Math.Sqrt(Math.Pow(labelPos[k].X - i, 2) + Math.Pow(labelPos[k].Y - j, 2)) < minDist)
                        {
                            minDist = Math.Sqrt(Math.Pow(labelPos[k].X - i, 2) + Math.Pow(labelPos[k].Y - j, 2));
                            minPoint = k;
                        }
                    }
                    int hue = (int)(temp[minPoint].currCloud * 1.75);
                    Color c = Color.FromArgb(hue, 100, 100, 100);
                    SolidBrush b = new SolidBrush(c);
                    Rectangle r = new Rectangle(i, j, range, range);
                    g.FillRectangle(b, r);

                }
            }

            makeScale(cloudScale, "Clear", "Covered");
            DateTime now = DateTime.Now;
            lblLastUpdate.BackColor = Color.Transparent;
            lblLastUpdate.Text = "Last Updated: " + now.ToString();
            btnSwitchUnits.Enabled = false;   
        }

        //Changing the units
        private void btnSwitchUnits_Click(object sender, EventArgs e)
        {
            if (isImperial)
            {
                isImperial = false;
                lblUnitType.Text = "Current Units: Metric";
                foreach (Label l in picMap.Controls.OfType<Label>())
                {
                    try
                    {
                        if (!l.Name.Contains("Update") && !l.Name.Contains("UnitType"))
                        {
                            if (l.Text.Contains("mph"))
                            {
                                string textOnLabel = l.Text;
                                string textForSpeed = textOnLabel.Substring(textOnLabel.IndexOf(" ") + 1);
                                double changeSpeed = Convert.ToDouble(textForSpeed.Substring(0, textForSpeed.IndexOf(" ")));
                                changeSpeed *= 1.6;
                                l.Text = (Math.Round(changeSpeed, MidpointRounding.ToEven).ToString() + textOnLabel.Substring(textOnLabel.IndexOf("mph")));
                                l.Text = l.Text.Replace("mph", " kph");

                            }
                            else if (l.Text.Contains("hPa"))
                            {
                                string textOnLabel = l.Text;
                                double changePressure = Convert.ToDouble(textOnLabel.Substring(0, textOnLabel.IndexOf(" ")));
                                changePressure /= 1013.25;
                                l.Text = String.Format("{0:0.000}", changePressure) + textOnLabel.Substring(textOnLabel.IndexOf("hPa"));
                                l.Text = l.Text.Replace("hPa", " atm");

                            }
                            else if (l.Text.Contains("in."))
                            {
                                string textOnLabel = l.Text;
                                double changePrecip = Convert.ToDouble(textOnLabel.Substring(0, textOnLabel.IndexOf(" ")));
                                changePrecip *= 25.4;
                                l.Text = String.Format("{0:0.00}", changePrecip) + textOnLabel.Substring(textOnLabel.IndexOf("in."));
                                l.Text = l.Text.Replace("in.", " mm");
                            }
                            else
                            {
                                double changeTemp;
                                string textOnLabel = l.Text;
                                changeTemp = Convert.ToDouble(textOnLabel.Substring(0, textOnLabel.IndexOf(" ")));
                                changeTemp = (changeTemp - 32.0) * (5.0 / 9.0);
                                l.Text = (Math.Round(changeTemp, MidpointRounding.ToEven).ToString() + " C" + textOnLabel.Substring(textOnLabel.IndexOf("F") + 1));
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error in converting");
                        break; //keep same unit when error?
                    }

                }
            }
            else
            {
                isImperial = true;
                lblUnitType.Text = "Current Units: Imperial";
                foreach (Label l in picMap.Controls.OfType<Label>())
                {
                    try
                    {
                        if (!l.Name.Contains("Update") && !l.Name.Contains("UnitType"))
                        {
                            if (l.Text.Contains("kph"))
                            {
                                string textOnLabel = l.Text;
                                string textForSpeed = textOnLabel.Substring(textOnLabel.IndexOf(" ") + 1);
                                double changeSpeed = Convert.ToDouble(textForSpeed.Substring(0, textForSpeed.IndexOf(" ")));
                                changeSpeed /= 1.6; //casting error
                                l.Text = ((Math.Round(changeSpeed, MidpointRounding.ToEven).ToString() + textOnLabel.Substring(textOnLabel.IndexOf("kph"))));
                                l.Text = l.Text.Replace("kph", " mph");

                            }
                            else if (l.Text.Contains("atm"))
                            {
                                string textOnLabel = l.Text;
                                double changePressure = Convert.ToDouble(textOnLabel.Substring(0, textOnLabel.IndexOf(" ")));
                                changePressure *= 1013.25;
                                changePressure = (int)changePressure;
                                l.Text = (changePressure).ToString() + textOnLabel.Substring(textOnLabel.IndexOf("atm"));
                                l.Text = l.Text.Replace("atm", " hPa");

                            }
                            else if (l.Text.Contains("mm"))
                            {
                                string textOnLabel = l.Text;
                                double changePrecip = Convert.ToDouble(textOnLabel.Substring(0, textOnLabel.IndexOf(" ")));
                                changePrecip /= 25.4;
                                l.Text = String.Format("{0:0.00}", changePrecip) + textOnLabel.Substring(textOnLabel.IndexOf("mm"));
                                l.Text = l.Text.Replace("mm", " in.");
                            }
                            else
                            {
                                double changeTemp;
                                string textOnLabel = l.Text;
                                changeTemp = Convert.ToInt32(textOnLabel.Substring(0, textOnLabel.IndexOf(" ")));
                                changeTemp = changeTemp * 1.8 + 32.0;
                                l.Text = (Math.Round(changeTemp, MidpointRounding.ToEven).ToString() + " F" + textOnLabel.Substring(textOnLabel.IndexOf("C") + 1));
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error in converting");
                        break; //keep same unit when error?
                    }

                }
            }
        }

        //forecasting
        private void displayForecastHigh(int daysFromToday)
        {
            DateTime now = DateTime.Now;
            var checkDate = now.Date.AddDays(daysFromToday);
            btnSwitchUnits.Enabled = false;
            Graphics g = picMap.CreateGraphics();
            picMap.Refresh();
            List<City> temp = ListOfCities;

            picMap.Controls.Clear();

            foreach (City c in temp)
            {
                int highTemp = c.getHighForecast(checkDate);
                string cityName = c.getName();
                if (isImperial)
                    picMap.Controls.Add(c.placeLabel(cityName, highTemp.ToString() + " F"));
                else
                {
                    picMap.Controls.Add(c.placeLabel(cityName, highTemp.ToString() + " C"));
                }
            }

            for (int i = 0; i < this.Size.Width; i += range)
            {
                for (int j = 0; j < this.Size.Height; j += range)
                {
                    double minDist = 9999.999;
                    int minPoint = 0;
                    for (int k = 0; k < labelPos.Length; k++)
                    {
                        if (Math.Sqrt(Math.Pow(labelPos[k].X - i, 2) + Math.Pow(labelPos[k].Y - j, 2)) < minDist)
                        {
                            minDist = Math.Sqrt(Math.Pow(labelPos[k].X - i, 2) + Math.Pow(labelPos[k].Y - j, 2));
                            minPoint = k;
                        }
                    }
                    int tempColor;
                    if (isImperial)
                        tempColor = (int)(ListOfCities[minPoint].forecastHigh / 5);
                    else
                    {
                        tempColor = (int)(ListOfCities[minPoint].forecastHigh / 5);
                    }
                    if (tempColor > 20) tempColor = 20;
                    Color colourTemp;
                    if (tempColor >= 0)
                    {
                        colourTemp = tempScale[tempColor];
                    }
                    else
                    {
                        tempColor = (int)(ListOfCities[minPoint].forecastHigh / 10);
                        if (tempColor < -2) tempColor = -2;

                        colourTemp = tempScaleNeg[Math.Abs(tempColor)];
                    }
                    SolidBrush b = new SolidBrush(colourTemp);
                    Rectangle r = new Rectangle(i, j, range, range);
                    g.FillRectangle(b, r);
                }
            }

            makeScale(totalScaleTemp, "Cold", "Hot");
            lblLastUpdate.Text = "Last Updated: " + now.ToString();
            btnSwitchUnits.Enabled = true;
        }
        private void displayForecastLow(int daysFromToday)
        {
            DateTime now = DateTime.Now;
            var dateOfTmr = now.Date.AddDays(daysFromToday);
            btnSwitchUnits.Enabled = false;
            Graphics g = picMap.CreateGraphics();
            picMap.Refresh();
            List<City> temp = ListOfCities;

            picMap.Controls.Clear();

            foreach (City c in temp)
            {
                int lowTemp = c.getLowForecast(dateOfTmr);
                string cityName = c.getName();
                if (isImperial)
                    picMap.Controls.Add(c.placeLabel(cityName, lowTemp.ToString() + " F"));
                else
                    picMap.Controls.Add(c.placeLabel(cityName, lowTemp.ToString() + " C"));
            }

            for (int i = 0; i < this.Size.Width; i += range)
            {
                for (int j = 0; j < this.Size.Height; j += range)
                {
                    double minDist = 9999.999;
                    int minPoint = 0;
                    for (int k = 0; k < labelPos.Length; k++)
                    {
                        if (Math.Sqrt(Math.Pow(labelPos[k].X - i, 2) + Math.Pow(labelPos[k].Y - j, 2)) < minDist)
                        {
                            minDist = Math.Sqrt(Math.Pow(labelPos[k].X - i, 2) + Math.Pow(labelPos[k].Y - j, 2));
                            minPoint = k;
                        }
                    }
                    int tempColor;
                    if (isImperial)
                        tempColor = (int)(ListOfCities[minPoint].forecastLow / 5);
                    else
                    {
                        tempColor = (int)(ListOfCities[minPoint].forecastLow / 5);
                    }
                    if (tempColor > 20) tempColor = 20;
                    Color colourTemp;
                    if (tempColor >= 0)
                    {
                        colourTemp = tempScale[tempColor];
                    }
                    else
                    {
                        tempColor = (int)(ListOfCities[minPoint].forecastLow / 10);
                        if (tempColor < -2) tempColor = -2;

                        colourTemp = tempScaleNeg[Math.Abs(tempColor)];
                    }
                    SolidBrush b = new SolidBrush(colourTemp);
                    Rectangle r = new Rectangle(i, j, range, range);
                    g.FillRectangle(b, r);
                }
            }
            makeScale(totalScaleTemp, "Cold", "Hot");
            lblLastUpdate.Text = "Last Updated: " + now.ToString();
            btnSwitchUnits.Enabled = true;
        }
        private void displayForecastWeather(int daysFromToday)
        {
            Graphics g = picMap.CreateGraphics();
            picMap.Refresh();
            List<City> temp = ListOfCities;
            btnSwitchUnits.Enabled = false;
            DateTime now = DateTime.Now;
            now = now.AddDays(daysFromToday);
            lblBack.Visible = false;
            lblBack2.Visible = false;
            lblFront.Visible = false;
            lblFront2.Visible = false;

            picMap.Controls.Clear();

            foreach (City c in temp)
            {
                string cityName, iconURL;
                cityName = c.getName();
                picMap.Controls.Add(c.placeLabel(cityName));
                iconURL = c.getIconForecast(now);
                //creating a picturebox in a panel
                Panel pnl = new Panel();

                pnl.Size = new System.Drawing.Size(60, 60);
                int remainder = 60 - c.placeLabel(cityName).Size.Width;
                pnl.Location = new Point(c.placeLabel(cityName).Location.X - remainder / 2, c.placeLabel(cityName).Location.Y - 44);

                picMap.Controls.Add(pnl);

                PictureBox pc = new PictureBox();
                pc.SizeMode = PictureBoxSizeMode.Zoom;
                pc.Size = new Size(60, 60);

                //placing icon in picturebox
                //taken from https:stackoverflow.com/questions/28255438/programmatically-create-panel-and-add-picture-boxes
                try
                {
                    var request = WebRequest.Create(iconURL);
                    using (var response = request.GetResponse())
                    using (var stream = response.GetResponseStream())
                    {
                        pc.Image = Bitmap.FromStream(stream);
                    }
                    pnl.Controls.Add(pc);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error getting the images. Please try again later.", "ERROR");
                    break;
                }
            }
            lblLastUpdate.Text = "Last Updated: " + now.ToString();
        }
        private void displayForecastPrecip(int daysFromToday)
        {
            DateTime now = DateTime.Now;
            var checkDate = now.Date.AddDays(daysFromToday);
            btnSwitchUnits.Enabled = false;
            Graphics g = picMap.CreateGraphics();
            List<City> temp = ListOfCities;
            picMap.Refresh();

            picMap.Controls.Clear();

            foreach (City c in temp)
            {
                double precip = c.getPrecipForecast(checkDate);
                string precipType = c.getPrecipType(checkDate);
                string cityName = c.getName();

                if (isImperial)
                    picMap.Controls.Add(c.placeLabel(cityName, String.Format("{0:0.00}", precip) + " in."));
                else
                {
                    picMap.Controls.Add(c.placeLabel(cityName, String.Format("{0:0.00}", precip) + " mm"));
                }
            }

            //coloring for precip
            for (int i = 0; i < this.Size.Width; i += range)
            {
                for (int j = 0; j < this.Size.Height; j += range)
                {
                    double minDist = 9999.999;
                    int minPoint = 0;
                    for (int k = 0; k < labelPos.Length; k++)
                    {
                        if (Math.Sqrt(Math.Pow(labelPos[k].X - i, 2) + Math.Pow(labelPos[k].Y - j, 2)) < minDist)
                        {
                            minDist = Math.Sqrt(Math.Pow(labelPos[k].X - i, 2) + Math.Pow(labelPos[k].Y - j, 2));
                            minPoint = k;
                        }
                    }
                    int precipcolour = 0;
                    double check = ListOfCities[minPoint].forecastPrecip;
                    Color colorPrecip;
                    if (ListOfCities[minPoint].precipType.Equals("rain"))
                    {
                        if (check <= 0)
                        {
                            colorPrecip = Color.Transparent;
                        }
                        else
                        {
                            if (check < .5 && check > 0) precipcolour = 0;
                            if (check >= .5 && check < 1) precipcolour = 1;
                            if (check >= 1 && check < 2) precipcolour = 2;
                            if (check >= 2 && check < 3) precipcolour = 3;
                            if (check >= 3) precipcolour = 4;

                            colorPrecip = precipScaleRain[precipcolour];
                        }
                    }
                    else if (ListOfCities[minPoint].precipType.Equals("snow"))
                    {
                        if (check <= 0)
                        {
                            colorPrecip = Color.Transparent;
                        }
                        else
                        {
                            if (check < .5 && check > 0) precipcolour = 0;
                            if (check >= .5 && check < 1) precipcolour = 1;
                            if (check >= 1 && check < 3) precipcolour = 2;
                            if (check >= 3 && check < 6) precipcolour = 3;
                            if (check >= 6 && check < 9) precipcolour = 4;
                            if (check >= 9) precipcolour = 5;

                            colorPrecip = precipScaleSnow[precipcolour];
                        }
                    }
                    else {
                        colorPrecip = Color.Transparent;
                    }
                    
                    SolidBrush b = new SolidBrush(colorPrecip);
                    Rectangle r = new Rectangle(i, j, range, range);
                    g.FillRectangle(b, r);
                }
            }

            makeScale(precipScaleRain, "No Rain", "Wall of Water");
            makeScale(precipScaleSnow, picMap.Height + 20, "No Snow", "Sky of Snow");
            lblLastUpdate.Text = "Last Updated: " + now.ToString();
            btnSwitchUnits.Enabled = true;
        }
        private void highTemperatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayForecastHigh(0);   
        }
        private void highTemperatureToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            displayForecastHigh(1);
        }
        private void highTemperatureToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            displayForecastHigh(2);
        }
        private void lowTemperatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayForecastLow(0);
        }
        private void lowTemperatureToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            displayForecastLow(1);
        }
        private void lowTemperatureToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            displayForecastLow(2);
        }        
        private void weatherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayForecastWeather(0);
        }
        private void weatherToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            displayForecastWeather(1);
        }
        private void weatherToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            displayForecastWeather(2);
        }
        private void precipitationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayForecastPrecip(0);
        }
        private void precipitationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            displayForecastPrecip(1);
        }
        private void precipitationToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            displayForecastPrecip(2);
        }

        //radar
        int timeForRadar = 0;
        private void futurePrecipitationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<City> temp = new List<City>();
            temp = ListOfCities;
            Graphics g = picMap.CreateGraphics();

            picMap.Controls.Clear();

            foreach (City c in ListOfCities)
            {
                c.getPrecipRadar();
                c.getPrecipTypeRadar();
                picMap.Controls.Add(c.placeLabel(c.getName()));
            }

            ListOfCities[0].getPrecipTimeRadar();
            timeForRadar = 0;
            tmrRadar.Enabled = true;
            makeScale(precipScaleRain, "No Rain", "Wall of Water");
            makeScale(precipScaleSnow, picMap.Height + 20, "No Snow","Sky of Snow");

        }
        private void tmrRadar_Tick(object sender, EventArgs e)
        {
            int rangeForRadar = 15;
            Graphics g = picMap.CreateGraphics();
            picMap.Refresh();
            //coloring for precip
            for (int i = 0; i < this.Size.Width; i += rangeForRadar)
            {
                for (int j = 0; j < this.Size.Height; j += rangeForRadar)
                {
                    double minDist = 9999.999;
                    int minPoint = 0;
                    for (int k = 0; k < labelPos.Length; k++)
                    {
                        if (Math.Sqrt(Math.Pow(labelPos[k].X - i, 2) + Math.Pow(labelPos[k].Y - j, 2)) < minDist)
                        {
                            minDist = Math.Sqrt(Math.Pow(labelPos[k].X - i, 2) + Math.Pow(labelPos[k].Y - j, 2));
                            minPoint = k;
                        }
                    }
                    int precipcolour = 0;
                    double check = ListOfCities[minPoint].precipRadarList[timeForRadar % 8];
                    Color colorPrecip;
                    if (ListOfCities[minPoint].precipRadarTypeList[timeForRadar%8].Equals("rain"))
                    {
                        if (check <= 0)
                        {
                            colorPrecip = Color.Transparent;
                        }
                        else
                        {
                            if (check < .5 && check > 0) precipcolour = 0;
                            if (check >= .5 && check < 1) precipcolour = 1;
                            if (check >= 1 && check < 2) precipcolour = 2;
                            if (check >= 2 && check < 3) precipcolour = 3;
                            if (check >= 3) precipcolour = 4;

                            colorPrecip = precipScaleRain[precipcolour];
                        }
                    }
                    else if (ListOfCities[minPoint].precipRadarTypeList[timeForRadar % 8].Equals("snow"))
                    {
                        if (check <= 0)
                        {
                            colorPrecip = Color.Transparent;
                        }
                        else
                        {
                            if (check < .5 && check > 0) precipcolour = 0;
                            if (check >= .5 && check < 1) precipcolour = 1;
                            if (check >= 1 && check < 3) precipcolour = 2;
                            if (check >= 3 && check < 6) precipcolour = 3;
                            if (check >= 6 && check < 9) precipcolour = 4;
                            if (check >= 9) precipcolour = 5;

                            colorPrecip = precipScaleSnow[precipcolour];
                        }
                    }
                    else
                    {
                        colorPrecip = Color.Transparent;
                    }

                    SolidBrush b = new SolidBrush(colorPrecip);
                    Rectangle r = new Rectangle(i, j, rangeForRadar, rangeForRadar);
                    g.FillRectangle(b, r);
                }
            }
            String time =  ListOfCities[0].precipRadarTimeList[timeForRadar % 8];

            lblLastUpdate.Text = "Time: " + time;
            timeForRadar++;
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (!e.ClickedItem.Name.Equals("futurePrecipitationToolStripMenuItem"))
                tmrRadar.Enabled = false;
            if (!e.ClickedItem.Name.Equals("futureCloudCoverToolStripMenuItem"))
                tmrCloud.Enabled = false;
            
        } //stops the radars
        private void futureCloudCoverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<City> temp = new List<City>();
            temp = ListOfCities;
            Graphics g = picMap.CreateGraphics();

            picMap.Controls.Clear();

            foreach (City c in ListOfCities)
            {
                c.getCloudRadar();
                c.getCloudTimeRadar();
                picMap.Controls.Add(c.placeLabel(c.getName()));
            }

            ListOfCities[0].getCloudTimeRadar();
            timeForRadar = 0;
            tmrCloud.Enabled = true;
            makeScale(cloudScale, "Clear", "Covered");
        }
        private void tmrCloud_Tick(object sender, EventArgs e)
        {
            int rangeForRadar = 15;
            Graphics g = picMap.CreateGraphics();
            picMap.Refresh();
            //coloring for cloud
            for (int i = 0; i < this.Size.Width; i += rangeForRadar)
            {
                for (int j = 0; j < this.Size.Height; j += rangeForRadar)
                {
                    double minDist = 9999.999;
                    int minPoint = 0;
                    for (int k = 0; k < labelPos.Length; k++)
                    {
                        if (Math.Sqrt(Math.Pow(labelPos[k].X - i, 2) + Math.Pow(labelPos[k].Y - j, 2)) < minDist)
                        {
                            minDist = Math.Sqrt(Math.Pow(labelPos[k].X - i, 2) + Math.Pow(labelPos[k].Y - j, 2));
                            minPoint = k;
                        }
                    }
                    double check = ListOfCities[minPoint].cloudRadarList[timeForRadar % 8];
                    check *= 1.75;
                    Color colorForCloudCover;
                    colorForCloudCover = Color.FromArgb((int)check, 100, 100, 100);

                    SolidBrush b = new SolidBrush(colorForCloudCover);
                    Rectangle r = new Rectangle(i, j, rangeForRadar, rangeForRadar);
                    g.FillRectangle(b, r);
                }
            }
            String time = ListOfCities[0].cloudRadarTimeList[timeForRadar % 8];

            lblLastUpdate.Text = "Time: " + time;
            timeForRadar++;
        }

        //switching current map
        private void eNebraskaWIowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            picMap.Image = Weather_Application.Properties.Resources.Possible_Map2;
        }

        private void picMap_Click(object sender, EventArgs e)
        {

        }

        private void uSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            picMap.Image = Weather_Application.Properties.Resources.usa_35713_960_7201;
        }

       
    }
}
