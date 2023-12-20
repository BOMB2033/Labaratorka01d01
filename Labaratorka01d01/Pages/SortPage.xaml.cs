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
    /// Логика взаимодействия для SortPage.xaml
    /// </summary>
    public partial class SortPage : Page
    {
        public SortPage()
        {
            InitializeComponent();
            SetDataInComboBox();
            UchetV.ItemsSource = Connect.Context.Uchet.ToList();

        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.GoBack();
        }
        private void RefrBtn_Click(object sender, RoutedEventArgs e)
        {
            UchetV.ItemsSource = Connect.Context.Uchet.ToList();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UchetV.ItemsSource = Connect.Context.Uchet.ToList();
        }
        private void SetDataInComboBox()
        {
            TypeSearchComboBox.Items.Clear();
            TypeSearchComboBox.Items.Add("По ФИО, Месяцу оплаты и тарифу");
            TypeSearchComboBox.Items.Add("По номеру лицевого счета");
            TypeSearchComboBox.Items.Add("По ФИО и тарифу");
        }
        private void TypeSearchComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (TypeSearchComboBox.SelectedIndex)
            {
                case 0:
                    UchetV.ItemsSource = Connect.Context.Uchet.OrderBy(x => x.Clients.FullName).ToList();
                    break;
                case 1:
                    UchetV.ItemsSource = Connect.Context.Uchet.OrderBy(x => x.NumbChet).ToList();
                    break;
                case 2:
                    UchetV.ItemsSource = Connect.Context.Uchet.OrderBy(x => x.Rate).ToList();
                    break;
                default:
                    break;
            }
        }
    }
}
