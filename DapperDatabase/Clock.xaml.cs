using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Threading;

namespace DapperDatabase
{
    /// <summary>
    /// Logika interakcji dla klasy Clock.xaml
    /// </summary>
    public partial class Clock : UserControl
    {
        public Clock()
        {
            InitializeComponent();
            InitalizeClock();
            calendar.Content = DateTime.Now.Date.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
        }

        private void InitalizeClock()
        {
            DispatcherTimer clock = new DispatcherTimer();
            clock.Interval = TimeSpan.FromSeconds(1);
            clock.Tick += Thick;
            clock.Start();
        }
        private void Thick(object sender, EventArgs e)
        {
            timer.Content = DateTime.Now.ToString("HH:mm",CultureInfo.CurrentCulture);

        }
    }
}
