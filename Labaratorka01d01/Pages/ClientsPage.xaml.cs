using Labaratorka01d01.AppData;
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

namespace Labaratorka01d01.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public ClientsPage()
        {
            InitializeComponent();
            ClientsLV.ItemsSource = Connect.Context.Clients.ToList();
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditClient(null));
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.GoBack();
        }
        private void RefrBtn_Click(object sender, RoutedEventArgs e)
        {
            ClientsLV.ItemsSource = Connect.Context.Clients.ToList();
        }
        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var delClients = ClientsLV.SelectedItems.Cast<Clients>().ToList();
            foreach (var delClient in delClients)
            if(Connect.Context.Uchet.Any(x => x.NumbChet == delClient.NumbChet))
                {
                    MessageBox.Show("Данные используются в таблице учета","Ошибка",MessageBoxButton.OK, MessageBoxImage.Error);
                }
            if (MessageBox.Show($"Удалить {delClients.Count} запсией", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Connect.Context.Clients.RemoveRange(delClients);
            try
            {
                Connect.Context.SaveChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            ClientsLV.ItemsSource = Connect.Context.Clients.ToList();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ClientsLV.ItemsSource = Connect.Context.Clients.ToList();
        }
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditClient((sender as Button).DataContext as Clients));
        }
    }
}
