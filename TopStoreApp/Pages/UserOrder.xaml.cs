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
using System.Data.Entity;
using TopStoreApp.Data;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.ObjectModel;

namespace TopStoreApp.Pages
{
    public partial class UserOrder : Page
    {
        TopStoreDb db;

        public static List<Order> userOrders = new List<Order>();


        public static Order _userOrder;


        public UserOrder()
        {
            InitializeComponent();

            db = new TopStoreDb();

            userOrdersView.ItemsSource = userOrders.ToList(); ;
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"FN {userOrders[0].ClientFirstName}" + Environment.NewLine + $"LN {userOrders[0].ClientLastName}" + Environment.NewLine + $"PN {userOrders[0].ClientPhoneNumber}" +
                $"PM {userOrders[0].PaymentMethod}" + Environment.NewLine + $"FN {userOrders[0].TotalPrice}" + Environment.NewLine + $"OD {userOrders[0].OrderDate}" + Environment.NewLine +
                $"PIO C {userOrders[0].ProductsInOrder.Count}");

            MessageBox.Show($"MDL {_userOrder.ProductsInOrder.First().Model}" + Environment.NewLine + $"CNT {_userOrder.ProductsInOrder.First().Count}" + Environment.NewLine + $"PRC {_userOrder.ProductsInOrder.First().Price}");
        }
    }
}
