﻿using System;
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
using Курсач.Classes;
using Курсач.Model;

namespace Курсач.Pages
{
    /// <summary>
    /// Логика взаимодействия для AccountantPage.xaml
    /// </summary>
    public partial class AccountantPage : Page
    {
        public AccountantPage()
        {
            InitializeComponent();
            UpCheck.IsChecked = true;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void Load()
        {
            var ApplicationList = DB.entities.Application.ToList();
            Document doc = DB.entities.Document.FirstOrDefault(c => c.DocumentId == 10);
            ApplicationList = ApplicationList.Where(c => c.Document.Client.FullName.
                ToLower().Contains(SearchBox.Text.ToLower())).ToList();
            if (DownCheck.IsChecked == true)
                ApplicationList = ApplicationList.OrderBy(c => c.ApplicationDate).ToList();
            else
                ApplicationList = ApplicationList.OrderByDescending(c => c.ApplicationDate).ToList();
            if (ApplicationList.Count == 0)
            {
                Model.Application application = new Model.Application();
                application.Document = new Document();
                application.Document.Client = new Client();
                application.Document.Client.ClientLN = "Результатов нет!";
                application.Document.Client.ClientGender = null;
                ApplicationList.Add(application);
            }
            ApplicationListView.ItemsSource = ApplicationList;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddClientPage());
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menu = sender as MenuItem;
            Model.Application selectedItem = menu.DataContext as Model.Application;
            NavigationService.Navigate(new AddClientPage(selectedItem));
        }

        private void AddContractButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddApplication());
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MenuItem menu = sender as MenuItem;
            Model.Application selectedItem = menu.DataContext as Model.Application;
            PrintCheck.OutputApplication(selectedItem);
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Load();
        }
    }
}
