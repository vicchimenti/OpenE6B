using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using OpenE6B.Properties;

namespace OpenE6B.Classes
{
    public class Metar
    {
        public string RawText { get; set; }
        public DateTime Time { get; set; }
        public float Temp { get; set; }
        public float DewPoint { get; set; }
        public int WindDirection { get; set; }
        public int WindSpeed { get; set; }
        public float Visibility { get; set; }
        public string SkyCondition { get; set; }

        public string Wind => $"{WindDirection} degrees @ {WindSpeed} Kts";
    }

    public class AirportNotFoundException : Exception
    {
        public AirportNotFoundException(string stationString) : base(stationString)
        {
          
        }
    }

    public class MetarRetriever
    {
        private string BaseUrl { get; set; }

        private string RequestString { get; set; }

        public MetarRetriever()
        {
            BaseUrl = Resources.MetarRequestBaseString;
            // testing comments
        }

        public async Task<Metar> GetMetar(string stationId)
        {
            RequestString = BaseUrl + "stationString=" + stationId + "&hoursBeforeNow=2";
            var metar = await MakeRequest();
            return metar;
        }

        private async Task<Metar> MakeRequest()
        {
            var metar = new Metar();
            HttpClient client = new HttpClient();
            var dataStream = await client.GetStreamAsync(RequestString);

            var document = XDocument.Load(dataStream);
            var metarElement = document.Descendants().FirstOrDefault(a => a.Name == "METAR");
            if (metarElement == null) throw new AirportNotFoundException("Invalid Station ID Entered: No METARs found");
            metar.RawText = document.Descendants().FirstOrDefault(a => a.Name == "raw_text").Value;
            metar.Time = DateTime.Parse(document.Descendants().FirstOrDefault(a => a.Name == "observation_time").Value, CultureInfo.InvariantCulture);
            metar.Time = TimeZoneInfo.ConvertTimeToUtc(metar.Time);
            metar.Temp = Convert.ToSingle(document.Descendants().FirstOrDefault(a => a.Name == "temp_c").Value);
            metar.DewPoint = Convert.ToSingle(document.Descendants().FirstOrDefault(a => a.Name == "dewpoint_c").Value);
            metar.WindDirection = Convert.ToInt16(document.Descendants().FirstOrDefault(a => a.Name == "wind_dir_degrees").Value);
            metar.WindSpeed = Convert.ToInt16(document.Descendants().FirstOrDefault(a => a.Name == "wind_speed_kt").Value);
            metar.Visibility = Convert.ToSingle(document.Descendants().FirstOrDefault(a => a.Name == "visibility_statute_mi").Value);

            var skyElements = metarElement.Descendants().Where(a => a.Name == "sky_condition");

            foreach (var skyElement in skyElements)
            {
                if (skyElement.Attribute("cloud_base_ft_agl") != null)
                {
                    metar.SkyCondition += ConvertSkyCondition(skyElement.Attribute("sky_cover").Value,
                        skyElement.Attribute("cloud_base_ft_agl").Value);
                }
                else
                {
                    metar.SkyCondition += ConvertSkyCondition(skyElement.Attribute("sky_cover").Value, "");
                }
            }


            return metar;
        }

        private string ConvertSkyCondition(string condition, string baseLevel)
        {
            if (condition == "CLR")
            {
                return "Clear";
            }

            if (condition == "SCT")
            {
                return $"Scattered at {baseLevel} ft. ";
            }

            if (condition == "BKN")
            {
                return $"Broken at {baseLevel} ft. ";
            }

            if (condition == "OVC")
            {
                return $"Overcast at {baseLevel} ft. ";
            }

            if (condition == "FEW")
            {
                return $"Few clouds at {baseLevel} ft. ";
            }

            else
            {
                return $"{condition} at {baseLevel} ft. ";
            }
        }
    }
}
