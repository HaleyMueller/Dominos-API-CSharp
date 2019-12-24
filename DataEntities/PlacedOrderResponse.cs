using System;
using System.Collections.Generic;
using System.Text;

namespace Dominos_API.DataEntities
{
    public class PlacedOrderResponse
    {
        public bool isSuccess
        {
            get; set;
        }

        public string PulseOrderGUID
        {
            get; set;
        }

        public List<StatusItemsClass> Status
        {
            get; set;
        } = new List<StatusItemsClass>();
    }
}
