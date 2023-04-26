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
    /// Логика взаимодействия для AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage : Page
    {
        Client cl;
        public AddClientPage()
        {
            cl = new Client();
            cl.ClientRh_ = false;
            cl.ClientGender = false;
            cl.Passport = new Passport();
            cl.Polis = new Polis();
            cl.Benefits = new Benefits();
            this.DataContext = cl;
            InitializeComponent();
            FamilyBox.ItemsSource = DB.entities.FamilyPosition.ToList();
            EducationBox.ItemsSource = DB.entities.Education.ToList();
            BusyBox.ItemsSource = DB.entities.Busyness.ToList();
            InsuranceBox.ItemsSource = DB.entities.Insurance.ToList();
            List<string> ListGroupBlood = new List<string>();
            for (int i = 1; i <= 4; i++)
            {
                ListGroupBlood.Add(i.ToString());
            }
            GroupBloodBox.ItemsSource = ListGroupBlood;
            PrivilegesBox.ItemsSource = DB.entities.BenefitsCategory.ToList();
        }

        public AddClientPage(Model.Application application)
        {
            cl = application.Document.Client;
            this.DataContext = cl;
            InitializeComponent();
            FamilyBox.ItemsSource = DB.entities.FamilyPosition.ToList();
            EducationBox.ItemsSource = DB.entities.Education.ToList();
            BusyBox.ItemsSource = DB.entities.Busyness.ToList();
            InsuranceBox.ItemsSource = DB.entities.Insurance.ToList();
            List<string> ListGroupBlood = new List<string>();
            for (int i = 1; i <= 4; i++)
            {
                ListGroupBlood.Add(i.ToString());
            }
            GroupBloodBox.ItemsSource = ListGroupBlood;
            PrivilegesBox.ItemsSource = DB.entities.BenefitsCategory.ToList();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (GenderBox.IsChecked == true)
            {
                cl.ClientGender = true;
            }
            else
            {
                cl.ClientGender = false;
            }
            if (RHBox.IsChecked == true)
            {
                cl.ClientRh_ = true;
            }
            else
            {
                cl.ClientRh_ = false;
            }
            cl.ClientBloodGroup = GroupBloodBox.SelectedItem.ToString();
            cl.ClientHB = HBBox.SelectedDate;
            cl.Passport.PassportDate = PassportDateBox.SelectedDate;
            if (cl.ClientId == 0)DB.entities.Client.Add(cl);
            DB.entities.SaveChanges();
            NavigationService.GoBack();
        }

        private void PhoneBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
