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
using TopStoreApp.Pages;
using System.Data.Entity;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace TopStoreApp.Pages
{
    public partial class ShoppingCart : Page
    {
        TopStoreDb db;

        public static Order tempOrder = new Order();

        public Product selectedProduct;

        //public static ObservableCollection<Product> products = new ObservableCollection<Product>();

        public ShoppingCart()
        {
            InitializeComponent();

            db = new TopStoreDb();
            //listViewOrder.ItemsSource = products;
            listViewOrder.ItemsSource = tempOrder.ProductsInOrder;

            totalpriceBlock.DataContext = tempOrder;
            //totalpriceBlock.Text = tempOrder.TotalPrice;
            //totalcashlabel2.Content = tempOrder.TotalPrice;

        }

        private void GoToProductPage_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/ProductPage.xaml", UriKind.Relative));
        }

        private void Grid_MouseEnter_1(object sender, MouseEventArgs e)
        {
            var productInfo = (Grid)sender;

            if (productInfo.DataContext is Product product)
            {
                selectedProduct = product;
            }
        }

        private void addCounter_Click(object sender, RoutedEventArgs e)
        {
            selectedProduct.Count++;
            selectedProduct.TotalCost += selectedProduct.Price;
            tempOrder.TotalPrice += selectedProduct.Price;
            // CheckTotalPrice();
        }

        private void downCounter_Click(object sender, RoutedEventArgs e)
        {
            if (selectedProduct.Count > 1)
            {
                selectedProduct.Count--;
                selectedProduct.TotalCost -= selectedProduct.Price;
                tempOrder.TotalPrice -= selectedProduct.Price;
            }
            else
            {
                selectedProduct.Count = 1;
                selectedProduct.TotalCost = selectedProduct.Price;
            }

        }

        private void CreateOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tempOrder.ClientFirstName = txtUserName.Text;
                tempOrder.ClientLastName = txtUserLastName.Text;
                tempOrder.ClientPhoneNumber = txtUserPhone.Text;

                db.AllOrders.Add(tempOrder);
                db.SaveChanges();



                tempOrder.ProductsInOrder.Clear();

                MessageBox.Show($"Ім'я: {tempOrder.ClientFirstName}" + Environment.NewLine + $"Прізвище: {tempOrder.ClientLastName}"
                + Environment.NewLine + $"Номер телефону: {tempOrder.ClientPhoneNumber}" + Environment.NewLine + $"Спосіб розрахунку: {tempOrder.PaymentMethod}"
                + Environment.NewLine + $"Сума замовлення: {tempOrder.TotalPrice}" + Environment.NewLine + $"Дата створення замовлення: {tempOrder.OrderDate}"
                + Environment.NewLine + $"Товари: {tempOrder.ProductsInOrder.First().Model.ToString()} {tempOrder.ProductsInOrder.First().Memory.ToString()} GB x " +
                $"{tempOrder.ProductsInOrder.First().Count.ToString()} шт.");
            }
            catch (Exception)
            {
                MessageBox.Show("Неможливо створити замовлення, якщо кошик пустий!");
            }


            
            
        }

        private void deleteProduct_Click(object sender, RoutedEventArgs e)
        {
            tempOrder.ProductsInOrder.Remove(selectedProduct);
            tempOrder.TotalPrice -= selectedProduct.TotalCost;
        }

        private void cashRb_Checked(object sender, RoutedEventArgs e)
        {
            tempOrder.PaymentMethod = "Готівка";
        }

        private void cardRb_Checked(object sender, RoutedEventArgs e)
        {
            tempOrder.PaymentMethod = "Безготівковий розрахунок / Картка";
        }

        private void CheckTotalPrice()
        {
            foreach (var item in tempOrder.ProductsInOrder)
            {
                tempOrder.TotalPrice += item.TotalCost;
            }
        }
    }
}
