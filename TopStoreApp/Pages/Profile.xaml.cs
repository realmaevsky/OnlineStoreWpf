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
using TopStoreApp.Data;

namespace TopStoreApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        readonly TopStoreDb db;
        public Profile()
        {
            InitializeComponent();

            db = new TopStoreDb();

            if (userFirstName.Text == null || userLastName.Text == null || userEmail.Text == null)
            {
                SaveProfileSettings.IsEnabled = false;
            }
            else
            {
                SaveProfileSettings.IsEnabled = true;
            }
        }

        private void SaveProfileSettings_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentAccount = new User();
                currentAccount.FirstName = userFirstName.Text;
                currentAccount.LastName = userFirstName.Text;
                currentAccount.Email = userFirstName.Text;

                db.Accounts.Add(currentAccount);
                db.SaveChanges();
                MessageBox.Show("Налаштування профілю успішно збережені", "Налаштування", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Усі поля мають бути заповнені!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
