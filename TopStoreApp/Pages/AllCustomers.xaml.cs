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
    public partial class AllCustomers : Page
    {
        TopStoreDb db;
        public AllCustomers()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            db = new TopStoreDb();
            db.AllCustomers.Load();
            AllCustomersDataGrid.ItemsSource = db.AllCustomers.Local.ToBindingList();
        }

        private void RefreshData_Click(object sender, RoutedEventArgs e)
        {
            AllCustomersDataGrid.Items.Refresh();
            db.AllCustomers.Load();
            AllCustomersDataGrid.ItemsSource = db.AllCustomers.Local.ToBindingList();
        }
    }
}
