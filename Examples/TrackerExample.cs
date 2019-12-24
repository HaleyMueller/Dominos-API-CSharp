using System;
using System.Collections.Generic;
using System.Text;

namespace Dominos_API.Examples
{
    public static class TrackerExample
    {
        public static void Run()
        {
            var nearbyStoresByZipCode = Dominos_API.Tracking.TrackOrder("GUID HERE");
        }
    }
}
