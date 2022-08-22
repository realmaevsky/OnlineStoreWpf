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
    public partial class AddNewAcc : Window
    {
        public AddNewAcc()
        {
            InitializeComponent();
        }

        private void createAccountButton_Click(object sender, RoutedEventArgs e)
        {
            using (TopStoreDb db = new TopStoreDb())
            {
                try
                {
                    var createdAcc = db.Accounts.FirstOrDefault(u => u.PhoneNumber == addNewLogin.Text);

                    if (createdAcc == null)
                    {
                        createdAcc = new User();
                        createdAcc.Login = addNewLogin.Text;
                        createdAcc.Password = addNewPassword.Password;
                        createdAcc.AccessLevel = Convert.ToInt32(addNewAccessLevel.Text);

                        db.Accounts.Add(createdAcc);
                    }
                    else
                    {
                        MessageBox.Show("Такий користувач вже існує");
                    }

                    db.SaveChanges();

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
