using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.IO;
using System.Net;
using System.Windows.Forms.Design;
namespace Weather_Application
{
    class City
    {
        private string cityName, urlForCurrent, iconUrl, urlForForecast, urlForRadar;
        public int zipCode, xPos, yPos, currCloud;
        public double currTemperature, currWind, currPressure, forecastHigh, forecastLow, forecastPrecip, currWindChill;
        private Label l = new Label();
        public string precipType, currCloudType;
        public List<double> precipRadarList;
        public List<string> precipRadarTypeList, precipRadarTimeList;
        public List<double> cloudRadarList;
        public List<string> cloudRadarTimeList;

        private const String CurrentUrl = "http://api.openweathermap.org/data/2.5/weather?" + "zip=@LOC@&mode=xml&units=imperial&APPID=@API@";
        private const string iIconUrl = "http://openweathermap.org/img/w/@PIC@.png";
        private const string ForecastUrl = "http://api.openweathermap.org/data/2.5/forecast/daily?zip=@LOC@&mode=xml&units=imperial&APPID=@API@";
        private string APIKEY = "434bec562fd0bc83a9abed6b6832ebaa"; //17cbc04997e5385ac63f75826f48685a
        private const string RadarUrl = "http://api.openweathermap.org/data/2.5/forecast?" + "zip=@LOC@&mode=xml&units=imperial&APPID=@API@";

        public City(int zip, int x, int y)
        {
            zipCode = zip;
            xPos = x;
            yPos = y;
            urlForCurrent = CurrentUrl.Replace("@LOC@", zipCode.ToString());
            urlForForecast = ForecastUrl.Replace("@LOC@", zipCode.ToString());
            urlForCurrent = urlForCurrent.Replace("@API@", APIKEY);
            urlForForecast = urlForForecast.Replace("@API@", APIKEY);
            urlForRadar = RadarUrl.Replace("@LOC@", zipCode.ToString());
            urlForRadar = urlForRadar.Replace("@API@", APIKEY);
            int a = 1;
        }

        public void updatePoint(int x, int y)
        {
            xPos = x;
            yPos = y;
        }

        public Label placeLabel(string name, string info)
        {
            l.Location = new Point(xPos, yPos);
            l.Text = info + "\n" + name;
            l.Font = new Font(SystemFonts.DefaultFont.FontFamily, 9);
            l.TextAlign = ContentAlignment.MiddleCenter;
            l.AutoSize = true;
            l.BackColor = Color.Transparent;
            return l;
        }

        public Label placeLabel(string name)
        {
            l.Location = new Point(xPos, yPos + 10);
            l.Text =  name;
            l.Font = new Font(SystemFonts.DefaultFont.FontFamily, 9);
            l.TextAlign = ContentAlignment.MiddleCenter;
            l.AutoSize = true;
            l.BackColor = Color.Transparent;
            return l;
        }

        public double getCurrentTemperature()
        {
            WeatherAPI weatherAPI = new WeatherAPI(urlForCurrent);
            currTemperature = (double)weatherAPI.getTemperature();
            if (Weather.isImperial)
                return currTemperature;
            else
                return ((currTemperature - 32) * 5 / 9);
        }

        public double getCurrentWindChill()
        {
            WeatherAPI weatherAPI = new WeatherAPI(urlForCurrent);
            currTemperature = (double)weatherAPI.getTemperature();
            currWindChill = (35.74 + .6215 * currTemperature - 35.75 * Math.Pow(getWindSpeed(), .16) + .4275 * currTemperature * Math.Pow(getWindSpeed(), .16));
            if (Weather.isImperial)
                return currWindChill;
            else
                return ((currWindChill - 32) * 5 / 9);
        }
        public double getWindSpeed()
        {
            WeatherAPI weatherAPI = new WeatherAPI(urlForCurrent);
            currWind = (double)weatherAPI.getWindSpeed();
            if (Weather.isImperial)
                return currWind;
            else
                return currWind * 1.6;
        }

        public string getWindDir()
        {
            WeatherAPI weatherAPI = new WeatherAPI(urlForCurrent);
            return weatherAPI.getWindDir();
        }

        public int getWindDegree()
        {
            WeatherAPI weatherAPI = new WeatherAPI(urlForCurrent);
            return (int)weatherAPI.getWindDegree();
        }

        public int getHumidity()
        {
            WeatherAPI weatherAPI = new WeatherAPI(urlForCurrent);
            return (int)weatherAPI.getHumidity();
        }

        public double getPressure()
        {
            WeatherAPI weatherAPI = new WeatherAPI(urlForCurrent);
            currPressure = weatherAPI.getPressure();
            if (Weather.isImperial)
                return currPressure;
            else
                return (double)(currPressure / 1013.25);
        }

        public int getCloudCover()
        {
            WeatherAPI weatherAPI = new WeatherAPI(urlForCurrent);
            currCloud = (int)weatherAPI.getCloudCover();
            return currCloud;
        }

        public string getCloudCoverType()
        {
            WeatherAPI weatherAPI = new WeatherAPI(urlForCurrent);
            currCloudType = weatherAPI.getCloudType();
            return currCloudType;
        }

        public DateTime getLastUpdate()
        {
            WeatherAPI weatherAPI = new WeatherAPI(urlForCurrent);
            string dt = weatherAPI.getLastUpdate();
            DateTime oDate = Convert.ToDateTime(dt);
            return oDate;
        }

        public string getIcon()
        {
            WeatherAPI weatherAPI = new WeatherAPI(urlForCurrent);
            string icon = weatherAPI.getIcon();
            iconUrl = iIconUrl.Replace("@PIC@", icon);
            return iconUrl;   
        }

        public string getIconForecast(DateTime d)
        {
            string dateOfChecking = d.ToString("yyyy-MM-dd");
            WeatherAPI weatherAPI = new WeatherAPI(urlForForecast);
            string icon = weatherAPI.getIconForecast(dateOfChecking);
            iconUrl = iIconUrl.Replace("@PIC@", icon);
            return iconUrl;
        }

        public String getName()
        {
            return cityName;
        }

        public void setName(string name)
        {
            cityName = name;
        }

        public int getHighForecast(DateTime date)
        {
            WeatherAPI weatherAPI = new WeatherAPI(urlForForecast);
            string dateOfChecking;
            dateOfChecking = date.ToString("yyyy-MM-dd");
            forecastHigh = weatherAPI.getForecastTemperature(dateOfChecking, "max");
            if (Weather.isImperial)
                return (int)forecastHigh;
            else
                return (int)((forecastHigh - 32) * (5.0 / 9.0));
        }

        public int getLowForecast(DateTime date)
        {
            WeatherAPI weatherAPI = new WeatherAPI(urlForForecast);
            string dateOfChecking;
            dateOfChecking = date.ToString("yyyy-MM-dd");
            forecastLow = weatherAPI.getForecastTemperature(dateOfChecking, "min");
            
            if (Weather.isImperial)
                return (int)forecastLow;
            else
                return (int)((forecastLow - 32) * (5.0 / 9.0));
        }

        public double getPrecipForecast(DateTime date)
        {
            WeatherAPI weatherAPI = new WeatherAPI(urlForForecast);
            string dateOfChecking;
            dateOfChecking = date.ToString("yyyy-MM-dd");
            forecastPrecip = weatherAPI.getForecastPrecipitation(dateOfChecking);

            if (Weather.isImperial)
                return forecastPrecip;
            else
                return forecastPrecip * 25.4;
        }

        public string getPrecipType(DateTime date)
        {
            WeatherAPI weatherAPI = new WeatherAPI(urlForForecast);
            string dateOfChecking;
            dateOfChecking = date.ToString("yyyy-MM-dd");
            precipType = weatherAPI.getForecastType(dateOfChecking);

            return precipType;
        }

        public List<double> getPrecipRadar()
        {
            WeatherAPI weatherAPI = new WeatherAPI(urlForRadar);
            precipRadarList = weatherAPI.getPrecipList();
            return precipRadarList;
        }

        public List<string> getPrecipTypeRadar()
        {
            WeatherAPI weatherAPI = new WeatherAPI(urlForRadar);
            precipRadarTypeList = weatherAPI.getPrecipTypeList();
            return precipRadarTypeList;
        }

        public List<string> getPrecipTimeRadar()
        {
            WeatherAPI weatherAPI = new WeatherAPI(urlForRadar);
            precipRadarTimeList = weatherAPI.getPrecipRadarTimeList();
            return precipRadarTimeList;
        }

        public List<double> getCloudRadar()
        {
            WeatherAPI weatherAPI = new WeatherAPI(urlForRadar);
            cloudRadarList = weatherAPI.getCloudRadarList();
            return cloudRadarList;
        }

        public List<string> getCloudTimeRadar()
        {
            WeatherAPI weatherAPI = new WeatherAPI(urlForRadar);
            cloudRadarTimeList = weatherAPI.getCloudTimeList();
            return cloudRadarTimeList;
        }
    }
}
