using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using TopStoreApp.Data;
using System.Collections;

namespace TopStoreApp
{
    public partial class MainWindow : Window
    {
        TopStoreDb db;

        public MainWindow()
        {
            db = new TopStoreDb();
            //newTables();

            //new StartLoading().ShowDialog();

            //new Authorization().ShowDialog();

            InitializeComponent();

                fContainer.Navigate(new System.Uri("Pages/StartPage.xaml", UriKind.RelativeOrAbsolute));

        }

        private void newTables()
        {
            var mngggr = new User();
            mngggr.Login = "manager01";
            mngggr.Password = "managerpswrd01";
            mngggr.AccessLevel = 1;
            db.Accounts.Add(mngggr);
            db.SaveChanges();
            User adm = new User();
            adm.Login = "root";
            adm.Password = "admin";
            adm.AccessLevel = 2;
            adm.Email = "realmaevsky@gmail.com";
            adm.FirstName = "Vladyslav";
            adm.LastName = "Hutsaliuk";

            db.Accounts.Add(adm);
            db.SaveChanges();

            Product a = new Product();
            Product b = new Product();
            Product c = new Product();
            Product d = new Product();
            Product e = new Product();

            a.Model = "iPhone X";
            a.Price = 8799;
            a.Memory = 64;
            a.InStock = true;

            b.Model = "iPhone Xs";
            b.Price = 9799;
            b.Memory = 64;
            b.InStock = true;

            c.Model = "iPhone Xr";
            c.Price = 10499;
            c.Memory = 128;
            c.InStock = true;

            d.Model = "iPhone Xs Max";
            d.Price = 12199;
            d.Memory = 128;
            d.InStock = true;

            e.Model = "iPhone 13";
            e.Price = 34999;
            e.Memory = 256;
            e.InStock = true;

            db.AllProducts.Add(a);
            db.AllProducts.Add(b);
            db.AllProducts.Add(c);
            db.AllProducts.Add(d);
            db.AllProducts.Add(e);

            db.SaveChanges();

            Manager mngr = new Manager();

            mngr.OrdersInProgress = 14;
            mngr.Online = true;
            //mngr.AccountInfo.Login = "manager01";
            //mngr.AccountInfo.Password = "managerpswrd01";
            //mngr.AccountInfo.AccessLevel = 1;
            db.AllManagers.Add(mngr);
            db.SaveChanges();

            Order ordr = new Order();
            //ordr.Client.FirstName = "Alex";
            //ordr.Client.LastName = "Nagorskiy";
            //ordr.Client.PhoneNumber = "380971234567";
            ordr.TotalPrice = 1555;
            ordr.ProductsInOrder.Add(db.AllProducts.First());
            ordr.ResponsibleMngr = mngr;

            db.AllOrders.Add(ordr);
            db.SaveChanges();
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        private void btnStartPage_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnStartPage;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Головна сторінка";
            }
        }

        private void btnStartPage_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnProducts_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnProducts;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Товари";
            }
        }

        private void btnProducts_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnShoppingCart_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnShoppingCart;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Кошик";
            }
        }

        private void btnShoppingCart_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnMyProfile_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnMyProfile;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Мій профіль";
            }
        }

        private void btnMyProfile_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnMyOrders_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnMyOrders;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Мої замовлення";
            }
        }

        private void btnMyOrders_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnAllProducts_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnAllProducts;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Всі products";
            }
        }

        private void btnAllProducts_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnOrderList_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnOrderList;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Всі замовлення";
            }
        }

        private void btnOrderList_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnManagersInfo_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnManagersInfo;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Всі менеджери";
            }
        }

        private void btnManagersInfo_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnAddUser_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnAddUser;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Додати користувача";
            }
        }

        private void btnAddUser_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnSetting_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnSetting;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Налаштування";
            }
        }

        private void btnSetting_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnStartPage_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Pages/StartPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Pages/ProductPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnShoppingCart_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Pages/ShoppingCart.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnMyProfile_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Pages/Profile.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnMyOrders_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Pages/UserOrder.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnAllProducts_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Pages/AllProducts.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnOrderList_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Pages/AllOrdersInfo.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnManagersInfo_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Pages/ManagerInfo.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Pages/AddUsers.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Pages/UserSettings.xaml", UriKind.RelativeOrAbsolute));
        }


        private void exitButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void minButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

    }

}
