using System;
using System.Collections.Generic;
using System.Text;

namespace Dominos_API.Examples
{
    public static class OrderExample
    {
        public static void Run()
        {
            var address = new Dominos_API.DataEntities.Address()
            {
                Street = "1600 Pennsylvania Ave NW",
                City = "Washington",
                Region = "DC",
                PostalCode = "20500",
                Type = "House"
            };

            var products = new List<Dominos_API.DataEntities.ProductOrder>(){ //BBQ PIZZA
                new Dominos_API.DataEntities.ProductOrder()
                {
                    Code = "12THIN",
                    Qty = 1,
                    Options = new Dictionary<string, Dictionary<Dominos_API.DataEntities.PizzaSide, Dominos_API.DataEntities.Amount>>()
                    {
                        { "C", //Cheese
                            new Dictionary<Dominos_API.DataEntities.PizzaSide, Dominos_API.DataEntities.Amount>() {
                                {  Dominos_API.DataEntities.PizzaSide.Both, Dominos_API.DataEntities.Amount.Normal }
                            }
                        },
                        { "Bq", //BBQ Sauce
                            new Dictionary<Dominos_API.DataEntities.PizzaSide, Dominos_API.DataEntities.Amount>() {
                                { Dominos_API.DataEntities.PizzaSide.Both, Dominos_API.DataEntities.Amount.Extra }
                            }
                        },
                        { "P", //Pepperoni
                            new Dictionary<Dominos_API.DataEntities.PizzaSide, Dominos_API.DataEntities.Amount>() {
                                { Dominos_API.DataEntities.PizzaSide.Both, Dominos_API.DataEntities.Amount.Normal }
                            }
                        },
                        { "K", //Bacon
                            new Dictionary<Dominos_API.DataEntities.PizzaSide, Dominos_API.DataEntities.Amount>() {
                                { Dominos_API.DataEntities.PizzaSide.Both, Dominos_API.DataEntities.Amount.Normal }
                            }
                        },
                        { "SA", //Salami
                            new Dictionary<Dominos_API.DataEntities.PizzaSide, Dominos_API.DataEntities.Amount>() {
                                { Dominos_API.DataEntities.PizzaSide.Both, Dominos_API.DataEntities.Amount.Normal }
                            }
                        },
                        { "X", //Tomato Sauce
                            new Dictionary<Dominos_API.DataEntities.PizzaSide, Dominos_API.DataEntities.Amount>() {
                                { Dominos_API.DataEntities.PizzaSide.Both, Dominos_API.DataEntities.Amount.None}
                            }
                        }
                    }
                }
            };

            var coupons = new List<Dominos_API.DataEntities.Coupon>()
            {
                new Dominos_API.DataEntities.Coupon(){
                    Code = "3030",
                    Qty = 1,
                    ID = 4
                }
            };

            var creditCard = new Dominos_API.DataEntities.PaymentObject(null, 9999999999999999, "1234", 123, 20500);

            var order = new DataEntities.Order()
            {
                Address = address,
                Coupons = coupons,
                StoreID = "4336",
                CustomerID = "FNq53fya_enCESbC5uVQG29iMmwuqMNSBdWs0Olf",
                Email = "potus@hotmail.com",
                FirstName = "Mr.",
                LastName = "President",
                Payments = new List<DataEntities.PaymentObject>()
                {
                    creditCard
                },
                Loyalty = new DataEntities.Order.LoyaltyClass
                {
                    CalculatePotentialPoints = false,
                    LoyaltyCustomer = true
                },
                OrderMethod = "Delivery",
                Phone = "2024561111",
                Products = products
            };

            var orderRequest = new DataEntities.OrderRequest() //Blame Domino's for this
            {
                Order = order
            };

            var validateOrder = Dominos_API.Order.ValidateOrder(orderRequest);

            var priceOfOrder = Dominos_API.Order.GetPriceOfOrder(orderRequest);

            var placeOrder = Dominos_API.Order.PlaceOrder(orderRequest);

            //The easy way
            var easyOrder = Dominos_API.Order.EasyOrder(address, products, coupons, creditCard, Dominos_API.DataEntities.StoreLocator.Type.Delivery, "4336", "FNq53fya_enCESbC5uVQG29iMmwuqMNSBdWs0Olf", "Mr.", "President", "2024561111", "potus@hotmail.com");
        }
    }
}
