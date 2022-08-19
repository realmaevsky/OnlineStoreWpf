using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using TopStoreApp.Data;

namespace TopStoreApp
{
    public partial class Authorization : Window
    {
        bool isLogin = false;
        public Authorization()
        {
            InitializeComponent();
        }
        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (userPassword.Password.Length > 0)
            {
                Wmark.Visibility = Visibility.Collapsed;
            }
            else
            {
                Wmark.Visibility = Visibility.Visible;
            }
        }
        private void Authorization_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void AuthorizationWindow_Closed(object sender, EventArgs e)
        {
            if (!isLogin)
                this.Close();
        }

        private void exitButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void minButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }


        private void authorizeButton_Click(object sender, RoutedEventArgs e)
        {
            using (TopStoreDb data = new TopStoreDb())
            {
                string login = userLogin.Text;
                string password = userPassword.Password;

                try
                {
                    User loginUser = data.Accounts.Where((u) => u.Login == login && u.Password == password).Single();

                    isLogin = true;


                    authorizeButton.Background = Brushes.LimeGreen;
                    authorizeButton.Opacity = 0.6;
                    authorizeButton.Content = "Успішно!";
                    MessageBox.Show("Авторизація пройшла успішно!", "Авторизація", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Логін або пароль невірний!", "Авторизація", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
        }

        private void userPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                authorizeButton_Click(sender, e);
            }
        }
    }
}
