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

namespace TopStoreApp.Pages
{
    /// <summary>
    /// Interaction logic for AllProducts.xaml
    /// </summary>
    public partial class AllProducts : Page
    {
        TopStoreDb db;
        public AllProducts()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            db = new TopStoreDb();
            db.Managers.Load();
            ProductsDataGrid.ItemsSource = db.AllProducts.Local.ToBindingList();
        }

        private void RefreshBD()
        {
            ProductsDataGrid.Items.Refresh();
            db.Managers.Load();
            ProductsDataGrid.ItemsSource = db.AllProducts.Local.ToBindingList();
        }

        private void editProduct_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Кнопка не працює...");
            RefreshBD();
        }

        private void deleteProduct_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Кнопка не працює...");
            RefreshBD();
        }

        private void SortAllProducts_Click(object sender, RoutedEventArgs e)
        {
            ProductsDataGrid.ItemsSource = db.AllProducts.Local.ToBindingList();
        }

        private void SortInStockTrue_Click(object sender, RoutedEventArgs e)
        {
            ProductsDataGrid.ItemsSource = db.AllProducts.Local.ToBindingList().Where(prod => prod.InStock == true);
        }

        private void SortInStockFalse_Click(object sender, RoutedEventArgs e)
        {
            ProductsDataGrid.ItemsSource = db.AllProducts.Local.ToBindingList().Where(prod => prod.InStock == false);
        }
        private void RefreshData_Click(object sender, RoutedEventArgs e)
        {
            RefreshBD();
        }
    }
}
