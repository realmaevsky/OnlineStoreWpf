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

        private void saveSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
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
                //ThemesController.SetTheme(ThemesController.ThemeTypes.Dark);

                //var uri = new Uri("Themes/DarkTheme.xaml", UriKind.Relative);
                //ResourceDictionary dark = Application.LoadComponent(uri) as ResourceDictionary;
                //Application.Current.Resources.MergedDictionaries.Clear();
                //Application.Current.Resources.MergedDictionaries.Add(dark);
            }
            else
            {
                //ThemesController.SetTheme(ThemesController.ThemeTypes.Light);

                //var uri = new Uri("Themes/LightTheme.xaml", UriKind.Relative);
                //ResourceDictionary resDict = Application.LoadComponent(uri) as ResourceDictionary;
                //Application.Current.Resources.MergedDictionaries.Clear();
                //Application.Current.Resources.MergedDictionaries.Add(resDict);
            }
        }
    }
}
