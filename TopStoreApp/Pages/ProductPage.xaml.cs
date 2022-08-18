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
    /// Логика взаимодействия для Apple.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        TopStoreDb db;

        public ProductPage()
        {
            InitializeComponent();
            db = new TopStoreDb();
            db.AllProducts.Load();

            listViewPhones.ItemsSource = db.AllProducts.Local.ToList();


        }
    }
}
