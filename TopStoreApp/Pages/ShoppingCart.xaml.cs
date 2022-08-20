using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TopStoreApp.Data;
using TopStoreApp.Pages;
using System.Data.Entity;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TopStoreApp.Pages
{
    public partial class ShoppingCart : Page
    {
        TopStoreDb db;

        public static Order tempOrder = new Order();

        public Product prodInOrder;

        public ShoppingCart()
        {
            InitializeComponent();

            db = new TopStoreDb();

            listViewOrder.ItemsSource = tempOrder.ProductsInOrder;
        }

        private void GoToProductPage_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/ProductPage.xaml", UriKind.Relative));
        }

        private void Grid_MouseEnter_1(object sender, MouseEventArgs e)
        {
            var productInfo = (Grid)sender;

            if (productInfo.DataContext is Product product)
            {
                prodInOrder = product;
            }
        }

        private void addCounter_Click(object sender, RoutedEventArgs e)
        {

            //foreach (var phone in tempOrder.ProductsInOrder.Where(p => p.Model == prodInOrder.Model))
            //{
            //    phone.Count++;
            //}
            
            prodInOrder.Count++;
            

        }

        private void downCounter_Click(object sender, RoutedEventArgs e)
        {
            prodInOrder.Count--;
            if (prodInOrder.Count > 1)
                prodInOrder.Count--;
            else
                prodInOrder.Count = 1;
        }


    }
}
