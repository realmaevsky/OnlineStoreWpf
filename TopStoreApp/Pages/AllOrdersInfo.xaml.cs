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
    
    public partial class AllOrdersInfo : Page
    {
        TopStoreDb db;

        public AllOrdersInfo()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            db = new TopStoreDb();
            db.AllOrders.Load();
            AllOrdersDataGrid.ItemsSource = db.AllOrders.Local.ToBindingList();
        }

        private void RefreshBD()
        {
            AllOrdersDataGrid.Items.Refresh();
            db.AllOrders.Load();
            AllOrdersDataGrid.ItemsSource = db.AllOrders.Local.ToBindingList();
        }

        private void editOrder_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Кнопка не працює...");
            RefreshBD();
        }

        private void deleteOrder_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Кнопка не працює...");
            RefreshBD();
        }

        private void SortAllOrders_Click(object sender, RoutedEventArgs e)
        {
            AllOrdersDataGrid.ItemsSource = db.AllOrders.Local.ToBindingList();
        }

        private void SortCashPay_Click(object sender, RoutedEventArgs e)
        {
            AllOrdersDataGrid.ItemsSource = db.AllOrders.Local.ToBindingList().Where(ord => ord.PaymentMethod == "Готівка");
        }

        private void SortCardPay_Click(object sender, RoutedEventArgs e)
        {
            AllOrdersDataGrid.ItemsSource = db.AllOrders.Local.ToBindingList().Where(ord => ord.PaymentMethod == "Оплата карткою");
        }

        private void RefreshData_Click(object sender, RoutedEventArgs e)
        {
            RefreshBD();
        }
    }
}
