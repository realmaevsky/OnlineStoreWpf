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
using System.Windows.Controls.Primitives;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace TopStoreApp.Pages
{
    public partial class AddUsers : Page
    {

        TopStoreDb db;

        public AddUsers()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            db = new TopStoreDb();
            db.Accounts.Load();
            usersDataGrid.ItemsSource = db.Accounts.Local.ToBindingList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var addNewAccount = new AddNewAcc();
            addNewAccount.Show();
            RefreshBD();
        }

        private void RefreshBD()
        {
            usersDataGrid.Items.Refresh();
            db.Accounts.Load();
            usersDataGrid.ItemsSource = db.Accounts.Local.ToBindingList();
        }

        private void editUserButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Кнопка не працює...");
            RefreshBD();
        }

        private void deleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            db.Accounts.Remove((User)usersDataGrid.SelectedItem);
            db.SaveChanges();
            MessageBox.Show("Користувач успішно видалений");
            RefreshBD();
        }
        private void SortAllUsers_Click(object sender, RoutedEventArgs e)
        {
            usersDataGrid.ItemsSource = db.Accounts.Local.ToBindingList();
        }

        private void SortManagers_Click(object sender, RoutedEventArgs e)
        {
            usersDataGrid.ItemsSource = db.Accounts.Local.ToBindingList().Where(acc => acc.AccessLevel == 1);
        }

        private void SortAdmins_Click(object sender, RoutedEventArgs e)
        {
            usersDataGrid.ItemsSource = db.Accounts.Local.ToBindingList().Where(acc => acc.AccessLevel == 2);
        }
    }
}
