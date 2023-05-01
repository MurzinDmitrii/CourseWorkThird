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
    /// Логика взаимодействия для CardPage.xaml
    /// </summary>
    public partial class CardPage : Page
    {
        Client client;
        bool newClient = false;
        Card card;
        public CardPage(Client client)
        {
            InitializeComponent();
            this.client = client;
            List<string> ListGroup = new List<string>();
            card = DB.entities.Card.FirstOrDefault(c => c.ClientId ==  client.ClientId);
            if (card == null)
            {
                card = new Card();
                newClient = true;
            }
            this.DataContext = card;
            for (int i = 1; i <= 4; i++)
            {
                ListGroup.Add(i.ToString());
            }
            GroupBox.ItemsSource = ListGroup;
            DesiaseBox.ItemsSource = DB.entities.Desiase.ToList();
            var ListDopDesiase = DB.entities.CardTablePart.Where(c => c.Card.ClientId == client.ClientId).ToList();
            DopDesiaseListView.ItemsSource = ListDopDesiase;
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            card.Client = client;
            card.CardDateEnd = DateEndBox.DisplayDate;
            card.WorkerId = Properties.Settings.Default.WorkerId;
            card.Desiase = DesiaseBox.SelectedValue as Desiase;
            if(newClient)
            {
                card.CardDateStart = DateTime.Now;
                DB.entities.Card.Add(card);
            }
            try
            {
                DB.entities.SaveChanges();
                NavigationService.GoBack();
            }
            catch
            {
                MessageBox.Show("Корректно заполните поля!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddAddCardPage(card));
        }
    }
}
