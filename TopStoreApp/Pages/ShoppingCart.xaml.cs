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

namespace TopStoreApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для ShoppingCart.xaml
    /// </summary>
    public partial class ShoppingCart : Page
    {
        public ShoppingCart()
        {
            InitializeComponent();
        }
        private void StackPanel_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
            {
            }
        }

        private void GoToProductPage_Click(object sender, RoutedEventArgs e)
        {
            ffContainer.Navigate(new System.Uri("Pages/ProductPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
