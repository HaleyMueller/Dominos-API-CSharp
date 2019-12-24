# Domino's API CSharp
This is an api that talks to Domino's web service that was made using C#

This was made on .NET Core 2.1. This can run on Windows, Linux, and Mac if you have [.NET Core](https://dotnet.microsoft.com/download) installed.

## Functionality
### Store.cs

This class is for getting stores near a location and accessing their menu.

#### Description

| Function Name | Description |
| ------------- | ---------- |
| GetNearbyStores | Returns a list of stores near the location. |
| GetStoreProfile | Returns the store's profile |
| GetStoreMenu | Returns the store's menu including coupons |
| GetStoresDriverStatus | Returns if the store has an active driver |

#### Functions

| Function Name | Parameters | Returns |
| ------------- | ---------- | ------- |
| GetNearbyStores | string zipCode, DataEntities.StoreLocator.Type? type | DataEntities.StoreLocator |
| GetNearbyStores | string street, string cityAndState, DataEntities.StoreLocator.Type? type | DataEntities.StoreLocator |
| GetStoreProfile | int storeID | DataEntities.StoreProfile |
| GetStoreMenu | int storeID | DataEntities.Menu |
| GetStoresDriverStatus | int storeID | DataEntities.HasDrivers |

### Order.cs

This class is for getting the price of an order, validating an order and placing an order.

#### Description

| Function Name | Description |
| ------------- | ---------- |
| GetPriceOfOrder | Returns the order response with the amounts object filled out |
| ValidateOrder | Returns the order response with a status |
| PlaceOrder | Places an order object and returns order response with status |
| EasyOrder | Take in a variety of variables that places an order and validates it |

#### Functions

| Function Name | Parameters | Returns |
| ------------- | ---------- | ------- |
| GetPriceOfOrder | DataEntities.OrderRequest order | DataEntities.OrderResponse |
| ValidateOrder | DataEntities.OrderRequest order | DataEntities.OrderResponse |
| PlaceOrder | DataEntities.OrderRequest order | DataEntities.OrderResponse |
| EasyOrder | DataEntities.Address address, List<DataEntities.ProductOrder> products, List<DataEntities.Coupon> coupons, DataEntities.PaymentObject paymentObject, DataEntities.StoreLocator.Type type, string storeID, string customerID, string firstName, string lastName, string phone, string email | DataEntities.PlacedOrderResponse |

### Tracking.cs

This class is for getting the status of an order.

#### Description

| Function Name | Description |
| ------------- | ---------- |
| TrackOrder | Returns information on an order's status |

#### Functions

| Function Name | Parameters | Returns |
| ------------- | ---------- | ------- |
| TrackOrder | string pulseOrderGUID | DataEntities.Tracker |

**Note:** pulseOrderGUID is from the EasyOrder() or PlaceOrder returned object.

### Interesting Domino's Features

- GetStoresDriverStatus returns if there are any active drivers at the store. You could use that to see if they are behind on deliveries.
- Getting the store menu returns all of the coupons that the store has
- An OrderResponse returns the estimated wait time for the order
- You can get store latitude and longitude coordinates
- The order tracker has the driver and manager name for the order

### Package References

- [Newtonsoft's Json.NET](https://www.newtonsoft.com/json)
