﻿using Labaratorka01d01.AppData;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnClients_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new ClientsPage());
        }
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void BtnFind_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new SearchPage());
        }

        private void BtnUchet_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new UchetPage());
        }

        private void BtnSort_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new SortPage());
        }
        private void BtnFiltr_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new FiltrPage());
        }
        private void BtnOthcet_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new OtchetPage());
        }
    }
}
