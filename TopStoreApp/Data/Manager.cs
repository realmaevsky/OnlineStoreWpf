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

        public int ManagerID
        {
            get { return 900 + Id; }
        }

        public User AccountInfo { get; set; }

        public string WorkName { get { return "Manager" + ManagerID; } }

        public bool Online { get; set; }

        public int OrdersInProgress { get; set; }

        public int CompletedOrders { get; set; }
    }
}
