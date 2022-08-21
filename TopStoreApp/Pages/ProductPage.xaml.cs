using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace TopStoreApp.Pages
{
    public partial class ProductPage : Page
    {
        TopStoreDb db;
        Product currentProduct;

        public ProductPage()
        {
            InitializeComponent();

            db = new TopStoreDb();

            db.AllProducts.Load();

            listViewPhones.ItemsSource = db.AllProducts.Local.ToBindingList();
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            if(currentProduct == null)
                currentProduct = (listViewPhones.SelectedItem as Product);

            var _productInCard = ShoppingCart.tempOrder.ProductsInOrder.ToList().Find(prod => prod.Model == currentProduct.Model);

            if (_productInCard != null)
            {
                _productInCard.Count++;
                _productInCard.TotalCost += _productInCard.Price;
                ShoppingCart.tempOrder.TotalPrice += _productInCard.Price;
            }
            else
            {
                ShoppingCart.tempOrder.ProductsInOrder.Add(currentProduct);
                ShoppingCart.tempOrder.TotalPrice += currentProduct.Price;
            }

            this.NavigationService.Navigate(new Uri("Pages/ShoppingCart.xaml", UriKind.Relative));
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            var productInfo = (Grid)sender;

            if (productInfo.DataContext is Product product)
            {
                currentProduct = product;
            }
        }
    }
}
