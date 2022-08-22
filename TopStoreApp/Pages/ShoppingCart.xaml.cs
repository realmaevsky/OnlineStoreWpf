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
using System.Threading;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Remoting.Messaging;
using System.Diagnostics;
using System.Reflection;

namespace TopStoreApp.Pages
{
    public partial class ShoppingCart : Page
    {
        TopStoreDb db;

        public static Order tempOrder = new Order();

        public Product selectedProduct;

        public ShoppingCart()
        {
            InitializeComponent();

            db = new TopStoreDb();

            listViewOrder.ItemsSource = tempOrder.ProductsInOrder;

            totalpriceBlock.DataContext = tempOrder;
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

        private async void CreateOrderButton_Click(object sender, RoutedEventArgs e)
        {
            if (tempOrder.ProductsInOrder.Count == 0)
            {
                MessageBox.Show("Я не можу прийняти замовлення, якщо кошик пустий :(");
            }
            else if (txtUserName.Text.Count() < 1 || txtUserLastName.Text.Count() < 1 || txtUserPhone.Text.Count() < 1)
            {
                MessageBox.Show("Всі поля мають бути заповнені");
            }
            else
            {
                try
                {
                    tempOrder.ClientFirstName = txtUserName.Text;
                    tempOrder.ClientLastName = txtUserLastName.Text;
                    tempOrder.ClientPhoneNumber = txtUserPhone.Text;

                    UserOrder.userOrders.Add(new Order()
                    {
                        Id = tempOrder.Id,
                        ClientFirstName = tempOrder.ClientFirstName,
                        ClientLastName = tempOrder.ClientLastName,
                        ClientPhoneNumber = tempOrder.ClientPhoneNumber,
                        ProductsInOrder = tempOrder.ProductsInOrder,
                        TotalPrice = tempOrder.TotalPrice,
                        PaymentMethod = tempOrder.PaymentMethod,
                    });

                    db.AllOrders.Add(tempOrder);

                    var customer = db.AllCustomers.FirstOrDefault(x => x.PhoneNumber == tempOrder.ClientPhoneNumber);

                    if (customer == null)
                    {
                        customer = new Customer();
                        customer.FirstName = tempOrder.ClientFirstName;
                        customer.LastName = tempOrder.ClientLastName;
                        customer.PhoneNumber = tempOrder.ClientPhoneNumber;
                        customer.AmountOrders = 1;
                        db.AllCustomers.Add(customer);
                    }
                    else
                    {
                        customer.AmountOrders++;
                    }

                    db.SaveChanges();

                    MessageBox.Show("Ваше замовлення прийнято! Зараз буде згенеровано чек з інформацією про замовлення!)");

                    await WriteOrderToFile(tempOrder);

                    tempOrder.ProductsInOrder.Clear();
                    tempOrder.TotalPrice = default;

                    this.NavigationService.Navigate(new Uri("Pages/StartPage.xaml", UriKind.Relative));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

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
            tempOrder.PaymentMethod = "Оплата карткою";
        }

        private async Task WriteOrderToFile(Order order)
        {
            var userOrderTxt = $"temp/{order.ClientLastName}_order_{order.Id}.txt";

            using (FileStream stream = new FileStream(userOrderTxt, FileMode.OpenOrCreate, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(stream))
            {
                await sw.WriteLineAsync(order.ToString());
            }

            Process.Start("notepad.exe", userOrderTxt);
        }
    }
}
