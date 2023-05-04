using ShcoolLearn.Components.Model;
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

namespace ShcoolLearn.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
            if(App.LoggedClient.RoleID == 2)
            {
                AddBtn.Visibility = Visibility.Collapsed;
                
            }
            
            ServiceLV.ItemsSource = App.DB.Service.ToList();
            GeneralCount.Text = App.DB.Service.Count().ToString();

        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

      

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var selService = (sender as Button).DataContext as Service;
            NavigationService.Navigate(new AEServise(selService));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var selService = (sender as Button).DataContext as Service;
            if (MessageBox.Show("Вы действительно хотите удалить эту запись?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                App.DB.Service.Remove(selService);
                App.DB.SaveChanges();
            }
        }

        private void DiscountCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }


        private void Refresh()
        {

            IEnumerable<Service> filterService = App.DB.Service.ToList();
            if (SortCb.SelectedIndex == 1)
                filterService = filterService.OrderBy(x => x.CostDiscount);
            else if (SortCb.SelectedIndex == 2)
                filterService = filterService.OrderByDescending(x => x.CostDiscount);
            if (DiscountCb.SelectedIndex > 0)
            {
                if (DiscountCb.SelectedIndex == 1)
                    filterService = filterService.Where(x => x.Discount >= 0 && x.Discount < 0.05 || x.Discount == null).ToList();
                else if (DiscountCb.SelectedIndex == 2)
                    filterService = filterService.Where(x => x.Discount >= 0.05 && x.Discount < 0.15).ToList();
                else if (DiscountCb.SelectedIndex == 3)
                    filterService = filterService.Where(x => x.Discount >= 0.15 && x.Discount < 0.30).ToList();
                else if (DiscountCb.SelectedIndex == 4)
                    filterService = filterService.Where(x => x.Discount >= 0.30 && x.Discount < 0.70).ToList();
                else if (DiscountCb.SelectedIndex == 5)
                    filterService = filterService.Where(x => x.Discount >= 0.70 && x.Discount < 1).ToList();
            }
            if (SearchTb.Text.Length > 0)
            {
                filterService = filterService.Where(x => x.Title.ToLower().StartsWith(SearchTb.Text.ToLower()) || x.Description.ToLower().StartsWith(SearchTb.Text.ToLower()));
            }
            ServiceLV.ItemsSource = filterService.ToList();

            FilterCount.Text = filterService.Count() + " из";
            

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AEServise(new Service()));
        }

        private void ServiceLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }


        private void SignUpServiceBtn_Click(object sender, RoutedEventArgs e)
        {
            var selService = (sender as Button).DataContext as Service;
            NavigationService.Navigate(new SignUpServicePage(selService));
        }

        private void UpCommingBtn_Click(object sender, RoutedEventArgs e)
        {
            var selService = (sender as Button).DataContext as Service;
            NavigationService.Navigate(new UpCommingPage(selService));
        }
    }
}
