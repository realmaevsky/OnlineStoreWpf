using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopStoreApp.Data
{
    public class Order
    {
        public int Id { get; set; }

        public string ClientName { get; set; }

        public string ClientMail { get; set; }

        public string ClientPhone { get; set; }

        public decimal TotalPrice { get; set; }

        public bool IsCompleted { get; set; }   

        public ICollection<Product> ProductsInOrder { get; set; }

        public Order()
        {
            ProductsInOrder = new List<Product>();
        }
    }
}
