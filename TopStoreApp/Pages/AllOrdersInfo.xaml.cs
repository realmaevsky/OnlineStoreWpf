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
            usersDataGrid.ItemsSource = db.AllOrders.Local.ToBindingList();
        }

        private void RefreshBD()
        {
            usersDataGrid.Items.Refresh();
            db.AllOrders.Load();
            usersDataGrid.ItemsSource = db.AllOrders.Local.ToBindingList();
        }

        private void editOrder_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Кнопка не працює...");
            RefreshBD();
        }

        private void deleteOrder_Click(object sender, RoutedEventArgs e)
        {
            db.Accounts.Remove((User)usersDataGrid.SelectedItem);
            db.SaveChanges();
            MessageBox.Show("Користувач успішно видалений");
            RefreshBD();
        }
        private void SortAllOrders_Click(object sender, RoutedEventArgs e)
        {
            usersDataGrid.ItemsSource = db.Accounts.Local.ToBindingList();
        }

        private void SortInWorkOrders_Click(object sender, RoutedEventArgs e)
        {
            usersDataGrid.ItemsSource = db.Accounts.Local.ToBindingList().Where(acc => acc.AccessLevel == 1);
        }

        private void SortCompletedOrders_Click(object sender, RoutedEventArgs e)
        {
            usersDataGrid.ItemsSource = db.Accounts.Local.ToBindingList().Where(acc => acc.AccessLevel == 2);
        }
    }
}
