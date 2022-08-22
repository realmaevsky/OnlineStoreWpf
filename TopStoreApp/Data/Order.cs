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
                if (ProductsInOrder.Count == 0)
                {
                    totalPrice = value;
                }
                else
                {
                    totalPrice = ProductsInOrder.Sum(t => t.TotalCost);
                }

                OnPropertyChanged();
            }
        }

        public ICollection<Product> ProductsInOrder { get; set; }

        public Order()
        {
            ProductsInOrder = new List<Product>();
            this.OrderDate = DateTimeOffset.Now.LocalDateTime;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Замовник: {ClientFirstName} {ClientLastName}\n" +
                $"Номер телефону: {ClientPhoneNumber}\n" +
                $"Дата замовлення: {OrderDate:G}\n" +
                $"Тип оплати: {PaymentMethod}\n" +
                $"Товари: \n");
            sb.Append(string.Join("\n\n", ProductsInOrder));
            sb.Append($"\n       Загальна вартість замовлення: {TotalPrice} грн.");
            return sb.ToString();
        }
    }
}
