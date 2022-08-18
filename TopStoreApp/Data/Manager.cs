using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopStoreApp.Data
{
    public class Manager
    {
        public int Id { get; set; }

        public int InnerId
        {
            get { return InnerId; }
            set { InnerId = 900 + Id; }
        }
        public string WorkName { get { return "Manager" + InnerId; } }

        public bool Online { get; set; }

        public short OrdersInProgress { get; set; }

        public int CompletedOrders { get; set; }
    }
}
