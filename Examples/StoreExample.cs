using System;
using System.Collections.Generic;
using System.Text;

namespace Dominos_API.Examples
{
    public static class StoreExample
    {
        public static void Run()
        {
            var nearbyStoresByZipCode = Dominos_API.Store.GetNearbyStores("12345", DataEntities.StoreLocator.Type.CarryOut);

            var nearbyStoresAddress = Dominos_API.Store.GetNearbyStores("1600 Pennsylvania Ave NW", "Washington, DC", null);

            var storeProfile = Dominos_API.Store.GetStoreProfile(4336);

            var storeMenu = Dominos_API.Store.GetStoreMenu(4336);

            var storeDriverStatus = Dominos_API.Store.GetStoresDriverStatus(4336);
        }
    }
}
