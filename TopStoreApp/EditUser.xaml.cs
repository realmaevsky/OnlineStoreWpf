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
using System.Windows.Shapes;
using TopStoreApp.Data;

namespace TopStoreApp
{
    /// <summary>
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        public EditUser()
        {
            InitializeComponent();
        }

        private void editUserButton_Click(object sender, RoutedEventArgs e)
        {
            using (TopStoreDb db = new TopStoreDb())
            {
                try
                {
                    var editedAccount = new User();
                    editedAccount.Login = addNewLogin.Text;
                    editedAccount.Password = addNewPassword.Password;
                    editedAccount.AccessLevel = Convert.ToInt32(addNewAccessLevel.Text);

                    db.Accounts.Add(editedAccount);
                    db.SaveChanges();
                    MessageBox.Show($"Користувач [{addNewLogin.Text}] успішно відредагований!", "Редагування користувача", MessageBoxButton.OK, MessageBoxImage.Information);

                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Усі поля мають бути заповнені!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (addNewPassword.Password.Length > 0)
            {
                Wmark.Visibility = Visibility.Collapsed;
            }
            else
            {
                Wmark.Visibility = Visibility.Visible;
            }
        }
    }

}
