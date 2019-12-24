using System;
using System.Collections.Generic;
using System.Text;

namespace Dominos_API.DataEntities
{
    public class HasDrivers
    {
        public bool HasActiveDriver
        {
            get; set;
        }

        public bool SmsOptInEnabled
        {
            get; set;
        }
    }
}
