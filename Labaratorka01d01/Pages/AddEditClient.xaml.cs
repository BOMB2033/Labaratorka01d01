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
    /// Логика взаимодействия для AddEditClient.xaml
    /// </summary>
    public partial class AddEditClient : Page
    {
        public static bool CheckClient(Clients c)
        {
            if (string.IsNullOrEmpty(c.FullName) || !c.FullName.All(char.IsLetter) )
                return false;
            return true;
        }
        Clients client;
        bool checkNew;
        public AddEditClient(Clients c)
        {
            InitializeComponent();
            if (c == null) 
            { 
                c = new Clients();
                checkNew = true;
            }else
                checkNew = false;
            DataContext = client = c;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if(checkNew)
                Connect.Context.Clients.Add(client);
            try
            {
                Connect.Context.SaveChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),"Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Nav.GoBack();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.GoBack();
        }
    }
}
