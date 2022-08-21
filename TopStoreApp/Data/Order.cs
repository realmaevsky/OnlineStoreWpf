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

        public string ClientFirstName { get; set; }

        public string ClientLastName { get; set; }

        public string ClientPhoneNumber { get; set; }

        public string PaymentMethod { get; set; }

        public Manager ResponsibleMngr { get; set; }

        public DateTimeOffset OrderDate { get; set; }

        private decimal totalPrice;

        public decimal TotalPrice
        {
            get
            {
                return totalPrice;
            }
            set
            {
                totalPrice = ProductsInOrder.Sum(t => t.TotalCost);
                //totalPrice = value;
                OnPropertyChanged();
            }
        }

        public bool IsCompleted { get; set; }

        public ICollection<Product> ProductsInOrder { get; set; }

        public Order()
        {
            ProductsInOrder = new ObservableCollection<Product>();
            this.OrderDate = DateTimeOffset.Now.LocalDateTime;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
