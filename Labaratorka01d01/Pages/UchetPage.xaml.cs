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
    /// Логика взаимодействия для UchetPage.xaml
    /// </summary>
    public partial class UchetPage : Page
    {
        public UchetPage()
        {
            InitializeComponent();
            UchetV.ItemsSource = Connect.Context.Uchet.ToList();
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditUchet(null));
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.GoBack();
        }
        private void RefrBtn_Click(object sender, RoutedEventArgs e)
        {
            UchetV.ItemsSource = Connect.Context.Uchet.ToList();
        }
        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var delUchet = UchetV.SelectedItems.Cast<Uchet>().ToList();
            if (MessageBox.Show($"Удалить {delUchet.Count} запсией", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Connect.Context.Uchet.RemoveRange(delUchet);
            try
            {
                Connect.Context.SaveChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            UchetV.ItemsSource = Connect.Context.Uchet.ToList();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UchetV.ItemsSource = Connect.Context.Uchet.ToList();
        }
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditUchet((sender as Button).DataContext as Uchet));
        }
    }
}
