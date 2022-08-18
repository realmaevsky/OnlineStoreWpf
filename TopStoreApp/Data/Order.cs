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

        public User Client { get; set; }

        public decimal TotalPrice 
        { 
            get
            {
                return TotalPrice;
            }
            set
            {
                foreach (var item in ProductsInOrder)
                {
                    TotalPrice += item.Price;
                }
                
            } 
        }

        public Manager ResponsibleMngr { get; set; }

        public bool IsCompleted { get; set; }   

        public ICollection<Product> ProductsInOrder { get; set; }

        public Order()
        {
            ProductsInOrder = new List<Product>();
        }
    }
}
