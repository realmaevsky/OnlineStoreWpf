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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TopStoreApp
{
    public partial class StartLoading : Window
    {
        private readonly DispatcherTimer timer;
        public StartLoading()
        {
            InitializeComponent();

            this.timer = new DispatcherTimer();
            this.timer.Tick += timer_Tick;
            this.timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            this.timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.loadBar.Value++;

            if (loadBar.Value == loadBar.Maximum)
            {
                this.Close();
            }
        }
    }
}
