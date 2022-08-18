using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopStoreApp.Data
{
    public class TopStoreDb : DbContext
    {
        public TopStoreDb()
             : base("name=TopStoreDb")
        {
        }

        public virtual DbSet<User> Accounts { get; set; }

        public virtual DbSet<Product> AllProducts { get; set; }

        public virtual DbSet<Order> AllOrders { get; set; }

        public virtual DbSet<Manager> Managers { get; set; }

    }
}
