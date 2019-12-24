using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Dominos_API
{
    public static class Tracking
    {
        public static DataEntities.Tracker TrackOrder(string pulseOrderGUID)
        {
            string url = $"https://tracker.dominos.com/tracker-presentation-service/v2/orders/stores/1554/orderkeys/155488126940/pulseorderguids/{pulseOrderGUID}";

            string html = GetTrackingRequest(url);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<DataEntities.Tracker>(html);
        }

        internal static string GetTrackingRequest(string url)
        {
            string html = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            request.Headers.Add("DPZ-Language:en");
            request.Headers.Add("DPZ-Market:UNITED_STATES");

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            return html;
        }
    }
}
