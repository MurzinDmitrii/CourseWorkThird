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
using Курсач.Model;

namespace Курсач.Pages
{
    /// <summary>
    /// Логика взаимодействия для DoctorPage.xaml
    /// </summary>
    public partial class DoctorPage : Page
    {
        public DoctorPage()
        {
            InitializeComponent();
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
            var CardList = DB.entities.Client.ToList();
            CardList = CardList.Where(c => c.FullName.ToLower().Contains(SearchBox.Text.ToLower())).ToList();
            if(CardList.Count == 0)
            {
                Client client = new Client();
                client.ClientLN = "Результатов нет!";
                client.ClientGender = null;
                CardList.Add(client);
            }
            CardListView.ItemsSource = CardList;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Load();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            Client client = item.DataContext as Client;
            NavigationService.Navigate(new CardPage(client));
        }

    }
}
