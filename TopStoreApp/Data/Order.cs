using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TopStoreApp.Data
{
    public class Order : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public User Client { get; set; }

        private decimal totalPrice;

        public decimal TotalPrice 
        { 
            get
            {
                return totalPrice;
            }
            set
            {
                foreach (var item in ProductsInOrder)
                {
                    totalPrice += item.Price * item.Count;
                    OnPropertyChanged("TotalPrice");
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
