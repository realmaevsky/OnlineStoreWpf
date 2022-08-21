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

namespace TopStoreApp.Pages
{
    public partial class UserOrder : Page
    {
        TopStoreDb db;

        public static List<Order> userOrdersCollection = new List<Order>();

        public UserOrder()
        {
            InitializeComponent();

            db = new TopStoreDb();

            listViewUserOrders.ItemsSource = userOrdersCollection;

        }


    }
}
