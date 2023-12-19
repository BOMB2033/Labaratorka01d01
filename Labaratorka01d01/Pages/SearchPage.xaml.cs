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
    /// Логика взаимодействия для SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        public SearchPage()
        {
            InitializeComponent();
            SetDataInComboBox();
            HideElement();
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
        private void HideElement()
        {
            FirstTextBlok.Visibility = Visibility.Collapsed;
            FirstTextBox.Visibility = Visibility.Collapsed;
            SecondTextBlok.Visibility = Visibility.Collapsed;
            SecondTextBox.Visibility = Visibility.Collapsed;
            ThirdTextBlok.Visibility = Visibility.Collapsed;
            ThirdTextBox.Visibility = Visibility.Collapsed;
        }
        private void TypeSearchComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (TypeSearchComboBox.SelectedIndex)
            {
                case 0:
                    FirstTextBlok.Visibility = Visibility.Visible;
                    FirstTextBox.Visibility = Visibility.Visible;
                    SecondTextBlok.Visibility = Visibility.Visible;
                    SecondTextBox.Visibility = Visibility.Visible;
                    ThirdTextBlok.Visibility = Visibility.Visible;
                    ThirdTextBox.Visibility = Visibility.Visible;
                    FirstTextBlok.Text = "ФИО";
                    SecondTextBlok.Text = "Месяц оплаты";
                    ThirdTextBlok.Text = "Тариф";
                    break;
                case 1:
                    FirstTextBlok.Visibility = Visibility.Visible;
                    FirstTextBox.Visibility = Visibility.Visible;
                    SecondTextBlok.Visibility = Visibility.Collapsed;
                    SecondTextBox.Visibility = Visibility.Collapsed;
                    ThirdTextBlok.Visibility = Visibility.Collapsed;
                    ThirdTextBox.Visibility = Visibility.Collapsed;
                    FirstTextBlok.Text = "Номер лицевого счета";
                    break;
                case 2:
                    FirstTextBlok.Visibility = Visibility.Visible;
                    FirstTextBox.Visibility = Visibility.Visible;
                    SecondTextBlok.Visibility = Visibility.Visible;
                    SecondTextBox.Visibility = Visibility.Visible;
                    ThirdTextBlok.Visibility = Visibility.Collapsed;
                    ThirdTextBox.Visibility = Visibility.Collapsed;
                    FirstTextBlok.Text = "ФИО";
                    SecondTextBlok.Text = "Тариф";
                    break;
                default:
                    HideElement();
                    break;
            }
        }
        private Clients GetClient(int x)
        {
            foreach (var item in Connect.Context.Clients)
                if (item.NumbChet == x) return item;
            return null;
        }
        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            List<Uchet> list = new List<Uchet>();
            switch (TypeSearchComboBox.SelectedIndex)
            {
                case 0:
                    foreach (var item in Connect.Context.Uchet)
                        if (GetClient(item.NumbChet).FullName.ToLower().StartsWith(FirstTextBox.Text.ToLower()) &&
                            item.MothPay.ToString().ToLower().StartsWith(SecondTextBox.Text.ToLower()) &&
                            item.Rate.ToString().ToLower().StartsWith(ThirdTextBox.Text.ToLower()))
                            list.Add(item);
                    break;
                case 1:
                    foreach (var item in Connect.Context.Uchet)
                        if (item.NumbChet.ToString().ToLower().StartsWith(FirstTextBox.Text.ToLower()))
                            list.Add(item);
                    break;
                case 2:
                    foreach (var item in Connect.Context.Uchet)
                        if (GetClient(item.NumbChet).FullName.ToLower().StartsWith(FirstTextBox.Text.ToLower()) &&
                            item.Rate.ToString().ToLower().StartsWith(SecondTextBox.Text.ToLower()))
                            list.Add(item);
                    break;
                default:
                    HideElement();
                    break;
            }
            UchetV.ItemsSource = list;
        }
    }
}
