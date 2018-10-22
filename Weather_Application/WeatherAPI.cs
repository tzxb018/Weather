using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Weather_Application
{
    class WeatherAPI
    {
        private string www;
        private XmlDocument doc;

        public WeatherAPI(string URL)
        {
            www = URL;
            doc = GetXML(www);
        }

        private XmlDocument GetXML(string url)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    string xml = client.DownloadString(url);
                    XmlDocument xml_document = new XmlDocument();
                    xml_document.LoadXml(xml);
                    return xml_document;
                }
                catch (Exception ex)
                {
                    try
                    {
                        string xml = client.DownloadString(url.Replace("434bec562fd0bc83a9abed6b6832ebaa", "17cbc04997e5385ac63f75826f48685a"));
                        XmlDocument xml_document = new XmlDocument();
                        xml_document.LoadXml(xml);
                        return xml_document;
                    }
                    catch(Exception exc)
                    {
                        MessageBox.Show("Data could not be retrieved. Make sure you are connected to the internet and try again.", "ERROR");
                        return null;
                    }
                    
                }
            }
        }

        public float getTemperature()
        {
            XmlNode temperatureNode = doc.SelectSingleNode("//temperature");
            XmlAttribute temperatureValue = temperatureNode.Attributes["value"];
            string temperatureString = temperatureValue.Value;
            return float.Parse(temperatureString);
        }

        public float getHigh()
        {
            XmlNode temperatureNode = doc.SelectSingleNode("//temperature");
            XmlAttribute temperatureValue = temperatureNode.Attributes["max"];
            string temperatureString = temperatureValue.Value;
            return float.Parse(temperatureString);
        }

        public float getLow()
        {
            XmlNode temperatureNode = doc.SelectSingleNode("//temperature");
            XmlAttribute temperatureValue = temperatureNode.Attributes["min"];
            string temperatureString = temperatureValue.Value;
            return float.Parse(temperatureString);
        }

        public float getWindSpeed()
        {
            XmlNode node = doc.SelectSingleNode("//speed");
            XmlAttribute att = node.Attributes["value"];
            string ot = att.Value;
            return float.Parse(ot);
        }

        public string getWindDir()
        {
            XmlNode node = doc.SelectSingleNode("//direction");
            XmlAttribute att = node.Attributes["code"];
            string ot = att.Value;
            return ot;
        }

        public float getWindDegree()
        {
            XmlNode node = doc.SelectSingleNode("//direction");
            XmlAttribute a = node.Attributes["value"];
            return float.Parse(a.Value);
        }

        public float getHumidity()
        {
            XmlNode node = doc.SelectSingleNode("//humidity");
            XmlAttribute att = node.Attributes["value"];
            string ot = att.Value;
            return float.Parse(ot);
        }

        public float getPressure()
        {
            XmlNode node = doc.SelectSingleNode("//pressure");
            XmlAttribute att = node.Attributes["value"];
            string ot = att.Value;
            return float.Parse(ot);
        }

        public float getCloudCover()
        {
            XmlNode node = doc.SelectSingleNode("//clouds");
            XmlAttribute att = node.Attributes["value"];
            string ot = att.Value;
            return float.Parse(ot);
        }

        public string getCloudType()
        {
            XmlNode node = doc.SelectSingleNode("//clouds");
            XmlAttribute att = node.Attributes["name"];
            string ot = att.Value;
            return ot;
        }

        public string getCityName()
        {
            XmlNode CityNode = doc.SelectSingleNode("//city");
            XmlAttribute cityVal = CityNode.Attributes["name"];
            string cityString = cityVal.Value;
            return cityString;
        }

        public string getLastUpdate()
        {
            XmlNode node = doc.SelectSingleNode("//lastupdate");
            XmlAttribute att = node.Attributes["value"];
            string dt = att.Value;
            return dt;
        }

        public string getIcon()
        {
            XmlNode node = doc.SelectSingleNode("//weather");
            XmlAttribute att = node.Attributes["icon"];
            string icon = att.Value;
            return icon;
        }

        public string getIconForecast(string checkDate)
        {
            XmlNodeList xmlNodeList = doc.SelectNodes("//time");
            XmlAttribute att;

            int thatDay = 0;
            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                att = xmlNodeList[i].Attributes["day"];
                if (att.Value.Contains(checkDate))
                {
                    thatDay = i;
                }
            }
            XmlNodeList tempList = doc.SelectNodes("//symbol");
            XmlAttribute xmlAttribute = tempList[thatDay].Attributes["var"];
            return xmlAttribute.Value;
        }

        public float getForecastPrecipitation(string checkDate)
        {
            XmlNodeList xmlNodeList = doc.SelectNodes("//time");
            XmlAttribute att;

            int thatDay = 0;
            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                att = xmlNodeList[i].Attributes["day"];
                if (att.Value.Contains(checkDate))
                {
                    thatDay = i;
                }
            }

            XmlNodeList precipList = doc.SelectNodes("//precipitation");
            XmlAttribute a = precipList[thatDay].Attributes["value"];
            if (a != null)
                return float.Parse(a.Value);
            else
            {
                return 0;
            }
        }

        public string getForecastType(string checkDate)
        {
            try
            {
                XmlNodeList xmlNodeList = doc.SelectNodes("//time");
                XmlAttribute att;

                int thatDay = 0;
                for (int i = 0; i < xmlNodeList.Count; i++)
                {
                    att = xmlNodeList[i].Attributes["day"];
                    if (att.Value.Contains(checkDate))
                    {
                        thatDay = i;
                    }
                }

                XmlNodeList precipList = doc.SelectNodes("//precipitation");
                XmlAttribute a = precipList[thatDay].Attributes["type"];
                return a.Value;
            }
            catch (Exception ex)
            {
                return "none";
            }
        }

        public float getForecastTemperature(string checkDate, string typeOf)
        {
            XmlNodeList xmlNodeList = doc.SelectNodes("//time");
            XmlAttribute att;
            
            int thatDay = 0;
            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                att = xmlNodeList[i].Attributes["day"];
                if (att.Value.Contains(checkDate))
                {
                    thatDay = i;
                }
            }
            XmlNodeList tempList = doc.SelectNodes("//temperature");
            XmlAttribute xmlAttribute = tempList[thatDay].Attributes[typeOf];
            return float.Parse(xmlAttribute.Value);
        }

        public List<double> getPrecipList()
        {
            List<double> precipList = new List<double>();
            XmlNodeList xmlNodeList = doc.SelectNodes("//precipitation");

            int times = 0;
            while (times < 8)
            {
                XmlNode node = xmlNodeList[times].Attributes["value"];
                if (node != null)
                {
                    string In = xmlNodeList[times].Attributes["value"].Value;
                    double x = Convert.ToDouble(In);
                    precipList.Add(x);
                }
                else
                    precipList.Add(0);
               
                times++;
            }
            return precipList;
        }

        public List<string> getPrecipTypeList()
        {
            List<string> precipList = new List<string>();
            XmlNodeList xmlNodeList = doc.SelectNodes("//precipitation");

            int times = 0;
            while (times < 8)
            {
                XmlNode node = xmlNodeList[times].Attributes["type"];
                if (node != null)
                {
                    string In = xmlNodeList[times].Attributes["type"].Value;
                    precipList.Add(In);
                }
                else
                    precipList.Add("");

                times++;
            }
            return precipList;
        }

        public List<string> getPrecipRadarTimeList()
        {
            List<string> precipList = new List<string>();
            XmlNodeList xmlNodeList = doc.SelectNodes("//time");

            int times = 0;
            while (times < 8)
            {
                XmlNode node = xmlNodeList[times].Attributes["from"];
                if (node != null)
                {
                    string In = xmlNodeList[times].Attributes["from"].Value;
                    precipList.Add(In);
                }
                else
                    precipList.Add("");

                times++;
            }
            return precipList;
        }

        public List<double> getCloudRadarList()
        {
            List<double> precipList = new List<double>();
            XmlNodeList xmlNodeList = doc.SelectNodes("//clouds");

            int times = 0;
            while (times < 8)
            {
                XmlNode node = xmlNodeList[times].Attributes["all"];
                if (node != null)
                {
                    string In = xmlNodeList[times].Attributes["all"].Value;
                    double x = Convert.ToDouble(In);
                    precipList.Add(x);
                }
                else
                    precipList.Add(0);

                times++;
            }
            return precipList;
        }

        public List<string> getCloudTimeList()
        {
            List<string> precipList = new List<string>();
            XmlNodeList xmlNodeList = doc.SelectNodes("//time");

            int times = 0;
            while (times < 8)
            {
                XmlNode node = xmlNodeList[times].Attributes["from"];
                if (node != null)
                {
                    string In = xmlNodeList[times].Attributes["from"].Value;
                    precipList.Add(In);
                }
                else
                    precipList.Add("");

                times++;
            }
            return precipList;
        }
    }
}
