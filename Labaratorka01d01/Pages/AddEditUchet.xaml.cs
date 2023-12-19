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
    public partial class AddEditUchet : Page
    {
        public static bool CheckTest(Uchet u)
        {
            if (u.NumbChet < 0 || u.MothPay > 12 || u.MothPay < 1)
                return false;
            return true;
        }
        Uchet uchet;
        bool checkNew;
        public AddEditUchet(Uchet u)
        {
            InitializeComponent();
            if (u == null) 
            { 
                u = new Uchet();
                checkNew = true;
            }else
                checkNew = false;
            DataContext = uchet = u;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if(checkNew)
                Connect.Context.Uchet.Add(uchet);
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
