using System;
using System.Collections.Generic;
using System.Dynamic;
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
    }

    public class MetarRetriever
    {
        private string BaseUrl { get; set; }

        private string RequestString { get; set; }

        public MetarRetriever()
        {
            BaseUrl = Resources.MetarRequestBaseString;
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
            await Task.Delay(3000);
            HttpClient client = new HttpClient();
            var dataStream = await client.GetStreamAsync(RequestString);

            var document = XDocument.Load(dataStream);
            var metarElement = document.Descendants().FirstOrDefault(a => a.Name == "METAR");
            metar.RawText = document.Descendants().FirstOrDefault(a => a.Name == "raw_text").Value.ToString();


            return metar;
        }
    }
}
