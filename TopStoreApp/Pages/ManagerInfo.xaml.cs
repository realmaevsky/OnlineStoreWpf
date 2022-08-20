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
    public partial class ManagerInfo : Page
    {
        TopStoreDb db;

        public ManagerInfo()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            db = new TopStoreDb();
            db.AllManagers.Load();
            AllManagersDataGrid.ItemsSource = db.AllManagers.Local.ToBindingList();
        }

        private void RefreshBD()
        {
            AllManagersDataGrid.Items.Refresh();
            db.AllManagers.Load();
            AllManagersDataGrid.ItemsSource = db.AllManagers.Local.ToBindingList();
        }

        private void editManager_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Кнопка не працює...");
            RefreshBD();
        }

        private void deleteManager_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Кнопка не працює...");
            RefreshBD();
        }

        private void SortAllManagers_Click(object sender, RoutedEventArgs e)
        {
            AllManagersDataGrid.ItemsSource = db.AllManagers.Local.ToBindingList();
        }

        private void SortWorkedManagers_Click(object sender, RoutedEventArgs e)
        {
            AllManagersDataGrid.ItemsSource = db.AllManagers.Local.ToBindingList().Where(mngr => mngr.Online == true);
        }

        private void RefreshData_Click(object sender, RoutedEventArgs e)
        {
            RefreshBD();
        }
    }
}
