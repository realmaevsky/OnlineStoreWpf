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
    public class Product : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        private decimal _totalCost;

        public decimal TotalCost
        {
            get { return _totalCost; }
            set
            {
                _totalCost = value;
                OnPropertyChanged();
            }
        }

        public short Memory { get; set; }

        public bool InStock { get; set; }

        public string ImageSource { get; set; }

        private int _count;

        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
                OnPropertyChanged();
            }

        }

        public ICollection<Order> Ordr { get; set; }

        public Product()
        {
            Ordr = new List<Order>();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public override string ToString()
        {
            return $"{Model} {Memory} GB // {Count} шт.\n" +
                $"Ціна за шт.: {Price} грн.\n";
        }
    }
}
