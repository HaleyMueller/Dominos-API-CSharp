using System;
using System.Collections.Generic;
using System.Text;

namespace Dominos_API
{
    public static class Store
    {
        public static DataEntities.StoreLocator GetNearbyStores(string zipCode, DataEntities.StoreLocator.Type? type)
        {
            string strType = "";

            switch (type)
            {
                case DataEntities.StoreLocator.Type.Delivery:
                    strType = "Delivery";
                    break;
                case DataEntities.StoreLocator.Type.CarryOut:
                    strType = "Carryout";
                    break;
            }

            string url = $"https://order.dominos.com/power/store-locator?s={zipCode}&type={strType}";

            string html = WebRequestor.GetRequest(url);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<DataEntities.StoreLocator>(html);
        }

        public static DataEntities.StoreLocator GetNearbyStores(string street, string cityAndState, DataEntities.StoreLocator.Type? type)
        {
            string strType = "";

            switch (type)
            {
                case DataEntities.StoreLocator.Type.Delivery:
                    strType = "Delivery";
                    break;
                case DataEntities.StoreLocator.Type.CarryOut:
                    strType = "Carryout";
                    break;
            }

            string url = $"https://order.dominos.com/power/store-locator?s={street}&c={cityAndState}&type={strType}";

            string html = WebRequestor.GetRequest(url);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<DataEntities.StoreLocator>(html);
        }

        public static DataEntities.StoreProfile GetStoreProfile(int storeID)
        {
            string url = $"https://order.dominos.com/power/store/{storeID}/profile";

            string html = WebRequestor.GetRequest(url);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<DataEntities.StoreProfile>(html);
        }

        public static DataEntities.Menu GetStoreMenu(int storeID)
        {
            string url = $"https://order.dominos.com/power/store/{storeID}/menu?structured=true&lang=en";

            string html = WebRequestor.GetRequest(url);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<DataEntities.Menu>(html);
        }

        public static DataEntities.HasDrivers GetStoresDriverStatus(int storeID)
        {
            string url = $"https://tracker.dominos.com/tracker-presentation-service/status?storeId={storeID}";

            string html = WebRequestor.GetRequest(url);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<DataEntities.HasDrivers>(html);
        }
    }
}
