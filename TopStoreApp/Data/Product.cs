using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopStoreApp.Data
{
    public class Product
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public short Memory { get; set; }

        public bool InStock { get; set; }

        public string ImageSource { get; set; }

        public Order Ordr { get; set; }
    }
}
