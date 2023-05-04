using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;
using ShcoolLearn.Components.Model;
using ShcoolLearn.Pages;
using System.Text.RegularExpressions;

namespace ShcoolLearn.Pages
{
    /// <summary>
    /// Логика взаимодействия для AEServise.xaml
    /// </summary>
    public partial class AEServise : Page
    {
        Service contextService;
        public AEServise(Service service)
        {
            InitializeComponent();
            contextService = service;
            DataContext = contextService;

        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            string error = "";

            if (contextService.ID == 0)
            {
                App.DB.Service.Add(contextService);
                App.DB.SaveChanges();
                NavigationService.GoBack();
            }
            else 
            {
                App.DB.SaveChanges();
                NavigationService.GoBack();
                
            }

        }

        private void BCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void EditImgBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                contextService.MainImagePath = File.ReadAllBytes(dialog.FileName);
                DataContext = null;
                DataContext = contextService;
                App.DB.SaveChanges();
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[A-zА-я]") == false)
            {
                e.Handled = true;
            }
        }

        private void TextBox_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[0-9]") == false)
            {
                e.Handled = true;
            }
        }

        
    }
}
