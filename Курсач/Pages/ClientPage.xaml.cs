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
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        Client client;
        public ClientPage(Client client)
        {
            InitializeComponent();
            this.client = client;
        }

        private void UpCheck_Checked(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }
        private void Load()
        {
            var ClientList = DB.entities.Card.Where(c => c.Client == client);
            if(UpCheck.IsChecked == true)
            {
                ClientList = ClientList.OrderBy(c => c.CardDateStart);
            }
            else
            {
                ClientList = ClientList.OrderByDescending(c => c.CardDateStart);
            }
            if (!string.IsNullOrEmpty(SearchBox.Text))
            {
                ClientList = ClientList.Where(c => c.Client.FullName.ToLower().Contains(SearchBox.Text.ToLower()));
            }
            DesiaseListView.ItemsSource = ClientList;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Load();
        }
    }
}
