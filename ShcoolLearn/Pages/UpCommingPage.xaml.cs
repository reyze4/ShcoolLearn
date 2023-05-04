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
using System.Windows.Threading;
using ShcoolLearn.Components.Model;

namespace ShcoolLearn.Pages
{
    /// <summary>
    /// Логика взаимодействия для UpCommingPage.xaml
    /// </summary>
    public partial class UpCommingPage : Page
    {
        IEnumerable<ClientService> filterService = App.DB.ClientService.ToList();
        public UpCommingPage(Service service)
        {
            InitializeComponent();
            Refresh();
            var Timer = new DispatcherTimer();
            Timer.Tick += new EventHandler(dispTimer);
            Timer.Interval = new TimeSpan(0, 0, 30);
            Timer.Start();
        }

        private void Refresh()
        {
            DateTime tommorow = DateTime.Today.AddDays(1).AddHours(DateTime.Now.Hour);
            LVUpComingList.ItemsSource = App.DB.ClientService.Where(x => x.StartTime >= DateTime.Now && x.StartTime <= tommorow).ToList().OrderBy(x => x.StartTime);
        }


        private void dispTimer(object sender, EventArgs e)
        {
            Refresh();
            CommandManager.InvalidateRequerySuggested();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
