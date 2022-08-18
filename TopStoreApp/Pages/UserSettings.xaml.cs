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
using TopStoreApp.Properties;
using TopStoreApp.Themes;

namespace TopStoreApp.Pages
{
    public partial class UserSettings : Page
    {

        public UserSettings()
        {
            InitializeComponent();

        }


        private void DarkThemeButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void LightThemeButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void WhiteClr_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GrayClr_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GreenClr_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RedClr_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BlackClr_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BlueClr_Click(object sender, RoutedEventArgs e)
        {

        }

        //private void chooseDarkThemeButton_Click(object sender, RoutedEventArgs e)
        //{
        //    var uri = new Uri("Themes/DarkTheme.xaml", UriKind.Relative);
        //    ResourceDictionary resDict = Application.LoadComponent(uri) as ResourceDictionary;
        //    Application.Current.Resources.MergedDictionaries.Add(resDict);

        //}

        //private void chooseLightThemeButton_Click(object sender, RoutedEventArgs e)
        //{
        //    var uri = new Uri("Themes/LightTheme.xaml", UriKind.Relative);
        //    ResourceDictionary resDict = Application.LoadComponent(uri) as ResourceDictionary;
        //    Application.Current.Resources.MergedDictionaries.Add(resDict);
        //}
        private void saveSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Settings.Default.Save();
                MessageBox.Show("Налаштування успішно збережені!", "Application Settings", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Application Settings", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Themes_Click(object sender, RoutedEventArgs e)
        {
            if (Themes.IsChecked == true)
            {
                ThemesController.SetTheme(ThemesController.ThemeTypes.Dark);

                var uri = new Uri("Themes/DarkTheme.xaml", UriKind.Relative);
                ResourceDictionary resDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.MergedDictionaries.Add(resDict);
            }
            else
            {
                ThemesController.SetTheme(ThemesController.ThemeTypes.Light);

                var uri = new Uri("Themes/LightTheme.xaml", UriKind.Relative);
                ResourceDictionary resDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.MergedDictionaries.Add(resDict);
            }
        }
    }
}
